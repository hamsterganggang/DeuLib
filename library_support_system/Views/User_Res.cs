using library_support_system.Model;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_support_system
{
    public partial class User_Res : Form , IUser_Res
    {
        #region Properties
        public string UserPhone => txtNum.Text.Trim();
        public string UserName => txtName.Text.Trim();
        public string UserBirthdate => txtBthDate.Text.Trim();
        public int UserGender => cmbGen.SelectedIndex;
        public string UserMail => txtEmail.Text.Trim();
        public string UserImage => pictureBoxUpload.ImageLocation ?? ""; // 또는 이미지 파일 경로 등
        PictureBox IUser_Res.pictureBoxUpload => this.pictureBoxUpload;
        #endregion

        //Event Handler
        public event EventHandler ExitUserRes;
        public event EventHandler btnSave_Click;
        public event EventHandler btnCancel_Click;
        public event EventHandler pictureBoxUpload_Click;

        public void SetUserData(UserModel user)
        {
            if (user == null) return;

            txtNum.Text = user.User_Phone ?? "";
            txtName.Text = user.User_Name ?? "";
            txtBthDate.Text = user.User_Birthdate ?? "";
            cmbGen.SelectedIndex = user.User_Gender; // Gender가 int라면 바로 설정
            txtEmail.Text = user.User_Mail ?? "";
            pictureBoxUpload.ImageLocation = user.User_Image ?? "";
        }
        public User_Res()
        {
            InitializeComponent();

            exit_button.Click += (sender, e) => ExitUserRes?.Invoke(sender, e);
            btnSave.Click += (sender, e) => btnSave_Click?.Invoke(sender, e);
            cancel_button.Click += (sender, e) => btnCancel_Click?.Invoke(sender, e);
            pictureBoxUpload.Click += (sender, e) => pictureBoxUpload_Click?.Invoke(sender, e); 


        }
       
        #region Method
        #endregion

        #region Event
        public void CloseView()
        {
            this.Close();  
        }
        #endregion

        #region GridEvent   
        #endregion

    }
}
