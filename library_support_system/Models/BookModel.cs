using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_support_system.Models
{
    public class BookModel
    {
        //ORACLE BOOKS와 매핑되는 모델 클래스
        #region Properties
        public string Book_ISBN { get; set; }
        public string Book_Title { get; set; }
        public string Book_Author { get; set; }
        public string Book_Pbl { get; set; }
        public int Book_Price { get; set; }
        public string Book_Link { get; set; }
        public string Book_Img { get; set; }
        public string Book_Exp { get; set; }
        #endregion
    }
}
