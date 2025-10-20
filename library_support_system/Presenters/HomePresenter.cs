using library_support_system.Views;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_support_system.Presenters
{
    public class HomePresenter
    {
        #region Fields
        private readonly IHomeView view;
        private BookViewPresenter currentBookViewPresenter; // 현재 BookViewPresenter 참조 유지
        #endregion

        // pullrequst test
        public HomePresenter(IHomeView view)
        {
            this.view = view;
            this.view.UserMenu += UserMenu;
            this.view.BookMenu += BookMenu;
            this.view.RentalMenu += RentalMenu;

            //회원등록 팝업
            this.view.OpenUserRes += OpenUserRes;
            this.view.OpenUserRetrieve += OpenUserRetrieve;
            this.view.OpenBookRes += OpenBookRes;
            this.view.OpenBookRetrieve += OpenBookRetrieve;
            this.view.OpenBookRental += OpenBookRental;
            this.view.OpenBookReturn += OpenBookReturn;
            this.view.OpenHomeSearch += OpenHomeSearch;  // 홈 검색 이벤트 핸들러 추가
            this.view.ExitProgram += ExitProgram;
        }

        #region 메서드
        private void UserMenu(object sender, EventArgs e)
        {
            view.ToggleAccountPanel();
        }
        private void BookMenu(object sender, EventArgs e)
        {
            view.ToggleBookPanel();
        }
        private void RentalMenu(object sender, EventArgs e)
        {
            view.ToggleRentalPanel();
        }
        private void OpenUserRetrieve(object sender, EventArgs e)
        {
            view.CurrentMenu1Text = "회원조회";
            view.CurrentMenu2Text = "회원조회";
            view.ShowChildForm(new User_View());
        }
        private void OpenUserRes(object sender, EventArgs e)
        {
            view.CurrentMenu1Text = "회원등록";
            view.CurrentMenu2Text = "회원등록";
            IUser_Res userResView = new User_Res();
            UserResPresenter userResPresenter = new UserResPresenter(userResView);
            ((Form)userResView).ShowDialog();  // 팝업 실행
        }
        private void OpenBookRetrieve(object sender, EventArgs e)
        {
            view.CurrentMenu1Text = "도서조회";
            view.CurrentMenu2Text = "도서조회";
            var bookView = new Book_View();
            
            // BookViewPresenter 참조를 유지
            currentBookViewPresenter = new BookViewPresenter(bookView);
            
            view.ShowChildForm(bookView);
        }
        private void OpenBookRes(object sender, EventArgs e)
        {
            view.CurrentMenu1Text = "도서등록";
            view.CurrentMenu2Text = "도서등록";
            IBook_Res bookResView = new Book_Res();
            BookResPresenter bookResPresenter = new BookResPresenter(bookResView);
            ((Form)bookResView).ShowDialog();  // 팝업 실행
        }
        private void OpenBookRental(object sender, EventArgs e)
        {
            view.CurrentMenu1Text = "도서대여";
            view.CurrentMenu2Text = "도서대여";
            view.ShowChildForm(new Book_Rental());
        }
        private void OpenBookReturn(object sender, EventArgs e)
        {
            view.CurrentMenu1Text = "도서반납";
            view.CurrentMenu2Text = "도서반납";
            view.ShowChildForm(new Book_Return());
        }
        private void OpenHomeSearch(object sender, EventArgs e)
        {
            view.CurrentMenu1Text = "도서검색";
            view.CurrentMenu2Text = "홈 검색";
            view.ShowChildForm(new Home_Search());
        }
        private void ExitProgram(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
