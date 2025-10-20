using library_support_system.Views;
using library_support_system.Repositories;
using library_support_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_support_system.Presenters
{
    public class HomeSearchPresenter
    {
        #region Fields
        private readonly IHome_Search view;
        private readonly BookRepository bookRepository;
        #endregion

        public HomeSearchPresenter(IHome_Search view)
        {
            this.view = view;
            this.bookRepository = new BookRepository();

            // View 이벤트 연결
            this.view.SearchButtonClick += OnSearchButtonClick;
            this.view.SearchTextChanged += OnSearchTextChanged;
            this.view.SearchKeyDown += OnSearchKeyDown;
            this.view.SearchOptionChanged += OnSearchOptionChanged;

            // 초기 상태 설정
            InitializeView();
        }

        #region Private Methods
        private void InitializeView()
        {
            view.SearchButtonEnabled = false;
            view.SetSearchButtonStyle(false);
        }

        private void OnSearchButtonClick(object sender, EventArgs e)
        {
            PerformSearch();
        }

        private void OnSearchTextChanged(object sender, EventArgs e)
        {
            string searchText = view.SearchText?.Trim() ?? string.Empty;
            bool hasText = !string.IsNullOrEmpty(searchText);
            
            view.SearchButtonEnabled = hasText;
            view.SetSearchButtonStyle(hasText);
        }

        private void OnSearchKeyDown(object sender, EventArgs e)
        {
            if (e is KeyEventArgs keyArgs && keyArgs.KeyCode == Keys.Enter)
            {
                string searchText = view.SearchText?.Trim() ?? string.Empty;
                bool hasText = !string.IsNullOrEmpty(searchText);
                if (hasText)
                {
                    PerformSearch();
                }
            }
        }

        private void OnSearchOptionChanged(object sender, EventArgs e)
        {
            // 검색 옵션이 변경될 때 필요한 처리
            // 현재는 특별한 작업 없음
        }

        private void PerformSearch()
        {
            try
            {
                string searchText = view.SearchText?.Trim() ?? string.Empty;
                string searchOption = view.SearchOption ?? "책이름";

                if (string.IsNullOrEmpty(searchText))
                {
                    view.ShowMessage("검색할 내용을 입력해주세요.", "알림", MessageBoxIcon.Information);
                    return;
                }

                List<BookModel> searchResults = null;

                // 검색 옵션에 따라 다른 검색 메서드 호출
                if (searchOption == "ISBN")
                {
                    searchResults = bookRepository.SearchByISBN(searchText);
                }
                else // 책이름
                {
                    searchResults = bookRepository.SearchByTitle(searchText);
                }

                if (searchResults != null && searchResults.Count > 0)
                {
                    // 검색 결과를 매개변수로 전달하여 페이지 이동
                    string searchInfo = $"{searchOption}: {searchText}";
                    view.NavigateToBookCheck(searchResults, searchInfo);
                }
                else
                {
                    string optionText = searchOption == "ISBN" ? "ISBN" : "책 제목";
                    view.ShowMessage($"'{searchText}'로 검색된 {optionText} 결과가 없습니다.", "검색 결과", MessageBoxIcon.Information);
                    
                    // 검색 결과가 없어도 빈 리스트로 전달
                    string searchInfo = $"{searchOption}: {searchText}";
                    view.NavigateToBookCheck(new List<BookModel>(), searchInfo);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"검색 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine($"HomeSearchPresenter PerformSearch Error: {ex.Message}");
            }
        }
        #endregion

        #region Dispose
        public void Dispose()
        {
            bookRepository?.Dispose();
        }
        #endregion
    }
}