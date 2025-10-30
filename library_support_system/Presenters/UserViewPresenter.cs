using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace library_support_system.Presenters
{
    public class UserViewPresenter
    {
        private readonly IUser_View view;
        private readonly UserRepository userRepository;
        private readonly RentalRepository rentalRepository;

        private List<UserModel> _cachedUserList;

        public UserViewPresenter(IUser_View view)
        {
            this.view = view;
            this.userRepository = new UserRepository();
            this.rentalRepository = new RentalRepository();
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
            if (user == null)
            {
                view.ShowMessage("처리할 회원을 선택하세요.");
                return;
            }

            try
            {
                // --- ★★★ 3. (로직 분기) 선택된 회원의 상태 확인 ★★★ ---
                if (user.User_WTHDR == 0) // 현재 "활성 회원"인 경우 -> "탈퇴" 처리
                {
                    // 3-1. 탈퇴 확인 메시지
                    DialogResult confirm = MessageBox.Show($"'{user.User_Name}' 회원을 정말로 탈퇴 처리하시겠습니까?",
                                                         "탈퇴 확인",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Warning);
                    if (confirm == DialogResult.No) return;

                    // 3-2. 대여 상태 확인 (기존 로직)
                    bool isRenting = rentalRepository.IsUserRenting(user.User_Phone);
                    if (isRenting)
                    {
                        view.ShowMessage("대여중인 도서가 있는 회원은 탈퇴시킬 수 없습니다.\n먼저 도서를 모두 반납 처리해주세요.");
                        return;
                    }

                    // 3-3. 탈퇴(WTHDR=1) 처리
                    bool success = userRepository.UpdateUserWTHDR(user.User_Phone);
                    if (success)
                    {
                        view.ShowMessage("회원 탈퇴가 완료되었습니다.");
                        RetrieveDataFromDB(); // 새로고침
                    }
                    else
                    {
                        view.ShowMessage("회원 탈퇴에 실패했습니다.");
                    }
                }
                else // 현재 "탈퇴 회원"(User_WTHDR == 1)인 경우 -> "복구" 처리
                {
                    // 3-4. 복구 확인 메시지
                    DialogResult confirm = MessageBox.Show($"'{user.User_Name}' 회원을 다시 가입 상태로 복구하시겠습니까?",
                                                         "복구 확인",
                                                         MessageBoxButtons.YesNo,
                                                         MessageBoxIcon.Question);
                    if (confirm == DialogResult.No) return;

                    // 3-5. 복구(WTHDR=0) 처리
                    // (Repository에 RestoreUserWTHDR 메서드가 있어야 함)
                    bool success = userRepository.RestoreUserWTHDR(user.User_Phone);
                    if (success)
                    {
                        view.ShowMessage("회원 복구가 완료되었습니다.");
                        RetrieveDataFromDB(); // 새로고침
                    }
                    else
                    {
                        view.ShowMessage("회원 복구에 실패했습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                view.ShowMessage($"회원 상태 변경 처리 중 오류가 발생했습니다: {ex.Message}");
            }
        }
    }
}