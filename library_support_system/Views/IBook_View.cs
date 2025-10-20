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
        event EventHandler SearchButtonClick;  // 검색 버튼 클릭 이벤트 추가
        
        void SetBookList(List<BookModel> books);
        BookModel SelectedBook { get; }
        void ShowMessage(string message);
        
        string SearchText { get; }  // 검색 텍스트 속성 추가
    }

}