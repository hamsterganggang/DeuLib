// library_support_system.Presenters/RentalPopupPresenter.cs
using library_support_system.Models;
using library_support_system.Repositories;
using library_support_system.Views;
using System;

namespace library_support_system.Presenters
{
    public class RentalPopupPresenter
    {
        private readonly IRental_Popup _view;
        private readonly RentalModel _rental; // 부모 폼에서 전달받은 모델

        // "사용자 확인" 완료 상태를 저장하는 변수
        private bool isUserPhoneValidated = false;

        public RentalPopupPresenter(IRental_Popup view, RentalModel rental)
        {
            _view = view;
            _rental = rental;

            // 이벤트를 구독 
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
            isUserPhoneValidated = false;

            if (_rental.Rental_Status == 1) // "대여중"
            {
                _view.UserPhone = _rental.User_Phone;
                _view.RentalDate = _rental.Rental_Date;
                _view.ReturnDate = _rental.Rental_Return_Date;

                _view.IsDatePickersReadOnly = true;
                _view.IsUserPhoneReadOnly = true;
                _view.IsRentButtonEnabled = false;
                _view.IsCheckButtonEnabled = false;
            }
            else // "대여가능"
            {
                _view.UserPhone = "";
                _view.RentalDate = DateTime.Today;
                _view.ReturnDate = DateTime.Today.AddDays(14);

                _view.IsDatePickersReadOnly = true;
                _view.IsUserPhoneReadOnly = false;
                _view.IsRentButtonEnabled = false;
                _view.IsCheckButtonEnabled = true;
            }
        }

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
                using (var repo = new RentalRepository())
                {
                    bool userExists = repo.CheckUserExists(userPhone);

                    if (userExists)
                    {
                        _view.ShowMessage("확인되었습니다.");
                        isUserPhoneValidated = true;  // *** 1. 상태를 "확인됨"으로 변경 ***
                        _view.IsRentButtonEnabled = true; // *** 2. "대여" 버튼 활성화 ***
                    }
                    else
                    {
                        _view.ShowMessage("등록되지 않은 사용자 번호입니다.");
                        isUserPhoneValidated = false; // (상태는 여전히 false)
                        _view.IsRentButtonEnabled = false; // (버튼은 여전히 false)
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("사용자 확인 중 오류가 발생했습니다: " + ex.Message);
                isUserPhoneValidated = false;
                _view.IsRentButtonEnabled = false;
            }
        }
        private void OnSaveClicked(object sender, EventArgs e)
        {
            if (!isUserPhoneValidated)
            {
                _view.ShowMessage("사용자 번호 확인이 필요합니다.");
                return;
            }

            try
            {
                // 2. View에서 데이터 수집
                string userPhone = _view.UserPhone;

                // (유효성 검사는 OnCheckUserClicked에서 이미 했으므로 생략 가능)

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
                using (var repo = new RentalRepository())
                {
                    bool success = repo.Create(modelToCreate);

                    if (success)
                    {
                        _view.ShowMessage("대여 처리가 완료되었습니다.");
                        _view.CloseView(); // 성공 시 팝업 닫기
                    }
                    else
                    {
                        _view.ShowMessage("대여 처리에 실패했습니다.");
                    }
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage("오류가 발생했습니다: " + ex.Message);
            }
        }
        private void OnUserPhoneTextChanged(object sender, EventArgs e)
        {
            if (isUserPhoneValidated)
            {
                isUserPhoneValidated = false;
                _view.IsRentButtonEnabled = false;
            }
        }
    }
}