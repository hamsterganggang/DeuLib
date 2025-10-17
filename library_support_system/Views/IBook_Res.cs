using System;
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
        string BookImage { get; }
        string BookExplain { get; }
        PictureBox BookPictureBox { get; }
        #endregion


        #region Events
        event EventHandler ExitBookRes;
        event EventHandler btnSave_Click;
        event EventHandler btnCancel_Click;
        event EventHandler btnDuplicateCheck_Click;
        event EventHandler pictureBoxUpload_Click;

        void ShowMessage(string message, string title, MessageBoxIcon icon);
        void ClearForm();
        #endregion

        #region Methods
        void SetBookData(BookModel book);
        void CloseView();
        #endregion
    }
}