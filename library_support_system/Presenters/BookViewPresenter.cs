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

            _view.ViewLoaded += OnViewLoaded;
            _view.ChangeBookEvent += OnChangeBook;
            _view.DeleteBookEvent += OnDeleteBook;
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            List<BookModel> books = _repository.ReadAll();
            _view.SetBookList(books);
            RefreshBookList();
        }

        private void RefreshBookList()
        {
            var books = _repository.ReadAll();
            _view.BookList = books;
        }

        private void OnChangeBook(object sender, EventArgs e)
        {
            var selected = _view.SelectedBook;
            if (selected != null)
            {
                var bookResForm = new Book_Res(selected); // 선택도서 전달
                var bookResPresenter = new BookResPresenter(bookResForm, selected); // [수정모드]

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
                if (_repository.Delete(selected.Book_ISBN))
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
    }
}