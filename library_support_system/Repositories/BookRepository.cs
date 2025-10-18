using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using library_support_system.Models;

namespace library_support_system.Repositories
{
    internal class BookRepository : IDisposable
    {
        private readonly OracleConnection _conn;

        public BookRepository()
        {
            // app.config에서 커넥션 문자열 읽기 111
            string connStr = ConfigurationManager.ConnectionStrings["OracleDb"].ConnectionString;
            _conn = new OracleConnection(connStr);
            _conn.Open();
        }

        // CREATE: 도서 추가
        public bool Create(BookModel book)
        {
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        INSERT INTO Books
                        (Book_ISBN, Book_Title, Book_Author, Book_Pbl, Book_Price, Book_Link, Book_Img, Book_Exp)
                        VALUES
                        (:Book_ISBN, :Book_Title, :Book_Author, :Book_Pbl, :Book_Price, :Book_Link, :Book_Img, :Book_Exp)";
                    
                    // 파라미터 추가 시 NULL 체크와 OracleDbType 명시
                    cmd.Parameters.Add(new OracleParameter("Book_ISBN", OracleDbType.Varchar2) { Value = book.Book_ISBN ?? (object)DBNull.Value });
                    cmd.Parameters.Add(new OracleParameter("Book_Title", OracleDbType.Varchar2) { Value = book.Book_Title ?? (object)DBNull.Value });
                    cmd.Parameters.Add(new OracleParameter("Book_Author", OracleDbType.Varchar2) { Value = book.Book_Author ?? (object)DBNull.Value });
                    cmd.Parameters.Add(new OracleParameter("Book_Pbl", OracleDbType.Varchar2) { Value = book.Book_Pbl ?? (object)DBNull.Value });
                    cmd.Parameters.Add(new OracleParameter("Book_Price", OracleDbType.Int32) { Value = book.Book_Price });
                    cmd.Parameters.Add(new OracleParameter("Book_Link", OracleDbType.Varchar2) { Value = book.Book_Link ?? (object)DBNull.Value });
                    cmd.Parameters.Add(new OracleParameter("Book_Img", OracleDbType.Varchar2) { Value = book.Book_Img ?? (object)DBNull.Value });
                    
                    // Book_Exp는 긴 텍스트일 수 있으므로 CLOB 타입으로 처리
                    var explainParam = new OracleParameter("Book_Exp", OracleDbType.Clob);
                    explainParam.Value = string.IsNullOrEmpty(book.Book_Exp) ? (object)DBNull.Value : book.Book_Exp;
                    cmd.Parameters.Add(explainParam);
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                // 상세한 오류 정보를 로그로 출력
                System.Diagnostics.Debug.WriteLine($"BookRepository Create Error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"Book_Exp value: '{book.Book_Exp}'");
                throw; // 상위로 예외 전파
            }
        }

