using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library_support_system.Views;

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

        //EventHandler 작성
        public event EventHandler ExitUserRes;
        public event EventHandler btnSave_Click;
        public event EventHandler btnCancel_Click;
        public event EventHandler pictureBoxUpload_Click;
 

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
