using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.Json.Nodes;

using System.Security.Cryptography;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace Client
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            var webClient = new System.Net.WebClient();
            var json = webClient.DownloadString("https://maksasj.github.io/finite-quest/status.json");

            var jsonObject = JsonNode.Parse(json).AsObject();


            foreach (var realm in jsonObject["realms"].AsArray())
            {
                serverList.Items.Add(realm["realm-name"].ToString());
            }

            serverList.SelectionMode = SelectionMode.One;
            serverList.CheckOnClick = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (serverList.SelectedItems.Count == 0) return;
            if (String.IsNullOrEmpty(UsernameTextBox.Text)) return;
            if (String.IsNullOrEmpty(PasswordTextBox.Text)) return;

            //Lets try to loggin
            var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;

            string token = GetHashString(password);
            token = GetHashString(token + username);
            token = GetHashString(token);

            var response = PGet("http://www.ursina.io/api/login.php?username=" + username + "&token=" + token);

            if ( response.Equals("Success") ) {

            } else {

            }
        }

        public string PGet(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public static string GetHashString(string inputString)
        {
            byte[] plainHash = (new SHA256Managed()).ComputeHash(Encoding.UTF8.GetBytes(inputString));

            string hashValue = BitConverter.ToString(plainHash);

            return hashValue.Replace("-", String.Empty).ToLower();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = serverList.SelectedIndex;
            int count = serverList.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (index != i)
                {
                    serverList.SetItemChecked(i, false);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
