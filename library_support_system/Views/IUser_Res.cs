using library_support_system.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public interface IUser_Res
    {
        #region Properties
        string UserPhone { get; }
        string UserName { get; }
        string UserBirthdate { get; }
        int UserGender { get; }
        string UserMail { get; }
        string UserImage { get; }
        PictureBox pictureBoxUpload { get; }
        #endregion

        #region Events
        event EventHandler ExitUserRes;
        event EventHandler btnSave_Click;
        event EventHandler btnCancel_Click;
        event EventHandler pictureBoxUpload_Click;
        void SetUserData(UserModel user); // ← 반드시 추가!
        void CloseView();
        #endregion
    }
}
