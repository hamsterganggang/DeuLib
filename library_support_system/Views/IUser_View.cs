using library_support_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public interface IUser_View
    {
        #region Properties
        string SearchValue { get; } // 검색어
        string SearchBy { get; }     // 검색옵션(이름/전화번호)
        UserModel SelectedUser { get; }
        bool IsRetireUserChecked { get; }
        IEnumerable<UserModel> UserList { set; }
        #endregion

        #region Events
        //회원수정
        event EventHandler ChangeUserEvent;
        //회원검색
        event EventHandler SearchEvent;
        //회원탈퇴
        event EventHandler DeleteUserEvent;
        //탈퇴회원조회
        event EventHandler RetireFilterChanged;
        //회원수정폼
        void ShowUserEditForm(UserModel userToEdit);
        void ShowMessage(string message);
        #endregion
    }
}
