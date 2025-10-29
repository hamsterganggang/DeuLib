using library_support_system.Presenters;
using library_support_system.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library_support_system
{
    internal static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FontManager.LoadFonts();

            IHomeView view = new HomeView();
            HomePresenter presenter = new HomePresenter(view);
            Application.Run((Form)view); // 똑같은 view 인스턴스 사용!
        }
    }
}
