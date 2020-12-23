using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.ReadLine();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //List<string> a = new List<string> { "烤冷面（大） X1", "烤冷面（小） X1" };
            //List<double> b = new List<double> { 10, 6 };
            //Application.Run(new PayCheck(200,a,b));

            //Application.Run(new UserOrder());

            // Application.Run(new StudentMainWin("171123127"));
            //Application.Run(new StaffMainWin("1900202"));

            Console.ReadLine();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LogIn li = new LogIn();
            li.ShowDialog();
            string ID = li.userID;
            li.Close();
            if (li.DialogResult == DialogResult.Yes)
            {
                Application.Run(new StaffMainWin(ID));
            }
            else if (li.DialogResult == DialogResult.OK)
            {
                Application.Run(new StudentMainWin(ID));
            }
        }
    }
}
/*

//"Data Source=pmptdb;User Id=sa;Password=123456";

*/         