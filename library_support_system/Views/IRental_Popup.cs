using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_support_system.Views
{
    public interface IRental_Popup
    {
        // 1. View -> Presenter (이벤트)
        event EventHandler PopupLoaded;
        event EventHandler SaveClicked;
        event EventHandler CheckUserClicked;
        event EventHandler UserPhoneTextChanged;

        // 2. Presenter -> View (속성 제어)
        string UserPhone { get; set; } // txtPhoneNum
        DateTime RentalDate { get; set; } // TimeRent
        DateTime ReturnDate { get; set; } // TimeReturn

        // 3. Presenter -> View (상태 제어)
        bool IsDatePickersReadOnly { set; }
        bool IsUserPhoneReadOnly { set; } 
        bool IsRentButtonEnabled { set; } // *** (추가) 대여 버튼 활성화
        bool IsCheckButtonEnabled { set; }

        // 4. Presenter -> View (메서드)
        void CloseView(); // *** (추가) 폼 닫기
        void ShowMessage(string message); // *** (추가) 메시지 박스
    }
}
