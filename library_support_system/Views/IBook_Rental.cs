using System;
using System.Collections.Generic;
using library_support_system.Models;

namespace library_support_system.Views
{
    public interface IBook_Rental
    {
        event EventHandler ViewLoaded;
        List<RentalModel> RentalList { set; }
        RentalModel SelectedRental { get; }
        void ShowMessage(string message);
    }
}