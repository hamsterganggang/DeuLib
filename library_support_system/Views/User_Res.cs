using library_support_system.Models;
using library_support_system.Views;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace library_support_system
{
    // partial 키워드를 사용하여 .Designer.cs 파일과 클래스를 공유합니다.
    public partial class User_Res : Form, IUser_Res
    {
        #region Properties (인터페이스 구현)

        // 각 컨트롤의 값을 반환합니다.
        public string UserPhone => txtNum.Text.Trim();
        public string UserName => txtName.Text.Trim();
        public string UserBirthdate => txtBthDate.Text.Trim();
        public int UserGender => cmbGen.SelectedIndex;
        public string UserMail => txtEmail.Text.Trim();

        // 업로드된 이미지의 byte 데이터를 저장하고 반환합니다.
        public byte[] UploadImageBytes { get; private set; }

        // 디자이너가 만든 필드와의 이름 충돌을 피하기 위해 '명시적 인터페이스 구현'을 사용합니다.
        PictureBox IUser_Res.pictureBoxUpload => this.pictureBoxUpload;

        // Form의 제목(Text)과 저장 버튼의 텍스트를 가져오거나 설정합니다.
        public string FormText { get => this.Text; set => this.Text = value; }
        public string SaveButtonText { get => this.btnSave.Text; set => this.btnSave.Text = value; }
        public bool IsSaveButtonEnabled
        {
            set { btnSave.Enabled = value; }
        }
        public bool IsPhoneTextBoxReadOnly
        {
            set
            {
                txtNum.ReadOnly = value;
                txtNum.BackColor = value ? SystemColors.Control : SystemColors.Window;
            }
        }
        public bool IsCheckButtonEnabled
        {
            set
            {
                button1.Enabled = value; // (디자이너의 버튼 이름이 'button1'이라고 가정)
                button1.BackColor = value ? SystemColors.Window : SystemColors.Control;
            }
        }
        #endregion

        #region Events (인터페이스 구현)

        // Presenter가 구독할 이벤트들을 정의합니다.
        public event EventHandler ExitUserRes;
        public event EventHandler btnSave_Click;
        public event EventHandler btnCancel_Click;
        public event EventHandler pictureBoxUpload_Click;
        public event EventHandler btnCheckDuplicate_Click;
        public event EventHandler PhoneNumberChanged; // 전화번호 텍스트 변경 감지 이벤트

        #endregion

        // 생성자
        public User_Res()
        {
            InitializeComponent();
            BindDropDownListGen(); // 성별 콤보박스 초기화

            // UI 컨트롤의 이벤트를 인터페이스의 이벤트에 연결(매핑)합니다.
            // UI 이벤트가 발생하면 Presenter에게 "이런 일이 발생했어!"라고 알려주는 역할을 합니다.
            exit_button.Click += (sender, e) => ExitUserRes?.Invoke(sender, e);
            btnSave.Click += (sender, e) => btnSave_Click?.Invoke(sender, e);
            cancel_button.Click += (sender, e) => btnCancel_Click?.Invoke(sender, e);
            pictureBoxUpload.Click += (sender, e) => pictureBoxUpload_Click?.Invoke(sender, e);
            button1.Click += (sender, e) => btnCheckDuplicate_Click?.Invoke(sender, e);

            // 전화번호 입력창의 텍스트가 변경될 때마다 PhoneNumberChanged 이벤트를 발생시킵니다.
            txtNum.TextChanged += (sender, e) => PhoneNumberChanged?.Invoke(sender, e);
        }

        #region Methods (인터페이스 구현)

        /// <summary>
        /// Presenter로부터 받은 사용자 데이터로 화면 컨트롤을 채웁니다.
        /// </summary>
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
                UploadImageBytes = user.User_Image; // byte 데이터도 저장
            }
            else
            {
                pictureBoxUpload.Image = null;
                UploadImageBytes = null;
            }
        }

        /// <summary>
        /// Presenter로부터 받은 이미지 byte 데이터를 View의 속성에 저장합니다.
        /// </summary>
        public void SetUploadedImage(byte[] bytes)
        {
            UploadImageBytes = bytes;
        }

        /// <summary>
        /// 성별 콤보박스의 항목을 초기화합니다.
        /// </summary>
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

        // 다양한 종류의 메시지 박스를 띄웁니다.
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

        /// <summary>
        /// 전화번호 형식의 유효성만 검사합니다. (Presenter 호출용)
        /// </summary>
        public bool IsValidPhoneFormat()
        {
            return Regex.IsMatch(UserPhone, @"^010\d{8}$");
        }

        /// <summary>
        /// 전화번호 입력창으로 포커스를 이동시킵니다. (Presenter 호출용)
        /// </summary>
        public void FocusPhoneInput()
        {
            txtNum.Focus();
        }

        /// <summary>
        /// '저장' 버튼 클릭 시 모든 입력 항목의 유효성을 순차적으로 검사합니다.
        /// </summary>
        public bool ValidateAllInputs()
        {
            if (string.IsNullOrWhiteSpace(UserPhone) || !IsValidPhoneFormat())
            {
                ShowErrorMessage("올바른 전화번호를 입력해주세요.\n예: 01012345678");
                txtNum.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(UserName) || UserName.Length < 2 || UserName.Length > 10)
            {
                ShowErrorMessage("이름은 2자 이상 10자 이하로 입력해주세요.");
                txtName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(UserBirthdate) || !Regex.IsMatch(UserBirthdate, @"^\d{8}$"))
            {
                ShowErrorMessage("올바른 생년월일을 입력해주세요.\n예: 19900101");
                txtBthDate.Focus();
                return false;
            }
            if (UserGender == 0)
            {
                ShowErrorMessage("성별을 선택해주세요.");
                cmbGen.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(UserMail) || !Regex.IsMatch(UserMail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                ShowErrorMessage("올바른 이메일 형식을 입력해주세요.");
                txtEmail.Focus();
                return false;
            }
            return true; // 모든 검사를 통과하면 true 반환
        }

        /// <summary>
        /// 현재 창을 닫습니다. (Presenter 호출용)
        /// </summary>
        public void CloseView()
        {
            this.Close();
        }

        #endregion
    }
}