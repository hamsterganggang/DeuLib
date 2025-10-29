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
        string SearchValue { get; set; }
        string SearchBy { get; set; }
        UserModel SelectedUser { get; }
        bool IsRetireUserChecked { get; }
        IEnumerable<UserModel> UserList { set; } // Presenter에서 View로 데이터를 전달하는 통로
        #endregion

        #region Events
        //회원수정
        event EventHandler ChangeUserEvent;
        //회원검색
        event EventHandler SearchEvent;
        //회원삭제
        event EventHandler DeleteUserEvent;
        //탈퇴회원조회
        event EventHandler RetireFilterChanged;
        //회원수정폼
        void ShowUserEditForm(UserModel userToEdit);
        void ShowMessage(string message);
        #endregion
    }
}
