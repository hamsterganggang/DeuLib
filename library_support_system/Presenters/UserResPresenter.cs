using library_support_system.Model;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_support_system.Presenters
{
    public class UserResPresenter
    {
        #region Fields
        private readonly IUser_Res view;
        private readonly UserRepository userRepository;
        private readonly bool isEditMode;
        private readonly UserModel editingUser;
        #endregion


        public UserResPresenter(IUser_Res view, UserModel user = null)
        {
            this.view = view;
            this.userRepository = new UserRepository();

            this.view.ExitUserRes += exit_button_Click; //우측 위 종료 버튼
            this.view.btnSave_Click += btnSave_Click; //등록버튼
            this.view.btnCancel_Click += cancel_button_Click; //취소 버튼
            this.view.pictureBoxUpload_Click += pictureBoxUpload_Click; //사진 업로드

            if (user != null)
            {
                isEditMode = true;
                editingUser = user;
                view.SetUserData(user);
                (view as Form).Text = "회원정보 수정";
                var btnSave = (view as Form).Controls["btnSave"] as Button;
                if (btnSave != null) btnSave.Text = "수정";
            }
            else
            {
                isEditMode = false;
                (view as Form).Text = "회원 신규등록";
                var btnSave = (view as Form).Controls["btnSave"] as Button;
                if (btnSave != null) btnSave.Text = "등록";
            }
        }
        #region Method
        private void exit_button_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "정말로 가입을 중단하시겠습니까?",
            "가입 중단 확인",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                view.CloseView();  // View 닫기 요청
            }
            // 아니요: 아무 동작 없음 (그냥 복귀)
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "정말로 가입을 중단하시겠습니까?",
            "가입 중단 확인",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                view.CloseView();
            }
        }
        private void pictureBoxUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png",
                Title = "사진 업로드",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                view.pictureBoxUpload.Image = Image.FromFile(dialog.FileName);
                view.pictureBoxUpload.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            UserModel model = new UserModel
            {
                User_Phone = view.UserPhone,
                User_Name = view.UserName,
                User_Birthdate = view.UserBirthdate,
                User_Gender = view.UserGender,
                User_Mail = view.UserMail,
                User_Image = view.UserImage,
                User_WithDR = 0
            };

            bool result = isEditMode
                ? userRepository.Update(model)
                : userRepository.Create(model);

            if (result)
            {
                MessageBox.Show(isEditMode ? "회원 정보 수정 완료" : "회원 등록 완료");
                view.CloseView();
            }
            else
            {
                MessageBox.Show(isEditMode ? "회원 정보 수정 실패" : "회원 등록 실패");
            }
        }
        #endregion
    }
}
