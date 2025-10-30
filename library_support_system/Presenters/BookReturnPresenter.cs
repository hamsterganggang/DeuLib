// library_support_system.Presenters/BookReturnPresenter.cs
using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Linq; // ★★★ LINQ 네임스페이스 추가 ★★★
using System.Windows.Forms;

namespace library_support_system.Presenters
{
    public class BookReturnPresenter
    {
        private readonly IBook_Return _view;
        private readonly RentalRepository _repository;

        // ★★★ 1. DB 원본 데이터를 저장할 "캐시" 변수 추가 ★★★
        private List<RentalModel> _cachedRentalList;

        public BookReturnPresenter(IBook_Return view)
        {
            _view = view;
            _repository = new RentalRepository();
            _cachedRentalList = new List<RentalModel>(); // 캐시 초기화

            // --- 이벤트 구독 ---
            _view.ViewLoaded += OnViewLoaded;
            _view.ReturnClicked += OnReturnClicked;
            _view.ReturnListFilterChanged += OnReturnListFilterChanged;
            _view.SearchClicked += OnSearchClicked; // ★★★ 2. "검색" 이벤트 구독 ★★★
        }

        /// <summary>
        /// 폼 로드 시: DB 데이터 로드
        /// </summary>
        private void OnViewLoaded(object sender, EventArgs e)
        {
            LoadRentals(); // 실제 로직은 LoadRentals 메서드에 위임
        }

        /// <summary>
        /// 체크박스 변경 시: DB 데이터 다시 로드
        /// </summary>
        private void OnReturnListFilterChanged(object sender, EventArgs e)
        {
            LoadRentals(); // DB 새로고침
        }

        /// <summary>
        /// "검색" 버튼 클릭 시: 캐시 필터링
        /// </summary>
        private void OnSearchClicked(object sender, EventArgs e)
        {
            ApplyFilter(); // DB 접속 없이 필터링만
        }

        /// <summary>
        /// (수정) DB에서 데이터를 조회하여 캐시에 저장하고, 필터링 적용
        /// </summary>
        private void LoadRentals()
        {
            try
            {
                // 1. Repository에서 모든 대여/반납 기록 가져오기
                _cachedRentalList = _repository.RetrieveRentalList();

                // 2. 필터링 로직 실행하여 화면에 표시
                ApplyFilter();
            }
            catch (Exception ex)
            {
                _view.ShowMessage("데이터 조회 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        /// <summary>
        /// (신규) 캐시된 목록을 View의 조건으로 필터링하여 그리드에 바인딩
        /// </summary>
        private void ApplyFilter()
        {
            try
            {
                // 1. View에서 체크박스 상태 확인
                bool showReturned = _view.IsReturnedListChecked;
                List<RentalModel> listByStatus;

                // 2. 체크박스 상태에 따라 1차 필터링
                if (showReturned)
                {
                    // "반납된 목록 보기" 체크: Status == 0
                    listByStatus = _cachedRentalList
                        .Where(book => book.Rental_Status == 0)
                        .ToList();
                }
                else
                {
                    // 체크 해제 (기본값): Status == 1 (대여중)
                    listByStatus = _cachedRentalList
                        .Where(book => book.Rental_Status == 1)
                        .ToList();
                }

                // 3. View에서 검색 조건과 검색어 가져오기
                string searchType = _view.SearchType;
                string searchKeyword = _view.SearchKeyword.ToLower();

                List<RentalModel> finalList;

                // 4. 검색어로 2차 필터링
                if (string.IsNullOrWhiteSpace(searchKeyword))
                {
                    finalList = listByStatus; // 검색어 없으면 1차 필터링 결과 그대로 사용
                }
                else
                {
                    if (searchType == "저자")
                    {
                        finalList = listByStatus
                            .Where(b => b.Book_Author != null &&
                                        b.Book_Author.ToLower().Contains(searchKeyword))
                            .ToList();
                    }
                    else // "도서 제목" (기본값)
                    {
                        finalList = listByStatus
                            .Where(b => b.Book_Title != null &&
                                        b.Book_Title.ToLower().Contains(searchKeyword))
                            .ToList();
                    }
                }

                // 5. 최종 결과를 View의 그리드에 바인딩
                _view.RentalList = finalList;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("데이터 필터링 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        /// <summary>
        /// "반납" 버튼 클릭 시 실행되는 로직
        /// </summary>
        private void OnReturnClicked(object sender, EventArgs e)
        {
            RentalModel selected = _view.SelectedRental;
            if (selected == null)
            {
                _view.ShowMessage("반납할 도서를 선택하세요.");
                return;
            }

            // "반납된 목록" 뷰에서는 반납 버튼이 작동하지 않도록 방어
            if (_view.IsReturnedListChecked)
            {
                _view.ShowMessage("이미 반납된 도서입니다.");
                return;
            }

            DialogResult confirm = MessageBox.Show($"'{selected.Book_Title}' 도서를 반납하시겠습니까?");
            if (confirm == DialogResult.No) return;

            try
            {
                bool success = _repository.UpdateRentalStatusToReturned(selected.Book_ISBN);
                if (success)
                {
                    _view.ShowMessage("반납 처리가 완료되었습니다.");
                    LoadRentals(); // ★★★ 성공 시 목록 새로고침 ★★★
                }
                else
                {
                    _view.ShowMessage("반납 처리에 실패했습니다.");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("반납 처리 중 오류가 발생했습니다: " + ex.Message);
            }
        }
    }
}