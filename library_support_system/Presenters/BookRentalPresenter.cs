// library_support_system.Presenters/BookRentalPresenter.cs
using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Linq; // ★★★ LINQ 네임스페이스 추가 ★★★

namespace library_support_system.Presenters
{
    public class BookRentalPresenter
    {
        private readonly IBook_Rental _view;
        private readonly RentalRepository _repository;

        // ★★★ 1. DB 원본 데이터를 저장할 "캐시" 변수 추가 ★★★
        private List<RentalModel> _cachedBookList;

        public BookRentalPresenter(IBook_Rental view)
        {
            _view = view;
            _repository = new RentalRepository();
            _cachedBookList = new List<RentalModel>(); // 캐시 초기화

            // --- 이벤트 구독 ---
            _view.ViewLoaded += OnViewLoaded;
            _view.RentalCheckClicked += OnRentalCheckClicked;
            _view.SearchClicked += OnSearchClicked; // ★★★ 2. "검색" 이벤트 구독 ★★★
        }

        /// <summary>
        /// 폼 로드 시: DB에서 데이터를 가져와 캐시에 저장
        /// </summary>
        private void OnViewLoaded(object sender, EventArgs e)
        {
            try
            {
                // 1. DB에서 전체 목록을 가져와 캐시에 저장
                _cachedBookList = _repository.Retrieve();

                // 2. 필터링 로직을 실행하여 화면에 표시 (처음엔 빈 검색어로 전체 목록 표시)
                ApplyFilter();
            }
            catch (Exception ex)
            {
                _view.ShowMessage("대여 목록 조회 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        /// <summary>
        /// "조회" 버튼 클릭 시: 팝업 띄우기
        /// </summary>
        private void OnRentalCheckClicked(object sender, RentalModelEventArgs e)
        {
            _view.ShowRentalPopup(e.Rental);
        }

        /// <summary>
        /// "검색" 버튼 클릭 시: 캐시된 목록을 필터링
        /// </summary>
        private void OnSearchClicked(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        /// <summary>
        /// (신규) 캐시된 목록을 View의 검색 조건으로 필터링하여 그리드에 바인딩
        /// </summary>
        private void ApplyFilter()
        {
            try
            {
                // 1. View에서 검색 조건 가져오기
                string searchType = _view.SearchType;
                string searchKeyword = _view.SearchKeyword.ToLower(); // 검색어는 소문자로

                List<RentalModel> filteredList;

                // 2. 검색어가 비어있는지 확인 ("빈칸입력시 전체 조회")
                if (string.IsNullOrWhiteSpace(searchKeyword))
                {
                    // 비어있으면: 전체 목록 보여주기 (캐시 원본)
                    filteredList = _cachedBookList;
                }
                else
                {
                    // 비어있지 않으면: LINQ로 캐시에서 필터링
                    if (searchType == "저자")
                    {
                        filteredList = _cachedBookList
                            .Where(book => book.Book_Author != null &&
                                           book.Book_Author.ToLower().Contains(searchKeyword))
                            .ToList();
                    }
                    else // "도서 제목" (기본값)
                    {
                        filteredList = _cachedBookList
                            .Where(book => book.Book_Title != null &&
                                           book.Book_Title.ToLower().Contains(searchKeyword))
                            .ToList();
                    }
                }

                // 3. 필터링된 결과를 View의 그리드에 할당
                _view.RentalList = filteredList;
            }
            catch (Exception ex)
            {
                _view.ShowMessage("목록 필터링 중 오류가 발생했습니다: " + ex.Message);
            }
        }
    }
}