using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
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
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Books
                    (Book_ISBN, Book_Title, Book_Author, Book_Pbl, Book_Price, Book_Link, Book_Img, Book_Explain)
                    VALUES
                    (:Book_ISBN, :Book_Title, :Book_Author, :Book_Pbl, :Book_Price, :Book_Link, :Book_Img, :Book_Explain)";
                cmd.Parameters.Add(new OracleParameter("Book_ISBN", book.Book_ISBN));
                cmd.Parameters.Add(new OracleParameter("Book_Title", book.Book_Title));
                cmd.Parameters.Add(new OracleParameter("Book_Author", book.Book_Author));
                cmd.Parameters.Add(new OracleParameter("Book_Pbl", book.Book_Pbl));
                cmd.Parameters.Add(new OracleParameter("Book_Price", book.Book_Price));
                cmd.Parameters.Add(new OracleParameter("Book_Link", book.Book_Link));
                cmd.Parameters.Add(new OracleParameter("Book_Img", book.Book_Img));
                cmd.Parameters.Add(new OracleParameter("Book_Explain", book.Book_Explain));
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // READ: 특정 도서 조회 (ISBN 기준)
        public BookModel Read(string isbn)
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
                            Book_ISBN = reader["Book_ISBN"].ToString(),
                            Book_Title = reader["Book_Title"].ToString(),
                            Book_Author = reader["Book_Author"].ToString(),
                            Book_Pbl = reader["Book_Pbl"].ToString(),
                            Book_Price = Convert.ToInt32(reader["Book_Price"]),
                            Book_Link = reader["Book_Link"].ToString(),
                            Book_Img = reader["Book_Img"].ToString(),
                            Book_Explain = reader["Book_Explain"].ToString()
                        };
                    }
                    return null;
                }
            }
        }

        // READ ALL: 모든 도서 조회
        public List<BookModel> ReadAll()
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
                            Book_ISBN = reader["Book_ISBN"].ToString(),
                            Book_Title = reader["Book_Title"].ToString(),
                            Book_Author = reader["Book_Author"].ToString(),
                            Book_Pbl = reader["Book_Pbl"].ToString(),
                            Book_Price = Convert.ToInt32(reader["Book_Price"]),
                            Book_Link = reader["Book_Link"].ToString(),
                            Book_Img = reader["Book_Img"].ToString(),
                            Book_Explain = reader["Book_Explain"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        // SEARCH: 제목으로 도서 검색
        public List<BookModel> SearchByTitle(string searchTitle)
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
                            Book_ISBN = reader["Book_ISBN"].ToString(),
                            Book_Title = reader["Book_Title"].ToString(),
                            Book_Author = reader["Book_Author"].ToString(),
                            Book_Pbl = reader["Book_Pbl"].ToString(),
                            Book_Price = Convert.ToInt32(reader["Book_Price"]),
                            Book_Link = reader["Book_Link"].ToString(),
                            Book_Img = reader["Book_Img"].ToString(),
                            Book_Explain = reader["Book_Explain"].ToString()
                        });
                    }
                }
            }
            return list;
        }

        // UPDATE: 도서 정보 수정
        public bool Update(BookModel book)
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
                        Book_Explain = :Book_Explain
                    WHERE Book_ISBN = :Book_ISBN";
                cmd.Parameters.Add(new OracleParameter("Book_Title", book.Book_Title));
                cmd.Parameters.Add(new OracleParameter("Book_Author", book.Book_Author));
                cmd.Parameters.Add(new OracleParameter("Book_Pbl", book.Book_Pbl));
                cmd.Parameters.Add(new OracleParameter("Book_Price", book.Book_Price));
                cmd.Parameters.Add(new OracleParameter("Book_Link", book.Book_Link));
                cmd.Parameters.Add(new OracleParameter("Book_Img", book.Book_Img));
                cmd.Parameters.Add(new OracleParameter("Book_Explain", book.Book_Explain));
                cmd.Parameters.Add(new OracleParameter("Book_ISBN", book.Book_ISBN));
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // DELETE: 도서 삭제 (ISBN 기준)
        public bool Delete(string isbn)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM Books WHERE Book_ISBN = :Book_ISBN";
                cmd.Parameters.Add(new OracleParameter("Book_ISBN", isbn));
                return cmd.ExecuteNonQuery() > 0;
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