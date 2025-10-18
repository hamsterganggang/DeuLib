using library_support_system.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public partial class Book_View : Form, IBook_View
    {
        public event EventHandler ViewLoaded;

        public Book_View()
        {
            InitializeComponent();
            this.Load += (s, e) => ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void SetBookList(List<BookModel> books)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = books;
        }
    }
}