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

            _view.ViewLoaded += (s, e) => RefreshBookList();
            _view.ChangeBookEvent += OnChangeBook;
            _view.DeleteBookEvent += OnDeleteBook;
            _view.SearchButtonClick += OnSearchBook;  // 검색 버튼 이벤트 핸들러 추가

            // Presenter 생성 시 바로 전체 도서 목록 로드
            RefreshBookList();
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
            var selected = _view.SelectedBook;
            if (selected != null)
            {
                if (_repository.Delete(selected.Book_Seq))
                {
                    _view.ShowMessage("도서 삭제가 완료되었습니다.");
                    RefreshBookList();
                }
                else
                {
                    _view.ShowMessage("도서 삭제에 실패했습니다.");
                }
            }
            else
            {
                _view.ShowMessage("삭제할 도서를 선택하세요.");
            }
        }

        // 검색 기능 구현 - 검색 결과가 없을 때 전체 목록 표시
        private void OnSearchBook(object sender, EventArgs e)
        {
            try
            {
                string searchText = _view.SearchText;
                List<BookModel> searchResults;

                // 빈 검색어인 경우 전체 목록을 반환
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    searchResults = _repository.ReadAll();
                    _view.SetBookList(searchResults);
                    _view.ShowMessage($"전체 도서 목록을 표시합니다. (총 {searchResults.Count}권)");
                }
                else
                {
                    // 제목으로 검색
                    searchResults = _repository.SearchByTitle(searchText);
                    
                    if (searchResults.Count == 0)
                    {
                        // 검색 결과가 없으면 전체 목록을 표시
                        searchResults = _repository.ReadAll();
                        _view.SetBookList(searchResults);
                        _view.ShowMessage($"'{searchText}'에 해당하는 도서를 찾을 수 없어 전체 도서 목록을 표시합니다. (총 {searchResults.Count}권)");
                    }
                    else
                    {
                        // 검색 결과가 있으면 해당 결과만 표시
                        _view.SetBookList(searchResults);
                        _view.ShowMessage($"'{searchText}' 검색 결과: {searchResults.Count}권의 도서를 찾았습니다.");
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