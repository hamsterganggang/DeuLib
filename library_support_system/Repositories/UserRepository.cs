using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using library_support_system.Model;
using System.Configuration;

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
                cmd.Parameters.Add(new OracleParameter("User_WTHDR", user.User_WithDR));
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // READ (특정 회원)
        public UserModel Read(string userPhone)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE User_Phone = :User_Phone";
                cmd.Parameters.Add(new OracleParameter("User_Phone", userPhone));
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UserModel
                        {
                            User_Phone = reader["User_Phone"].ToString(),
                            User_Name = reader["User_Name"].ToString(),
                            User_Gender = Convert.ToInt32(reader["User_Gender"]),
                            User_Mail = reader["User_Mail"].ToString(),
                            User_Image = reader["User_Image"].ToString(),
                            User_WithDR = Convert.ToInt32(reader["User_WithDR"])
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
                            User_Phone = reader["User_Phone"].ToString(),
                            User_Name = reader["User_Name"].ToString(),

                            // 💡 수정: DB의 날짜/시간(Date/Timestamp) 데이터를 
                            // 모델의 string 속성에 할당하기 위해 명시적으로 ToString() 처리.
                            User_Birthdate = reader["User_Birthdate"].ToString(),

                            User_Gender = Convert.ToInt32(reader["User_Gender"]),
                            User_Mail = reader["User_Mail"].ToString(),
                            User_Image = reader["User_Image"].ToString(),
                            User_WithDR = Convert.ToInt32(reader["User_WTHDR"])
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
                        User_Name = :User_Name,
                        User_Birthdate = :User_Birthdate,
                        User_Gender = :User_Gender,
                        User_Mail = :User_Mail,
                        User_Image = :User_Image,
                        User_WithDR = :User_WithDR
                    WHERE User_Phone = :User_Phone";
                cmd.Parameters.Add(new OracleParameter("User_Name", user.User_Name));
                cmd.Parameters.Add(new OracleParameter("User_Birthdate", user.User_Birthdate));
                cmd.Parameters.Add(new OracleParameter("User_Gender", user.User_Gender));
                cmd.Parameters.Add(new OracleParameter("User_Mail", user.User_Mail));
                cmd.Parameters.Add(new OracleParameter("User_Image", user.User_Image));
                cmd.Parameters.Add(new OracleParameter("User_WithDR", user.User_WithDR));
                cmd.Parameters.Add(new OracleParameter("User_Phone", user.User_Phone));
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // DELETE
        public bool Delete(string userPhone)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE User_Phone = :User_Phone";
                cmd.Parameters.Add(new OracleParameter("User_Phone", userPhone));
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // 자원 해제 (프로그램 종료 시 호출)
        public void Dispose()
        {
            if (_conn != null && _conn.State != ConnectionState.Closed)
                _conn.Close();
            _conn.Dispose();
        }
    }
}