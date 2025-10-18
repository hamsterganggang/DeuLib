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
        IEnumerable<UserModel> UserList { set; } // Presenter에서 View로 데이터를 전달하는 통로
        #endregion

        #region Events
        event EventHandler ChangeUserEvent;
        event EventHandler SearchEvent;
        event EventHandler DeleteUserEvent;
        void ShowMessage(string message);
        #endregion
    }
}
