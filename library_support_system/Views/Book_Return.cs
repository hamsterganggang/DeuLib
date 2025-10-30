// library_support_system.Views/Book_Return.cs
using library_support_system.Models;
using library_support_system.Presenters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public partial class Book_Return : Form, IBook_Return
    {
        private BookReturnPresenter _presenter;

        // --- 이벤트 선언 ---
        public event EventHandler ViewLoaded;
        public event EventHandler ReturnClicked;
        public event EventHandler ReturnListFilterChanged;
        public event EventHandler SearchClicked; // "검색" 이벤트 선언

        public Book_Return()
        {
            InitializeComponent();
            BindDropDownListSearch(); // ★★★ 컨트롤 이름 수정됨 ★★★
            _presenter = new BookReturnPresenter(this);

            dataGridView1.AutoGenerateColumns = false;

            this.Load += (sender, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);
            this.btnSave.Click += (sender, e) => ReturnClicked?.Invoke(this, EventArgs.Empty);
            this.chkReturnList.CheckedChanged += (sender, e) => ReturnListFilterChanged?.Invoke(this, EventArgs.Empty);
            this.dataGridView1.CellFormatting += DataGridView1_CellFormatting;

            // --- ★★★ (수정) "btnSearch", "txtSearch"로 이벤트 연결 ★★★ ---
            this.btnSearch.Click += (s, e) => SearchClicked?.Invoke(this, EventArgs.Empty);
            this.txtSearch.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchClicked?.Invoke(this, EventArgs.Empty);
                    e.SuppressKeyPress = true; // 엔터 키 "삑" 소리 방지
                }
            };
        }

        // ★★★ (수정) "ddlSearch"로 이름 변경 ★★★
        private void BindDropDownListSearch()
        {
            if (ddlSearch != null)
            {
                ddlSearch.Items.Clear();
                ddlSearch.Items.Add("도서 제목");
                ddlSearch.Items.Add("저자");
                ddlSearch.SelectedIndex = 0;
            }
        }

        // --- ★★★ (수정) 인터페이스 속성 구현 (컨트롤 이름 변경) ★★★ ---
        public string SearchType => ddlSearch.SelectedItem?.ToString() ?? "도서 제목";
        public string SearchKeyword => txtSearch.Text.Trim();
        public bool IsReturnedListChecked => chkReturnList.Checked;
        public RentalModel SelectedRental => dataGridView1.SelectedRows.Count > 0
            ? dataGridView1.SelectedRows[0].DataBoundItem as RentalModel
            : null;

        // --- 나머지 인터페이스 구현 ---
        public List<RentalModel> RentalList
        {
            set
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = value;
            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        // --- DataGridView 포맷팅 (변경 없음) ---
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Designer.cs의 "반납여부" 컬럼 (DataPropertyName: "Rental_Status")을 찾음
            // ★★★ Designer.cs에서 해당 컬럼의 Name 속성도 "반납여부"로 설정했는지 확인하세요 ★★★
            if (dataGridView1.Columns[e.ColumnIndex].Name == "반납여부" && e.Value != null)
            {
                // e.Value는 Rental_Status (int) 값입니다.
                if (e.Value is int status) // 형변환이 안전하게 되는지 확인
                {
                    if (status == 1)
                    {
                        e.Value = "대여중";
                    }
                    else // status가 0 또는 그 외의 값일 경우
                    {
                        e.Value = "반납 완료";
                    }
                    e.FormattingApplied = true; // WinForms에게 값이 처리되었음을 알림
                }
            }

            // --- 날짜 컬럼 형식 변경 (기존 로직 유지) ---

            // Designer.cs의 대여일 컬럼 (DataPropertyName: "Rental_Date")
            // ★★★ Designer.cs에서 해당 컬럼의 Name이 "txtEmail"로 되어있는지 확인하세요 ★★★
            if (dataGridView1.Columns[e.ColumnIndex].Name == "txtEmail" && e.Value != null)
            {
                if (e.Value is DateTime date && date.Year > 1900)
                {
                    e.Value = date.ToString("yyyy-MM-dd");
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = ""; // 1900년이거나 날짜 형식이 아니면 비움
                }
            }

            // Designer.cs의 반납 예정일 컬럼 (DataPropertyName: "Rental_Return_Date")
            // ★★★ Designer.cs에서 해당 컬럼의 Name이 "txtPicture"로 되어있는지 확인하세요 ★★★
            if (dataGridView1.Columns[e.ColumnIndex].Name == "txtPicture" && e.Value != null)
            {
                if (e.Value is DateTime date && date.Year > 1900)
                {
                    e.Value = date.ToString("yyyy-MM-dd");
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = "";
                }
            }
        }
    }
}