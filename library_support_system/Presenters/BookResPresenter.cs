using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Drawing;
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

            if (book != null)
            {
                isEditMode = true;
                editingBook = book;
                view.SetBookData(book);
                (view as Form).Text = "�������� ����";
                var btnSave = (view as Form).Controls["btnSave"] as Button;
                if (btnSave != null) btnSave.Text = "����";
            }
            else
            {
                isEditMode = false;
                (view as Form).Text = "���� �űԵ��";
                var btnSave = (view as Form).Controls["btnSave"] as Button;
                if (btnSave != null) btnSave.Text = "���";
            }
        }

        #region Method
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

        private void btnDuplicateCheck_Click(object sender, EventArgs e)
        {
            string isbn = view.BookISBN.Trim();
            
            if (string.IsNullOrEmpty(isbn))
            {
                MessageBox.Show("ISBN�� �Է����ּ���.", "�˸�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existingBook = bookRepository.Read(isbn);
                if (existingBook != null)
                {
                    MessageBox.Show("�̹� ��ϵ� ISBN�Դϴ�.", "�ߺ� Ȯ��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("��� ������ ISBN�Դϴ�.", "�ߺ� Ȯ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"�ߺ� Ȯ�� �� ������ �߻��߽��ϴ�: {ex.Message}", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png",
                Title = "���� �̹��� ���ε�",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                view.BookPictureBox.Image = Image.FromFile(dialog.FileName);
                view.BookPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BookModel model = new BookModel
            {
                Book_Seq = isEditMode ? editingBook.Book_Seq : 0,  // �� �κ� �߰�
                Book_ISBN = view.BookISBN.Trim(),
                Book_Title = view.BookTitle.Trim(),
                Book_Author = view.BookAuthor.Trim(),
                Book_Pbl = view.BookPublisher.Trim(),
                Book_Price = view.BookPrice,
                Book_Link = view.BookLink.Trim(),
                Book_Img = view.BookImage ?? "",
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