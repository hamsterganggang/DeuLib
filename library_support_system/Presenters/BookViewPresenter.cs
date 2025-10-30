using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace library_support_system.Presenters
{
    public class BookViewPresenter
    {
        private readonly IBook_View _view;
        private readonly BookRepository _repository;

        public BookViewPresenter(IBook_View view)
        {
            _view = view;
            _repository = new BookRepository();

            _view.ViewLoaded += (s, e) => OnViewLoaded();
            _view.ChangeBookEvent += OnChangeBook;
            _view.DeleteBookEvent += OnDeleteBook;
            _view.SearchButtonClick += OnSearchBook;  // 검색 버튼 이벤트 핸들러 추가

            // 초기 데이터가 없는 경우에만 전체 도서 목록 로드
            if (!_view.HasInitialData)
            {
                RefreshBookList();
            }
        }

        private void OnViewLoaded()
        {
            // ViewLoaded 이벤트 처리 시에도 초기 데이터가 없는 경우에만 로드
            if (!_view.HasInitialData)
            {
                RefreshBookList();
            }
        }
        private void RefreshBookList()
        {
            var books = _repository.ReadAll();
            _view.SetBookList(books);
        }
        private void OnChangeBook(object sender, EventArgs e)
        {
            var selected = _view.SelectedBook;
            if (selected != null)
            {
                var bookResForm = new Book_Res(selected);
                var bookResPresenter = new BookResPresenter(bookResForm, selected);

                if (bookResForm.ShowDialog() == DialogResult.OK)
                    RefreshBookList();
            }
            else
            {
                _view.ShowMessage("수정할 도서를 선택하세요.");
            }
        }
        private void OnDeleteBook(object sender, EventArgs e)
        {
            // 1. View에서 선택된 항목 가져오기
            var selected = _view.SelectedBook;
            if (selected == null)
            {
                _view.ShowMessage("삭제할 도서를 선택하세요.");
                return;
            }

            // (선택사항) 사용자에게 확인 메시지 (MVP 패턴에 맞게 View로 분리 권장)
            DialogResult confirm = MessageBox.Show($"'{selected.Book_Title}' 도서를 정말 삭제하시겠습니까?",
                                                 "삭제 확인",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Warning);
            if (confirm == DialogResult.No)
            {
                return;
            }

            try
            {
                // 2. 삭제 시도
                // (Repository의 Delete 메서드는 '대여중이 아니면' 삭제하고 true 반환)
                bool success = _repository.Delete(selected.Book_Seq);

                if (success)
                {
                    // 3. 삭제 성공
                    _view.ShowMessage("도서 삭제가 완료되었습니다.");
                    RefreshBookList(); // 목록 새로고침
                }
                else
                {
                    // 4. ★★★ 삭제 실패 (0 rows affected) ★★★
                    //    이유를 확인하기 위해 "대여중"인지 검사
                    //    (Repository에 IsBookRented(int bookSeq) 메서드가 있어야 함)
                    bool isRented = _repository.IsBookRented(selected.Book_Seq);

                    if (isRented)
                    {
                        // 4-1. 이유: 대여중
                        _view.ShowMessage("대여중인 도서는 삭제할 수 없습니다.");
                    }
                    else
                    {
                        // 4-2. 이유: 이미 삭제되었거나 존재하지 않는 도서
                        _view.ShowMessage("도서 삭제에 실패했습니다. (이미 삭제되었거나 존재하지 않는 도서일 수 있습니다.)");
                    }
                }
            }
            catch (Exception ex)
            {
                // 5. DB 예외 발생 (예: FK 제약조건 위배 등)
                _view.ShowMessage($"삭제 중 오류가 발생했습니다: {ex.Message}");
            }
        }
        private void OnSearchBook(object sender, EventArgs e)
        {
            try
            {
                string searchText = _view.SearchText?.Trim() ?? string.Empty;
                string searchOption = _view.SearchOption ?? "책이름";
                List<BookModel> searchResults;

                // 빈 검색어인 경우 전체 목록을 반환
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    searchResults = _repository.ReadAll();
                    _view.SetBookList(searchResults);
                }
                else
                {
                    // 검색 옵션에 따라 다른 검색 메서드 호출
                    if (searchOption == "ISBN")
                    {
                        searchResults = _repository.SearchByISBN(searchText);
                    }
                    else // 책이름
                    {
                        searchResults = _repository.SearchByTitle(searchText);
                    }
                    
                    if (searchResults.Count == 0)
                    {
                        // 검색 결과가 없으면 현재 화면을 그대로 유지하고 메시지만 표시
                        string optionText = searchOption == "ISBN" ? "ISBN" : "책 제목";
                    }
                    else
                    {
                        // 검색 결과가 있으면 해당 결과만 표시
                        _view.SetBookList(searchResults);
                        string optionText = searchOption == "ISBN" ? "ISBN" : "책 제목";
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"검색 중 오류가 발생했습니다: {ex.Message}");
            }
        }
    }
}