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

            // 이벤트 연결 (UserResPresenter와 동일한 패턴)
            this.view.ExitBookRes += exit_button_Click; // 우측 위 종료 버튼
            this.view.btnSave_Click += btnSave_Click; // 등록버튼
            this.view.btnCancel_Click += cancel_button_Click; // 취소 버튼
            this.view.btnDuplicateCheck_Click += btnDuplicateCheck_Click; // 중복확인 버튼
            this.view.pictureBoxUpload_Click += pictureBoxUpload_Click; // 사진 업로드

            if (book != null)
            {
                isEditMode = true;
                editingBook = book;
                view.SetBookData(book);
                (view as Form).Text = "도서정보 수정";
                var btnSave = (view as Form).Controls["btnSave"] as Button;
                if (btnSave != null) btnSave.Text = "수정";
            }
            else
            {
                isEditMode = false;
                (view as Form).Text = "도서 신규등록";
                var btnSave = (view as Form).Controls["btnSave"] as Button;
                if (btnSave != null) btnSave.Text = "등록";
            }
        }

        #region Method
        private void exit_button_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "정말로 등록을 중단하시겠습니까?",
                "등록 중단 확인",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                view.CloseView(); // View 닫기 요청
            }
            // 아니요: 아무 동작 없음 (그냥 복귀)
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "정말로 등록을 중단하시겠습니까?",
                "등록 중단 확인",
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
                MessageBox.Show("ISBN을 입력해주세요.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existingBook = bookRepository.Read(isbn);
                if (existingBook != null)
                {
                    MessageBox.Show("이미 등록된 ISBN입니다.", "중복 확인", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("사용 가능한 ISBN입니다.", "중복 확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"중복 확인 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBoxUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png",
                Title = "도서 이미지 업로드",
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
                Book_Seq = isEditMode ? editingBook.Book_Seq : 0,  // 이 부분 추가
                Book_ISBN = view.BookISBN.Trim(),
                Book_Title = view.BookTitle.Trim(),
                Book_Author = view.BookAuthor.Trim(),
                Book_Pbl = view.BookPublisher.Trim(),
                Book_Price = view.BookPrice,
                Book_Link = view.BookLink.Trim(),
                Book_Img = view.BookImage ?? "",
                Book_Exp = view.BookExplain.Trim()
            };

            // 유효성 검사
            if (string.IsNullOrWhiteSpace(model.Book_ISBN))
            {
                MessageBox.Show("ISBN을 입력해주세요.", "유효성 검사", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(model.Book_Title))
            {
                MessageBox.Show("도서 제목을 입력해주세요.", "유효성 검사", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(model.Book_Author))
            {
                MessageBox.Show("저자를 입력해주세요.", "유효성 검사", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(model.Book_Pbl))
            {
                MessageBox.Show("출판사를 입력해주세요.", "유효성 검사", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (model.Book_Price <= 0)
            {
                MessageBox.Show("유효한 가격을 입력해주세요.", "유효성 검사", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = isEditMode
                ? bookRepository.Update(model)
                : bookRepository.Create(model);

            if (result)
            {
                MessageBox.Show(isEditMode ? "도서 정보 수정 완료" : "도서 등록 완료");

                // DialogResult 설정 후 폼 닫기 (중요)
                ((Form)view).DialogResult = DialogResult.OK;
                view.CloseView();
            }
            else
            {
                MessageBox.Show(isEditMode ? "도서 정보 수정 실패" : "도서 등록 실패");
            }
        }
        #endregion
    }
}