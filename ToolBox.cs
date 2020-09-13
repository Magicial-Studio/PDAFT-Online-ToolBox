using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;

namespace AFT_Online_Stater
{
    public partial class ToolBox : Form
    {
        public ToolBox()
        {
            InitializeComponent();
        }

        private readonly FileIniDataParser _iniParser = new FileIniDataParser()
        {
            Parser = {Configuration = {CommentString = "#"}}
        };

        private readonly FileIniDataParser _segatoolsIniParser = new FileIniDataParser()
        {
            Parser = {Configuration = {CommentString = ";"}}
        };

        private IniData _components;
        private IniData _graphics;
        private IniData _config;
        private IniData _segatools;

        private void ToolBox_Load(object sender, EventArgs e)
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
                _graphics = _iniParser.ReadFile("plugins\\graphics.ini");
                _config = _iniParser.ReadFile("plugins\\config.ini");
                _segatools = _segatoolsIniParser.ReadFile("segatools.ini");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                Application.Exit();
                return;
            }

            TAACheckBox.Checked = _config["Graphics"]["TAA"] == "1";
            MLAACheckBox.Checked = _config["Graphics"]["MLAA"] == "1";

            DirectXCheckBox.Checked = _graphics.Global["dxgi"] == "1";
            UpdateGraphicsAPIStatusLabel();

            IRCheck.Checked = _config["Resolution"]["r.Enable"] == "1";
            IRCheck_CheckedChanged(null, null);

            // var Speed = int.Parse(_components["components"]["fast_loader_speed"]);

            HeightTextBox.Text = _config["Resolution"]["Height"];
            WidthTextBox.Text = _config["Resolution"]["Width"];
            RHeightTextBox.Text = _config["Resolution"]["r.Height"];
            RWidthTextBox.Text = _config["Resolution"]["r.Width"];

            PlayerDataManagerCheckBox.Checked = _components["components"]["player_data_manager"] == "true";
            ScoreSaverCheckBox.Checked = _components["components"]["score_saver"] == "true";
            FastLoaderCheckBox.Checked = _components["components"]["fast_loader"] == "true";

            StageManagerCheckBox.Checked = _components["components"]["stage_manager"] == "true";

            LaunchPDButton.Text = !File.Exists("plugins\\Launcher.dva") ? "启用PD-Loader" : "禁用PD-Loader";

            GameServerTextBox.Text = _segatools["dns"]["default"];
        }

        private void UpdateGraphicsAPIStatusLabel()
        {
            GraphicsAPIStatusLabel.Text = $"Graphics API -- {(DirectXCheckBox.Checked ? "DirectX 11" : "OpenGL")}";
        }

        private void ClearDNS_Click(object sender, EventArgs e)
        {
            NativeMethods.FlushDNSResolverCache();
        }

        private void LaunchDivaButton_Click(object sender, EventArgs e)
        {
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

        private void WebUI_Click(object sender, EventArgs e)
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

        private void LaunchPDButton_Click(object sender, EventArgs e)
        {
            switch (LaunchPDButton.Text)
            {
                case "启用PD-Loader":
                    File.Move("Launcher.dva", "plugins\\Launcher.dva");
                    LaunchPDButton.Text = "禁用PD-Loader";
                    break;
                case "禁用PD-Loader":
                    File.Move("plugins\\Launcher.dva", "Launcher.dva");
                    LaunchPDButton.Text = "启用PD-Loader";
                    break;
            }
        }

        private void FastLoaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _components["components"]["fast_loader"] = FastLoaderCheckBox.Checked.ToString().ToLowerInvariant();
            // _components["components"]["fast_loader_speed"] = "4";
            _iniParser.WriteFile("plugins\\components.ini", _components);
        }

        private void ScoreSaverCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _components["components"]["score_saver"] = ScoreSaverCheckBox.Checked.ToString().ToLowerInvariant();
            _iniParser.WriteFile("plugins\\components.ini", _components);
        }

        private void Player_Click(object sender, EventArgs e)
        {
            _components["components"]["player_data_manager"] = PlayerDataManagerCheckBox.Checked.ToString().ToLowerInvariant();
            _iniParser.WriteFile("plugins\\components.ini", _components);
        }

        private void Stage_Click(object sender, EventArgs e)
        {
            _components["components"]["stage_manager"] = StageManagerCheckBox.Checked.ToString().ToLowerInvariant();
            _iniParser.WriteFile("plugins\\components.ini", _components);
        }

        private void SaveGameServerButton_Click(object sender, EventArgs e)
        {
            _segatools["dns"]["default"] = GameServerTextBox.Text;
            _segatoolsIniParser.WriteFile("segatools.ini", _segatools);
        }

        private void TAACheckBox_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void MLAACheck_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void SaveGraphics_Click(object sender, EventArgs e)
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

            _iniParser.WriteFile("plugins\\config.ini", _config);
            _iniParser.WriteFile("plugins\\graphics.ini", _graphics);
        }

        private void IRCheck_CheckedChanged(object sender, EventArgs e)
        {
            RHeightTextBox.Enabled = RWidthTextBox.Enabled = IRCheck.Checked;
        }
    }
}