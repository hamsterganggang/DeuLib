using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace library_support_system.Presenters
{
    public class BookResPresenter
    {
        #region Fields
        private readonly IBook_Res view;
        private readonly BookRepository bookRepository;
        private readonly bool isEditMode;
        private readonly BookModel editingBook;
        private bool isIsbnValidated = false;
        private bool isRecoveryMode = false;
        private int recoveredBookSeq = 0;
        #endregion

        public BookResPresenter(IBook_Res view, BookModel book = null)
        {
            this.view = view;
            this.bookRepository = new BookRepository();

            this.view.ExitBookRes += exit_button_Click;
            this.view.btnSave_Click += btnSave_Click;
            this.view.btnCancel_Click += cancel_button_Click;
            this.view.btnDuplicateCheck_Click += btnDuplicateCheck_Click;
            this.view.pictureBoxUpload_Click += pictureBoxUpload_Click;
            this.view.IsbnTextChanged += OnIsbnTextChanged;

            if (book != null) // "����" ���
            {
                isEditMode = true;
                editingBook = book;
                view.SetBookData(book);

                var btnSave = (view as Form).Controls.Find("btnSave", true).FirstOrDefault() as Button;
                if (btnSave != null) btnSave.Text = "����";

                isIsbnValidated = true;
                view.IsSaveButtonEnabled = true;
                view.IsIsbnTextBoxReadOnly = true;
                view.IsDuplicateCheckButtonEnabled = false;
            }
            else // "�ű� ���" ���
            {
                isEditMode = false;

                var btnSave = (view as Form).Controls.Find("btnSave", true).FirstOrDefault() as Button;
                if (btnSave != null) btnSave.Text = "���";

                isIsbnValidated = false;
                view.IsSaveButtonEnabled = false;
                view.IsIsbnTextBoxReadOnly = false;
                view.IsDuplicateCheckButtonEnabled = true;

                // �ڡڡ� (�߰�) �ű� ����� �� ���� ��尡 �ƴ�
                isRecoveryMode = false;
                recoveredBookSeq = 0;
            }
        }

        #region Method
        private void OnIsbnTextChanged(object sender, EventArgs e)
        {
            if (isEditMode) return; // ���� ��忡�� ����

            // ISBN�� ����Ǹ�, "Ȯ��" ���� �� "����" ���¸� ��� ����
            if (isIsbnValidated)
            {
                isIsbnValidated = false;
                view.IsSaveButtonEnabled = false;
            }
            if (isRecoveryMode)
            {
                isRecoveryMode = false;
                recoveredBookSeq = 0;
                // (����) view.ClearForm(); // ���� �ٽ� ��� ���� ����
            }
        }
        private void btnDuplicateCheck_Click(object sender, EventArgs e)
        {
            string isbn = view.BookISBN.Trim();

            if (string.IsNullOrEmpty(isbn) || isbn.Length != 13)
            {
                view.ShowMessage("ISBN 13�ڸ��� �ùٸ��� �Է����ּ���.", "�˸�", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // YN ���¿� ������� ISBN���� ���� ��ȸ (Repository�� ReadByIsbnRegardlessOfStatus �ʿ�)
                var existingBook = bookRepository.ReadByIsbnRegardlessOfStatus(isbn);

                if (existingBook == null)
                {
                    // --- (��� 1) ���� �ű� ISBN ---
                    view.ShowMessage("��� ������ ISBN�Դϴ�.", "�ߺ� Ȯ��", MessageBoxIcon.Information);
                    isIsbnValidated = true;
                    isRecoveryMode = false; // �� �ű� ���
                    recoveredBookSeq = 0;
                    view.IsSaveButtonEnabled = true; // "���" ��ư Ȱ��ȭ
                }
                else if (existingBook.Book_YN == 0)
                {
                    // --- (��� 2) �̹� ��ϵ� Ȱ�� ���� (YN = 0) ---
                    view.ShowMessage("�̹� ��ϵ� ISBN�Դϴ�.", "�ߺ� Ȯ��", MessageBoxIcon.Warning);
                    isIsbnValidated = false;
                    isRecoveryMode = false;
                    view.IsSaveButtonEnabled = false;
                }
                else // (existingBook.Book_YN == 1)
                {
                    // --- (��� 3) ������ ���� (YN = 1) -> "���(ó��)" ��� ���� �ڡڡ�

                    // �� (����) "����" �޽��� ��� "��� ����" �޽���
                    view.ShowMessage("��� ������ ISBN�Դϴ�. (������ ���� �����)", "�ߺ� Ȯ��", MessageBoxIcon.Information);

                    isIsbnValidated = true;        // ��ȿ�� ���
                    isRecoveryMode = true;         // �� "����(������Ʈ)" ������� ���
                    recoveredBookSeq = existingBook.Book_Seq; // �� ������Ʈ�� ���(Seq)�� ���
                    view.IsSaveButtonEnabled = true; // "���" ��ư Ȱ��ȭ

                    // (���û���) ������ ������ ���� ������ ���� �ҷ��ͼ� ������ �� �ְ� ��
                    view.SetBookData(existingBook);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"�ߺ� Ȯ�� �� ������ �߻��߽��ϴ�: {ex.Message}", "����", MessageBoxIcon.Error);
                isIsbnValidated = false;
                isRecoveryMode = false;
                view.IsSaveButtonEnabled = false;
            }
        }
        private void exit_button_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "������ ����� �ߴ��Ͻðڽ��ϱ�?",
                "��� �ߴ� Ȯ��",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                view.CloseView(); // View �ݱ� ��û
            }
            // �ƴϿ�: �ƹ� ���� ���� (�׳� ����)
        }
        private void cancel_button_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "������ ����� �ߴ��Ͻðڽ��ϱ�?",
                "��� �ߴ� Ȯ��",
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
                Title = "���� �̹��� ���ε�"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // ���� �� byte[] ��ȯ
                byte[] imageBytes = File.ReadAllBytes(dialog.FileName);

                // View�� �ִ� PictureBox�� �̹��� ǥ��
                var picBox = view.BookPictureBox;
                picBox.Image = Image.FromFile(dialog.FileName);
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // View�� ���ε� ���� ���� (Book_Res�� ������Ƽ �߰�)
                if (view is Book_Res form)
                {
                    form.SetUploadedImage(imageBytes);
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try // �� ��ü ������ try-catch�� ����
            {
                // 1. ISBN �ߺ� Ȯ�� ���� (Presenter ���� ����)
                if (!isIsbnValidated)
                {
                    // �� (����) MessageBox -> view.ShowMessage
                    view.ShowMessage("ISBN �ߺ� Ȯ���� ���� �����ؾ� �մϴ�.", "�˸�", MessageBoxIcon.Warning);
                    return;
                }

                // 2. View�� ������ ��ü �Է� ��ȿ�� �˻� ȣ��
                // (�� ����� View�� �ʹ� ���� ������ ���� �ǹǷ�,
                //  Presenter���� ���� ���� ������ �˻��ϴ� ���� �� �����ϴ�.)
                // if (!view.ValidateAllInputs()) return; // <-- User_Res.cs�� ������ ���

                // --- (����) Presenter���� ���� ��ȿ�� �˻� ---
                BookModel model = new BookModel
                {
                    Book_Seq = isEditMode ? editingBook.Book_Seq : 0,
                    Book_ISBN = view.BookISBN.Trim(),
                    Book_Title = view.BookTitle.Trim(),
                    Book_Author = view.BookAuthor.Trim(),
                    Book_Pbl = view.BookPublisher.Trim(),
                    Book_Price = view.BookPrice,
                    Book_Link = view.BookLink.Trim(),
                    Book_Img = (view as Book_Res)?.UploadImageBytes, // ����ȯ ��� �������̽� �Ӽ� ��� ����
                    Book_Exp = view.BookExplain.Trim(),
                    Book_YN = 0 // �� ��·�� Ȱ�� ����(0)�� ����
                };

                // �� (����) ��ȿ�� �˻� (MessageBox -> view.ShowMessage)
                if (string.IsNullOrWhiteSpace(model.Book_ISBN) || model.Book_ISBN.Length != 13)
                {
                    view.ShowMessage("ISBN 13�ڸ��� �ùٸ��� �Է����ּ���.", "��ȿ�� �˻�", MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(model.Book_Title))
                {
                    view.ShowMessage("���� ������ �Է����ּ���.", "��ȿ�� �˻�", MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(model.Book_Author))
                {
                    view.ShowMessage("���ڸ� �Է����ּ���.", "��ȿ�� �˻�", MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(model.Book_Pbl))
                {
                    view.ShowMessage("���ǻ縦 �Է����ּ���.", "��ȿ�� �˻�", MessageBoxIcon.Warning);
                    return;
                }
                if (model.Book_Price <= 0)
                {
                    view.ShowMessage("��ȿ�� ������ �Է����ּ���.", "��ȿ�� �˻�", MessageBoxIcon.Warning);
                    return;
                }
                // --- ��ȿ�� �˻� �� ---

                // 3. DB �۾� ����
                bool result = false;
                string successMessage = "";

                if (isEditMode) // --- (��� 1) "����" ��� ---
                {
                    model.Book_Seq = editingBook.Book_Seq; // ���� Seq ���
                    result = bookRepository.Update(model);
                    successMessage = "���� ���� ���� �Ϸ�";
                }
                else if (isRecoveryMode) // --- �� (��� 2) "����" ��� �� ---
                {
                    model.Book_Seq = recoveredBookSeq; // "�ߺ� Ȯ��" �� �����ص� Seq ���
                    result = bookRepository.Update(model); // �� INSERT�� �ƴ� UPDATE ȣ��!
                    successMessage = "���� ������ (����) ��ϵǾ����ϴ�.";
                }
                else // --- (��� 3) "�ű� ���" ��� ---
                {
                    result = bookRepository.Create(model);
                    successMessage = "���� ��� �Ϸ�";
                }

                // 4. ��� ó��
                if (result)
                {
                    view.ShowMessage(successMessage, "����", MessageBoxIcon.Information);
                    ((Form)view).DialogResult = DialogResult.OK;
                    view.CloseView();
                }
                else
                {
                    view.ShowMessage(isEditMode ? "���� ���� ���� ����" : "���� ���/���� ����", "����", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) // �� Repository���� �߻��� ���� ó��
            {
                view.ShowMessage($"���� �� ������ �߻��߽��ϴ�: {ex.Message}", "����", MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}