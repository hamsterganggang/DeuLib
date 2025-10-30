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

            // 이벤트 연결 (UserResPresenter와 동일한 패턴)
            this.view.ExitBookRes += exit_button_Click; // 우측 위 종료 버튼
            this.view.btnSave_Click += btnSave_Click; // 등록버튼
            this.view.btnCancel_Click += cancel_button_Click; // 취소 버튼
            this.view.btnDuplicateCheck_Click += btnDuplicateCheck_Click; // 중복확인 버튼
            this.view.pictureBoxUpload_Click += pictureBoxUpload_Click; // 사진 업로드
            this.view.IsbnTextChanged += OnIsbnTextChanged; // ★★★ 2. 텍스트 변경 이벤트 구독 ★★★

            if (book != null) // --- ★★★ 3. "수정" 모드일 때 ★★★ ---
            {
                isEditMode = true;
                editingBook = book;
                view.SetBookData(book);
                (view as Form).Text = "도서정보 수정";

                // (Designer.cs에 btnSave가 있다고 가정)
                var btnSave = (view as Form).Controls.Find("btnSave", true).FirstOrDefault() as Button;
                if (btnSave != null) btnSave.Text = "수정";

                // --- (수정 모드 로직 추가) ---
                isIsbnValidated = true;             // (수정 모드) 이미 검증된 ISBN으로 간주
                view.IsSaveButtonEnabled = true;    // (수정 모드) "수정" 버튼 활성화
                view.IsIsbnTextBoxReadOnly = true;  // (수정 모드) ISBN(PK) 변경 불가
                view.IsDuplicateCheckButtonEnabled = false;
            }
            else // --- ★★★ 4. "신규 등록" 모드일 때 ★★★ ---
            {
                isEditMode = false;
                (view as Form).Text = "도서 신규등록";

                var btnSave = (view as Form).Controls.Find("btnSave", true).FirstOrDefault() as Button;
                if (btnSave != null) btnSave.Text = "등록";

                // --- (신규 등록 로직 추가) ---
                isIsbnValidated = false;             // (신규 모드) 아직 미검증
                view.IsSaveButtonEnabled = false;   // (신규 모드) "등록" 버튼 비활성화
                view.IsIsbnTextBoxReadOnly = false; // (신규 모드) ISBN 입력 가능
                view.IsDuplicateCheckButtonEnabled = true;
            }
        }

        #region Method
        private void OnIsbnTextChanged(object sender, EventArgs e)
        {
            // "수정" 모드일 때는 이 로직을 무시 (ISBN이 ReadOnly이므로)
            if (isEditMode) return;

            // "신규" 모드에서 사용자가 ISBN을 수정하면,
            // "중복 확인" 상태를 리셋하고 "등록" 버튼을 다시 비활성화
            if (isIsbnValidated)
            {
                isIsbnValidated = false;
                view.IsSaveButtonEnabled = false;
            }
        }
        private void btnDuplicateCheck_Click(object sender, EventArgs e)
        {
            string isbn = view.BookISBN.Trim();

            // --- ★★★ 5. 유효성 검사 1: 빈 값 확인 ★★★ ---
            if (string.IsNullOrEmpty(isbn))
            {
                view.ShowMessage("ISBN을 입력해주세요.", "알림", MessageBoxIcon.Warning);
                return;
            }

            // --- ★★★ 6. 유효성 검사 2: 글자 수 (13자리) 확인 ★★★ ---
            if (isbn.Length != 13)
            {
                view.ShowMessage("ISBN은 13자리여야 합니다.", "알림", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var existingBook = bookRepository.Read(isbn);
                if (existingBook != null)
                {
                    view.ShowMessage("이미 등록된 ISBN입니다.", "중복 확인", MessageBoxIcon.Warning);
                    isIsbnValidated = false;
                    view.IsSaveButtonEnabled = false; // "등록" 버튼 비활성화
                }
                else
                {
                    view.ShowMessage("사용 가능한 ISBN입니다.", "중복 확인", MessageBoxIcon.Information);
                    isIsbnValidated = true;            // ★★★ 검증 성공 ★★★
                    view.IsSaveButtonEnabled = true;   // ★★★ "등록" 버튼 활성화 ★★★
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"중복 확인 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxIcon.Error);
                isIsbnValidated = false;
                view.IsSaveButtonEnabled = false;
            }
        }
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

        private void pictureBoxUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Image Files (*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png",
                Title = "도서 이미지 업로드"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // 파일 → byte[] 변환
                byte[] imageBytes = File.ReadAllBytes(dialog.FileName);

                // View에 있는 PictureBox에 이미지 표시
                var picBox = view.BookPictureBox;
                picBox.Image = Image.FromFile(dialog.FileName);
                picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                // View에 업로드 정보 전달 (Book_Res에 프로퍼티 추가)
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
                view.ShowMessage("ISBN 중복 확인을 먼저 수행해야 합니다.", "알림", MessageBoxIcon.Warning);
                return;
            }
            BookModel model = new BookModel
            {

                Book_Seq = isEditMode ? editingBook.Book_Seq : 0,  // 이 부분 추가
                Book_ISBN = view.BookISBN.Trim(),
                Book_Title = view.BookTitle.Trim(),
                Book_Author = view.BookAuthor.Trim(),
                Book_Pbl = view.BookPublisher.Trim(),
                Book_Price = view.BookPrice,
                Book_Link = view.BookLink.Trim(),
                Book_Img = (view as Book_Res)?.UploadImageBytes,
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