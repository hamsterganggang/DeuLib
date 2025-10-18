using library_support_system.Models;
using System;
using System.Collections.Generic;

namespace library_support_system.Views
{
    public interface IBook_View
    {
        event EventHandler ViewLoaded;
        event EventHandler ChangeBookEvent;  // 수정 이벤트
        event EventHandler DeleteBookEvent;  // 삭제 이벤트
        void SetBookList(List<BookModel> books);
        List<BookModel> BookList { set; }
        BookModel SelectedBook { get; }
        void ShowMessage(string message);
    }
}