using System;
using System.Drawing;
using System.Windows.Forms;
using library_support_system.Views;
using library_support_system.Presenters;
using library_support_system.Models;
using System.Collections.Generic;

namespace library_support_system.Views
{
    public partial class Home_Search : Form, IHome_Search
    {
        #region Fields
        private HomeSearchPresenter presenter;
        #endregion

        public Home_Search()
        {
            InitializeComponent();
            InitializeSearchOptions();
            presenter = new HomeSearchPresenter(this);
        }

        #region IHomeSearchView Implementation
        public string SearchText
        {
            get { return search_textbox != null ? search_textbox.Text : string.Empty; }
        }

        public string SearchOption
        {
            get { return search_option_combobox != null ? search_option_combobox.SelectedItem?.ToString() : "책이름"; }
        }

        public bool SearchButtonEnabled
        {
            set
            {
                if (search_button != null)
                    search_button.Enabled = value;
            }
        }

        public event EventHandler SearchButtonClick;
        public event EventHandler SearchTextChanged;
        public event EventHandler SearchKeyDown;
        public event EventHandler SearchOptionChanged;

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void NavigateToBookCheck(List<BookModel> searchResults, string searchInfo)
        {
            try
            {
                HomeView homeView = FindHomeView();
                if (homeView != null)
                {
                    string searchOption = SearchOption;
                    string searchText = SearchText;
                    
                    homeView.CurrentMenu1Text = $"{searchOption} 검색결과";
                    homeView.CurrentMenu2Text = $"{searchOption}: {searchText}";

                    // 검색 결과를 생성자로 전달하여 Book_View 생성
                    var checkForm = new Book_View(searchResults, searchInfo);
                    var bookPresenter = new BookViewPresenter(checkForm);
                    homeView.ShowChildForm(checkForm);
                }
                else
                {
                    ShowMessage("검색 결과를 표시할 수 없습니다.", "알림", MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                ShowMessage("페이지 이동 중 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxIcon.Warning);
            }
        }

        public void ClearSearchText()
        {
            if (search_textbox != null)
                search_textbox.Clear();
        }

        public void SetSearchButtonStyle(bool enabled)
        {
            if (search_button != null)
            {
                search_button.BackColor = enabled ? Color.White : Color.LightGray;
            }
        }
        #endregion

        #region Private Methods
        private void InitializeSearchOptions()
        {
            if (search_option_combobox != null)
            {
                search_option_combobox.Items.Clear();
                search_option_combobox.Items.Add("도서 제목");
                search_option_combobox.Items.Add("ISBN");
                search_option_combobox.SelectedIndex = 0; // 기본값: 책이름
                
                // 이벤트 핸들러 연결
                search_option_combobox.SelectedIndexChanged += search_option_combobox_SelectedIndexChanged;
            }
        }

        private HomeView FindHomeView()
        {
            try
            {
                Control current = this;
                while (current != null)
                {
                    HomeView homeView = current as HomeView;
                    if (homeView != null)
                        return homeView;
                    current = current.Parent;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Event Handlers
        private void book_rental_Load(object sender, EventArgs e)
        {
            try
            {
                // 초기 설정은 Presenter에서 처리
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("초기화 오류: " + ex.Message);
            }
        }

        private void search_button_Click(object sender, EventArgs e)
        {
            SearchButtonClick?.Invoke(sender, e);
        }

        private void search_textbox_TextChanged(object sender, EventArgs e)
        {
            SearchTextChanged?.Invoke(sender, e);
        }

        private void search_textbox_KeyDown(object sender, KeyEventArgs e)
        {
            SearchKeyDown?.Invoke(sender, e);
        }

        private void search_option_combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 검색 옵션이 변경될 때 텍스트박스 플레이스홀더 업데이트
            UpdateSearchTextBoxPlaceholder();
            SearchOptionChanged?.Invoke(sender, e);
        }

        private void UpdateSearchTextBoxPlaceholder()
        {
            if (search_textbox != null && search_option_combobox != null)
            {
                string selectedOption = search_option_combobox.SelectedItem?.ToString();
                // 플레이스홀더는 실제로는 WaterMark 같은 기능이 필요하지만, 
                // 간단히 포커스 이벤트로 구현할 수 있습니다.
            }
        }
        #endregion

        private void main_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search_option_combobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}