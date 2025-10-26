using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace library_support_system.Presenters
{
    public class UserResPresenter
    {
        #region Fields
        private readonly IUser_Res view;
        private readonly UserRepository userRepository;
        private readonly bool isEditMode;
        private readonly UserModel editingUser;
        private bool isPhoneChecked = false; // 전화번호 중복 확인 여부
        private string checkedPhone = "";    // 중복 확인된 전화번호
        #endregion

        public UserResPresenter(IUser_Res view, UserModel user = null)
        {
            this.view = view;
            this.userRepository = new UserRepository();

            this.view.ExitUserRes += exit_button_Click; //우측 위 종료 버튼
            this.view.btnSave_Click += btnSave_Click; //등록버튼
            this.view.btnCancel_Click += cancel_button_Click; //취소 버튼
            this.view.pictureBoxUpload_Click += pictureBoxUpload_Click; //사진 업로드
            this.view.btnCheckDuplicate_Click += btnCheckDuplicate_Click; // 중복 확인 버튼

            if (user != null)
            {
                isEditMode = true;
                editingUser = user;
                view.SetUserData(user);
                (view as Form).Text = "회원정보 수정";
                var btnSave = (view as Form).Controls["btnSave"] as Button;
                if (btnSave != null) btnSave.Text = "수정";
                
                // 수정 모드에서는 본인 전화번호는 중복 확인 통과로 처리
                isPhoneChecked = true;
                checkedPhone = user.User_Phone;
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
                Title = "사진 업로드"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                byte[] imageBytes = File.ReadAllBytes(dialog.FileName);

                // View의 PictureBox를 property로 접근
                var picBox = view.pictureBoxUpload;
                using (var ms = new MemoryStream(imageBytes))
                {
                    picBox.Image = Image.FromStream(ms);
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                // View에 byte[] 데이터 저장
                // 캐스팅하지 않고 인터페이스의 UploadImageBytes(setter나 메서드로 할당해도 됨)
                if (view is User_Res viewImpl)
                {
                    viewImpl.SetUploadedImage(imageBytes); // 아래처럼 Set 메서드 추가해도 됨
                }
            }
        }

        // 전화번호 중복 확인
        private void btnCheckDuplicate_Click(object sender, EventArgs e)
        {
            string phone = view.UserPhone.Trim();
            
            if (string.IsNullOrEmpty(phone))
            {
                view.ShowErrorMessage("전화번호를 입력해주세요.");
                return;
            }

            try
            {
                // 수정 모드에서 본인 전화번호인 경우 중복 확인 통과
                if (isEditMode && phone == editingUser.User_Phone)
                {
                    isPhoneChecked = true;
                    checkedPhone = phone;
                    view.ShowSuccessMessage("사용 가능한 전화번호입니다.");
                    return;
                }

                // 중복 확인
                bool exists = userRepository.IsPhoneExists(phone);
                
                if (exists)
                {
                    isPhoneChecked = false;
                    checkedPhone = "";
                    view.ShowErrorMessage("이미 사용중인 전화번호입니다.");
                }
                else
                {
                    isPhoneChecked = true;
                    checkedPhone = phone;
                    view.ShowSuccessMessage("사용 가능한 전화번호입니다.");
                }
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage($"중복 확인 중 오류가 발생했습니다: {ex.Message}");
            }
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            try 
            {
                // 입력 유효성 검증
                if (!(view as User_Res).ValidateAllInputs())
                {
                    return;
                }

                // 신규 등록 시 전화번호 중복 확인 여부 체크
                if (!isEditMode)
                {
                    if (!isPhoneChecked || checkedPhone != view.UserPhone)
                    {
                        view.ShowErrorMessage("전화번호 중복 확인을 해주세요.");
                        return;
                    }
                }
                // 수정 모드에서 전화번호가 변경된 경우 중복 확인 필요
                else if (isEditMode && view.UserPhone != editingUser.User_Phone)
                {
                    if (!isPhoneChecked || checkedPhone != view.UserPhone)
                    {
                        view.ShowErrorMessage("변경된 전화번호의 중복 확인을 해주세요.");
                        return;
                    }
                }

                UserModel model = new UserModel
                {
                    User_Seq = isEditMode ? editingUser.User_Seq : 0, // 수정 모드 PK 필수
                    User_Phone = view.UserPhone,
                    User_Name = view.UserName,
                    User_Birthdate = view.UserBirthdate,
                    User_Gender = view.UserGender,
                    User_Mail = view.UserMail,
                    User_Image = (view as User_Res)?.UploadImageBytes,
                    User_WTHDR = 0
                };

                bool result = isEditMode
                    ? userRepository.Update(model)
                    : userRepository.Create(model);

                if (result)
                {
                    view.ShowSuccessMessage(isEditMode ? "회원 정보 수정이 완료되었습니다." : "회원 등록이 완료되었습니다.");
                    view.CloseView();
                }
                else
                {
                    view.ShowErrorMessage(isEditMode ? "회원 정보 수정에 실패했습니다." : "회원 등록에 실패했습니다.");
                }
            }
            catch (Exception ex)
            {
                view.ShowErrorMessage($"저장 중 오류가 발생했습니다: {ex.Message}");
            }
        }
        #endregion
    }
}
