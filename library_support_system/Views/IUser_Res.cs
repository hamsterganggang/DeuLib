using library_support_system.Models;
using System;
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
        byte[] UploadImageBytes { get; }
        PictureBox pictureBoxUpload { get; }

        // [추가] Presenter가 View의 UI 텍스트를 제어하기 위한 속성
        string FormText { get; set; }
        string SaveButtonText { get; set; }
        bool IsSaveButtonEnabled { set; }         // ★ (추가) "저장" 버튼 활성화/비활성화
        bool IsPhoneTextBoxReadOnly { set; }      // ★ (추가) "전화번호" 텍스트박스 읽기전용/활성화
        bool IsCheckButtonEnabled { set; }
        #endregion

        #region Events
        event EventHandler ExitUserRes;
        event EventHandler btnSave_Click;
        event EventHandler btnCancel_Click;
        event EventHandler pictureBoxUpload_Click;
        event EventHandler btnCheckDuplicate_Click;

        // [추가] 전화번호가 수정될 때마다 Presenter에게 알리기 위한 이벤트
        event EventHandler PhoneNumberChanged;
        #endregion

        #region Methods
        void SetUserData(UserModel user);
        void SetUploadedImage(byte[] bytes); // [개선] 이미지 설정 메서드 추가
        void ShowMessage(string message);
        void ShowErrorMessage(string message);
        void ShowSuccessMessage(string message);

        // [추가] Presenter가 View의 기능을 직접 호출하기 위한 메서드들
        bool ValidateAllInputs();
        bool IsValidPhoneFormat(); // 전화번호 형식만 검사
        void FocusPhoneInput();    // 전화번호 입력창에 포커스
        void CloseView();
        #endregion
    }
}