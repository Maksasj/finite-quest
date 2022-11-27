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

        public long _poiStartCooldown = 0;
        public long _poiFinishCooldown = 0;
        public List<string> _poiLogTmp = new List<string>();

        public long _xp;
        public long _xpUntilNext;

        public bool _autoAction = false;

        Dictionary<string, string> _activePOIsTypes = new Dictionary<string, string>();
        Dictionary<string, string> _activePOIsIds = new Dictionary<string, string>();
        Dictionary<string, string> _activeEquipment = new Dictionary<string, string>();

        Dictionary<string, string> _activeInventoryIds = new Dictionary<string, string>();

        public MainGameForm(string username, string token, string character)
        {
            InitializeComponent();

            _username = username;
            _token = token;
            _character = character;

            nameLabel.Text = character;

            _poiStartCooldown = 0;
            _poiFinishCooldown = 0;

            var response = GetRequest.get("http://ursina.io/api/get_character.php?character=" + _character);
            var jsonObject = JsonNode.Parse(response).AsObject();
            _poiStartCooldown = (long) Convert.ToInt64(jsonObject["timestamps"]["activity_cooldown"].ToString());

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
            _activeInventoryIds.Clear();

            var response = GetRequest.get("http://ursina.io/api/get_character.php?character=" + _character);
            var jsonObject = JsonNode.Parse(response).AsObject();

            foreach (var item in jsonObject["inventory"]["bag"].AsObject())
            {
                _activeInventoryIds.Add(item.Value["name"].ToString(), item.Key.ToString());
                inventoryList.Items.Add(item.Value["name"].ToString());
            }
        }

        private void Timer1s(object sender, EventArgs e)
        {
            updateGeneral();
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

        public KeyValuePair<string, Brush> getColoredListElement(string text, Brush color)
        {
            return new KeyValuePair<string, Brush>(text, color);
        }

        public void updatePOI()
        {
            poiList.Items.Clear();
            _activePOIsIds.Clear();
            _activePOIsTypes.Clear();

            var response2 = GetRequest.get("http://ursina.io/api/get_poi.php?character=" + _character);
            var jsonObject2 = JsonNode.Parse(response2).AsObject();

            foreach (var item in jsonObject2["connections"].AsObject())
            {
                poiList.Items.Add(getColoredListElement(item.Value.ToString(), Brushes.Blue));
                _activePOIsTypes.Add(item.Key.ToString(), "connections");
                _activePOIsIds.Add(item.Value.ToString(), item.Key.ToString());
            }

            foreach (var item in jsonObject2["gathering"].AsObject())
            {
                poiList.Items.Add(getColoredListElement(item.Value.ToString(), Brushes.Green));
                _activePOIsTypes.Add(item.Key.ToString(), "gathering");
                _activePOIsIds.Add(item.Value.ToString(), item.Key.ToString());
            }

            foreach (var item in jsonObject2["mobs"].AsObject())
            {
                poiList.Items.Add(getColoredListElement(item.Value.ToString(), Brushes.Red));
                _activePOIsTypes.Add(item.Key.ToString(), "mobs");
                _activePOIsIds.Add(item.Value.ToString(), item.Key.ToString());
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var text = ((KeyValuePair<string, Brush>)poiList.Items[e.Index]).Key;
            var color = ((KeyValuePair<string, Brush>)poiList.Items[e.Index]).Value;

            e.DrawBackground();
            e.Graphics.DrawString(text, poiList.Font, color, e.Bounds);
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
            goldLabel.Text = jsonObject["gold"].ToString();

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
            var item_name = ((KeyValuePair<string, Brush>)poiList.SelectedItems[0]).Key;
            var item_id = _activePOIsIds[item_name];
            var selectedInteresType = _activePOIsTypes[item_id];

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
            if (getUnixTimeInSeconds() - _poiStartCooldown < 0) return;
            
            var item_name = ((KeyValuePair<string, Brush>)poiList.SelectedItems[0]).Key;
            var item_id = _activePOIsIds[item_name];
            var selectedInteresType = _activePOIsTypes[item_id];

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

                _poiStartCooldown = (long) Convert.ToInt64(jsonObject["result"]["start_time"].ToString());
                _poiFinishCooldown = (long) Convert.ToInt64(jsonObject["result"]["finish_time"].ToString());
            } else if(selectedInteresType.Equals("connections"))
            {
                var response = GetRequest.get("http://ursina.io/api/go_to.php?username=" + _username + "&token=" + _token + "&character=" + _character + "&target=" + item_id);

                if (response == "Such place is not connected to current location") return;
                if (response == "Traveling in process") return;

                var jsonObject = JsonNode.Parse(response).AsObject();

                _poiStartCooldown = (long)Convert.ToInt64(jsonObject["result"]["start_time"].ToString());
                _poiFinishCooldown = (long)Convert.ToInt64(jsonObject["result"]["finish_time"].ToString());
                
                updatePOI();
            }


            updateInventory();
        }

        private long getUnixTimeInSeconds()
        {
            DateTime foo = DateTime.Now;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeSeconds();
            return unixTime;
        }

        private long getUnixTimeInMilliseconds()
        {
            DateTime foo = DateTime.Now;
            long unixTime = ((DateTimeOffset)foo).ToUnixTimeMilliseconds();
            return unixTime;
        }

        private void Timer01s(object sender, EventArgs e)
        {
            long time_eclapsed = _poiFinishCooldown - _poiStartCooldown;
            long long_delta = (getUnixTimeInMilliseconds() - _poiStartCooldown * 1000);

            float delta = (float) clamp(long_delta, 0, time_eclapsed*1000) / ((float) time_eclapsed*1000);
            activityProgressBar.Value = (int)(delta * 100);
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

        private void equipButton_Click(object sender, EventArgs e)
        {
            if (inventoryList.SelectedItems.Count == 0) return;

            var selectedItem = inventoryList.SelectedItems[0].ToString();
            var selectedItemId = _activeInventoryIds[selectedItem];

            var response = GetRequest.get("http://ursina.io/api/equip.php?username=" + _username + "&token=" + _token + "&character=" + _character + "&target=" + selectedItemId);

            updateInventory();
            updateEquipment();
            updateGeneral();
            //Debug.WriteLine(selectedItemId);
        }
    }
}
 