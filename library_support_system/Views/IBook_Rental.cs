using System;
using System.Collections.Generic;
using library_support_system.Models;

namespace library_support_system.Views
{
    public interface IBook_Rental
    {
        event EventHandler ViewLoaded;
        event EventHandler<RentalModelEventArgs> RentalCheckClicked;
        RentalModel SelectedRental { get; }
        List<RentalModel> RentalList { set; }
        void ShowMessage(string message);
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