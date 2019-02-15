using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetMembersFromGroups
{
    static class Prog
    {
        public static string Token = "", User_Id, Version = "5.80", NameOfApp = "GetMembersFromGroups";
        public static bool again;
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            again = true;
            while (again)
            {
                again = false;
                Application.Run(new Auth());
                if (Prog.Token == "")
                    return;
                Application.Run(new GetMembersFromGroups());
            }
        }
    }
}
