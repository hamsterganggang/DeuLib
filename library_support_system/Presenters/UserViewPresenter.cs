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

            // 💡 View가 생성될 때(Presenter가 연결될 때) 전체 회원 조회 로직 수행
            LoadAllUsers();

            // 검색 이벤트 구독은 필요하다면 여기에 유지 (검색 기능 사용 시)
            // this.view.SearchEvent += OnSearchUser;
        }

        // 💡 전체 회원 조회 및 View 업데이트 메서드
        private void LoadAllUsers()
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

        // ... (기존 OnSearchUser 메서드는 검색 기능이 필요하면 유지)
    }
}
