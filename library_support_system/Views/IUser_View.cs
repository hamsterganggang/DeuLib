using library_support_system.Model;
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
        string SearchValue { get; set; }
        string SearchBy { get; set; }
        IEnumerable<UserModel> UserList { set; } // Presenter에서 View로 데이터를 전달하는 통로

        event EventHandler SearchEvent;
        void ShowMessage(string message);
    }
}
