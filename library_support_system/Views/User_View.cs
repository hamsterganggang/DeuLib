using library_support_system;
using library_support_system.Models;
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

        //Event Handler
        public event EventHandler ChangeUserEvent;
        public event EventHandler SearchEvent;
        public event EventHandler DeleteUserEvent;
        public event EventHandler RetireFilterChanged;
        private UserViewPresenter presenter;

        const string placeholder = "";
        public User_View()
        {
            InitializeComponent();

            this.AutoSize = false;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;

            this.Load += User_View_Load;
            btnChange.Click += (sender, e) => ChangeUserEvent?.Invoke(sender, e);
            btnDel.Click += (sender, e) => DeleteUserEvent?.Invoke(sender, e);
            this.chkRetireUser.CheckedChanged += (sender, e) => RetireFilterChanged?.Invoke(this, EventArgs.Empty);
        }
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
        public UserModel SelectedUser
        {
            get
            {
                if (dataGridView1.SelectedRows.Count > 0)
                    return dataGridView1.SelectedRows[0].DataBoundItem as UserModel;
                return null;
            }
        }
        private void User_View_Load(object sender, EventArgs e)
        {
            this.presenter = new UserViewPresenter(this);
        }
        public void ShowUserEditForm(UserModel userToEdit)
        {
            // 💡 화면 이동/생성 로직은 View가 담당
            var userResForm = new User_Res();
            var userResPresenter = new UserResPresenter(userResForm, userToEdit);
            userResForm.ShowDialog();
        }
        public bool IsRetireUserChecked => chkRetireUser.Checked;
        public string SearchValue { get => txtSearch.Text; set => txtSearch.Text = value; }
        public string SearchBy { get => ddlSearch.SelectedItem?.ToString() ?? "이름"; set { /* ... */ } }
        public void ShowMessage(string message) { MessageBox.Show(message); }

    }
}