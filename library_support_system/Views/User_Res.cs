using library_support_system.Models;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        public event EventHandler btnCheckDuplicate_Click; // 중복 확인 이벤트
        private byte[] _uploadedImageBytes;           // 업로드된 이미지 임시 저장소
        public byte[] UploadImageBytes => _uploadedImageBytes;
        public void SetUserData(UserModel user)
        {
            if (user == null) return;
            txtNum.Text = user.User_Phone ?? "";
            txtName.Text = user.User_Name ?? "";
            txtBthDate.Text = user.User_Birthdate ?? "";
            cmbGen.SelectedIndex = user.User_Gender;
            txtEmail.Text = user.User_Mail ?? "";

            if (user.User_Image != null && user.User_Image.Length > 0)
            {
                using (var ms = new MemoryStream(user.User_Image))
                {
                    pictureBoxUpload.Image = Image.FromStream(ms);
                }
                _uploadedImageBytes = user.User_Image;
            }
            else
            {
                pictureBoxUpload.Image = null;
                _uploadedImageBytes = null;
            }
        }
        public void SetUploadedImage(byte[] bytes)
        {
            _uploadedImageBytes = bytes;
        }
        public User_Res()
        {
            InitializeComponent();
            BindDropDownListGen();

            exit_button.Click += (sender, e) => ExitUserRes?.Invoke(sender, e);
            btnSave.Click += (sender, e) => btnSave_Click?.Invoke(sender, e);
            cancel_button.Click += (sender, e) => btnCancel_Click?.Invoke(sender, e);
            pictureBoxUpload.Click += (sender, e) => pictureBoxUpload_Click?.Invoke(sender, e);
            button1.Click += (sender, e) => btnCheckDuplicate_Click?.Invoke(sender, e); // 중복 확인 버튼

            // 입력 필드 유효성 검증 이벤트 추가
            txtNum.Leave += ValidatePhone;
            txtName.Leave += ValidateName;
            txtBthDate.Leave += ValidateBirthdate;
            txtEmail.Leave += ValidateEmail;
            
            // 성별 콤보박스 초기화
            cmbGen.SelectedIndex = 0; // 빈 항목으로 초기화
        }

        #region Method
        private void BindDropDownListGen()
        {
            if (cmbGen != null)
            {
                cmbGen.Items.Clear();
                cmbGen.Items.Add("선택");
                cmbGen.Items.Add("남");
                cmbGen.Items.Add("여");
                cmbGen.SelectedIndex = 0;
            }
        }
        // 메시지 표시 메서드들
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSuccessMessage(string message)
        {
            MessageBox.Show(message, "성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // 입력 유효성 검증 메서드들
        private void ValidatePhone(object sender, EventArgs e)
        {
            string phone = txtNum.Text.Trim();
            if (string.IsNullOrEmpty(phone)) return;

            // 전화번호 형식 검증 (숫자만, 11자리 010으로 시작)
            if (!Regex.IsMatch(phone, @"^010\d{8}$"))
            {
                ShowErrorMessage("올바른 전화번호 형식이 아닙니다.\n예: 01012345678 (11자리 숫자)");
                txtNum.Focus();
            }
        }

        private void ValidateName(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrEmpty(name)) return;

            // 이름 길이 검증 (2-10자)
            if (name.Length < 2 || name.Length > 10)
            {
                ShowErrorMessage("이름은 2자 이상 10자 이하로 입력해주세요.");
                txtName.Focus();
            }
        }

        private void ValidateBirthdate(object sender, EventArgs e)
        {
            string birthdate = txtBthDate.Text.Trim();
            if (string.IsNullOrEmpty(birthdate)) return;

            DateTime parsedDate;
            bool isValid = false;

            // 생년월일 형식 검증 (YYYYMMDD 8자리 숫자)
            if (Regex.IsMatch(birthdate, @"^\d{8}$"))
            {
                if (DateTime.TryParseExact(birthdate, "yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    // 유효한 날짜 범위 확인 (1900년 이후, 현재 날짜 이전)
                    if (parsedDate.Year >= 1900 && parsedDate <= DateTime.Now)
                    {
                        isValid = true;
                        // YYYYMMDD 형식 유지
                        txtBthDate.Text = parsedDate.ToString("yyyyMMdd");
                    }
                }
            }

            if (!isValid)
            {
                ShowErrorMessage("올바른 생년월일 형식이 아닙니다.\n예: 19900101 (8자리 숫자)");
                txtBthDate.Focus();
            }
        }

        private void ValidateEmail(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(email)) return;

            // 이메일 형식 검증
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                ShowErrorMessage("올바른 이메일 형식이 아닙니다.\n예: user@example.com");
                txtEmail.Focus();
            }
        }

        // 전체 입력 유효성 검증
        public bool ValidateAllInputs()
        {
            // 필수 입력 필드 확인
            if (string.IsNullOrWhiteSpace(UserPhone))
            {
                ShowErrorMessage("전화번호를 입력해주세요.");
                txtNum.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(UserName))
            {
                ShowErrorMessage("이름을 입력해주세요.");
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(UserBirthdate))
            {
                ShowErrorMessage("생년월일을 입력해주세요.");
                txtBthDate.Focus();
                return false;
            }

            if (UserGender == 0)
            {
                ShowErrorMessage("성별을 선택해주세요.");
                cmbGen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(UserMail))
            {
                ShowErrorMessage("이메일을 입력해주세요.");
                txtEmail.Focus();
                return false;
            }

            // 각 필드별 형식 검증
            ValidatePhone(txtNum, EventArgs.Empty);
            ValidateName(txtName, EventArgs.Empty);
            ValidateBirthdate(txtBthDate, EventArgs.Empty);
            ValidateEmail(txtEmail, EventArgs.Empty);

            return true;
        }

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
