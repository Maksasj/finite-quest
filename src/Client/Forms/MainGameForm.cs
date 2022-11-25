using Client.Utils;
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

namespace Client.Forms
{
    public partial class MainGameForm : Form
    {
        public string _username;
        public string _token;   
        public string _character;

        public long _poiCooldown;
        public List<string> _poiLogTmp = new List<string>();

        public long _xp;
        public long _xpUntilNext;

        public bool _autoAction = false;

        Dictionary<string, string> _activePOIs = new Dictionary<string, string>();
        Dictionary<string, string> _activeEquipment = new Dictionary<string, string>();

        public MainGameForm(string username, string token, string character)
        {
            InitializeComponent();

            _username = username;
            _token = token;
            _character = character;

            nameLabel.Text = character;

            var response = GetRequest.get("http://ursina.io/api/get_character.php?character=" + _character);
            var jsonObject = JsonNode.Parse(response).AsObject();
            _poiCooldown = (long) Convert.ToInt64(jsonObject["timestamps"]["activity_cooldown"].ToString());

            updateGeneral();
            updateStats();
            updateInventory();
            updatePOI();
        }

        public void updateEquipment()
        {
            equipmentList.Items.Clear();

            var response = GetRequest.get("http://ursina.io/api/get_character.php?character=" + _character);
            var jsonObject = JsonNode.Parse(response).AsObject();

            foreach (var element in jsonObject["inventory"]["equipment"].AsObject())
                foreach (var item in element.Value.AsObject())
                {
                    equipmentList.Items.Add(element.Key + ": " + item.Value.AsObject()["name"]);
                    _activeEquipment["type"] = item.Value.AsObject()["name"].ToString();
                    break;
                }
        }

        private void updateInventory()
        {
            inventoryList.Items.Clear();

            var response = GetRequest.get("http://ursina.io/api/get_character.php?character=" + _character);
            var jsonObject = JsonNode.Parse(response).AsObject();

            foreach (var item in jsonObject["inventory"]["bag"].AsObject())
            {
                inventoryList.Items.Add(item.Value["name"] + " x" + item.Value["count"]);
            }
        }

        private void Timer1s(object sender, EventArgs e)
        {
            updateGeneral();
                updateInventory();
                updateEquipment();
            updateStats();

            tryAutoAction();

            updateLogs();
        }

        public void tryAutoAction()
        {
            if (_autoAction == true)
            {   
                //Simply spam attack
                doActivityButtonCallBack(null, null);
            }
        }

        public void updateLogs()
        {
            float delta = (float)clamp(getUnixTime() - _poiCooldown, 0, 5) / 5.0f;
            activityProgressBar.Value = (int)(delta * 100);

            float delta1 = (float)clamp(_xp, 0, _xpUntilNext) / (float)_xpUntilNext;
            experienceProgressBar.Value = (int)(delta1 * 100);

            xpLabel.Text = _xp.ToString() + "/" + _xpUntilNext.ToString();

            if (_poiLogTmp.Count != 0)
            {
                logsList.Items.Add(_poiLogTmp[0]);
                _poiLogTmp.RemoveAt(0);

                logsList.TopIndex = logsList.Items.Count - 1;
            }
        }

        private long clamp(long value, long min, long max)
        {
            if (value < min) return min;
            if (value > max) return max;

            return value;
        }

        public void updatePOI()
        {
            poiList.Items.Clear();
            _activePOIs.Clear();

            var response2 = GetRequest.get("http://ursina.io/api/get_poi.php?character=" + _character);
            var jsonObject2 = JsonNode.Parse(response2).AsObject();

            foreach (var item in jsonObject2["connections"].AsArray())
            {
                poiList.Items.Add(item);
                _activePOIs.Add(item.ToString(), "connections");
            }

            foreach (var item in jsonObject2["gathering"].AsArray())
            {
                poiList.Items.Add(item);
                _activePOIs.Add(item.ToString(), "gathering");

            }

            foreach (var item in jsonObject2["mobs"].AsArray())
            {
                poiList.Items.Add(item);
                _activePOIs.Add(item.ToString(), "mobs");
            }
        }

        public void updateStats()
        {
            statList.Items.Clear();

            var response1 = GetRequest.get("http://ursina.io/api/get_character_stats.php?character=" + _character);
            var jsonObject1 = JsonNode.Parse(response1).AsObject();

            foreach (var item in jsonObject1.AsObject())
            {
                statList.Items.Add(item.Key + " " + item.Value);
            }

            maxHealthLabel.Text = (Convert.ToInt32(jsonObject1["stamina"].ToString()) * 10).ToString();
        }

        public void updateGeneral()
        {
            var response = GetRequest.get("http://ursina.io/api/get_character.php?character=" + _character);
            var jsonObject = JsonNode.Parse(response).AsObject();

            levelLabel.Text = jsonObject["lvl"].ToString();

            _xp = (long)Convert.ToInt64(jsonObject["xp"].ToString());
            _xpUntilNext = (long)Convert.ToInt64(jsonObject["xp_until_next_lvl"].ToString());

            classLabel.Text = jsonObject["class"].ToString();
            raceLabel.Text = jsonObject["race"].ToString();
        }

        private void ClearLogsButton_Click(object sender, EventArgs e)
        {
            logsList.Items.Clear();
        }

        private void poiList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item_id = poiList.SelectedItems[0].ToString();
            var selectedInteresType = _activePOIs[item_id];

            switch (selectedInteresType)
            {
                case "mobs":
                    doActivityButton.Text = "Attack";
                    autoDoActivityButton.Text = "Auto Attack";

                    autoDoActivityButton.Visible = true;
                    break;
                case "gathering":
                    doActivityButton.Text = "Gather";
                    autoDoActivityButton.Text = "Auto Gather";

                    autoDoActivityButton.Visible = true;
                    break;
                case "connections":
                    doActivityButton.Text = "Go to";

                    autoDoActivityButton.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void doActivityButtonCallBack(object sender, EventArgs e)
        {
            if (poiList.SelectedItems.Count == 0) return;
            if (getUnixTime() - _poiCooldown < 0) return;

            var item_id = poiList.SelectedItems[0].ToString();
            var selectedInteresType = _activePOIs[item_id];

            if (selectedInteresType.Equals("mobs"))
            {
                var response = GetRequest.get("http://ursina.io/api/attack_mob.php?username=" + _username + "&token=" + _token + "&character=" + _character + "&mob=" + item_id);

                if (response == "Combat in process") return;
                
                var jsonObject = JsonNode.Parse(response).AsObject();

                foreach (var value in jsonObject["logs"].AsArray())
                {
                    if (value["status"].ToString() == "in_process")
                    {
                        _poiLogTmp.Add(value["damage_dealer"].ToString() + " dealed " + value["damage"].ToString());
                    } else
                    {
                        _poiLogTmp.Add(value["damage_dealer"].ToString() + " dealed final blow with " + value["damage"].ToString());
                    }



                }

                _poiCooldown = (long) Convert.ToInt64(jsonObject["result"]["time"].ToString());
            }
        }

        private long getUnixTime()
        {
            DateTime foo = DateTime.Now;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            return unixTime;
        }

        private void Timer01s(object sender, EventArgs e)
        {
        }

        private void autoDoActivityButtonCallBack(object sender, EventArgs e)
        {
            if(_autoAction == true)
            {
                _autoAction = false;
                doActivityButton.Visible = true;
                return;
            }

            if (_autoAction == false)
            {
                _autoAction = true;
                doActivityButton.Visible = false;
                return;
            }
        }
    }
}
 