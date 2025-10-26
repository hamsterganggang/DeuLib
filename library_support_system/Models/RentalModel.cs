using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_support_system.Models
{
    public class RentalModel
    {
        //ORACLE BOOK_RENTAL과 매핑되는 모델 클래스
        #region Properties
        public int Rental_Seq { get; set; }
        public string Book_ISBN { get; set; }
        public string Book_Title { get; set; }      // 추가
        public byte[] Book_Img { get; set; }
        public string Book_Author { get; set; }
        public string Book_Pbl { get; set; }
        public int Rental_Status { get; set; }
        public string User_Phone { get; set; }
        public string User_Name { get; set; }       // 추가
        public DateTime Rental_Date { get; set; }
        public DateTime Rental_Return_Date { get; set; }
        public bool IsChildRow { get; set; } = false;
        #endregion
        public string Rental_Status_Text
        {
            get
            {
                return Rental_Status == 1 ? "대여중" : "대여가능";
            }
        }
    }
}
