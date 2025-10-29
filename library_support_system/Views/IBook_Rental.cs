using System;
using System.Collections.Generic;
using library_support_system.Models;

namespace library_support_system.Views
{
    public interface IBook_Rental
    {
        event EventHandler ViewLoaded;
        event EventHandler<RentalModelEventArgs> RentalCheckClicked; // Presenter에게 보고할 이벤트
        List<RentalModel> RentalList { set; }
        void ShowMessage(string message);
        void ShowRentalPopup(RentalModel rental); // Presenter가 View에게 명령할 메서드
    }
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