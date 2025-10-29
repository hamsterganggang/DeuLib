using library_support_system.Models;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

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
                cmd.CommandText = @" INSERT INTO BOOK_RNT( Book_ISBN
                                                                                                     , User_Phone
                                                                                                     , Rental_Status
                                                                                                     , Rental_Date
                                                                                                     , Rental_Return_Date
                                                                                                     )
                                                                                                     VALUES
                                                                                                     ( :Book_ISBN
                                                                                                     , :User_Phone
                                                                                                     , :Rental_Status
                                                                                                     , :Rental_Date
                                                                                                     , :Rental_Return_Date
                                                                                                     )";
                cmd.Parameters.Add(new OracleParameter("Book_ISBN", rental.Book_ISBN));
                cmd.Parameters.Add(new OracleParameter("User_Phone", rental.User_Phone));
                cmd.Parameters.Add(new OracleParameter("Rental_Status", rental.Rental_Status));
                cmd.Parameters.Add(new OracleParameter("Rental_Date", rental.Rental_Date));
                cmd.Parameters.Add(new OracleParameter("Rental_Return_Date", rental.Rental_Return_Date));

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<RentalModel> Retrieve()
        {
            var list = new List<RentalModel>();
            string sql = @" SELECT b.Book_ISBN
                                                ,  b.Book_Title
                                                ,  b.Book_Img
                                                ,  b.Book_Author
                                                ,  b.Book_Pbl
                                                ,  NVL(r.Rental_Status, 0) AS Rental_Status
                                                ,  NVL(u.User_Name, '') AS User_Name
                                                ,  NVL(r.User_Phone, '') AS User_Phone
                                                ,  NVL(r.Rental_Date, TO_DATE('1900-01-01', 'YYYY-MM-DD')) AS Rental_Date
                                                ,  NVL(r.Rental_Return_Date, TO_DATE('1900-01-01', 'YYYY-MM-DD')) AS Rental_Return_Date
                                        FROM BOOKS b
                                          LEFT JOIN BOOK_RNT r 
                                             ON b.Book_ISBN = r.Book_ISBN
                                           AND r.Rental_Status = 1
                                          LEFT JOIN USERS u 
                                             ON r.User_Phone = u.User_Phone
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
                            Book_Img = reader.IsDBNull(reader.GetOrdinal("Book_Img")) ? null : (byte[])reader["Book_Img"],
                            Book_Author = reader.IsDBNull(reader.GetOrdinal("Book_Author")) ? "" : reader.GetString(reader.GetOrdinal("Book_Author")),
                            Book_Pbl = reader.IsDBNull(reader.GetOrdinal("Book_Pbl")) ? "" : reader.GetString(reader.GetOrdinal("Book_Pbl")),
                            Rental_Status = reader.IsDBNull(reader.GetOrdinal("Rental_Status")) ? 0 : reader.GetInt32(reader.GetOrdinal("Rental_Status")),
                            User_Name = reader.IsDBNull(reader.GetOrdinal("User_Name")) ? "" : reader.GetString(reader.GetOrdinal("User_Name")),
                            User_Phone = reader.IsDBNull(reader.GetOrdinal("User_Phone")) ? "" : reader.GetString(reader.GetOrdinal("User_Phone")), // *** "사용자번호" 매핑 ***
                            Rental_Date = reader.IsDBNull(reader.GetOrdinal("Rental_Date")) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("Rental_Date")),
                            Rental_Return_Date = reader.IsDBNull(reader.GetOrdinal("Rental_Return_Date")) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("Rental_Return_Date"))
                        };
                        list.Add(rental);
                    }
                }
            }
            return list;
        }
        public bool CheckUserExists(string userPhone)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT User_Phone
                    FROM USERS 
                    WHERE User_Phone = :User_Phone";

                cmd.Parameters.Add(new OracleParameter("User_Phone", userPhone));

                // ExecuteScalar는 쿼리 결과의 첫 번째 행, 첫 번째 열의 값을 반환합니다. (여기서는 COUNT 값)
                // Oracle은 COUNT를 decimal로 반환할 수 있으므로 Convert.ToInt32로 안전하게 변환합니다.
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }
        public bool UpdateRentalStatusToReturned(string bookIsbn)
        {
            using (var cmd = _conn.CreateCommand())
            {
                // Rental_Status가 1(대여중)인 레코드만 0(대여가능)으로 변경
                cmd.CommandText = @"
                    UPDATE BOOK_RNT
                    SET Rental_Status = 0
                    WHERE Book_ISBN = :Book_ISBN
                      AND Rental_Status = 1";

                cmd.Parameters.Add(new OracleParameter("Book_ISBN", bookIsbn));

                // ExecuteNonQuery는 영향을 받은 행의 수를 반환합니다.
                // 1개 행이 업데이트되었으면 성공입니다.
                int affectedRows = cmd.ExecuteNonQuery();
                return affectedRows == 1;
            }
        }
        public List<RentalModel> RetrieveRentalList()
        {
            var list = new List<RentalModel>();

            // 1. BOOK_RNT를 기준으로 BOOKS, USERS 테이블 조인
            string sql = @"
                SELECT
                    r.Rental_Seq, -- PK (필요하면 사용)
                    r.Book_ISBN,
                    b.Book_Title,
                    b.Book_Author,
                    b.Book_Pbl,
                    r.Rental_Status, -- 0(반납됨) 또는 1(대여중)
                    u.User_Name,
                    r.User_Phone,
                    r.Rental_Date,
                    r.Rental_Return_Date
                FROM BOOK_RNT r
                JOIN BOOKS b ON r.Book_ISBN = b.Book_ISBN -- INNER JOIN (대여 기록이 있는 책만)
                JOIN USERS u ON r.User_Phone = u.User_Phone -- INNER JOIN (등록된 사용자의 대여만)
                ORDER BY r.Rental_Date DESC"; // 최근 대여/반납 순으로 정렬 (선택)

            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = sql;

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var rental = new RentalModel
                        {
                            Rental_Seq = reader.IsDBNull(reader.GetOrdinal("Rental_Seq")) ? 0 : reader.GetInt32(reader.GetOrdinal("Rental_Seq")),
                            Book_ISBN = reader.IsDBNull(reader.GetOrdinal("Book_ISBN")) ? "" : reader.GetString(reader.GetOrdinal("Book_ISBN")),
                            Book_Title = reader.IsDBNull(reader.GetOrdinal("Book_Title")) ? "" : reader.GetString(reader.GetOrdinal("Book_Title")),
                            Book_Author = reader.IsDBNull(reader.GetOrdinal("Book_Author")) ? "" : reader.GetString(reader.GetOrdinal("Book_Author")),
                            Book_Pbl = reader.IsDBNull(reader.GetOrdinal("Book_Pbl")) ? "" : reader.GetString(reader.GetOrdinal("Book_Pbl")),
                            Rental_Status = reader.IsDBNull(reader.GetOrdinal("Rental_Status")) ? 0 : reader.GetInt32(reader.GetOrdinal("Rental_Status")),
                            User_Name = reader.IsDBNull(reader.GetOrdinal("User_Name")) ? "" : reader.GetString(reader.GetOrdinal("User_Name")),
                            User_Phone = reader.IsDBNull(reader.GetOrdinal("User_Phone")) ? "" : reader.GetString(reader.GetOrdinal("User_Phone")),
                            Rental_Date = reader.IsDBNull(reader.GetOrdinal("Rental_Date")) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("Rental_Date")),
                            Rental_Return_Date = reader.IsDBNull(reader.GetOrdinal("Rental_Return_Date")) ? default(DateTime) : reader.GetDateTime(reader.GetOrdinal("Rental_Return_Date"))
                        };
                        list.Add(rental);
                    }
                }
            }
            return list;
        }
        public void Dispose()
        {
            if (_conn != null && _conn.State != ConnectionState.Closed)
                _conn.Close();
            _conn.Dispose();
        }
    }
}