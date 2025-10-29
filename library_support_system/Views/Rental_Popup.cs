// library_support_system.Views/Rental_Popup.cs
using library_support_system.Models;
using library_support_system.Presenters;
using System;
using System.Windows.Forms;

namespace library_support_system.Views
{
    public partial class Rental_Popup : Form, IRental_Popup
    {
        // --- 이벤트 선언 ---
        public event EventHandler PopupLoaded;
        public event EventHandler SaveClicked;
        public event EventHandler CheckUserClicked;
        public event EventHandler UserPhoneTextChanged;
        private RentalPopupPresenter _presenter;

        #region Properties
        public string UserPhone
        {
            get => txtPhoneNum.Text;
            set => txtPhoneNum.Text = value;
        }
        public DateTime RentalDate
        {
            get => TimeRent.Value;
            set => TimeRent.Value = value;
        }
        public DateTime ReturnDate
        {
            get => TimeReturn.Value;
            set => TimeReturn.Value = value;
        }
        public bool IsDatePickersReadOnly
        {
            set
            {
                TimeRent.Enabled = !value;
                TimeReturn.Enabled = !value;
            }
        }
        public bool IsUserPhoneReadOnly
        {
            set { txtPhoneNum.ReadOnly = value; }
        }
        public bool IsRentButtonEnabled
        {
            set { btnSave.Enabled = value; }
        }
        public bool IsCheckButtonEnabled
        {
            set { btnNumCheck.Enabled = value; }
        }
        #endregion

        // --- 생성자 ---
        public Rental_Popup(RentalModel rental)
        {
            InitializeComponent();
            _presenter = new RentalPopupPresenter(this, rental);

            // 이벤트 핸들러 연결
            this.Load += (sender, e) => PopupLoaded?.Invoke(this, EventArgs.Empty);
            this.btnSave.Click += (sender, e) => SaveClicked?.Invoke(this, EventArgs.Empty);
            this.btnNumCheck.Click += (sender, e) => CheckUserClicked?.Invoke(this, EventArgs.Empty);
            this.txtPhoneNum.TextChanged += (sender, e) => UserPhoneTextChanged?.Invoke(this, EventArgs.Empty);
        }

        #region Method
        public void CloseView()
        {
            this.Close();
        }
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
        #endregion
    }
}