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
        event EventHandler ReturnClicked; // *** "반납" 버튼 클릭 이벤트 추가 ***
        event EventHandler ReturnListFilterChanged;
        // 2. View -> Presenter (데이터 제공)
        RentalModel SelectedRental { get; } // *** 그리드 선택 항목 속성 추가 ***
        bool IsReturnedListChecked { get; }
        // 3. Presenter -> View (명령)
        List<RentalModel> RentalList { set; }
        void ShowMessage(string message);
    }
}