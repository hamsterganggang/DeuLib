using library_support_system.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public partial class Book_View : Form, IBook_View
    {
        public event EventHandler ViewLoaded;
        public event EventHandler ChangeBookEvent;
        public event EventHandler DeleteBookEvent;

        public Book_View()
        {
            InitializeComponent();
            this.Load += (s, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);

            btnChange.Click += (s, e) => ChangeBookEvent?.Invoke(s, e);
            btnDel.Click += (s, e) => DeleteBookEvent?.Invoke(s, e);
        }

        public void SetBookList(List<BookModel> books)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = books;
        }
        public List<BookModel> BookList
        {
            set
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = value;
            }
        }

        public BookModel SelectedBook =>
            dataGridView1.SelectedRows.Count > 0
                ? dataGridView1.SelectedRows[0].DataBoundItem as BookModel
                : null;

        public void ShowMessage(string message) => MessageBox.Show(message);
    }
}