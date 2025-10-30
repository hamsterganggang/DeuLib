using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;

namespace library_support_system.Presenters
{
    public class UserViewPresenter
    {
        private readonly IUser_View view;
        private readonly UserRepository userRepository;

        public UserViewPresenter(IUser_View view)
        {
            this.view = view;
            this.userRepository = new UserRepository();
            Retrieve();

            this.view.ChangeUserEvent += OnChangeUser;
            this.view.DeleteUserEvent += OnDeleteUser;
            this.view.SearchEvent += OnSearchUser; // 검색 이벤트 연결
        }

        private void Retrieve(int withdrawalStatus = 0)
        {
            try
            {
                List<UserModel> userList = userRepository.ReadAll(withdrawalStatus);
                view.UserList = userList;
            }
            catch (Exception ex)
            {
                view.ShowMessage("회원 목록 로드 중 오류가 발생했습니다: " + ex.Message);
            }
        }

        private void OnChangeUser(object sender, EventArgs e)
        {
            var selectedUser = view.SelectedUser;
            if (selectedUser != null)
            {
                var userResForm = new User_Res();
                var userResPresenter = new UserResPresenter(userResForm, selectedUser);
                userResForm.ShowDialog();
                Retrieve();
            }
            else
            {
                view.ShowMessage("수정할 회원을 먼저 선택하세요.");
            }
        }
        private void OnDeleteUser(object sender, EventArgs e)
        {
            var user = view.SelectedUser;
            if (user != null)
            {
                bool success = userRepository.UpdateUserWTHDR(user.User_Phone);
                if (success)
                {
                    view.ShowMessage("회원 탈퇴가 완료되었습니다.");
                    Retrieve();
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

        // 검색 이벤트 핸들러
        private void OnSearchUser(object sender, EventArgs e)
        {
            string searchValue = view.SearchValue?.Trim() ?? "";
            string searchBy = view.SearchBy ?? "이름";
            int withdrawalStatus = 0; // 필요시 탈퇴회원 포함 옵션 처리
            List<UserModel> result;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                Retrieve(withdrawalStatus);
                view.ShowMessage("전체 회원 목록을 표시합니다.");
                return;
            }

            if (searchBy == "전화번호")
            {
                result = userRepository.SearchByPhone(searchValue, withdrawalStatus);
            }
            else // 이름
            {
                result = userRepository.SearchByName(searchValue, withdrawalStatus);
            }

            view.UserList = result;
            if (result.Count == 0)
                view.ShowMessage("검색 결과가 없습니다.");
            else
                view.ShowMessage($"검색 결과: {result.Count}명");
        }
    }
}
