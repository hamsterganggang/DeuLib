using System;
using System.Drawing;
using System.Windows.Forms;
using library_support_system.Models;
using library_support_system.Presenters;

namespace library_support_system.Views
{
    public partial class Book_Res : Form, IBook_Res
    {
        #region Properties
        public string BookISBN => txtNum.Text.Trim();
        public string BookTitle => textBox5.Text.Trim();
        public string BookAuthor => textBox4.Text.Trim();
        public string BookPublisher => txtEmail.Text.Trim();
        public int BookPrice 
        { 
            get 
            { 
                int.TryParse(textBox1.Text.Trim(), out int price);
                return price;
            } 
        }
        public string BookLink => textBox2.Text.Trim();
        public string BookImage => pictureBoxUpload.ImageLocation ?? "";
        public string BookExplain => textBox3.Text.Trim();
        PictureBox IBook_Res.BookPictureBox => this.pictureBoxUpload;
        #endregion

        #region Events
        public event EventHandler ExitBookRes;
        public event EventHandler btnSave_Click;
        public event EventHandler btnCancel_Click;
        public event EventHandler btnDuplicateCheck_Click;
        public event EventHandler pictureBoxUpload_Click;
        #endregion

        public Book_Res()
        {
            InitializeComponent();

            // 스크롤 기능 초기화
            InitializeScrollFeatures();

            // 이벤트 연결 (User_Res와 동일한 패턴)
            exit_button.Click += (sender, e) => ExitBookRes?.Invoke(sender, e);
            btnSave.Click += (sender, e) => btnSave_Click?.Invoke(sender, e);
            cancel_button.Click += (sender, e) => btnCancel_Click?.Invoke(sender, e);
            button1.Click += (sender, e) => btnDuplicateCheck_Click?.Invoke(sender, e); // 중복확인 버튼
            pictureBoxUpload.Click += (sender, e) => pictureBoxUpload_Click?.Invoke(sender, e);

            // PictureBox 초기 설정
            pictureBoxUpload.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxUpload.SizeMode = PictureBoxSizeMode.StretchImage;
            
            // 숫자만 입력 가능하도록 설정 (가격 필드)
            textBox1.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            };
        }

        private void InitializeScrollFeatures()
        {
            // 스크롤 패널 설정
            scrollablePanel.AutoScroll = true;
            
            // 스크롤바 항상 표시
            scrollablePanel.HorizontalScroll.Visible = false;
            scrollablePanel.VerticalScroll.Visible = true;
            
            // 스크롤 속도 설정
            scrollablePanel.VerticalScroll.SmallChange = 20;
            scrollablePanel.VerticalScroll.LargeChange = 100;
            
            // 마우스 휠 스크롤 지원
            this.MouseWheel += Book_Res_MouseWheel;
            scrollablePanel.MouseWheel += ScrollablePanel_MouseWheel;
            
            // 폼 크기 조정 시 스크롤 업데이트
            this.SizeChanged += Book_Res_SizeChanged;
        }

        private void ScrollablePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            // 마우스 휠로 스크롤 지원
            var vPos = scrollablePanel.VerticalScroll.Value;
            scrollablePanel.VerticalScroll.Value = Math.Max(0, 
                Math.Min(scrollablePanel.VerticalScroll.Maximum, vPos - e.Delta));
        }

        private void Book_Res_MouseWheel(object sender, MouseEventArgs e)
        {
            // 폼에서 마우스 휠 이벤트를 스크롤 패널로 전달
            if (scrollablePanel.ClientRectangle.Contains(scrollablePanel.PointToClient(MousePosition)))
            {
                ScrollablePanel_MouseWheel(sender, e);
            }
        }

        private void Book_Res_SizeChanged(object sender, EventArgs e)
        {
            // 폼 크기 변경 시 스크롤 업데이트
            scrollablePanel.Invalidate();
            scrollablePanel.Update();
        }

        #region IBook_Res Implementation
        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void ClearForm()
        {
            txtNum.Clear();
            textBox5.Clear(); // 제목
            textBox4.Clear(); // 저자
            txtEmail.Clear(); // 출판사
            textBox1.Clear(); // 가격
            textBox2.Clear(); // 링크
            textBox3.Clear(); // 설명
            pictureBoxUpload.Image = null;
            pictureBoxUpload.ImageLocation = null;
            
            // 스크롤 위치 초기화
            scrollablePanel.VerticalScroll.Value = 0;
            scrollablePanel.HorizontalScroll.Value = 0;
        }

        public void CloseView()
        {
            this.Close();
        }

        public void SetBookData(BookModel book)
        {
            if (book == null) return;

            txtNum.Text = book.Book_ISBN ?? "";
            textBox5.Text = book.Book_Title ?? "";
            textBox4.Text = book.Book_Author ?? "";
            txtEmail.Text = book.Book_Pbl ?? "";
            textBox1.Text = book.Book_Price.ToString();
            textBox2.Text = book.Book_Link ?? "";
            textBox3.Text = book.Book_Exp ?? ""; // Book_Explain → Book_Exp로 수정
            
            // 이미지 로드
            if (!string.IsNullOrEmpty(book.Book_Img))
            {
                try
                {
                    pictureBoxUpload.ImageLocation = book.Book_Img;
                }
                catch
                {
                    // 이미지 로드 실패 시 무시
                }
            }
            
            // 데이터 로드 후 스크롤 위치 초기화
            scrollablePanel.VerticalScroll.Value = 0;
            scrollablePanel.HorizontalScroll.Value = 0;
        }
        #endregion

        #region Form Events
        private void Book_Res_Load(object sender, EventArgs e)
        {
            // 폼 로드 시 스크롤 초기화
            scrollablePanel.VerticalScroll.Value = 0;
            scrollablePanel.HorizontalScroll.Value = 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // 이벤트 해제
            this.MouseWheel -= Book_Res_MouseWheel;
            scrollablePanel.MouseWheel -= ScrollablePanel_MouseWheel;
            this.SizeChanged -= Book_Res_SizeChanged;
            
            base.OnFormClosing(e);
        }
        #endregion

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
