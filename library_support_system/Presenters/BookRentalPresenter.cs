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
            _view.RentalCheckClicked += OnRentalCheckClicked;
        }

        private void OnViewLoaded(object sender, EventArgs e)
        {
            try
            {
                var rentals = _repository.ReadBooksWithRentalStatus();
                // _view.RentalList = rentals; // 
                SetRentalList(rentals); //  <- 이 메서드를 사용해야 _cachedList가 초기화됩니다.
            }
            catch (Exception ex)
            {
                _view.ShowMessage("대여 목록 조회 중 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void OnRentalCheckClicked(object sender, RentalModelEventArgs e)
        {
            var currentList = GetCurrentRentalList();
            if (currentList == null) return;

            var newList = new List<RentalModel>(currentList);

            // 1. 다음 행이 있는지, 그리고 그 행이 자식 행(IsChildRow)인지 확인
            bool isDetailRowVisible = (e.RowIndex + 1 < newList.Count) && newList[e.RowIndex + 1].IsChildRow;

            if (isDetailRowVisible)
            {
                // 2. 이미 상세 행이 보인다면 -> 제거
                newList.RemoveAt(e.RowIndex + 1);
            }
            else
            {
                // 3. 상세 행이 보이지 않는다면 -> 추가 (기존 로직)
                var detailRow = new RentalModel
                {
                    Book_Title = "     " + e.Rental.Book_Title + " - 상세", // 들여쓰기
                    User_Name = e.Rental.User_Name,
                    Rental_Date = e.Rental.Rental_Date,
                    Rental_Return_Date = e.Rental.Rental_Return_Date,
                    IsChildRow = true
                };

                newList.Insert(e.RowIndex + 1, detailRow); // 바로 아래에 추가
            }

            // 4. 변경된 리스트로 뷰와 캐시 업데이트
            SetRentalList(newList);
            // _cachedList = newList;
            // _view.RentalList = newList; 
            // -> SetRentalList 메서드를 사용하는 것이 더 일관성 있습니다.
        }

        private List<RentalModel> _cachedList;

        private List<RentalModel> GetCurrentRentalList()
        {
            // 뷰에 데이터를 계속 공급하기 위해 캐싱
            return _cachedList;
        }

        // 뷰에 리스트 할당 시 캐시 저장 추가 (뷰에서 호출 가능하게 인터페이스에 추가 권장)
        public void SetRentalList(List<RentalModel> list)
        {
            _cachedList = list;
            _view.RentalList = list;
        }
    }
}
