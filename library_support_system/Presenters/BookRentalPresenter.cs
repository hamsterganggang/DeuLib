using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;

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

            // *** 1. View의 이벤트를 구독(Subscribe)해야 합니다. ***
            _view.RentalCheckClicked += OnRentalCheckClicked;
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            try
            {
                var rentals = _repository.Retrieve();
                // *** 2. 캐싱이 필요 없으므로 SetRentalList 대신 바로 할당 ***
                _view.RentalList = rentals;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("대여 목록 조회 중 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void OnRentalCheckClicked(object sender, RentalModelEventArgs e)
        {
            // View로부터 보고를 받고, View에게 팝업을 띄우라고 "명령"합니다.
            _view.ShowRentalPopup(e.Rental);
        }
    }
}
