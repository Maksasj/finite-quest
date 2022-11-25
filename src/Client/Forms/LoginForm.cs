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

using Client.Utils;

namespace Client
{
    public partial class LoginForm : Form
    {
        public string _username;
        public string _token;

        public bool _done = false;

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
            if (serverList.SelectedItems.Count == 0)
            {
                pleaseTryAgainLabel.Visible = true;
                return;
            }


            if (String.IsNullOrEmpty(UsernameTextBox.Text))
            {
                pleaseTryAgainLabel.Visible = true;
                return;
            }
            if (String.IsNullOrEmpty(PasswordTextBox.Text))
            {
                pleaseTryAgainLabel.Visible = true;
                return;
            }

                //Lets try to loggin
                var username = UsernameTextBox.Text;
            var password = PasswordTextBox.Text;

            string token = Hash.hash256(password);
            token = Hash.hash256(token + username);
            token = Hash.hash256(token);

            var response = GetRequest.get("http://www.ursina.io/api/login.php?username=" + username + "&token=" + token);

            if ( response.Equals("Success") ) {
                _username = username;
                _token = token;
                _done = true;
                this.Close();
            } else {
                pleaseTryAgainLabel.Visible = true;
                return;
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Maksasj/finite-quest");
        }

        private void pleaseTryAgainLabel_Click(object sender, EventArgs e)
        {
        }
    }
}
