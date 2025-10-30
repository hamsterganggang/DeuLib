// library_support_system.Views/IBook_Return.cs
using library_support_system.Models;
using System;
using System.Collections.Generic;

namespace library_support_system.Views
{
    public interface IBook_Return
    {
        // 1. View -> Presenter (이벤트)
        event EventHandler ViewLoaded;
        event EventHandler ReturnClicked;
        event EventHandler ReturnListFilterChanged;
        event EventHandler SearchClicked; // *** "검색" 버튼 클릭 이벤트 추가 ***

        // 2. View -> Presenter (데이터 제공)
        RentalModel SelectedRental { get; }
        bool IsReturnedListChecked { get; }
        string SearchType { get; }      // *** (추가) 검색 조건 (예: "도서 제목")
        string SearchKeyword { get; }   // *** (추가) 검색어 (예: "C#")

        // 3. Presenter -> View (명령)
        List<RentalModel> RentalList { set; }
        void ShowMessage(string message);
    }
}