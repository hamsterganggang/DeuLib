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

        // 생년월일 형식 변환 헬퍼 메서드
        private string FormatBirthdate(object birthdateValue)
        {
            if (birthdateValue == null || birthdateValue == DBNull.Value)
                return "";

            // 문자열인 경우
            if (birthdateValue is string strValue)
            {
                if (DateTime.TryParse(strValue, out DateTime dateValue))
                {
                    return dateValue.ToString("yyyyMMdd");
                }
                return strValue; // 이미 올바른 형식일 수 있음
            }

            // DateTime인 경우
            if (birthdateValue is DateTime dtValue)
            {
                return dtValue.ToString("yyyyMMdd");
            }

            // 기타의 경우 문자열로 변환 시도
            return birthdateValue.ToString();
        }

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
                cmd.Parameters.Add(new OracleParameter("User_Image", OracleDbType.Blob)
                {
                    Value = user.User_Image ?? (object)DBNull.Value
                });
                cmd.Parameters.Add(new OracleParameter("User_WTHDR", user.User_WTHDR));
                return cmd.ExecuteNonQuery() > 0;
            }
        }
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
                cmd.Parameters.Add(new OracleParameter("User_Birthdate", user.User_Birthdate));
                cmd.Parameters.Add(new OracleParameter("User_Gender", user.User_Gender));
                cmd.Parameters.Add(new OracleParameter("User_Mail", user.User_Mail));
                cmd.Parameters.Add(new OracleParameter("User_Image", OracleDbType.Blob)
                {
                    Value = user.User_Image ?? (object)DBNull.Value
                });
                cmd.Parameters.Add(new OracleParameter("User_WTHDR", user.User_WTHDR));
                cmd.Parameters.Add(new OracleParameter("User_SEQ", user.User_Seq));
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public bool Delete(int userSeq)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Users WHERE User_SEQ = :User_SEQ";
                cmd.Parameters.Add(new OracleParameter("User_SEQ", userSeq));
                return cmd.ExecuteNonQuery() > 0;
            }
        }
        public List<UserModel> ReadAll(int withdrawalStatus = 0)
        {
            var list = new List<UserModel>();
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM Users WHERE User_WTHDR = :User_WTHDR";
                cmd.Parameters.Add(new OracleParameter("User_WTHDR", withdrawalStatus)); // 파라미터 바인딩
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new UserModel
                        {
                            User_Seq = Convert.ToInt32(reader["User_Seq"]), // ★ 반드시 포함
                            User_Phone = reader["User_Phone"].ToString(),
                            User_Name = reader["User_Name"].ToString(),
                            User_Birthdate = FormatBirthdate(reader["User_Birthdate"]), // 형식 변환
                            User_Gender = Convert.ToInt32(reader["User_Gender"]),
                            User_Mail = reader["User_Mail"].ToString(),
                            User_Image = reader["User_Image"] == DBNull.Value ? null : (byte[])reader["User_Image"],
                            User_WTHDR = Convert.ToInt32(reader["User_WTHDR"])
                        });
                    }
                }
            }
            return list;
        }
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
                            User_Seq = Convert.ToInt32(reader["User_Seq"]),
                            User_Phone = reader["User_Phone"].ToString(),
                            User_Name = reader["User_Name"].ToString(),
                            User_Birthdate = FormatBirthdate(reader["User_Birthdate"]), // 형식 변환
                            User_Gender = Convert.ToInt32(reader["User_Gender"]),
                            User_Mail = reader["User_Mail"].ToString(),
                            User_Image = reader["User_Image"] == DBNull.Value ? null : (byte[])reader["User_Image"],
                            User_WTHDR = Convert.ToInt32(reader["User_WTHDR"])
                        };
                    }
                    return null;
                }
            }
        }

        // 전화번호로 사용자 검색 (중복 확인용)
        public UserModel ReadByPhone(string userPhone)
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
                            User_Seq = Convert.ToInt32(reader["User_Seq"]),
                            User_Phone = reader["User_Phone"].ToString(),
                            User_Name = reader["User_Name"].ToString(),
                            User_Birthdate = FormatBirthdate(reader["User_Birthdate"]), // 형식 변환
                            User_Gender = Convert.ToInt32(reader["User_Gender"]),
                            User_Mail = reader["User_Mail"].ToString(),
                            User_Image = reader["User_Image"] == DBNull.Value ? null : (byte[])reader["User_Image"],
                            User_WTHDR = Convert.ToInt32(reader["User_WTHDR"])
                        };
                    }
                    return null;
                }
            }
        }

        // 전화번호 중복 확인
        public bool IsPhoneExists(string userPhone)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE User_Phone = :User_Phone";
                cmd.Parameters.Add(new OracleParameter("User_Phone", userPhone));
                var count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
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