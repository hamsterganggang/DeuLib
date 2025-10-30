// library_support_system.Views/IBook_Res.cs
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using library_support_system.Models;

namespace library_support_system.Views
{
    public interface IBook_Res
    {
        #region Properties
        string BookISBN { get; }
        string BookTitle { get; }
        string BookAuthor { get; }
        string BookPublisher { get; }
        int BookPrice { get; }
        string BookLink { get; }
        byte[] UploadImageBytes { get; }
        string BookExplain { get; }
        PictureBox BookPictureBox { get; }

        // --- ★★★ 1. Presenter가 View를 제어하기 위한 속성 추가 ★★★ ---
        bool IsSaveButtonEnabled { set; }
        bool IsIsbnTextBoxReadOnly { set; }
        bool IsDuplicateCheckButtonEnabled { set; }
        #endregion

        #region Events
        event EventHandler ExitBookRes;
        event EventHandler btnSave_Click;
        event EventHandler btnCancel_Click;
        event EventHandler btnDuplicateCheck_Click;
        event EventHandler pictureBoxUpload_Click;

        // --- ★★★ 2. ISBN 텍스트 변경 "보고" 이벤트 추가 ★★★ ---
        event EventHandler IsbnTextChanged;

        void ShowMessage(string message, string title, MessageBoxIcon icon);
        void ClearForm();
        #endregion

        #region Methods
        void SetBookData(BookModel book);
        void CloseView();
        #endregion
    }
}