        // READ: 특정 도서 조회 (ISBN 기준)
        public BookModel Read(string isbn)
        {
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Books WHERE Book_ISBN = :Book_ISBN";
                    cmd.Parameters.Add(new OracleParameter("Book_ISBN", isbn));
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new BookModel
                            {
                                Book_ISBN = reader["Book_ISBN"]?.ToString() ?? "",
                                Book_Title = reader["Book_Title"]?.ToString() ?? "",
                                Book_Author = reader["Book_Author"]?.ToString() ?? "",
                                Book_Pbl = reader["Book_Pbl"]?.ToString() ?? "",
                                Book_Price = Convert.ToInt32(reader["Book_Price"] ?? 0),
                                Book_Link = reader["Book_Link"]?.ToString() ?? "",
                                Book_Img = reader["Book_Img"]?.ToString() ?? "",
                                Book_Exp = reader["Book_Exp"]?.ToString() ?? ""
                            };
                        }
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BookRepository Read Error: {ex.Message}");
                throw;
            }
        }

        // READ ALL: 모든 도서 조회
        public List<BookModel> ReadAll()
        {
            try
            {
                var list = new List<BookModel>();
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Books";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new BookModel
                            {
                                Book_ISBN = reader["Book_ISBN"]?.ToString() ?? "",
                                Book_Title = reader["Book_Title"]?.ToString() ?? "",
                                Book_Author = reader["Book_Author"]?.ToString() ?? "",
                                Book_Pbl = reader["Book_Pbl"]?.ToString() ?? "",
                                Book_Price = Convert.ToInt32(reader["Book_Price"] ?? 0),
                                Book_Link = reader["Book_Link"]?.ToString() ?? "",
                                Book_Img = reader["Book_Img"]?.ToString() ?? "",
                                Book_Exp = reader["Book_Exp"]?.ToString() ?? ""
                            });
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BookRepository ReadAll Error: {ex.Message}");
                throw;
            }
        }

        // SEARCH: 제목으로 도서 검색
        public List<BookModel> SearchByTitle(string searchTitle)
        {
            try
            {
                var list = new List<BookModel>();
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Books WHERE UPPER(Book_Title) LIKE UPPER(:searchTitle)";
                    cmd.Parameters.Add(new OracleParameter("searchTitle", "%" + searchTitle + "%"));
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            list.Add(new BookModel
                            {
                                Book_ISBN = reader["Book_ISBN"]?.ToString() ?? "",
                                Book_Title = reader["Book_Title"]?.ToString() ?? "",
                                Book_Author = reader["Book_Author"]?.ToString() ?? "",
                                Book_Pbl = reader["Book_Pbl"]?.ToString() ?? "",
                                Book_Price = Convert.ToInt32(reader["Book_Price"] ?? 0),
                                Book_Link = reader["Book_Link"]?.ToString() ?? "",
                                Book_Img = reader["Book_Img"]?.ToString() ?? "",
                                Book_Exp = reader["Book_Exp"]?.ToString() ?? ""
                            });
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BookRepository SearchByTitle Error: {ex.Message}");
                throw;
            }
        }

        // UPDATE: 도서 정보 수정
        public bool Update(BookModel book)
        {
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        UPDATE Books SET
                            Book_Title = :Book_Title,
                            Book_Author = :Book_Author,
                            Book_Pbl = :Book_Pbl,
                            Book_Price = :Book_Price,
                            Book_Link = :Book_Link,
                            Book_Img = :Book_Img,
                            Book_Exp = :Book_Exp
                        WHERE Book_ISBN = :Book_ISBN";
                    
                    cmd.Parameters.Add(new OracleParameter("Book_Title", OracleDbType.Varchar2) { Value = book.Book_Title ?? (object)DBNull.Value });
                    cmd.Parameters.Add(new OracleParameter("Book_Author", OracleDbType.Varchar2) { Value = book.Book_Author ?? (object)DBNull.Value });
                    cmd.Parameters.Add(new OracleParameter("Book_Pbl", OracleDbType.Varchar2) { Value = book.Book_Pbl ?? (object)DBNull.Value });
                    cmd.Parameters.Add(new OracleParameter("Book_Price", OracleDbType.Int32) { Value = book.Book_Price });
                    cmd.Parameters.Add(new OracleParameter("Book_Link", OracleDbType.Varchar2) { Value = book.Book_Link ?? (object)DBNull.Value });
                    cmd.Parameters.Add(new OracleParameter("Book_Img", OracleDbType.Varchar2) { Value = book.Book_Img ?? (object)DBNull.Value });
                    
                    // Book_Exp CLOB 처리
                    var explainParam = new OracleParameter("Book_Exp", OracleDbType.Clob);
                    explainParam.Value = string.IsNullOrEmpty(book.Book_Exp) ? (object)DBNull.Value : book.Book_Exp;
                    cmd.Parameters.Add(explainParam);
                    
                    cmd.Parameters.Add(new OracleParameter("Book_ISBN", OracleDbType.Varchar2) { Value = book.Book_ISBN });
                    
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BookRepository Update Error: {ex.Message}");
                throw;
            }
        }

        // DELETE: 도서 삭제 (ISBN 기준)
        public bool Delete(string isbn)
        {
            try
            {
                using (var cmd = _conn.CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Books WHERE Book_ISBN = :Book_ISBN";
                    cmd.Parameters.Add(new OracleParameter("Book_ISBN", isbn));
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"BookRepository Delete Error: {ex.Message}");
                throw;
            }
        }

        // 자원 해제(종료시)
        public void Dispose()
        {
            if (_conn != null && _conn.State != ConnectionState.Closed)
                _conn.Close();
            _conn.Dispose();
        }
    }
}