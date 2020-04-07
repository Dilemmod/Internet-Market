using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseLibrary;

namespace InternetMarket
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (M3 db = new M3())
            {
                var queryCustumerInfo = from custInfo in db.CustomersInformations.AsParallel()
                                        where custInfo.UserLoginId== 1
                                        select custInfo;
                List<CustomerInformation> cInfoList = queryCustumerInfo.ToList();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new AccountLoginForm());
                //Application.Run(new CustomerForm(cInfoList[0]));
            }
        }
    }
}
