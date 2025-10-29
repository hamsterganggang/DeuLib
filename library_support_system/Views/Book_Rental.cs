using library_support_system.Models;
using library_support_system.Presenters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public partial class Book_Rental : Form, IBook_Rental
    {
        private BookRentalPresenter _presenter;
        public event EventHandler ViewLoaded;
        public event EventHandler<RentalModelEventArgs> RentalCheckClicked;

        public Book_Rental()
        {
            InitializeComponent();
            BindDropDownListSearch();
            _presenter = new BookRentalPresenter(this); // 반드시 추가
            dataGridView1.AutoGenerateColumns = false;

            this.Load += (s, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

        }
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
        public List<RentalModel> RentalList
        {
            set
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = value;
            }
        }

        public RentalModel SelectedRental => dataGridView1.SelectedRows.Count > 0
            ? dataGridView1.SelectedRows[0].DataBoundItem as RentalModel
            : null;

        #region Method
        public void ShowRentalPopup(RentalModel rental)
        {
            // Presenter의 명령을 받아 팝업을 띄웁니다.
            var popupForm = new Rental_Popup(rental);
            popupForm.ShowDialog();

            // 팝업이 닫힌 후, 목록을 새로고침합니다.
            ViewLoaded?.Invoke(this, EventArgs.Empty);
        }
        //셀 클릭 하면 Rental_Popup 띄우기
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnRentCheck")
            {
                var currentList = dataGridView1.DataSource as List<RentalModel>;
                if (currentList == null) return;
                var clickedRental = currentList[e.RowIndex];

                // !!! 여기가 수정되어야 합니다 !!!
                // (팝업을 직접 띄우는 대신) Presenter에게 이벤트를 보냅니다.
                RentalCheckClicked?.Invoke(this, new RentalModelEventArgs(clickedRental, e.RowIndex));
            }
        }
        public void ShowMessage(string message) => MessageBox.Show(message);
        #endregion
    }
}
