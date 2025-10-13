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

            // View �̺�Ʈ ����
            this.view.SearchButtonClick += OnSearchButtonClick;
            this.view.SearchTextChanged += OnSearchTextChanged;
            this.view.SearchKeyDown += OnSearchKeyDown;

            // �ʱ� ���� ����
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
                    view.ShowMessage("�˻��� å ������ �Է����ּ���.", "�˸�", MessageBoxIcon.Information);
                    return;
                }

                var searchResults = bookRepository.SearchByTitle(searchTitle);

                if (searchResults != null && searchResults.Count > 0)
                {
                    // �˻� ����� ������ book_check �������� �̵�
                    view.NavigateToBookCheck();
                }
                else
                {
                    view.ShowMessage($"'{searchTitle}' ������ ������ ������ ã�� �� �����ϴ�.", "�˻� ���", MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"�˻� �� ������ �߻��߽��ϴ�: {ex.Message}", "����", MessageBoxIcon.Error);
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