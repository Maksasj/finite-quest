using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class CharacterChooseForm : Form
    {
        public string _character;
        public CharacterChooseForm()
        {
            InitializeComponent();

            var webClient = new System.Net.WebClient();

            var username = "maksasj";

            var response = PGet("http://www.ursina.io/api/get_player_character_list.php?username=" + username);

            var jsonObject = JsonNode.Parse(response).AsObject();

            foreach (var realm in jsonObject.AsObject())
            {
                characterSelectionListBox.Items.Add(realm.Key);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (characterSelectionListBox.SelectedItems.Count == 0) return;

            _character = characterSelectionListBox.GetItemText(characterSelectionListBox.SelectedItem);
            this.Close();
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

        private void characterSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = characterSelectionListBox.SelectedIndex;
            int count = characterSelectionListBox.Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (index != i)
                {
                    characterSelectionListBox.SetItemChecked(i, false);
                }
            }
        }
    }
}
