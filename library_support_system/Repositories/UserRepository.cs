using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using library_support_system.Models;

namespace library_support_system.Repositories
{
    internal class UserRepository : IDisposable
    {
        private readonly OracleConnection _conn;
        // 생성자에서 커넥션 미리 오픈
        public UserRepository()
        {
            string connStr = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
            _conn = new OracleConnection(connStr);
            _conn.Open();
        }
        // CREATE
        public bool Create(UserModel user)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Users
                    (User_Phone, User_Name, User_Birthdate, User_Gender, User_Mail, User_Image, User_WTHDR)
                    VALUES
                    (:User_Phone, :User_Name, :User_Birthdate, :User_Gender, :User_Mail, :User_Image, :User_WTHDR)";
                cmd.Parameters.Add(new OracleParameter("User_Phone", user.User_Phone));
                cmd.Parameters.Add(new OracleParameter("User_Name", user.User_Name));
                cmd.Parameters.Add(new OracleParameter("User_Birthdate", user.User_Birthdate));
                cmd.Parameters.Add(new OracleParameter("User_Gender", user.User_Gender));
                cmd.Parameters.Add(new OracleParameter("User_Mail", user.User_Mail));
                cmd.Parameters.Add(new OracleParameter("User_Image", user.User_Image));
                cmd.Parameters.Add(new OracleParameter("User_WTHDR", user.User_WTHDR));
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // READ (특정 회원)
        public UserModel Read(int userSeq)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE User_Seq = :User_Seq";
                cmd.Parameters.Add(new OracleParameter("User_Seq", userSeq));
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserModel
                        {
                            User_Seq = Convert.ToInt32(reader["User_Seq"]), // ★ 반드시 포함
                                                                            // 이하 동일
                        };
                    }
                    return null;
                }
            }
        }
        // READ ALL
        public List<UserModel> ReadAll()
        {
            var list = new List<UserModel>();
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserModel
                        {
                            User_Seq = Convert.ToInt32(reader["User_Seq"]), // ★ 반드시 포함
                            User_Phone = reader["User_Phone"].ToString(),
                            User_Name = reader["User_Name"].ToString(),
                            User_Birthdate = reader["User_Birthdate"].ToString(),
                            User_Gender = Convert.ToInt32(reader["User_Gender"]),
                            User_Mail = reader["User_Mail"].ToString(),
                            User_Image = reader["User_Image"].ToString(),
                            User_WTHDR = Convert.ToInt32(reader["User_WTHDR"])
                        });
                    }
                }
            }
            return list;
        }
        // UPDATE
            public bool Update(UserModel user)
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandText = @"
                    UPDATE Users SET
                    User_Phone = :User_Phone,
                    User_Name = :User_Name,
                    User_Birthdate = :User_Birthdate,
                    User_Gender = :User_Gender,
                    User_Mail = :User_Mail,
                    User_Image = :User_Image,
                    User_WTHDR = :User_WTHDR
                    WHERE User_SEQ = :User_SEQ";

                cmd.Parameters.Add(new OracleParameter("User_Phone", user.User_Phone));
                cmd.Parameters.Add(new OracleParameter("User_Name", user.User_Name));
                cmd.Parameters.Add(new OracleParameter("User_Birthdate", DateTime.Parse(user.User_Birthdate)));
                cmd.Parameters.Add(new OracleParameter("User_Gender", user.User_Gender));
                cmd.Parameters.Add(new OracleParameter("User_Mail", user.User_Mail));
                cmd.Parameters.Add(new OracleParameter("User_Image", user.User_Image));
                cmd.Parameters.Add(new OracleParameter("User_WTHDR", user.User_WTHDR));
                cmd.Parameters.Add(new OracleParameter("User_SEQ", user.User_Seq));
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE (User_SEQ 기준 삭제)
        public bool Delete(int userSeq)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE User_SEQ = :User_SEQ";
                cmd.Parameters.Add(new OracleParameter("User_SEQ", userSeq));
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public void Dispose()
        {
            if (_conn != null && _conn.State != ConnectionState.Closed)
                _conn.Close();
            _conn.Dispose();
        }

        public bool UpdateUserWTHDR(string User_Seq)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = @"
            UPDATE Users SET User_WTHDR = 1 
            WHERE User_Phone = :User_Phone";
                cmd.Parameters.Add(new OracleParameter("User_Seq", User_Seq));
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // 자원 해제 (프로그램 종료 시 호출)
 
    }
}