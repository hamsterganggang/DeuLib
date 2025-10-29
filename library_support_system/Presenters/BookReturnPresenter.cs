// library_support_system.Presenters/BookReturnPresenter.cs
using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace library_support_system.Presenters
{
    public class BookReturnPresenter
    {
        private readonly IBook_Return _view;
        private readonly RentalRepository _repository;

        public BookReturnPresenter(IBook_Return view)
        {
            _view = view;
            _repository = new RentalRepository();

            // *** 1. "폼 로드" 이벤트만 구독 ***
            _view.ViewLoaded += OnViewLoaded;
            _view.ReturnClicked += OnReturnClicked;
            _view.ReturnListFilterChanged += OnReturnListFilterChanged;
        }

        /// <summary>
        /// 폼이 로드될 때 실행되는 메인 로직
        /// </summary>
        private void OnViewLoaded(object sender, EventArgs e)
        {
            try
            {
                // 1. Repository를 통해 "모든" 도서의 대여 상태를 가져옴
                // (사용자님이 `Retrieve`라고 하신 함수. 여기서는 `ReadBooksWithRentalStatus`로 가정)
                var allBookStatus = _repository.Retrieve();

                // 2. "반납 관리"이므로, "대여중(Status == 1)"인 도서만 필터링
                var rentedBooks = allBookStatus
                    .Where(book => book.Rental_Status == 1)
                    .ToList();

                // 3. 최종 결과를 View의 그리드에 바인딩
                _view.RentalList = rentedBooks;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("데이터 조회 중 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void OnReturnListFilterChanged(object sender, EventArgs e)
        {
            LoadRentals(); // 실제 로직은 LoadRentals 메서드에 위임
        }
        private void LoadRentals()
        {
            try
            {
                // 1. Repository에서 모든 도서 상태 가져오기
                var allBookStatus = _repository.RetrieveRentalList(); // ReadBooksWithRentalStatus()일 수도 있음

                // 2. View에서 체크박스 상태 확인
                bool showReturned = _view.IsReturnedListChecked;

                // 3. 체크박스 상태에 따라 필터링
                List<RentalModel> filteredList;
                if (showReturned)
                {
                    // "반납된 목록 보기"가 체크된 경우: Status == 0
                    filteredList = allBookStatus
                        .Where(book => book.Rental_Status == 0)
                        .ToList();
                }
                else
                {
                    // 체크 해제된 경우 (기본값): Status == 1 (대여중)
                    filteredList = allBookStatus
                        .Where(book => book.Rental_Status == 1)
                        .ToList();
                }

                // 4. 필터링된 결과를 View의 그리드에 바인딩
                _view.RentalList = filteredList;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("데이터 조회 중 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void OnReturnClicked(object sender, EventArgs e)
        {
            // 1. View에서 선택된 항목 가져오기
            RentalModel selected = _view.SelectedRental;

            // 2. 유효성 검사: 선택된 항목이 있는지 확인
            if (selected == null)
            {
                _view.ShowMessage("반납할 도서를 선택하세요.");
                return;
            }

            // 3. (선택사항) 사용자에게 확인 메시지
            DialogResult confirm = MessageBox.Show($"'{selected.Book_Title}' 도서를 반납하시겠습니까?",
                                                 "반납 확인",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (confirm == DialogResult.No)
            {
                return;
            }

            try
            {
                // 4. 리포지토리를 통해 DB 업데이트
                bool success = _repository.UpdateRentalStatusToReturned(selected.Book_ISBN);

                if (success)
                {
                    _view.ShowMessage("반납 처리가 완료되었습니다.");
                    // 5. 성공 시 목록 새로고침 (OnViewLoaded 다시 호출)
                    OnViewLoaded(sender, e);
                }
                else
                {
                    // UpdateRentalStatusToReturned 쿼리 조건(Status=1)에 맞지 않아 0개 행이 업데이트된 경우
                    _view.ShowMessage("반납 처리에 실패했습니다. (이미 반납되었거나 상태가 다를 수 있습니다.)");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("반납 처리 중 오류가 발생했습니다: " + ex.Message);
            }
        }
    }
}