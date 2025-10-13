using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_support_system.Models
{
    public class RentalModel
    {
        #region Properties
        public int Rental_Seq { get; set; }
        public string Book_ISBN { get; set; }
        public string User_Phone { get; set; }
        public int Rental_Status { get; set; } = 0;
        public DateTime Rental_Date { get; set; }
        public DateTime Rental_Return_Date { get; set; }
        #endregion
    }
}
