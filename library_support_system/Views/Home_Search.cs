using System;
using System.Drawing;
using System.Windows.Forms;
using library_support_system.Views;
using library_support_system.Presenters;

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
            presenter = new HomeSearchPresenter(this);
        }

        #region IHomeSearchView Implementation
        public string SearchText
        {
            get { return search_textbox != null ? search_textbox.Text : string.Empty; }
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

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void NavigateToBookCheck()
        {
            try
            {
                HomeView homeView = FindHomeView();
                if (homeView != null)
                {
                    homeView.CurrentMenu1Text = "도서검색 결과";
                    homeView.CurrentMenu2Text = "도서검색 결과";

                    var checkForm = new Book_View();
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
        #endregion
    }
}