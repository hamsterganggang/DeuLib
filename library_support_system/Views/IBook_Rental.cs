// library_support_system.Views/IBook_Rental.cs
using System;
using System.Collections.Generic;
using library_support_system.Models;

namespace library_support_system.Views
{
    public interface IBook_Rental
    {
        event EventHandler ViewLoaded;
        event EventHandler<RentalModelEventArgs> RentalCheckClicked;

        // --- ★★★ 1. "검색" 이벤트 추가 ★★★ ---
        event EventHandler SearchClicked;

        // --- ★★★ 2. "검색어" 속성 추가 ★★★ ---
        string SearchType { get; }
        string SearchKeyword { get; }

        List<RentalModel> RentalList { set; }
        void ShowMessage(string message);
        void ShowRentalPopup(RentalModel rental);
    }

    // RentalModelEventArgs 클래스는 변경 사항 없습니다.
    public class RentalModelEventArgs : EventArgs
    {
        public RentalModel Rental { get; }
        public int RowIndex { get; }

        public RentalModelEventArgs(RentalModel rental, int rowIndex)
        {
            Rental = rental;
            RowIndex = rowIndex;
        }
    }
}