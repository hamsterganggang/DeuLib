using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;

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
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            List<BookModel> books = _repository.ReadAll();
            _view.SetBookList(books);
        }
    }
}