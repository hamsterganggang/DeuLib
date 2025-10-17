using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using library_support_system.Models;

namespace library_support_system.Views
{
    public interface IHome_Search
    {
        //1
        #region Properties
        string SearchText { get; }
        bool SearchButtonEnabled { set; }
        #endregion

        #region Events
        event EventHandler SearchButtonClick;
        event EventHandler SearchTextChanged;
        event EventHandler SearchKeyDown;
        #endregion

        #region Methods
        void ShowMessage(string message, string title, MessageBoxIcon icon);
        void NavigateToBookCheck();
        void ClearSearchText();
        void SetSearchButtonStyle(bool enabled);
        #endregion
    }
}