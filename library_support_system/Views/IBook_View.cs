using library_support_system.Models;
using System;
using System.Collections.Generic;

namespace library_support_system.Views
{
    public interface IBook_View
    {
        event EventHandler ViewLoaded;
        event EventHandler ChangeBookEvent;
        event EventHandler DeleteBookEvent;
        void SetBookList(List<BookModel> books);
        BookModel SelectedBook { get; }
        void ShowMessage(string message);
    }

}