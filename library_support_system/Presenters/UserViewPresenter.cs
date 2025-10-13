using library_support_system.Model;
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
        }

        private void Retrieve()
        {
            try
            {
                // 1. Repository를 통해 모든 회원 데이터 조회
                List<UserModel> userList = userRepository.ReadAll();

                // 2. 조회 결과를 View의 UserList 속성에 설정 (View 업데이트)
                view.UserList = userList;
            }
            catch (Exception ex)
            {
                // 예외 발생 시 View를 통해 사용자에게 알림
                view.ShowMessage("회원 목록 로드 중 오류가 발생했습니다: " + ex.Message);
            }
        }
        private void OnChangeUser(object sender, EventArgs e)
        {
            var selectedUser = view.SelectedUser;
            if (selectedUser != null)
            {
                var userResForm = new User_Res();
                var userResPresenter = new UserResPresenter(userResForm, selectedUser); // [수정모드]
                userResForm.ShowDialog();
                Retrieve(); // 팝업 후 갱신
            }
            else
            {
                view.ShowMessage("수정할 회원을 먼저 선택하세요.");
            }
        }
    }
}
