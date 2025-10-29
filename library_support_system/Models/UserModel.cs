using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_support_system.Models
{
    public class UserModel
    {
        //ORACLE USERS와 매핑되는 모델 클래스
        #region Properties
        public int User_Seq { get; set; }  // 새로운 PK 속성
        public string User_Phone { get; set; }
        public string User_Name { get; set; }
        public string User_Birthdate { get; set; }
        public int User_Gender { get; set; } = 0;
        public string User_Mail { get; set; }
        public byte[] User_Image { get; set; }
        public int User_WTHDR { get; set; } = 1;
        public string GenderDisplay
        {
            get
            {
                return User_Gender == 1 ? "남성" : User_Gender == 2 ? "여성" : "-";
            }
        }
        public string WTHDRDisplay
        {
            get
            {
                return User_WTHDR == 0 ? "가입" : User_WTHDR == 1 ? "탈퇴" : "-";
            }
        }
        #endregion
    }
}
