using library_support_system;
using library_support_system.Model;
using library_support_system.Presenters;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_support_system
{
    public partial class User_View : Form, IUser_View
    {
        private UserViewPresenter presenter;
        const string placeholder = "";

        public User_View()
        {
            InitializeComponent();

            // View의 Load 이벤트에서 Presenter를 초기화하고 연결합니다.
            this.Load += User_View_Load;
            // 💡 주의: designer.cs에 있는 user_check_Load 메서드 대신 새로운 이벤트를 연결합니다.
            // 만약 기존 user_check_Load를 사용하려면 그 안에 presenter 초기화 로직을 넣으면 됩니다.
        }
        private void User_View_Load(object sender, EventArgs e)
        {
            // View가 로드될 때 Presenter를 인스턴스화하여 연결합니다.
            // 이 시점에 Presenter 생성자가 실행되고, 전체 조회 로직이 수행됩니다.
            this.presenter = new UserViewPresenter(this);

            // 만약 검색 버튼이 있다면 이벤트 구독 로직은 여기에 넣거나 (추천), 
            // Presenter 생성자 안에 넣어주세요. (이벤트 구독은 보통 생성자에서 합니다)
            // this.search_button.Click += SearchButton_Click; 
        }
        // 💡 IUser_View.UserList 구현 (데이터 바인딩)
        public IEnumerable<UserModel> UserList
        {
            set
            {
                // 💡 1. 자동 컬럼 생성을 비활성화합니다.
                // User_View.designer.cs에 이미 모든 컬럼이 정의되어 있으므로 자동 생성을 막아야 데이터가 밀리지 않습니다.
                dataGridView1.AutoGenerateColumns = false;

                // 2. 기존 데이터소스 해제 (필요하다면)
                dataGridView1.DataSource = null;

                // 3. 새 데이터 바인딩
                dataGridView1.DataSource = value;
            }
        }

        // ... (나머지 IUser_View 구현: SearchValue, SearchBy, SearchEvent, ShowMessage)
        // 전체 조회를 위해 SearchEvent는 사용하지 않지만, 인터페이스는 구현해야 합니다.
        public string SearchValue { get => search_textbox.Text; set => search_textbox.Text = value; }
        public string SearchBy { get => cmbGen.SelectedItem?.ToString() ?? "이름"; set { /* ... */ } }
        public event EventHandler SearchEvent;
        public void ShowMessage(string message) { MessageBox.Show(message); }

        // 기존 user_check_Load 메서드는 비워둡니다.
        private void user_check_Load(object sender, EventArgs e)
        {
        }
    }
}