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
        public string Book_Title { get; set; }   // 추가
        public byte[] Book_Img { get; set; }
        public string Book_Author { get; set; }
        public string Book_Pbl { get; set; }
        public int Rental_Status { get; set; }
        public string User_Phone { get; set; }   // *** "사용자번호"를 위해 이 속성을 추가합니다 ***
        public string User_Name { get; set; }    // 추가
        public DateTime Rental_Date { get; set; }
        public DateTime Rental_Return_Date { get; set; }

        // IsChildRow 속성은 이제 필요 없으므로 삭제합니다.
        // public bool IsChildRow { get; set; } = false; 
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
