using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GetMembersFromGroups
{
    public partial class Auth : Form
    {

        public Auth()
        {
            InitializeComponent();
        }

        public static void LogOut()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Prog.NameOfApp + "\\pass";
            Prog.Token = "";
            StreamWriter write = new StreamWriter(path);
            write.WriteLine(Prog.Token);
            write.WriteLine(Prog.User_Id);
            write.Close();
            Prog.again = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string t = webBrowser1.Url.ToString();
            int ti = t.IndexOf("https://oauth.vk.com/blank.html#access_token=");
            int terr = t.IndexOf("https://oauth.vk.com/blank.html#error=access_denied&error_reason=user_denied");
            if(terr == 0)
            {
                Close();
            }
            if (ti == 0)
            {
                ti += "https://oauth.vk.com/blank.html#access_token=".Length;
                Prog.Token = "";
                for (; t[ti] != '&'; ti++)
                {
                    Prog.Token += t[ti];
                }
                ti = t.IndexOf("user_id=") + "user_id=".Length;
                Prog.User_Id = "";
                for (; ti < t.Length; ti++)
                {
                    Prog.User_Id += t[ti];
                }
                string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Prog.NameOfApp;
                if (Directory.Exists(path) == false)
                    Directory.CreateDirectory(path);
                path += "\\pass";
                StreamWriter write = new StreamWriter(path);
                write.WriteLine(Prog.Token);
                write.WriteLine(Prog.User_Id);
                write.Close();
                Close();
            }
        }

        bool check()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\" + Prog.NameOfApp + "\\pass";
            try
            {
                StreamReader read = new StreamReader(path);
                Prog.Token = read.ReadLine();
                Prog.User_Id = read.ReadLine();
                read.Close();
            }
            catch
            {
                return false;
            }
            string got = get("https://api.vk.com/method/groups.get?user_id=" + Prog.User_Id + "&access_token=" + Prog.Token + "&v=" + Prog.Version).ToString();
            int ind = got.IndexOf("error_code");
            if (ind == -1)
                return true;
            else
                return false;
        }

        private static string get(string Url)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            if (check())
                Close();
            else
                webBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=5155001&redirect_uri=https://oauth.vk.com/blank.html&display=popup&response_type=token&revoke=1");
        }
    }
}
