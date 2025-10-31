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

            if (book != null) // "수정" 모드
            {
                isEditMode = true;
                editingBook = book;
                view.SetBookData(book);

                var btnSave = (view as Form).Controls.Find("btnSave", true).FirstOrDefault() as Button;
                if (btnSave != null) btnSave.Text = "수정";

                isIsbnValidated = true;
                view.IsSaveButtonEnabled = true;
                view.IsIsbnTextBoxReadOnly = true;
                view.IsDuplicateCheckButtonEnabled = false;
            }
            else // "신규 등록" 모드
            {
                isEditMode = false;

                var btnSave = (view as Form).Controls.Find("btnSave", true).FirstOrDefault() as Button;
                if (btnSave != null) btnSave.Text = "등록";

                isIsbnValidated = false;
                view.IsSaveButtonEnabled = false;
                view.IsIsbnTextBoxReadOnly = false;
                view.IsDuplicateCheckButtonEnabled = true;

                // ★★★ (추가) 신규 모드일 땐 복구 모드가 아님
                isRecoveryMode = false;
                recoveredBookSeq = 0;
            }
        }

        #region Method
        private void OnIsbnTextChanged(object sender, EventArgs e)
        {
            if (isEditMode) return; // 수정 모드에선 무시

            // ISBN이 변경되면, "확인" 상태 및 "복구" 상태를 모두 리셋
            if (isIsbnValidated)
            {
                isIsbnValidated = false;
                view.IsSaveButtonEnabled = false;
            }
            if (isRecoveryMode)
            {
                isRecoveryMode = false;
                recoveredBookSeq = 0;
                // (선택) view.ClearForm(); // 폼을 다시 비울 수도 있음
            }
        }
        private void btnDuplicateCheck_Click(object sender, EventArgs e)
        {
            string isbn = view.BookISBN.Trim();

            if (string.IsNullOrEmpty(isbn) || isbn.Length != 13)
            {
                view.ShowMessage("ISBN 13자리를 올바르게 입력해주세요.", "알림", MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // YN 상태와 관계없이 ISBN으로 도서 조회 (Repository에 ReadByIsbnRegardlessOfStatus 필요)
                var existingBook = bookRepository.ReadByIsbnRegardlessOfStatus(isbn);

                if (existingBook == null)
                {
                    // --- (경우 1) 완전 신규 ISBN ---
                    view.ShowMessage("사용 가능한 ISBN입니다.", "중복 확인", MessageBoxIcon.Information);
                    isIsbnValidated = true;
                    isRecoveryMode = false; // ★ 신규 모드
                    recoveredBookSeq = 0;
                    view.IsSaveButtonEnabled = true; // "등록" 버튼 활성화
                }
                else if (existingBook.Book_YN == 0)
                {
                    // --- (경우 2) 이미 등록된 활성 도서 (YN = 0) ---
                    view.ShowMessage("이미 등록된 ISBN입니다.", "중복 확인", MessageBoxIcon.Warning);
                    isIsbnValidated = false;
                    isRecoveryMode = false;
                    view.IsSaveButtonEnabled = false;
                }
                else // (existingBook.Book_YN == 1)
                {
                    // --- (경우 3) 삭제된 도서 (YN = 1) -> "등록(처럼)" 모드 돌입 ★★★

                    // ★ (수정) "복구" 메시지 대신 "사용 가능" 메시지
                    view.ShowMessage("사용 가능한 ISBN입니다. (삭제된 정보 덮어쓰기)", "중복 확인", MessageBoxIcon.Information);

                    isIsbnValidated = true;        // 유효성 통과
                    isRecoveryMode = true;         // ★ "복구(업데이트)" 모드임을 기억
                    recoveredBookSeq = existingBook.Book_Seq; // ★ 업데이트할 대상(Seq)을 기억
                    view.IsSaveButtonEnabled = true; // "등록" 버튼 활성화

                    // (선택사항) 삭제된 도서의 기존 정보를 폼에 불러와서 수정할 수 있게 함
                    view.SetBookData(existingBook);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"중복 확인 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxIcon.Error);
                isIsbnValidated = false;
                isRecoveryMode = false;
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
            try // ★ 전체 로직을 try-catch로 감쌈
            {
                // 1. ISBN 중복 확인 여부 (Presenter 상태 변수)
                if (!isIsbnValidated)
                {
                    // ★ (수정) MessageBox -> view.ShowMessage
                    view.ShowMessage("ISBN 중복 확인을 먼저 수행해야 합니다.", "알림", MessageBoxIcon.Warning);
                    return;
                }

                // 2. View에 구현된 전체 입력 유효성 검사 호출
                // (이 방식은 View가 너무 많은 로직을 갖게 되므로,
                //  Presenter에서 직접 값을 가져와 검사하는 것이 더 좋습니다.)
                // if (!view.ValidateAllInputs()) return; // <-- User_Res.cs에 구현된 방식

                // --- (권장) Presenter에서 직접 유효성 검사 ---
                BookModel model = new BookModel
                {
                    Book_Seq = isEditMode ? editingBook.Book_Seq : 0,
                    Book_ISBN = view.BookISBN.Trim(),
                    Book_Title = view.BookTitle.Trim(),
                    Book_Author = view.BookAuthor.Trim(),
                    Book_Pbl = view.BookPublisher.Trim(),
                    Book_Price = view.BookPrice,
                    Book_Link = view.BookLink.Trim(),
                    Book_Img = (view as Book_Res)?.UploadImageBytes, // 형변환 대신 인터페이스 속성 사용 권장
                    Book_Exp = view.BookExplain.Trim(),
                    Book_YN = 0 // ★ 어쨌든 활성 상태(0)로 저장
                };

                // ★ (수정) 유효성 검사 (MessageBox -> view.ShowMessage)
                if (string.IsNullOrWhiteSpace(model.Book_ISBN) || model.Book_ISBN.Length != 13)
                {
                    view.ShowMessage("ISBN 13자리를 올바르게 입력해주세요.", "유효성 검사", MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(model.Book_Title))
                {
                    view.ShowMessage("도서 제목을 입력해주세요.", "유효성 검사", MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(model.Book_Author))
                {
                    view.ShowMessage("저자를 입력해주세요.", "유효성 검사", MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(model.Book_Pbl))
                {
                    view.ShowMessage("출판사를 입력해주세요.", "유효성 검사", MessageBoxIcon.Warning);
                    return;
                }
                if (model.Book_Price <= 0)
                {
                    view.ShowMessage("유효한 가격을 입력해주세요.", "유효성 검사", MessageBoxIcon.Warning);
                    return;
                }
                // --- 유효성 검사 끝 ---

                // 3. DB 작업 수행
                bool result = false;
                string successMessage = "";

                if (isEditMode) // --- (경우 1) "수정" 모드 ---
                {
                    model.Book_Seq = editingBook.Book_Seq; // 원본 Seq 사용
                    result = bookRepository.Update(model);
                    successMessage = "도서 정보 수정 완료";
                }
                else if (isRecoveryMode) // --- ★ (경우 2) "복구" 모드 ★ ---
                {
                    model.Book_Seq = recoveredBookSeq; // "중복 확인" 때 저장해둔 Seq 사용
                    result = bookRepository.Update(model); // ★ INSERT가 아닌 UPDATE 호출!
                    successMessage = "도서 정보가 (복구) 등록되었습니다.";
                }
                else // --- (경우 3) "신규 등록" 모드 ---
                {
                    result = bookRepository.Create(model);
                    successMessage = "도서 등록 완료";
                }

                // 4. 결과 처리
                if (result)
                {
                    view.ShowMessage(successMessage, "성공", MessageBoxIcon.Information);
                    ((Form)view).DialogResult = DialogResult.OK;
                    view.CloseView();
                }
                else
                {
                    view.ShowMessage(isEditMode ? "도서 정보 수정 실패" : "도서 등록/복구 실패", "실패", MessageBoxIcon.Error);
                }
            }
            catch (Exception ex) // ★ Repository에서 발생한 예외 처리
            {
                view.ShowMessage($"저장 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}