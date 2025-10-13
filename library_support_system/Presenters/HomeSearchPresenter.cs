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

            // View 이벤트 구독
            this.view.SearchButtonClick += OnSearchButtonClick;
            this.view.SearchTextChanged += OnSearchTextChanged;
            this.view.SearchKeyDown += OnSearchKeyDown;

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

        private void PerformSearch()
        {
            try
            {
                string searchTitle = view.SearchText?.Trim() ?? string.Empty;

                if (string.IsNullOrEmpty(searchTitle))
                {
                    view.ShowMessage("검색할 책 제목을 입력해주세요.", "알림", MessageBoxIcon.Information);
                    return;
                }

                var searchResults = bookRepository.SearchByTitle(searchTitle);

                if (searchResults != null && searchResults.Count > 0)
                {
                    // 검색 결과가 있으면 book_check 페이지로 이동
                    view.NavigateToBookCheck();
                }
                else
                {
                    view.ShowMessage($"'{searchTitle}' 제목을 포함한 도서를 찾을 수 없습니다.", "검색 결과", MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"검색 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxIcon.Error);
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