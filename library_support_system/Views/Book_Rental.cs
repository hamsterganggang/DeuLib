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
            _presenter = new BookRentalPresenter(this); // 반드시 추가
            dataGridView1.AutoGenerateColumns = false;

            this.Load += (s, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;

        }

        public List<RentalModel> RentalList
        {
            set
            {
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = value;
                // 컬럼 자동 생성 등 필요시 설정 추가 가능
                ApplyRowStyles();
            }
        }

        public RentalModel SelectedRental => dataGridView1.SelectedRows.Count > 0
            ? dataGridView1.SelectedRows[0].DataBoundItem as RentalModel
            : null;

        public void ShowMessage(string message) => MessageBox.Show(message);

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dataGridView1.Columns[e.ColumnIndex].Name == "btnRentCheck")
            {
                var currentList = dataGridView1.DataSource as List<RentalModel>;
                if (currentList == null) return;

                var clickedRental = currentList[e.RowIndex];
                RentalCheckClicked?.Invoke(this, new RentalModelEventArgs(clickedRental, e.RowIndex));
            }
        }

        private void ApplyRowStyles()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var row = dataGridView1.Rows[i];
                var rental = row.DataBoundItem as RentalModel;
                if (rental == null) continue;

                if (rental.IsChildRow)
                {
                    row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Italic);
                    row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    row.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Regular);
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
