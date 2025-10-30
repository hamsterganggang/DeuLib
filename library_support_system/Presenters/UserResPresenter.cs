using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Drawing;
using System.IO;
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
        private bool isPhoneChecked = false; // 전화번호 중복 확인 여부
        private string checkedPhone = "";    // 중복 확인된 전화번호
        #endregion

        public UserResPresenter(IUser_Res view, UserModel user = null)
        {
            this.view = view;
            this.userRepository = new UserRepository();

            // 이벤트 핸들러 연결
            this.view.ExitUserRes += exit_button_Click;
            this.view.btnSave_Click += btnSave_Click;
            this.view.btnCancel_Click += cancel_button_Click;
            this.view.pictureBoxUpload_Click += pictureBoxUpload_Click;
            this.view.btnCheckDuplicate_Click += btnCheckDuplicate_Click;
            this.view.PhoneNumberChanged += OnPhoneNumberChanged; // [추가]

            if (user != null)
            {
                isEditMode = true;
                editingUser = user;
                view.SetUserData(user);
                view.FormText = "회원정보 수정";
                view.SaveButtonText = "수정";

                isPhoneChecked = true;
                checkedPhone = user.User_Phone;
            }
            else
            {
                isEditMode = false;
                view.FormText = "회원 신규등록";
                view.SaveButtonText = "등록";
            }
        }

        #region Event Handlers

        // [추가] 전화번호가 변경되면 중복확인 상태를 초기화
        private void OnPhoneNumberChanged(object sender, EventArgs e)
        {
            isPhoneChecked = false;
        }

        // [수정] 전화번호 중복 확인 로직
        private void btnCheckDuplicate_Click(object sender, EventArgs e)
        {
            string phone = view.UserPhone;

            // 1. 형식 유효성 검사 먼저 수행
            if (string.IsNullOrEmpty(phone))
            {
                view.ShowErrorMessage("전화번호를 입력해주세요.");
                view.FocusPhoneInput();
                return;
            }
            if (!view.IsValidPhoneFormat())
            {
                view.ShowErrorMessage("올바른 전화번호 형식이 아닙니다.\n예: 01012345678");
                view.FocusPhoneInput();
                return;
            }

            // 2. 유효성 검사 통과 후 DB 조회
            try
            {
                if (isEditMode && phone == editingUser.User_Phone)
                {
                    isPhoneChecked = true;
                    checkedPhone = phone;
                    view.ShowSuccessMessage("사용 가능한 전화번호입니다.");
                    return;
                }

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

        // [수정] 저장 로직
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. 전체 입력 유효성 검증
                if (!view.ValidateAllInputs())
                {
                    return;
                }

                // 2. 전화번호 중복 확인 여부 최종 체크
                // 현재 입력된 전화번호가 중복 확인을 통과한 번호와 같은지 확인
                if (!isPhoneChecked || checkedPhone != view.UserPhone)
                {
                    view.ShowErrorMessage("전화번호 중복 확인을 해주세요.");
                    view.FocusPhoneInput();
                    return;
                }

                UserModel model = new UserModel
                {
                    User_Seq = isEditMode ? editingUser.User_Seq : 0,
                    User_Phone = view.UserPhone,
                    User_Name = view.UserName,
                    User_Birthdate = view.UserBirthdate,
                    User_Gender = view.UserGender,
                    User_Mail = view.UserMail,
                    User_Image = view.UploadImageBytes,
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
                var picBox = view.pictureBoxUpload;
                using (var ms = new MemoryStream(imageBytes))
                {
                    picBox.Image = Image.FromStream(ms);
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                view.SetUploadedImage(imageBytes);
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("작업을 취소하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                view.CloseView();
            }
        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            cancel_button_Click(sender, e);
        }

        #endregion
    }
}