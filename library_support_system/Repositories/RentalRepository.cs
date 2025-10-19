using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using library_support_system.Models;

namespace library_support_system.Repositories
{
    public class RentalRepository : IDisposable
    {
        private readonly OracleConnection _conn;

        public RentalRepository()
        {
            string connStr = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
            _conn = new OracleConnection(connStr);
            _conn.Open();
        }

        // CREATE: 대여 기록 추가
        public bool Create(RentalModel rental)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO BOOK_RNT
                    (Rental_Seq, Book_ISBN, User_Phone, Rental_Status, Rental_Date, Rental_Return_Date)
                    VALUES
                    (:Rental_Seq, :Book_ISBN, :User_Phone, :Rental_Status, :Rental_Date, :Rental_Return_Date)";
                cmd.Parameters.Add(new OracleParameter("Rental_Seq", rental.Rental_Seq));
                cmd.Parameters.Add(new OracleParameter("Book_ISBN", rental.Book_ISBN));
                cmd.Parameters.Add(new OracleParameter("User_Phone", rental.User_Phone));
                cmd.Parameters.Add(new OracleParameter("Rental_Status", rental.Rental_Status));
                cmd.Parameters.Add(new OracleParameter("Rental_Date", rental.Rental_Date));
                cmd.Parameters.Add(new OracleParameter("Rental_Return_Date", rental.Rental_Return_Date));
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<RentalModel> ReadBooksWithRentalStatus()
        {
            var list = new List<RentalModel>();

            string sql = @"
    SELECT
        b.Book_ISBN,
        b.Book_Title,
        b.Book_Img,
        b.Book_Author,
        b.Book_Pbl,
        NVL(r.Rental_Status, 0) AS Rental_Status,
        NVL(u.User_Name, '') AS User_Name,
        NVL(r.Rental_Date, TO_DATE('1900-01-01', 'YYYY-MM-DD')) AS Rental_Date,
        NVL(r.Rental_Return_Date, TO_DATE('1900-01-01', 'YYYY-MM-DD')) AS Rental_Return_Date
    FROM BOOKS b
    LEFT JOIN BOOK_RNT r ON b.Book_ISBN = r.Book_ISBN AND r.Rental_Status = 1
    LEFT JOIN USERS u ON r.User_Phone = u.User_Phone
    ORDER BY b.Book_Title";

            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = sql;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var rental = new RentalModel
                        {
                            Book_ISBN = reader.IsDBNull(reader.GetOrdinal("Book_ISBN")) ? "" : reader.GetString(reader.GetOrdinal("Book_ISBN")),
                            Book_Title = reader.IsDBNull(reader.GetOrdinal("Book_Title")) ? "" : reader.GetString(reader.GetOrdinal("Book_Title")),
                            Book_Img = reader.IsDBNull(reader.GetOrdinal("Book_Img")) ? "" : reader.GetString(reader.GetOrdinal("Book_Img")),
                            Book_Author = reader.IsDBNull(reader.GetOrdinal("Book_Author")) ? "" : reader.GetString(reader.GetOrdinal("Book_Author")),
                            Book_Pbl = reader.IsDBNull(reader.GetOrdinal("Book_Pbl")) ? "" : reader.GetString(reader.GetOrdinal("Book_Pbl")),
                            Rental_Status = reader.IsDBNull(reader.GetOrdinal("Rental_Status")) ? 0 : reader.GetInt32(reader.GetOrdinal("Rental_Status")),
                            User_Name = reader.IsDBNull(reader.GetOrdinal("User_Name")) ? "" : reader.GetString(reader.GetOrdinal("User_Name")),
                            Rental_Date = reader.IsDBNull(reader.GetOrdinal("Rental_Date")) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("Rental_Date")),
                            Rental_Return_Date = reader.IsDBNull(reader.GetOrdinal("Rental_Return_Date")) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("Rental_Return_Date"))
                        };
                        list.Add(rental);
                    }
                }
            }
            return list;
        }
        // 기타 Read/Update/Delete는 UserRepository와 동일하게 구현

        public void Dispose()
        {
            if (_conn != null && _conn.State != ConnectionState.Closed)
                _conn.Close();
            _conn.Dispose();
        }
    }
}