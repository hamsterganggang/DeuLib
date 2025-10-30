using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace library_support_system.Presenters
{
    public class UserViewPresenter
    {
        private readonly IUser_View view;
        private readonly UserRepository userRepository;

        private List<UserModel> _cachedUserList;

        public UserViewPresenter(IUser_View view)
        {
            this.view = view;
            this.userRepository = new UserRepository();

            // --- 이벤트 구독 ---
            this.view.ChangeUserEvent += OnChangeUser;
            this.view.DeleteUserEvent += OnDeleteUser;
            this.view.SearchEvent += OnSearchUser;
            this.view.RetireFilterChanged += OnRetireFilterChanged;

            RetrieveDataFromDB();
        }
        private void RetrieveDataFromDB()
        {
            try
            {
                //
                int withdrawalStatus = view.IsRetireUserChecked ? 1 : 0;

                // DB에서 데이터 조회
                _cachedUserList = userRepository.ReadAll(withdrawalStatus);

                // 화면에 필터링 적용 
                ApplyFilter();
            }
            catch (Exception ex)
            {
                view.ShowMessage("회원 목록 로드 중 오류가 발생했습니다: " + ex.Message);
                _cachedUserList = new List<UserModel>(); // 오류 시 캐시 비우기
                view.UserList = _cachedUserList; // 오류 시 그리드 비우기
            }
        }
        private void ApplyFilter()
        {
            string searchValue = view.SearchValue.ToLower(); 
            string searchBy = view.SearchBy;

            List<UserModel> filteredList;

            if (string.IsNullOrWhiteSpace(searchValue))
            {
                filteredList = _cachedUserList;
            }
            else
            {
                if (searchBy == "전화번호")
                {
                    filteredList = _cachedUserList
                        .Where(u => u.User_Phone != null && u.User_Phone.Contains(searchValue))
                        .ToList();
                }
                else 
                {
                    filteredList = _cachedUserList
                        .Where(u => u.User_Name != null && u.User_Name.ToLower().Contains(searchValue))
                        .ToList();
                }
            }
            view.UserList = filteredList;
        }
        private void OnRetireFilterChanged(object sender, EventArgs e)
        {
            // ★★★ DB에서 데이터를 새로고침 (활성/탈퇴 회원 전환) ★★★
            RetrieveDataFromDB();
        }
        private void OnSearchUser(object sender, EventArgs e)
        {
            // ★★★ DB를 다시 조회하지 않고, 캐시된 데이터에서 "필터링"만 수행 ★★★
            ApplyFilter();
        }
        private void OnChangeUser(object sender, EventArgs e)
        {
            var selectedUser = view.SelectedUser;
            if (selectedUser != null)
            {
                view.ShowUserEditForm(selectedUser);
                RetrieveDataFromDB(); // ★★★ 수정: 팝업 닫힌 후 새로고침
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
                    RetrieveDataFromDB(); // ★★★ 수정: 삭제 후 새로고침
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
    }
}