using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace AFT_Online_Stater
{
    public partial class ToolBox : Form
    {
        public ToolBox()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Logs.AppendText("正在启动Project DIVA Arcade Future Tone" + Environment.NewLine);
            //创建启动对象 
            ProcessStartInfo StartAFT = new ProcessStartInfo
            {
                //设置运行文件 
                FileName = "inject.exe",
                //设置启动动作,确保以管理员身份运行 
                Verb = "runas",
                Arguments = "-d -k divahook.dll diva.exe --launch"
            };
            //如果不是管理员，则启动UAC

            Process[] pro = Process.GetProcesses();//获取已开启的所有进程

            //遍历所有查找到的进程

            for (int i = 0; i < pro.Length; i++)
            {

                //判断此进程是否是要查找的进程
                if (pro[i].ProcessName.ToLower() == "diva")
                {
                    pro[i].Kill();//结束进程
                }
            }
            Process.Start(StartAFT);//启动diva.exe

        }

        private void ClearDNS_Click(object sender, EventArgs e)
        {
            Logs.AppendText("开始刷新DNS缓存" + Environment.NewLine);
            string str = "ipconfig /flushdns";
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&&exit");
            p.StandardInput.AutoFlush = true;

            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();
            Logs.AppendText(output + Environment.NewLine);
        }

        private void Web_Click(object sender, EventArgs e)
        {
            Logs.AppendText("网页管理界面已打开" + Environment.NewLine);
            Process.Start("http://aqua.raspberrymonster.top/");
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Logs.AppendText("开始删除卡号文件" + Environment.NewLine);
            if (File.Exists(Directory.GetCurrentDirectory() + @"\device\felica.txt") && File.Exists(Directory.GetCurrentDirectory() + "\\device\\sram.bin"))
            {
                File.Delete(Directory.GetCurrentDirectory() + @"\device\felica.txt");
                File.Delete(Directory.GetCurrentDirectory() + @"\device\sram.bin");
                Logs.AppendText("卡号文件删除成功" + Environment.NewLine);
            }
            //else Logs.Text = Logs.Text + Environment.NewLine + "卡号文件删除失败:不存在felica.txt或者sram.bin";
            else Logs.AppendText("卡号已删除" + Environment.NewLine);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "启用PD-Loader")
            {
                File.Move("Launcher.dva", @"plugins\Launcher.dva");
                button1.Text = "禁用PD-Loader";
                Logs.AppendText("已启用PD-Loader" + Environment.NewLine);
            }
            else if (button1.Text == "禁用PD-Loader")
            {
                File.Move(@"plugins\Launcher.dva", "Launcher.dva");
                button1.Text = "启用PD-Loader";
                Logs.AppendText("已禁用PD-Loader" + Environment.NewLine);
            }
        }

        private void ToolBox_Load(object sender, EventArgs e)
        {
            Logs.AppendText("当前目录:  " + Directory.GetCurrentDirectory() + Environment.NewLine);
            Logs.AppendText("插件目录:  " + Directory.GetCurrentDirectory() + @"\plugins" + Environment.NewLine);
            StreamReader Components = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            StreamReader Graphics = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\graphics.ini");
            StreamReader Resolution = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
            StreamReader Config = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
            StreamReader Gameserver = new StreamReader(Directory.GetCurrentDirectory() + @"\segatools.ini");
            StreamReader GetGameserver = new StreamReader(Directory.GetCurrentDirectory() + @"\segatools.ini");
            StreamReader ReadFL = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            StreamReader GetFL = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            StreamReader GetResolution = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
            string FLReader = "";
            string gconfig = Config.ReadToEnd();
            string graphics = Graphics.ReadToEnd();
            string config = Components.ReadToEnd();
            string ServerReader = "";
            string ResolutionReader = "";
            Components.Close();
            Graphics.Close();
            Config.Close();
            bool FastC, StageC, PlayerC, ScoreC, DirectXC;
            FastC = false; StageC = false; PlayerC = false; ScoreC = false; DirectXC = false;
            if (gconfig.IndexOf("TAA=1") != -1) TAACheck.Checked = true;
            if (gconfig.IndexOf("MLAA=1") != -1) MLAACheck.Checked = true;
            if (graphics.IndexOf("dxgi = 1") != -1) DirectXC = true;
            if (gconfig.IndexOf("r.Enable=1") != -1) IRCheck.Checked = true;
            if (config.IndexOf("fast_loader =true") != -1) FastC = true;
            while (GetFL.ReadLine() != null)
            {
                FLReader = ReadFL.ReadLine();
                if (FLReader.IndexOf("fast_loader_speed=") != -1)
                {
                    FLReader = FLReader.Replace("fast_loader_speed=", "");
                    break;
                }
            }
            int Speed = 0;
            Speed = Convert.ToInt32(FLReader);
            if (Speed <= 4) FastC = false;
            ReadFL.Close();
            GetFL.Close();
            while (GetResolution.ReadLine() != null)
            {
                ResolutionReader = Resolution.ReadLine();
                if ((ResolutionReader.IndexOf("Width=") != -1) && (ResolutionReader.IndexOf("r.Width=") == -1)) WidthBox.Text = ResolutionReader.Replace("Width=", "");
                if ((ResolutionReader.IndexOf("Height=") != -1) && (ResolutionReader.IndexOf("r.Height=") == -1)) HeightBox.Text = ResolutionReader.Replace("Height=", "");
                if (ResolutionReader.IndexOf("r.Width=") != -1) RWidthBox.Text = ResolutionReader.Replace("r.Width=", "");
                if (ResolutionReader.IndexOf("r.Height=") != -1) RHeightBox.Text = ResolutionReader.Replace("r.Height=", "");
            }
            Resolution.Close();
            GetResolution.Close();
            if (config.IndexOf("stage_manager =true") != -1) StageC = true;
            if (config.IndexOf("player_data_manager =true") != -1) PlayerC = true;
            if (config.IndexOf("score_saver =true") != -1) ScoreC = true;
            Logs.AppendText("Checking Fast Loader");
            if (FastC == true)
            {
                Logs.AppendText(" -- Failed" + Environment.NewLine);
                Fast.Text = "Fast Loader -- Failed";
                Fast.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Logs.AppendText(" -- OK" + Environment.NewLine);
                Fast.Text = "Fast Loader -- OK";
                Fast.ForeColor = System.Drawing.Color.Green;
            }
            Logs.AppendText("Checking Stage Manager");
            if (StageC == true)
            {
                Logs.AppendText(" -- Failed" + Environment.NewLine);
                Stage.Text = "Stage Manager -- Failed";
                Stage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Logs.AppendText(" -- OK" + Environment.NewLine);
                Stage.Text = "Stage Manager -- OK";
                Stage.ForeColor = System.Drawing.Color.Green;
            }
            Logs.AppendText("Checking Player Data Manager");
            if (PlayerC == true)
            {
                Logs.AppendText(" -- Failed" + Environment.NewLine);
                Player.Text = "Player Data Manager -- Failed";
                Player.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Logs.AppendText(" -- OK" + Environment.NewLine);
                Player.Text = "Player Data Manager -- OK";
                Player.ForeColor = System.Drawing.Color.Green;
            }
            Logs.AppendText("Checking Score Saver");
            if (ScoreC == true)
            {
                Logs.AppendText(" -- Failed" + Environment.NewLine);
                Score.Text = "Score Saver -- Failed";
                Score.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Logs.AppendText(" -- OK" + Environment.NewLine);
                Score.Text = "Score Saver -- OK";
                Score.ForeColor = System.Drawing.Color.Green;
            }
            Logs.AppendText("Checking Griphics API");
            if (DirectXC == true)
            {
                Logs.AppendText(" -- DirectX 11" + Environment.NewLine);
                API.Text = ("Graphics API -- DirectX 11");
                DirectXCheck.Checked = true;
                API.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                Logs.AppendText(" -- OpenGL" + Environment.NewLine);
                API.Text = ("Graphics API -- OpenGL");
                API.ForeColor = System.Drawing.Color.Green;
            }
            if (File.Exists(Directory.GetCurrentDirectory() + @"\Launcher.dva") == true && File.Exists(Directory.GetCurrentDirectory() + "\\plugins\\Launcher.dva") == false)
            {
                Logs.AppendText("已禁用PD-Loader" + Environment.NewLine);
                button1.Text = "启用PD-Loader";
            }
            else
            {
                Logs.AppendText("已启用PD-Loader" + Environment.NewLine);
                button1.Text = "禁用PD-Loader";
            }
            while (GetGameserver.ReadLine() != null)
            {
                ServerReader = Gameserver.ReadLine();
                {
                    if (ServerReader.IndexOf("default=") != -1)
                    {
                        string ServerValue = "";
                        ServerValue = ServerReader.Replace("default=", "");
                        GameServer.Text = ServerValue;
                        Gameserver.Close();
                        GetGameserver.Close();
                        break;
                    }
                }
            }



        }

        private void Fast_Click(object sender, EventArgs e)
        {
            string Replace = "";
            string FLReader = "";
            string FLChanger = "";
            string FLSetting = "";

            StreamReader ReadFL = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            while (ReadFL.ReadLine() != null)
            {
                FLReader = ReadFL.ReadLine();
                if (FLReader.IndexOf("fast_loader_speed=") != -1)
                {
                    FLSetting = FLReader;
                    FLChanger = FLReader.Replace("fast_loader_speed=", "");
                    FLReader = FLReader.Replace(FLChanger, "4");
                    break;
                }
            }
            ReadFL.Close();
            StreamReader ReplaceFL = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            Replace = ReplaceFL.ReadToEnd();
            ReplaceFL.Close();
            Replace = Replace.Replace(FLSetting, FLReader);
            StreamWriter WriteFL = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            WriteFL.Write(Replace);
            WriteFL.Flush();
            WriteFL.Close();
            StreamReader CheckFL = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            string Check = CheckFL.ReadToEnd();
            CheckFL.Close();
            bool Fastloader = false;
            if (Check.IndexOf("fast_loader_speed=4") == -1) Fastloader = true;
            if (Fastloader == true)
            {
                Logs.AppendText("Fast Loader -- Failed" + Environment.NewLine);
                Fast.Text = "Fast Loader -- Failed";
                Fast.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Logs.AppendText("Fast Loader -- OK" + Environment.NewLine);
                Fast.Text = "Fast Loader -- OK";
                Fast.ForeColor = System.Drawing.Color.Green;
            }

        }

        private void Score_Click(object sender, EventArgs e)
        {
            StreamReader ReadScore = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            string Replace = ReadScore.ReadToEnd();
            ReadScore.Close();
            Replace = Replace.Replace("score_saver =true", "score_saver =false");
            StreamWriter WriteSC = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            WriteSC.Write(Replace);
            WriteSC.Flush();
            WriteSC.Close();
            StreamReader CheckSC = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            string Check = CheckSC.ReadToEnd();
            CheckSC.Close();
            bool Scoresaver = false;
            if (Check.IndexOf("score_saver =true") != -1) Scoresaver = true;
            if (Scoresaver == true)
            {
                Logs.AppendText("Score Saver -- Failed" + Environment.NewLine);
                Score.Text = "Score Saver -- Failed";
                Score.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Logs.AppendText("Score Saver -- OK" + Environment.NewLine);
                Score.Text = "Score Saver -- OK";
                Score.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void Player_Click(object sender, EventArgs e)
        {
            StreamReader ReadPlayer = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            string Replace = ReadPlayer.ReadToEnd();
            ReadPlayer.Close();
            Replace = Replace.Replace("player_data_manager =true", "player_data_manager =false");
            StreamWriter WritePL = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            WritePL.Write(Replace);
            WritePL.Flush();
            WritePL.Close();
            StreamReader CheckPL = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            string Check = CheckPL.ReadToEnd();
            CheckPL.Close();
            bool PlayerData = false;
            if (Check.IndexOf("player_data_manager =true") != -1) PlayerData = true;
            if (PlayerData == true)
            {
                Logs.AppendText("Player Data Manager -- Failed" + Environment.NewLine);
                Player.Text = "Player Data Manager -- Failed";
                Player.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Logs.AppendText("Player Data Manager -- OK" + Environment.NewLine);
                Player.Text = "Player Data Manager -- OK";
                Player.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void Stage_Click(object sender, EventArgs e)
        {
            StreamReader ReadStage = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            string Replace = ReadStage.ReadToEnd();
            ReadStage.Close();
            Replace = Replace.Replace("stage_manager =true", "stage_manager =false");
            StreamWriter WriteSM = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            WriteSM.Write(Replace);
            WriteSM.Flush();
            WriteSM.Close();
            StreamReader CheckSM = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\components.ini");
            string Check = CheckSM.ReadToEnd();
            CheckSM.Close();
            bool StageManager = false;
            if (Check.IndexOf("stage_manager =true") != -1) StageManager = true;
            if (StageManager == true)
            {
                Logs.AppendText("Stage Manager -- Failed" + Environment.NewLine);
                Stage.Text = "Stage Manager -- Failed";
                Stage.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                Logs.AppendText("Stage Manager -- OK" + Environment.NewLine);
                Stage.Text = "Stage Manager -- OK";
                Stage.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader GetGameserver = new StreamReader(Directory.GetCurrentDirectory() + @"\segatools.ini");
            StreamReader Gameserver = new StreamReader(Directory.GetCurrentDirectory() + @"\segatools.ini");

            string ServerReader = "";
            string OldServerName = "";
            string NewServerName = "";
            string ServerValue = "";
            while (GetGameserver.ReadLine() != null)
            {
                ServerReader = Gameserver.ReadLine();
                {
                    if (ServerReader.IndexOf("default=") != -1)
                    {
                        ServerValue = ServerReader.Replace("default=", "");
                        Gameserver.Close();
                        GetGameserver.Close();
                        break;
                    }
                }
            }
            StreamReader OldServer = new StreamReader(Directory.GetCurrentDirectory() + @"\segatools.ini");
            OldServerName = OldServer.ReadToEnd();
            OldServer.Close();
            NewServerName = OldServerName.Replace(ServerValue, GameServer.Text);
            StreamWriter ChangeServer = new StreamWriter(Directory.GetCurrentDirectory() + @"\segatools.ini");
            ChangeServer.Flush();
            ChangeServer.Write(NewServerName);
            ChangeServer.Close();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void MLAACheck_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SaveGraphics_Click(object sender, EventArgs e)
        {
            if (TAACheck.Checked == false)
            {
                StreamReader TAAReader = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                string TAASetting = TAAReader.ReadToEnd();
                TAAReader.Close();
                TAASetting = TAASetting.Replace("TAA=1", "TAA=0");
                StreamWriter TAAWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                TAAWriter.Flush();
                TAAWriter.Write(TAASetting);
                TAAWriter.Close();
                Logs.AppendText("TAA -- Disabled" + Environment.NewLine);


            }
            else
            {
                StreamReader TAAReader = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                string TAASetting = TAAReader.ReadToEnd();
                TAAReader.Close();
                TAASetting = TAASetting.Replace("TAA=0", "TAA=1");
                StreamWriter TAAWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                TAAWriter.Flush();
                TAAWriter.Write(TAASetting);
                TAAWriter.Close();
                Logs.AppendText("TAA -- Enabled" + Environment.NewLine);
            }
            if (MLAACheck.Checked == false)
            {
                StreamReader MLAAReader = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                string MLAASetting = MLAAReader.ReadToEnd();
                MLAAReader.Close();
                MLAASetting = MLAASetting.Replace("MLAA=1", "MLAA=0");
                StreamWriter MLAAWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                MLAAWriter.Flush();
                MLAAWriter.Write(MLAASetting);
                MLAAWriter.Close();
                Logs.AppendText("MLAA -- Disabled" + Environment.NewLine);


            }
            else
            {
                StreamReader MLAAReader = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                string MLAASetting = MLAAReader.ReadToEnd();
                MLAAReader.Close();
                MLAASetting = MLAASetting.Replace("MLAA=0", "MLAA=1");
                StreamWriter MLAAWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                MLAAWriter.Flush();
                MLAAWriter.Write(MLAASetting);
                MLAAWriter.Close();
                Logs.AppendText("MLAA -- Enabled" + Environment.NewLine);
            }
            if (DirectXCheck.Checked == false)
            {
                StreamReader DirectXReader = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\graphics.ini");
                string DirectXSetting = DirectXReader.ReadToEnd();
                DirectXReader.Close();
                DirectXSetting = DirectXSetting.Replace("dxgi = 1", "dxgi = 0");
                StreamWriter DirectXWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\graphics.ini");
                DirectXWriter.Flush();
                DirectXWriter.Write(DirectXSetting);
                DirectXWriter.Close();
                Logs.AppendText("DirectX 11 -- Disabled" + Environment.NewLine);
                API.Text = "Graphics API -- OpenGL";


            }
            else
            {
                StreamReader DirectXReader = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\graphics.ini");
                string DirectXSetting = DirectXReader.ReadToEnd();
                DirectXReader.Close();
                DirectXSetting = DirectXSetting.Replace("dxgi = 0", "dxgi = 1");
                StreamWriter DirectXWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\graphics.ini");
                DirectXWriter.Flush();
                DirectXWriter.Write(DirectXSetting);
                DirectXWriter.Close();
                Logs.AppendText("DirectX 11 -- Enabled" + Environment.NewLine);
                API.Text = "Graphics API -- DirectX 11";

            }
            if (IRCheck.Checked == false)
            {
                StreamReader IRReader = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                string IRSetting = IRReader.ReadToEnd();
                IRReader.Close();
                IRSetting = IRSetting.Replace("r.Enable=1", "r.Enable=0");
                StreamWriter IRWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                IRWriter.Flush();
                IRWriter.Write(IRSetting);
                IRWriter.Close();
                Logs.AppendText("Internal Resolution -- Disabled" + Environment.NewLine);



            }
            else
            {
                StreamReader IRReader = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                string IRSetting = IRReader.ReadToEnd();
                IRReader.Close();
                IRSetting = IRSetting.Replace("r.Enable=0", "r.Enable=1");
                StreamWriter IRWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
                IRWriter.Flush();
                IRWriter.Write(IRSetting);
                IRWriter.Close();
                Logs.AppendText("Internal Resolution -- Enabled" + Environment.NewLine);
            }
            string ResolutionReader = "";
            string NewResolution;
            StreamReader GetResolution = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
            StreamReader Resolution = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
            StreamReader OldResolution = new StreamReader(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
            NewResolution = OldResolution.ReadToEnd();
            while (GetResolution.ReadLine() != null)
            {
                ResolutionReader = Resolution.ReadLine();
                if ((ResolutionReader.IndexOf("Width=") != -1) && (ResolutionReader.IndexOf("r.Width=") == -1)) NewResolution= NewResolution.Replace(ResolutionReader, ResolutionReader.Replace(ResolutionReader.Replace("Width=", ""), WidthBox.Text));
                if ((ResolutionReader.IndexOf("Height=") != -1) && (ResolutionReader.IndexOf("r.Height=") == -1)) NewResolution = NewResolution.Replace(ResolutionReader, ResolutionReader.Replace(ResolutionReader.Replace("Height=", ""), HeightBox.Text));
                if (ResolutionReader.IndexOf("r.Width=") != -1) NewResolution = NewResolution.Replace(ResolutionReader, ResolutionReader.Replace(ResolutionReader.Replace("r.Width=", ""), RHeightBox.Text));
                if (ResolutionReader.IndexOf("r.Height=") != -1) NewResolution = NewResolution.Replace(ResolutionReader, ResolutionReader.Replace(ResolutionReader.Replace("r.Height=", ""), RWidthBox.Text));
            }
            GetResolution.Close();
            Resolution.Close();
            OldResolution.Close();
            StreamWriter ResolutionWriter = new StreamWriter(Directory.GetCurrentDirectory() + @"\plugins\config.ini");
            ResolutionWriter.Flush();
            ResolutionWriter.Write(NewResolution);
            ResolutionWriter.Close();
        }
    }
}
