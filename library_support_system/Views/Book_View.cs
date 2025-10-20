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
        public event EventHandler SearchButtonClick;  // 검색 버튼 클릭 이벤트

        // 생성자 오버로드: 검색 결과와 함께 생성하는 경우
        private List<BookModel> _initialBooks;
        
        public Book_View()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeDataGrid();
            
            // 즉시 ViewLoaded 이벤트 발생
            ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        // 검색 결과를 받는 생성자 (Home_Search에서 사용)
        public Book_View(List<BookModel> searchResults, string searchInfo)
        {
            InitializeComponent();
            InitializeEvents();
            InitializeDataGrid();
            _initialBooks = searchResults;
            
            // 검색 결과가 있는 경우 바로 표시
            if (_initialBooks != null)
            {
                SetBookList(_initialBooks);
            }
        }

        private void InitializeEvents()
        {
            btnChange.Click += (s, e) => ChangeBookEvent?.Invoke(s, e);
            btnDel.Click += (s, e) => DeleteBookEvent?.Invoke(s, e);
            search_button.Click += (s, e) => SearchButtonClick?.Invoke(s, e);
            
            // 엔터키로 검색 실행
            search_textbox.KeyDown += (s, e) => {
                if (e.KeyCode == Keys.Enter)
                {
                    SearchButtonClick?.Invoke(s, e);
                }
            };
        }

        private void InitializeDataGrid()
        {
            // 컬럼 자동 생성 비활성화 (한 번만)
            dataGridView1.AutoGenerateColumns = false;
        }

        public void SetBookList(List<BookModel> books)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = books;
        }

        public BookModel SelectedBook =>
            dataGridView1.SelectedRows.Count > 0
                ? dataGridView1.SelectedRows[0].DataBoundItem as BookModel
                : null;

        public void ShowMessage(string message) => MessageBox.Show(message);

        // 검색 텍스트 속성
        public string SearchText => search_textbox.Text?.Trim() ?? string.Empty;
    }

}