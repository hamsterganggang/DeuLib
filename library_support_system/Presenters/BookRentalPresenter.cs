using System;
using library_support_system.Views;
using library_support_system.Repositories;

namespace library_support_system.Presenters
{
    public class BookRentalPresenter
    {
        private readonly IBook_Rental _view;
        private readonly RentalRepository _repository;

        public BookRentalPresenter(IBook_Rental view)
        {
            _view = view;
            _repository = new RentalRepository();

            _view.ViewLoaded += OnViewLoaded;
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            try
            {
                var rentals = _repository.ReadBooksWithRentalStatus();
                _view.RentalList = rentals;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("대여 목록 조회 중 오류가 발생했습니다: " + ex.Message);
            }
        }
    }
}
