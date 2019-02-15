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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Threading;

namespace GetMembersFromGroups
{
    public partial class GetMembersFromGroups : Form
    {
        public GetMembersFromGroups()
        {
            InitializeComponent();
        }

        private void open_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "Выберите файл";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pathbox.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Auth.LogOut();
            Close();
        }

        private void DisEnb(bool action)
        {
            open.Enabled = action;
            start.Enabled = action;
            logout.Enabled = action;
            pathbox.Enabled = action;
        }

        private void start_Click(object sender, EventArgs e)
        {
            try
            {
                int.Parse(intersectionbox.Text);
            }
            catch
            {
                MessageBox.Show("Значение должно быть целым числом!");
                return;
            }

            string[] readText;
            List<string> ids = new List<string>();
            try
            {
                readText = File.ReadAllLines(pathbox.Text);
                foreach (string a in readText)
                {
                    int i = a.IndexOf("club");
                    if (i == -1)
                    {
                        i = a.IndexOf("public");
                        if (i == -1)
                        {
                            MessageBox.Show("Неправильный формат групп");
                            return;
                        }
                        else
                            i += 6;
                    }
                    else
                        i += 4;

                    ids.Add(a.Substring(i));
                }
            }
            catch
            {
                MessageBox.Show("Считать файл не удалось!");
                return;
            }

            DisEnb(false);

            StreamWriter writer = new StreamWriter("out.txt");

            foreach(var x in GetMembers(ids))
            {
                if(x.Value == int.Parse(intersectionbox.Text))
                {
                    writer.WriteLine(x.Key);
                }
            }
            writer.Close();

            DisEnb(true);
        }

        private SortedDictionary<string, int> GetMembers(List<string> getfromgroups)
        {
            SortedDictionary<string, int> members = new SortedDictionary<string, int>();

            statuslabel1.Text = "Выгрузка участников из групп";

            int[] offset = new int[25];
            bool[] use = new bool[25];
            for (int i = 0; i < 25; i++)
            {
                offset[i] = 0;
                use[i] = false;
            }

            string[] groupids = new string[25];

            int nowmember = 0;
            for (; nowmember < 25 && nowmember < getfromgroups.Count(); nowmember++)
            {
                groupids[nowmember] = getfromgroups[nowmember];
                use[nowmember] = true;
            }



            string code = "";
            bool again = false;
            int finished = 0;

            while (finished < getfromgroups.Count())
            {
                statuslabel2.Text = finished + " из " + getfromgroups.Count() + " групп";
                progressBar1.Value = finished * 100 / getfromgroups.Count();
                Application.DoEvents();

                if (!again)
                {
                    code = "";
                    for (int i = 0; i < 25; i++)
                    {
                        if (use[i])
                            code += String.Format($"var {(char)(i + 'a')}=API.groups.getMembers(") + "{" + String.Format($"\"group_id\":\"{groupids[i]}\",\"offset\":\"{offset[i] * 1000}\",\"count\":\"1000\"") + "});";
                        offset[i]++;
                    }

                    code += "return [";

                    for (int i = 0; i < 25; i++)
                    {
                        if (use[i])
                            code += (char)(i + 'a') + ",";
                    }

                    code += "];";
                }

                again = false;
                string got = get("https://api.vk.com/method/execute?code=" + code + "&access_token=" + Prog.Token + "&v=" + Prog.Version).ToString();


                string save = got;
                got = got.Substring(12);
                try
                {
                    got = got.Remove(got.IndexOf(",\"execute_errors\""));
                }
                catch { }

                while (got.IndexOf("false") != -1)
                {
                    got = got.Replace("false", "{\"count\":0,\"items\":[]}");
                }


                MembersResponse[] membersResponses;
                try
                {
                    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(got)))
                    {
                        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(MembersResponse[]));
                        membersResponses = (MembersResponse[])jsonFormatter.ReadObject(ms);
                    }
                }
                catch
                {
                    /*ErrorResponse error;
                    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes("[" + save + "]")))
                    {
                        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(ErrorResponse));
                        error = (ErrorResponse)jsonFormatter.ReadObject(ms);
                    }*/

                    int s = save.IndexOf("{\"error\":{\"error_code\":6,\"error_msg");
                    if (s == 0)
                    {
                        Thread.Sleep(500);
                    }

                    again = true;
                    continue;
                }

                for (int i = 0, j = 0; i < 25; i++, j++)
                {
                    for (; j < 25 && !use[j]; j++) ;

                    if (j == 25)
                        break;

                    foreach (int ids in membersResponses[i].items)
                    {
                        if (members.ContainsKey(ids.ToString()))
                        {
                            members[ids.ToString()]++;
                        }
                        else
                        {
                            members.Add(ids.ToString(), 1);
                        }
                    }

                    if (membersResponses[i].items.Count() < 1000)
                    {
                        finished++;
                        offset[j] = 0;
                        if (nowmember == getfromgroups.Count())
                        {
                            use[j] = false;
                        }
                        else
                        {
                            groupids[j] = getfromgroups[nowmember];
                            nowmember++;
                        }
                    }
                }
            }

            statuslabel1.Text = "";
            statuslabel2.Text = "Участники были выгружены";
            progressBar1.Value = 100;

            return members;
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

        private void statuslabel1_TextChanged(object sender, EventArgs e)
        {
            //statuslabel1.Left = this.Width / 2 - statuslabel1.Width / 2;
            Application.DoEvents();
        }

        private void statuslabel2_TextChanged(object sender, EventArgs e)
        {
            statuslabel2.Left = this.Width / 2 - statuslabel2.Width / 2;
            Application.DoEvents();
        }
    }
}
