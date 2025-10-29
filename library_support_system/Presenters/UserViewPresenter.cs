using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_support_system.Presenters
{
    public class UserViewPresenter
    {
        #region Fields
        private readonly IUser_View view;
        private readonly UserRepository userRepository;
        #endregion

        public UserViewPresenter(IUser_View view)
        {
            this.view = view;
            this.userRepository = new UserRepository();
            Retrieve(); // 로딩 시 전체 회원 조회

            // this.view.SearchEvent += OnSearchUser; < 검색이벤트는 현재 사용하지 않음
            this.view.ChangeUserEvent += OnChangeUser;
            this.view.DeleteUserEvent += OnDeleteUser;
            this.view.RetireFilterChanged += OnRetireFilterChanged;
        }

        #region Methods
        //조회
        private void Retrieve()
        {
            try
            {
                bool showRetired = view.IsRetireUserChecked;
                int statusToRetrieve = showRetired ? 1 : 0; // 체크 시 1, 아니면 0

                // 수정된 ReadAll 메서드 호출
                List<UserModel> userList = userRepository.ReadAll(statusToRetrieve);

                view.UserList = userList;
            }
            catch (Exception ex)
            {
                view.ShowMessage("회원 목록 로드 중 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void OnRetireFilterChanged(object sender, EventArgs e)
        {
            Retrieve(); // 필터링 로직이 포함된 Retrieve 메서드 재호출
        }
        //수정
        private void OnChangeUser(object sender, EventArgs e)
        {
            var selectedUser = view.SelectedUser;
            if (selectedUser != null)
            {
                // 💡 Presenter는 View에게 '요청'만 보냄
                view.ShowUserEditForm(selectedUser);
                Retrieve(); // 팝업 후 갱신
            }
            else
            {
                view.ShowMessage("수정할 회원을 먼저 선택하세요.");
            }
        }
        //삭제
        private void OnDeleteUser(object sender, EventArgs e)
        {
            var user = view.SelectedUser;
            if (user != null)
            {
                bool success = userRepository.UpdateUserWTHDR(user.User_Phone);
                if (success)
                {
                    view.ShowMessage("회원 탈퇴가 완료되었습니다.");
                    Retrieve(); // 삭제 후 리스트 갱신
                }
                else
                {
                    view.ShowMessage("회원 탈퇴에 실패했습니다.");
                }
            }
            else
            {
                view.ShowMessage("삭제할 회원을 선택하세요.");
            }
        }
        #endregion
    }
}
