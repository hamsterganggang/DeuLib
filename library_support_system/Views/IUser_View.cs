using library_support_system.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public interface IUser_View
    {
        #region Properties
        string SearchValue { get; } // 검색어
        string SearchBy { get; }     // 검색옵션(이름/전화번호)
        UserModel SelectedUser { get; }
        IEnumerable<UserModel> UserList { set; }
        #endregion

        #region Events
        event EventHandler ChangeUserEvent;
        event EventHandler SearchEvent;
        event EventHandler DeleteUserEvent;
        void ShowMessage(string message);
        #endregion
    }
}
