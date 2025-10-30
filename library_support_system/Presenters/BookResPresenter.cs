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
        #endregion

        public BookResPresenter(IBook_Res view, BookModel book = null)
        {
            this.view = view;
            this.bookRepository = new BookRepository();

            // �̺�Ʈ ���� (UserResPresenter�� ������ ����)
            this.view.ExitBookRes += exit_button_Click; // ���� �� ���� ��ư
            this.view.btnSave_Click += btnSave_Click; // ��Ϲ�ư
            this.view.btnCancel_Click += cancel_button_Click; // ��� ��ư
            this.view.btnDuplicateCheck_Click += btnDuplicateCheck_Click; // �ߺ�Ȯ�� ��ư
            this.view.pictureBoxUpload_Click += pictureBoxUpload_Click; // ���� ���ε�
            this.view.IsbnTextChanged += OnIsbnTextChanged; // �ڡڡ� 2. �ؽ�Ʈ ���� �̺�Ʈ ���� �ڡڡ�

            if (book != null) // --- �ڡڡ� 3. "����" ����� �� �ڡڡ� ---
            {
                isEditMode = true;
                editingBook = book;
                view.SetBookData(book);
                (view as Form).Text = "�������� ����";

                // (Designer.cs�� btnSave�� �ִٰ� ����)
                var btnSave = (view as Form).Controls.Find("btnSave", true).FirstOrDefault() as Button;
                if (btnSave != null) btnSave.Text = "����";

                // --- (���� ��� ���� �߰�) ---
                isIsbnValidated = true;             // (���� ���) �̹� ������ ISBN���� ����
                view.IsSaveButtonEnabled = true;    // (���� ���) "����" ��ư Ȱ��ȭ
                view.IsIsbnTextBoxReadOnly = true;  // (���� ���) ISBN(PK) ���� �Ұ�
                view.IsDuplicateCheckButtonEnabled = false;
            }
            else // --- �ڡڡ� 4. "�ű� ���" ����� �� �ڡڡ� ---
            {
                isEditMode = false;
                (view as Form).Text = "���� �űԵ��";

                var btnSave = (view as Form).Controls.Find("btnSave", true).FirstOrDefault() as Button;
                if (btnSave != null) btnSave.Text = "���";

                // --- (�ű� ��� ���� �߰�) ---
                isIsbnValidated = false;             // (�ű� ���) ���� �̰���
                view.IsSaveButtonEnabled = false;   // (�ű� ���) "���" ��ư ��Ȱ��ȭ
                view.IsIsbnTextBoxReadOnly = false; // (�ű� ���) ISBN �Է� ����
                view.IsDuplicateCheckButtonEnabled = true;
            }
        }

        #region Method
        private void OnIsbnTextChanged(object sender, EventArgs e)
        {
            // "����" ����� ���� �� ������ ���� (ISBN�� ReadOnly�̹Ƿ�)
            if (isEditMode) return;

            // "�ű�" ��忡�� ����ڰ� ISBN�� �����ϸ�,
            // "�ߺ� Ȯ��" ���¸� �����ϰ� "���" ��ư�� �ٽ� ��Ȱ��ȭ
            if (isIsbnValidated)
            {
                isIsbnValidated = false;
                view.IsSaveButtonEnabled = false;
            }
        }
        private void btnDuplicateCheck_Click(object sender, EventArgs e)
        {
            string isbn = view.BookISBN.Trim();

            // --- �ڡڡ� 5. ��ȿ�� �˻� 1: �� �� Ȯ�� �ڡڡ� ---
            if (string.IsNullOrEmpty(isbn))
            {
                view.ShowMessage("ISBN�� �Է����ּ���.", "�˸�", MessageBoxIcon.Warning);
                return;
            }

            // --- �ڡڡ� 6. ��ȿ�� �˻� 2: ���� �� (13�ڸ�) Ȯ�� �ڡڡ� ---
            if (isbn.Length != 13)
            {
                view.ShowMessage("ISBN�� 13�ڸ����� �մϴ�.", "�˸�", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existingBook = bookRepository.Read(isbn);
                if (existingBook != null)
                {
                    view.ShowMessage("�̹� ��ϵ� ISBN�Դϴ�.", "�ߺ� Ȯ��", MessageBoxIcon.Warning);
                    isIsbnValidated = false;
                    view.IsSaveButtonEnabled = false; // "���" ��ư ��Ȱ��ȭ
                }
                else
                {
                    view.ShowMessage("��� ������ ISBN�Դϴ�.", "�ߺ� Ȯ��", MessageBoxIcon.Information);
                    isIsbnValidated = true;            // �ڡڡ� ���� ���� �ڡڡ�
                    view.IsSaveButtonEnabled = true;   // �ڡڡ� "���" ��ư Ȱ��ȭ �ڡڡ�
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"�ߺ� Ȯ�� �� ������ �߻��߽��ϴ�: {ex.Message}", "����", MessageBoxIcon.Error);
                isIsbnValidated = false;
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
            if (!isIsbnValidated)
            {
                view.ShowMessage("ISBN �ߺ� Ȯ���� ���� �����ؾ� �մϴ�.", "�˸�", MessageBoxIcon.Warning);
                return;
            }
            BookModel model = new BookModel
            {

                Book_Seq = isEditMode ? editingBook.Book_Seq : 0,  // �� �κ� �߰�
                Book_ISBN = view.BookISBN.Trim(),
                Book_Title = view.BookTitle.Trim(),
                Book_Author = view.BookAuthor.Trim(),
                Book_Pbl = view.BookPublisher.Trim(),
                Book_Price = view.BookPrice,
                Book_Link = view.BookLink.Trim(),
                Book_Img = (view as Book_Res)?.UploadImageBytes,
                Book_Exp = view.BookExplain.Trim()
            };

            // ��ȿ�� �˻�
            if (string.IsNullOrWhiteSpace(model.Book_ISBN))
            {
                MessageBox.Show("ISBN�� �Է����ּ���.", "��ȿ�� �˻�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(model.Book_Title))
            {
                MessageBox.Show("���� ������ �Է����ּ���.", "��ȿ�� �˻�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(model.Book_Author))
            {
                MessageBox.Show("���ڸ� �Է����ּ���.", "��ȿ�� �˻�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(model.Book_Pbl))
            {
                MessageBox.Show("���ǻ縦 �Է����ּ���.", "��ȿ�� �˻�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (model.Book_Price <= 0)
            {
                MessageBox.Show("��ȿ�� ������ �Է����ּ���.", "��ȿ�� �˻�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = isEditMode
                ? bookRepository.Update(model)
                : bookRepository.Create(model);

            if (result)
            {
                MessageBox.Show(isEditMode ? "���� ���� ���� �Ϸ�" : "���� ��� �Ϸ�");

                // DialogResult ���� �� �� �ݱ� (�߿�)
                ((Form)view).DialogResult = DialogResult.OK;
                view.CloseView();
            }
            else
            {
                MessageBox.Show(isEditMode ? "���� ���� ���� ����" : "���� ��� ����");
            }
        }
        #endregion
    }
}