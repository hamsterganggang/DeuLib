using library_support_system.Models;
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
        byte[] UploadImageBytes { get; }
        PictureBox pictureBoxUpload { get; }
        #endregion

        #region Events
        event EventHandler ExitUserRes;
        event EventHandler btnSave_Click;
        event EventHandler btnCancel_Click;
        event EventHandler pictureBoxUpload_Click;
        event EventHandler btnCheckDuplicate_Click; // 중복 확인 버튼 이벤트 추가

        void SetUserData(UserModel user); // ← 반드시 추가!
        void CloseView();
        void ShowMessage(string message);           // 메시지 표시 메서드 추가
        void ShowErrorMessage(string message);     // 에러 메시지 표시 메서드 추가
        void ShowSuccessMessage(string message);   // 성공 메시지 표시 메서드 추가
        #endregion
    }
}
