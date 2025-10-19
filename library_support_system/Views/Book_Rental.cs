using library_support_system.Models;
using library_support_system.Presenters;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public partial class Book_Rental : Form, IBook_Rental
    {
        private BookRentalPresenter _presenter;
        public event EventHandler ViewLoaded;

        public Book_Rental()
        {
            InitializeComponent();
            _presenter = new BookRentalPresenter(this); // 반드시 추가
            dataGridView1.AutoGenerateColumns = false;

            this.Load += (s, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        public List<RentalModel> RentalList
        {
            set
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = value;
                // 컬럼 자동 생성 등 필요시 설정 추가 가능
            }
        }

        public RentalModel SelectedRental => dataGridView1.SelectedRows.Count > 0
            ? dataGridView1.SelectedRows[0].DataBoundItem as RentalModel
            : null;

        public void ShowMessage(string message) => MessageBox.Show(message);
    }
}
