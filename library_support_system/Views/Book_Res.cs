using library_support_system.Models;
using library_support_system.Presenters;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public partial class Book_Res : Form, IBook_Res
    {
        #region Properties
        private BookModel _bookModel;
        private byte[] _uploadedImageBytes;
        
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
        public byte[] UploadImageBytes => _uploadedImageBytes;
        public string BookExplain => textBox3.Text.Trim();
        PictureBox IBook_Res.BookPictureBox => this.pictureBoxUpload;
        public bool IsSaveButtonEnabled
        {
            set { btnSave.Enabled = value; }
        }

        public bool IsIsbnTextBoxReadOnly
        {
            set
            {
                txtNum.ReadOnly = value; // 1. 읽기 전용 상태 설정
            
                // 2. 상태(value)에 따라 배경색 변경
                if (value == true) // "ReadOnly = true" (수정 모드)일 때
                {
                    // "비활성화된 컨트롤"의 표준 회색으로 변경
                    txtNum.BackColor = SystemColors.Control;
                }
                else // "ReadOnly = false" (신규 등록 모드)일 때
                {
                    // "활성화된 창"의 표준 흰색으로 변경
                    txtNum.BackColor = SystemColors.Window;
                }
            }
        }
        public bool IsDuplicateCheckButtonEnabled
        {
            set
            {
                button1.Enabled = value;

                // --- ★★★ 2. (추가) 상태에 따라 배경색 변경 ★★★ ---
                if (value == true) // "Enabled = true" (신규 등록 모드)일 때
                {
                    // 기본 버튼 색상 (보통 흰색 또는 시스템 기본값)
                    button1.BackColor = SystemColors.Window;
                }
                else // "Enabled = false" (수정 모드)일 때
                {
                    // 요청하신 "비활성화된 회색"
                    button1.BackColor = SystemColors.Control;
                }
            }
        }
        #endregion

        #region Events
        public event EventHandler ExitBookRes;
        public event EventHandler btnSave_Click;
        public event EventHandler btnCancel_Click;
        public event EventHandler btnDuplicateCheck_Click;
        public event EventHandler pictureBoxUpload_Click;
        public event EventHandler IsbnTextChanged;
        #endregion

        // 기본 생성자
        public Book_Res()
        {
            InitializeComponent();

            InitializeScrollFeatures();

            exit_button.Click += (sender, e) => ExitBookRes?.Invoke(sender, e);
            btnSave.Click += (sender, e) => btnSave_Click?.Invoke(sender, e);
            cancel_button.Click += (sender, e) => btnCancel_Click?.Invoke(sender, e);
            button1.Click += (sender, e) => btnDuplicateCheck_Click?.Invoke(sender, e);
            pictureBoxUpload.Click += (sender, e) => pictureBoxUpload_Click?.Invoke(sender, e);
            txtNum.TextChanged += (sender, e) => IsbnTextChanged?.Invoke(sender, e);

            pictureBoxUpload.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxUpload.SizeMode = PictureBoxSizeMode.StretchImage;

            textBox1.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            };
        }

        // 오버로드 생성자: BookModel을 인자로 받고 폼 데이터에 바인딩
        public Book_Res(BookModel book) : this()
        {
            _bookModel = book;
            SetBookData(book);
        }
    
        public void SetUploadedImage(byte[] bytes)
        {
            _uploadedImageBytes = bytes;
        }
        private void InitializeScrollFeatures()
        {
            scrollablePanel.AutoScroll = true;
            scrollablePanel.HorizontalScroll.Visible = false;
            scrollablePanel.VerticalScroll.Visible = true;
            scrollablePanel.VerticalScroll.SmallChange = 20;
            scrollablePanel.VerticalScroll.LargeChange = 100;
            this.MouseWheel += Book_Res_MouseWheel;
            scrollablePanel.MouseWheel += ScrollablePanel_MouseWheel;
            this.SizeChanged += Book_Res_SizeChanged;
        }

        private void ScrollablePanel_MouseWheel(object sender, MouseEventArgs e)
        {
            var vPos = scrollablePanel.VerticalScroll.Value;
            scrollablePanel.VerticalScroll.Value = Math.Max(0,
                Math.Min(scrollablePanel.VerticalScroll.Maximum, vPos - e.Delta));
        }

        private void Book_Res_MouseWheel(object sender, MouseEventArgs e)
        {
            if (scrollablePanel.ClientRectangle.Contains(scrollablePanel.PointToClient(MousePosition)))
            {
                ScrollablePanel_MouseWheel(sender, e);
            }
        }

        private void Book_Res_SizeChanged(object sender, EventArgs e)
        {
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
            textBox5.Clear();
            textBox4.Clear();
            txtEmail.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            pictureBoxUpload.Image = null;
            pictureBoxUpload.ImageLocation = null;

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

            // 텍스트 필드 세팅
            txtNum.Text = book.Book_ISBN ?? "";
            textBox5.Text = book.Book_Title ?? "";
            textBox4.Text = book.Book_Author ?? "";
            txtEmail.Text = book.Book_Pbl ?? "";
            textBox1.Text = book.Book_Price.ToString();
            textBox2.Text = book.Book_Link ?? "";
            textBox3.Text = book.Book_Exp ?? "";

            // 이미지 byte[] → PictureBox 변환
            if (book.Book_Img != null && book.Book_Img.Length > 0)
            {
                try
                {
                    using (var ms = new MemoryStream(book.Book_Img))
                    {
                        pictureBoxUpload.Image = Image.FromStream(ms);
                    }
                    _uploadedImageBytes = book.Book_Img;
                }
                catch
                {
                    pictureBoxUpload.Image = null;
                    _uploadedImageBytes = null;
                }
            }
            else
            {
                pictureBoxUpload.Image = null;
                _uploadedImageBytes = null;
            }

            // 스크롤/초기화 등 부가작업
            scrollablePanel.VerticalScroll.Value = 0;
            scrollablePanel.HorizontalScroll.Value = 0;
        }
        #endregion

        #region Form Events
        private void Book_Res_Load(object sender, EventArgs e)
        {
            scrollablePanel.VerticalScroll.Value = 0;
            scrollablePanel.HorizontalScroll.Value = 0;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.MouseWheel -= Book_Res_MouseWheel;
            scrollablePanel.MouseWheel -= ScrollablePanel_MouseWheel;
            this.SizeChanged -= Book_Res_SizeChanged;

            base.OnFormClosing(e);
        }
        #endregion
    }
}
