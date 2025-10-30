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

        // --- �ڡڡ� 1. Presenter�� View�� �����ϱ� ���� �Ӽ� �߰� �ڡڡ� ---
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

        // --- �ڡڡ� 2. ISBN �ؽ�Ʈ ���� "����" �̺�Ʈ �߰� �ڡڡ� ---
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