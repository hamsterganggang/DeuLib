// library_support_system.Presenters/RentalPopupPresenter.cs
using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;
using System.Windows.Forms; // ★★★ (ShowMessage용, 필요시 View로 이동)

namespace library_support_system.Presenters
{
    public class RentalPopupPresenter
    {
        private readonly IRental_Popup _view;
        private readonly RentalModel _rental; // 부모 폼에서 전달받은 모델

        // --- ★★★ 1. (수정) Repository 참조 및 상태 변수 추가 ★★★ ---
        private readonly RentalRepository _repository; // DB 통신용
        private bool isUserPhoneValidated = false; // "사용자 확인" 완료 여부
        private const int MAX_RENTAL_LIMIT = 3;    // 최대 대여 권수

        public RentalPopupPresenter(IRental_Popup view, RentalModel rental)
        {
            _view = view;
            _rental = rental;
            _repository = new RentalRepository(); // ★★★ Repository 인스턴스 생성 ★★★

            // --- 이벤트 구독 ---
            _view.PopupLoaded += OnPopupLoaded;
            _view.SaveClicked += OnSaveClicked;
            _view.CheckUserClicked += OnCheckUserClicked;
            _view.UserPhoneTextChanged += OnUserPhoneTextChanged;
        }

        /// <summary>
        /// 팝업 폼이 로드될 때 실행되는 메인 로직
        /// </summary>
        private void OnPopupLoaded(object sender, EventArgs e)
        {
            isUserPhoneValidated = false; // 상태 초기화

            if (_rental.Rental_Status == 1) // "대여중" (조회 모드)
            {
                _view.UserPhone = _rental.User_Phone;
                _view.RentalDate = _rental.Rental_Date;
                _view.ReturnDate = _rental.Rental_Return_Date;

                _view.IsDatePickersReadOnly = true;  // 날짜 변경 불가
                _view.IsUserPhoneReadOnly = true;    // 전화번호 변경 불가
                _view.IsRentButtonEnabled = false;   // "대여" 버튼 비활성화
                _view.IsCheckButtonEnabled = false;  // "확인" 버튼 비활성화
            }
            else // "대여가능" (신규 대여 모드)
            {
                _view.UserPhone = "";
                _view.RentalDate = DateTime.Today;
                _view.ReturnDate = DateTime.Today.AddDays(14); // 2주 뒤

                // ★★★ (수정) "대여가능"일 때도 날짜는 ReadOnly로 하라는 이전 요청 반영
                _view.IsDatePickersReadOnly = true;
                _view.IsUserPhoneReadOnly = false;   // 전화번호 입력 가능
                _view.IsRentButtonEnabled = false;   // "대여" 버튼은 비활성화로 시작
                _view.IsCheckButtonEnabled = true;   // "확인" 버튼 활성화
            }
        }

        /// <summary>
        /// "사용자 확인" (btnNumCheck) 버튼 클릭 시 실행되는 로직
        /// --- ★★★ 2. (수정) 탈퇴 회원 확인 로직 추가 ★★★ ---
        /// </summary>
        private void OnCheckUserClicked(object sender, EventArgs e)
        {
            string userPhone = _view.UserPhone;
            if (string.IsNullOrWhiteSpace(userPhone))
            {
                _view.ShowMessage("사용자 번호를 먼저 입력하세요.");
                return;
            }
            try
            {
                // DB에서 사용자 상태 확인 (Repository의 CheckUserStatus 호출)
                UserStatus status = _repository.CheckUserStatus(userPhone);

                switch (status)
                {
                    case UserStatus.Active: // "활성 회원"
                        _view.ShowMessage("확인되었습니다.");
                        isUserPhoneValidated = true;  // 상태를 "확인됨"으로 변경
                        _view.IsRentButtonEnabled = true; // "대여" 버튼 활성화
                        break;

                    case UserStatus.Withdrawn: // "탈퇴한 회원" (요청 사항 1)
                        _view.ShowMessage("탈퇴한 회원입니다. 대여할 수 없습니다.");
                        isUserPhoneValidated = false;
                        _view.IsRentButtonEnabled = false; // "대여" 버튼 비활성화
                        break;

                    case UserStatus.NotFound: // "등록되지 않은 회원"
                    default:
                        _view.ShowMessage("등록되지 않은 사용자 번호입니다.");
                        isUserPhoneValidated = false;
                        _view.IsRentButtonEnabled = false; // "대여" 버튼 비활성화
                        break;
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("사용자 확인 중 오류가 발생했습니다: " + ex.Message);
                isUserPhoneValidated = false;
                _view.IsRentButtonEnabled = false;
            }
        }

        /// <summary>
        /// "대여하기" (btnSave) 버튼 클릭 시 실행되는 로직
        /// --- ★★★ 3. (수정) 대여 권수 제한 로직 추가 ★★★ ---
        /// </summary>
        private void OnSaveClicked(object sender, EventArgs e)
        {
            // 1. "사용자 확인"을 통과했는지 먼저 확인
            if (!isUserPhoneValidated)
            {
                _view.ShowMessage("사용자 번호 확인이 필요합니다.");
                return;
            }

            string userPhone = _view.UserPhone; // View에서 현재 사용자 번호 가져오기

            try
            {
                // --- (로직 추가) 2. 대여 가능 권수 확인 (요청 사항 2) ---
                int currentRentalCount = _repository.CountActiveRentalsByUser(userPhone);

                if (currentRentalCount >= MAX_RENTAL_LIMIT)
                {
                    // 3권 이상이면 대여 불가
                    _view.ShowMessage($"이미 {currentRentalCount}권을 대여중입니다.\n대여는 최대 {MAX_RENTAL_LIMIT}권까지 가능합니다.");
                    return; // 대여 처리 중단
                }
                // --- 로직 추가 완료 ---

                // 3. DB에 저장할 모델 생성
                var modelToCreate = new RentalModel
                {
                    Book_ISBN = _rental.Book_ISBN, // 부모 폼에서 받은 도서 ISBN
                    User_Phone = userPhone,
                    Rental_Status = 1, // 1 = 대여중 상태
                    Rental_Date = _view.RentalDate,
                    Rental_Return_Date = _view.ReturnDate
                };

                // 4. 리포지토리를 통해 DB에 생성
                bool success = _repository.Create(modelToCreate);

                if (success)
                {
                    _view.ShowMessage($"대여 처리가 완료되었습니다. (현재 {currentRentalCount + 1}권 대여중)");
                    _view.CloseView(); // 성공 시 팝업 닫기
                }
                else
                {
                    _view.ShowMessage("대여 처리에 실패했습니다.");
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("오류가 발생했습니다: " + ex.Message);
            }
        }

        /// <summary>
        /// (수정) 사용자 번호 텍스트가 변경될 때마다 호출
        /// </summary>
        private void OnUserPhoneTextChanged(object sender, EventArgs e)
        {
            // "확인"을 받은 상태에서 사용자가 텍스트를 수정하면,
            // "확인" 상태를 무효화하고 "대여" 버튼을 다시 비활성화합니다.
            if (isUserPhoneValidated)
            {
                isUserPhoneValidated = false;
                _view.IsRentButtonEnabled = false;
            }
        }
    }
}