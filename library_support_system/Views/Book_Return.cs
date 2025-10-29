// library_support_system.Views/Book_Return.cs
using library_support_system.Models;
using library_support_system.Presenters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public partial class Book_Return : Form, IBook_Return // *** 1. 인터페이스 구현
    {
        private BookReturnPresenter _presenter;

        // --- 2. IBook_Return 인터페이스 이벤트 구현 ---
        public event EventHandler ViewLoaded;
        public event EventHandler ReturnClicked; // *** "반납" 이벤트 선언 ***
        public event EventHandler ReturnListFilterChanged;

        public Book_Return()
        {
            InitializeComponent();
            _presenter = new BookReturnPresenter(this);

            dataGridView1.AutoGenerateColumns = false;

            this.Load += (sender, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);

            // --- "btnSave" 버튼 클릭을 Presenter에게 "보고"하도록 연결 ---
            this.btnSave.Click += (sender, e) => ReturnClicked?.Invoke(this, EventArgs.Empty);
            this.chkReturnList.CheckedChanged += (sender, e) => ReturnListFilterChanged?.Invoke(this, EventArgs.Empty);
            this.dataGridView1.CellFormatting += DataGridView1_CellFormatting;
        }

        // --- 인터페이스 속성/메서드 구현 ---
        public bool IsReturnedListChecked => chkReturnList.Checked;
        // *** (추가) SelectedRental 속성 구현 ***
        public RentalModel SelectedRental => dataGridView1.SelectedRows.Count > 0
            ? dataGridView1.SelectedRows[0].DataBoundItem as RentalModel
            : null;

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

        // --- 7. (그대로 둠) DataGridView 표시 형식을 이쁘게 바꾸는 메서드 ---
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Designer.cs의 "반납여부" 컬럼 (Name: "반납여부")을 찾음
            if (dataGridView1.Columns[e.ColumnIndex].Name == "반납여부" && e.Value != null)
            {
                if ((int)e.Value == 1)
                {
                    e.Value = "대여중";
                }
                else
                {
                    e.Value = "반납 완료";
                }
                e.FormattingApplied = true;
            }

            // (추가) 날짜 컬럼 형식을 "yyyy-MM-dd"로 변경
            if (dataGridView1.Columns[e.ColumnIndex].Name == "txtEmail" && e.Value != null) // txtEmail = 대여일
            {
                // (날짜가 1900-01-01 (기본값)이 아닌 경우에만 표시)
                if (((DateTime)e.Value).Year > 1900)
                {
                    e.Value = ((DateTime)e.Value).ToString("yyyy-MM-dd");
                    e.FormattingApplied = true;
                }
                else
                {
                    e.Value = ""; // 대여가능 상태일 때 날짜를 비움
                }
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "txtPicture" && e.Value != null) // txtPicture = 반납 예정일
            {
                if (((DateTime)e.Value).Year > 1900)
                {
                    e.Value = ((DateTime)e.Value).ToString("yyyy-MM-dd");
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