using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_support_system.Views
{

    public partial class HomeView : Form, IHomeView
    {
        #region 전역변수
        public string CurrentMenu1Text { set => labelCurrentMenu1.Text = value; }
        public string CurrentMenu2Text { set => labelCurrentMenu2.Text = value; }
        #endregion
        //디자인 요소
        private const int PANEL_HEIGHT = 110; // 패널 펼칠 때 높이
        
        public void ToggleAccountPanel() => TogglePanel(account_panel);
        public void ToggleBookPanel() => TogglePanel(book_panel);
        public void ToggleRentalPanel() => TogglePanel(rental_panel);

        public event EventHandler BookMenu;
        public event EventHandler UserMenu;
        public event EventHandler RentalMenu;

        public event EventHandler OpenUserRes;
        public event EventHandler OpenUserRetrieve;
        public event EventHandler OpenBookRes;
        public event EventHandler OpenBookRetrieve;
        public event EventHandler OpenBookRental;
        public event EventHandler OpenBookReturn;
        public event EventHandler OpenHomeSearch;  // 홈 검색 이벤트 추가
        public event EventHandler ExitProgram;

        public HomeView()
        {
            InitializeComponent();

            btnUserRes.Click += (sender, e) => OpenUserRes?.Invoke(sender, e);
            user_check_button.Click += (sender, e) => OpenUserRetrieve?.Invoke(sender, e);
            book_enroll_button.Click += (sender, e) => OpenBookRes?.Invoke(sender, e);
            book_check_button.Click += (sender, e) => OpenBookRetrieve?.Invoke(sender, e);
            book_rental_button.Click += (sender, e) => OpenBookRental?.Invoke(sender, e);
            book_return_button.Click += (sender, e) => OpenBookReturn?.Invoke(sender, e);
            exit_button.Click += (sender, e) => ExitProgram?.Invoke(sender, e);
        }
        private void home_Load(object sender, EventArgs e)
        {
            // 각 버튼에 이벤트 연결 (이미 연결했다면 중복 X)
            book_button.Click += (s, ev) => FlyoutPanelToggle(book_panel);
            account_button.Click += (s, ev) => FlyoutPanelToggle(account_panel);
            rental_button.Click += (s, ev) => FlyoutPanelToggle(rental_panel);

            // 프로그램 시작 시 기본적으로 Home_Search 페이지 로드
            LoadDefaultHomeSearch();
        }

        // 기본 홈 검색 페이지 로드 메서드
        private void LoadDefaultHomeSearch()
        {
            CurrentMenu1Text = "도서검색";
            CurrentMenu2Text = "홈 검색";
            ShowChildForm(new Home_Search());
        }

        #region Method
        private void FlyoutPanelToggle(Panel panelToToggle)
        {
            bool isExpanded = panelToToggle.Height > 0;

            panelToToggle.Height = isExpanded ? 0 : PANEL_HEIGHT;

            // 토글에 따라 버튼 위치 및 패널 위치는 아래와 같이 재조정    
            List<(Button button, Panel panel)> items = new List<(Button, Panel)>
            {
                (book_button, book_panel),
                (account_button, account_panel),
                (rental_button, rental_panel)
            };

            int startY = book_button.Top;

            int currentY = startY;
            foreach (var item in items)
            {
                item.button.Top = currentY;
                currentY += item.button.Height;

                item.panel.Top = currentY;
                currentY += item.panel.Height;
            }

            this.PerformLayout();
            this.Refresh();
        }
        public void ShowChildForm(Form form) //탭이동 동적으로 시켜주는 메서드
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            main_panel.Controls.Clear(); // 기존 화면 제거
            main_panel.Controls.Add(form);
            form.Show();
        }
        
        // 홈 검색 페이지 실행 메서드
        public void ShowHomeSearch()
        {
            CurrentMenu1Text = "도서검색";
            CurrentMenu2Text = "홈 검색";
            ShowChildForm(new Home_Search());
        }
        #endregion

        #region Event

        private void TogglePanel(Panel panelToToggle)
        {
            panelToToggle.Visible = !panelToToggle.Visible;
        }

        private void home_button_Click(object sender, EventArgs e)
        {
            // 홈 검색 페이지 실행
            OpenHomeSearch?.Invoke(sender, e);
        }

        #endregion


    }
}
