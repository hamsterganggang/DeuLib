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

        // 초기 데이터가 설정되었는지 확인하는 속성 추가
        public bool HasInitialData => _initialBooks != null;

        public Book_View()
        {
            InitializeComponent();
            InitializeEvents();
            InitializeDataGrid();
            InitializeSearchOptions();

            // 즉시 ViewLoaded 이벤트 발생
            ViewLoaded?.Invoke(this, EventArgs.Empty);

            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        // 검색 결과를 받는 생성자 (Home_Search에서 사용)
        public Book_View(List<BookModel> searchResults, string searchInfo)
        {
            InitializeComponent();
            InitializeEvents();
            InitializeDataGrid();
            InitializeSearchOptions();
            _initialBooks = searchResults;

            // 검색 결과가 있는 경우 바로 표시
            if (_initialBooks != null)
            {
                SetBookList(_initialBooks);
            }
        }
        public BookModel SelectedBook =>
            dataGridView1.SelectedRows.Count > 0
                ? dataGridView1.SelectedRows[0].DataBoundItem as BookModel
                : null;
        #region Method
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
        private void InitializeSearchOptions()
        {
            if (search_option_combobox != null)
            {
                search_option_combobox.Items.Clear();
                search_option_combobox.Items.Add("도서 제목");
                search_option_combobox.Items.Add("ISBN");
                search_option_combobox.SelectedIndex = 0; // 기본값: 책이름
            }
        }
        public void SetBookList(List<BookModel> books)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = books;
        }
        public void ShowMessage(string message) => MessageBox.Show(message);
        #endregion

        #region Properties
        // 검색 텍스트 속성
        public string SearchText => search_textbox.Text?.Trim() ?? string.Empty;
        // 검색 옵션 속성
        public string SearchOption => search_option_combobox?.SelectedItem?.ToString() ?? "책이름";
        #endregion

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Book_Link")
            {
                string url = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();

                if (!string.IsNullOrEmpty(url))
                {
                    try
                    {
                        // 1. URL 앞에 프로토콜이 없는 경우 'http://'를 추가
                        if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) &&
                            !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                        {
                            url = "http://" + url;
                        }

                        // 2. 기본 웹 브라우저로 URL을 염
                        System.Diagnostics.Process.Start(url);
                    }
                    catch (Exception ex)
                    {
                        // URL 실행 중 오류 발생 시 메시지를 표시
                        MessageBox.Show($"웹사이트를 여는 중 오류가 발생했습니다: {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

}