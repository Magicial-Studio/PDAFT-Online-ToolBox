using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace PDAFT_Online_ToolBox
{
    public partial class ToolBox : Form
    {
        public ToolBox()
        {
            InitializeComponent();
        }

        private readonly FileIniDataParser _iniParser = new FileIniDataParser
        {
            Parser = {Configuration = {CommentString = "#"}}
        };

        private readonly FileIniDataParser _segatoolsIniParser = new FileIniDataParser
        {
            Parser = {Configuration = {CommentString = ";"}}
        };

        private IniData _components;
        private IniData _graphics;
        private IniData _config;
        private IniData _segatools;

        private async void ToolBox_Load(object sender, EventArgs e)
        {
            Directory.SetCurrentDirectory(Application.StartupPath);
            if (!File.Exists("diva.exe"))
            {
                var openFileDialog = new OpenFileDialog
                {
                    Title = "选择 diva.exe",
                    Filter = "diva.exe|diva.exe"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Directory.SetCurrentDirectory(Path.GetDirectoryName(openFileDialog.FileName));
                }
                else
                {
                    Close();
                    Application.Exit();
                    return;
                }
            }

            try
            {
                _components = _iniParser.ReadFile("plugins\\components.ini");
                if (File.Exists("plugins\\DivaImGui.dva")) _graphics = _iniParser.ReadFile("plugins\\graphics.ini");
                _config = _iniParser.ReadFile("plugins\\config.ini");
                _segatools = _segatoolsIniParser.ReadFile("segatools.ini");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "在读取配置文件时发生错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                Application.Exit();
                return;
            }

            TAACheckBox.Checked = _config["Graphics"]["TAA"] == "1";
            MLAACheckBox.Checked = _config["Graphics"]["MLAA"] == "1";
            if (File.Exists("plugins\\DivaImGui.dva"))
            {
                DirectXCheckBox.Checked = _graphics.Global["dxgi"] == "1";
                UpdateGraphicsAPIStatusLabel();
            }
            else
            {
                DirectXCheckBox.Visible = false;
                GraphicsAPIStatusLabel.Visible = false;
            }

            IRCheck.Checked = _config["Resolution"]["r.Enable"] == "1";

            // var Speed = int.Parse(_components["components"]["fast_loader_speed"]);

            HeightTextBox.Text = _config["Resolution"]["Height"];
            WidthTextBox.Text = _config["Resolution"]["Width"];
            RHeightTextBox.Text = _config["Resolution"]["r.Height"];
            RWidthTextBox.Text = _config["Resolution"]["r.Width"];

            PlayerDataManagerCheckBox.Checked = _components["components"]["player_data_manager"] == "true";
            ScoreSaverCheckBox.Checked = _components["components"]["score_saver"] == "true";
            FastLoaderCheckBox.Checked = _components["components"]["fast_loader"] == "true";

            StageManagerCheckBox.Checked = _components["components"]["stage_manager"] == "true";

            UsePDLoaderButton.Text = !File.Exists("plugins\\Launcher.dva") ? "启用PD-Loader" : "禁用PD-Loader";

            GameServerTextBox.Text = _segatools["dns"]["default"];

            DisplayModeComboBox.SelectedIndex = int.TryParse(_config["Resolution"]["Display"], out var display) ? display : 0;

            var subnet = _segatools["keychip"]["subnet"];
            SubnetTextBox.Text = subnet;
            //await Task.Run(() => CheckForUpdates(true));
            //CheckForUpdates((true));

            await Task.Run(() =>
            {
                try
                {
                    var bytes = Utils.BestLocalEndPoint(new IPEndPoint(0x72727272, 53)).Address.GetAddressBytes();
                    bytes[3] = 0;
                    var testedSubnet = new IPAddress(bytes).ToString();

                    if (!subnet.Equals(testedSubnet))
                        BeginInvoke(new Action(() => SubnetTextBox.Text = testedSubnet));
                }
                catch
                {
                    BeginInvoke(new Action(() => SubnetTextBox.Text = "192.168.0.0"));
                }
            });
        }

        private void UpdateGraphicsAPIStatusLabel()
        {
            GraphicsAPIStatusLabel.Text = $"Graphics API -- {(DirectXCheckBox.Checked ? "DirectX 11" : "OpenGL")}";
        }

        private void ClearDNSButton_Click(object sender, EventArgs e)
        {
            NativeMethods.FlushDNSResolverCache();
        }

        private void LaunchDivaButton_Click(object sender, EventArgs e)
        {
            if (ScoreSaverCheckBox.Checked || StageManagerCheckBox.Checked || PlayerDataManagerCheckBox.Checked)
            {
                var str = "PDAFT Launcher 模块检测到";
                if (ScoreSaverCheckBox.Checked) str += "Score Saver/";
                if (StageManagerCheckBox.Checked) str += "Stage Manager/";
                if (PlayerDataManagerCheckBox.Checked) str += "Player Data Manager/";
                str = str.Remove(str.Length - 1, 1);
                str += " 已被启用,这些功能可能会与 SegaTools 联网功能产生冲突，是否继续启动？";
                if (MessageBox.Show(str, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) !=
                    DialogResult.Yes) return;
            }

            foreach (var process in Process.GetProcessesByName("diva"))
            {
                try
                {
                    process.Kill();
                }
                catch
                {
                    // ignored
                }
            }

            Process.Start(new ProcessStartInfo
            {
                //设置运行文件 
                FileName = "inject.exe",
                //设置启动动作,确保以管理员身份运行 
                Verb = "runas",
                Arguments = "-d -k divahook.dll diva.exe --launch"
            }); //启动diva.exe
        }

        private void WebUIButton_Click(object sender, EventArgs e)
        {
            Process.Start("http://aqua.raspberrymonster.top/");
        }

        private void DeleteAccountButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认删除账号?", "", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            if (File.Exists("DEVICE\\felica.txt"))
            {
                File.Delete("DEVICE\\felica.txt");
            }

            if (File.Exists("DEVICE\\sram.bin"))
            {
                File.Delete("DEVICE\\sram.bin");
            }
        }

        private void UsePDLoaderButton_Click(object sender, EventArgs e)
        {
            switch (UsePDLoaderButton.Text)
            {
                case "启用PD-Loader":
                    File.Move("Launcher.dva", "plugins\\Launcher.dva");
                    UsePDLoaderButton.Text = "禁用PD-Loader";
                    break;
                case "禁用PD-Loader":
                    File.Move("plugins\\Launcher.dva", "Launcher.dva");
                    UsePDLoaderButton.Text = "启用PD-Loader";
                    break;
            }
        }

        private void FastLoaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _components["components"]["fast_loader"] = FastLoaderCheckBox.Checked.ToString().ToLowerInvariant();
            if (FastLoaderCheckBox.Checked) _components["components"]["fast_loader_speed"] = "4";
            _iniParser.WriteFile("plugins\\components.ini", _components,Encoding.Default);
        }

        private void ScoreSaverCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _components["components"]["score_saver"] = ScoreSaverCheckBox.Checked.ToString().ToLowerInvariant();
            _iniParser.WriteFile("plugins\\components.ini", _components,Encoding.Default);
        }

        private void PlayerDataManagerCheckBox_Click(object sender, EventArgs e)
        {
            _components["components"]["player_data_manager"] = PlayerDataManagerCheckBox.Checked.ToString().ToLowerInvariant();
            _iniParser.WriteFile("plugins\\components.ini", _components,Encoding.Default);
        }

        private void StageManagerCheckBox_Click(object sender, EventArgs e)
        {
            _components["components"]["stage_manager"] = StageManagerCheckBox.Checked.ToString().ToLowerInvariant();
            _iniParser.WriteFile("plugins\\components.ini", _components,Encoding.Default);
        }

        private void SaveGameServerButton_Click(object sender, EventArgs e)
        {
            _segatools["dns"]["default"] = GameServerTextBox.Text;
            _segatools["keychip"]["subnet"] = SubnetTextBox.Text;
            _segatoolsIniParser.WriteFile("segatools.ini", _segatools,Encoding.Default);
        }

        private void SaveGraphicsButton_Click(object sender, EventArgs e)
        {
            _config["Graphics"]["TAA"] = (TAACheckBox.Checked ? 1 : 0).ToString();
            _config["Graphics"]["MLAA"] = (MLAACheckBox.Checked ? 1 : 0).ToString();
            _graphics.Global["dxgi"] = (DirectXCheckBox.Checked ? 1 : 0).ToString();
            UpdateGraphicsAPIStatusLabel();
            _config["Resolution"]["Height"] = HeightTextBox.Text;
            _config["Resolution"]["Width"] = WidthTextBox.Text;
            _config["Resolution"]["r.Enable"] = (IRCheck.Checked ? 1 : 0).ToString();
            _config["Resolution"]["r.Height"] = RHeightTextBox.Text;
            _config["Resolution"]["r.Width"] = RWidthTextBox.Text;
            RHeightTextBox.Enabled = RWidthTextBox.Enabled = IRCheck.Checked;
            _config["Resolution"]["Display"] = DisplayModeComboBox.SelectedIndex.ToString();

            _iniParser.WriteFile("plugins\\config.ini", _config,Encoding.Default);
            _iniParser.WriteFile("plugins\\graphics.ini", _graphics,Encoding.Default);
        }

        private void CheckForUpdates(bool notifyOnFail)
        {
            if (Program.UnstableVersion)
            {
                CheckForUpdateLabel.Text = "测试版本:Version " + Program.Version;
                CheckForUpdateLabel.Enabled = false;
            }
            else
            {
                try
                {
                    using (var client = new WebClient())
                    {
                        client.Headers.Add("user-agent", Program.Name);
                        string response = client.DownloadString("https://api.github.com/repos/Magicial-Studio/PDAFT-Online-Toolbox/releases/latest");

                        // yes this is pure crackheadery
                        // no I won't use a json library

                        int index = response.IndexOf("tag_name", StringComparison.OrdinalIgnoreCase);

                        int firstIndex = response.IndexOf(':', index + 8);
                        int lastIndex = response.IndexOf(',', firstIndex + 1);

                        string tagName = Program.FixUpVersionString(response.Substring(firstIndex + 1, lastIndex - firstIndex - 1).Trim('"', ',', 'v', ' '));

                        if (tagName != Program.Version)
                        {
                            CheckForUpdateLabel.Text = "需要更新 最新版本： " + tagName;
                            Program.UpdateCheckedSucceed = true;
                        }

                        else if (notifyOnFail)
                        {
                            CheckForUpdateLabel.Text = "已为最新:Version " + tagName;
                            CheckForUpdateLabel.Enabled = false;
                            Program.UpdateCheckedSucceed = true;
                        }
                    }
                }

                catch
                {
                    if (!notifyOnFail)
                        return;
                    CheckForUpdateLabel.Text = "更新检查失败";
                }
            }
        }

        private void CheckForUpdateLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Program.UpdateCheckedSucceed) Process.Start("https://github.com/Magicial-Studio/PDAFT-Online-Toolbox/releases");
            else CheckForUpdates(true);
        }

        private void LaunchMdataManager_Click(object sender, EventArgs e)
        {
            MdataManager LaunchMdataManager = new MdataManager();
            LaunchMdataManager.Show();

        }
    }
}