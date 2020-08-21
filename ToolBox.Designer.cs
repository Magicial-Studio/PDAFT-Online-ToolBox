namespace AFT_Online_Stater
{
    partial class ToolBox
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolBox));
            this.ClearDNS = new System.Windows.Forms.Button();
            this.Delete = new System.Windows.Forms.Button();
            this.Web = new System.Windows.Forms.Button();
            this.Launch = new System.Windows.Forms.Button();
            this.Logs = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Fast = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.Player = new System.Windows.Forms.Label();
            this.Stage = new System.Windows.Forms.Label();
            this.GameServer = new System.Windows.Forms.TextBox();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.SaveGameServer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.API = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SaveGraphics = new System.Windows.Forms.Button();
            this.DirectXCheck = new System.Windows.Forms.CheckBox();
            this.MLAACheck = new System.Windows.Forms.CheckBox();
            this.IRCheck = new System.Windows.Forms.CheckBox();
            this.TAACheck = new System.Windows.Forms.CheckBox();
            this.RHeightBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.RWidthBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HeightBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.WidthBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClearDNS
            // 
            this.ClearDNS.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ClearDNS.Location = new System.Drawing.Point(420, 406);
            this.ClearDNS.Name = "ClearDNS";
            this.ClearDNS.Size = new System.Drawing.Size(101, 23);
            this.ClearDNS.TabIndex = 0;
            this.ClearDNS.Text = "清除DNS缓存";
            this.ClearDNS.UseVisualStyleBackColor = true;
            this.ClearDNS.Click += new System.EventHandler(this.ClearDNS_Click);
            // 
            // Delete
            // 
            this.Delete.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Delete.Location = new System.Drawing.Point(537, 406);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(78, 23);
            this.Delete.TabIndex = 1;
            this.Delete.Text = "删除账号";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Web
            // 
            this.Web.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Web.Location = new System.Drawing.Point(642, 406);
            this.Web.Name = "Web";
            this.Web.Size = new System.Drawing.Size(78, 23);
            this.Web.TabIndex = 2;
            this.Web.Text = "网页管理";
            this.Web.UseVisualStyleBackColor = true;
            this.Web.Click += new System.EventHandler(this.Web_Click);
            // 
            // Launch
            // 
            this.Launch.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Launch.Location = new System.Drawing.Point(749, 406);
            this.Launch.Name = "Launch";
            this.Launch.Size = new System.Drawing.Size(78, 23);
            this.Launch.TabIndex = 3;
            this.Launch.Text = "启动AFT";
            this.Launch.UseVisualStyleBackColor = true;
            this.Launch.Click += new System.EventHandler(this.Button4_Click);
            // 
            // Logs
            // 
            this.Logs.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Logs.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Logs.Location = new System.Drawing.Point(12, 12);
            this.Logs.Multiline = true;
            this.Logs.Name = "Logs";
            this.Logs.ReadOnly = true;
            this.Logs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Logs.Size = new System.Drawing.Size(341, 242);
            this.Logs.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.button1.Location = new System.Drawing.Point(288, 406);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "启用PD-Loader";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Fast
            // 
            this.Fast.AutoSize = true;
            this.Fast.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Fast.ForeColor = System.Drawing.Color.Olive;
            this.Fast.Location = new System.Drawing.Point(6, 17);
            this.Fast.Name = "Fast";
            this.Fast.Size = new System.Drawing.Size(147, 17);
            this.Fast.TabIndex = 6;
            this.Fast.Text = "Fast Loader -- Checking";
            this.Fast.Click += new System.EventHandler(this.Fast_Click);
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Score.ForeColor = System.Drawing.Color.Olive;
            this.Score.Location = new System.Drawing.Point(6, 47);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(148, 17);
            this.Score.TabIndex = 7;
            this.Score.Text = "Score Saver -- Checking";
            this.Score.Click += new System.EventHandler(this.Score_Click);
            // 
            // Player
            // 
            this.Player.AutoSize = true;
            this.Player.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Player.ForeColor = System.Drawing.Color.Olive;
            this.Player.Location = new System.Drawing.Point(6, 78);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(202, 17);
            this.Player.TabIndex = 8;
            this.Player.Text = "Player Data Manager -- Checking";
            this.Player.Click += new System.EventHandler(this.Player_Click);
            // 
            // Stage
            // 
            this.Stage.AutoSize = true;
            this.Stage.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Stage.ForeColor = System.Drawing.Color.Olive;
            this.Stage.Location = new System.Drawing.Point(6, 110);
            this.Stage.Name = "Stage";
            this.Stage.Size = new System.Drawing.Size(169, 17);
            this.Stage.TabIndex = 9;
            this.Stage.Text = "Stage Manager -- Checking";
            this.Stage.Click += new System.EventHandler(this.Stage_Click);
            // 
            // GameServer
            // 
            this.GameServer.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.GameServer.Location = new System.Drawing.Point(88, 20);
            this.GameServer.Name = "GameServer";
            this.GameServer.Size = new System.Drawing.Size(313, 23);
            this.GameServer.TabIndex = 10;
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.ServerLabel.Location = new System.Drawing.Point(7, 23);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(68, 17);
            this.ServerLabel.TabIndex = 11;
            this.ServerLabel.Text = "游戏服务器";
            // 
            // SaveGameServer
            // 
            this.SaveGameServer.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.SaveGameServer.Location = new System.Drawing.Point(326, 49);
            this.SaveGameServer.Name = "SaveGameServer";
            this.SaveGameServer.Size = new System.Drawing.Size(75, 23);
            this.SaveGameServer.TabIndex = 12;
            this.SaveGameServer.Text = "保存";
            this.SaveGameServer.UseVisualStyleBackColor = true;
            this.SaveGameServer.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.API);
            this.groupBox1.Controls.Add(this.Fast);
            this.groupBox1.Controls.Add(this.Score);
            this.groupBox1.Controls.Add(this.Player);
            this.groupBox1.Controls.Add(this.Stage);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.groupBox1.Location = new System.Drawing.Point(12, 260);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 169);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "AFT启动前自检";
            // 
            // API
            // 
            this.API.AutoSize = true;
            this.API.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.API.ForeColor = System.Drawing.Color.Olive;
            this.API.Location = new System.Drawing.Point(6, 146);
            this.API.Name = "API";
            this.API.Size = new System.Drawing.Size(153, 17);
            this.API.TabIndex = 10;
            this.API.Text = "Graphics API -- Checking";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ServerLabel);
            this.groupBox2.Controls.Add(this.GameServer);
            this.groupBox2.Controls.Add(this.SaveGameServer);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(371, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(451, 92);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器设定";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SaveGraphics);
            this.groupBox3.Controls.Add(this.DirectXCheck);
            this.groupBox3.Controls.Add(this.MLAACheck);
            this.groupBox3.Controls.Add(this.IRCheck);
            this.groupBox3.Controls.Add(this.TAACheck);
            this.groupBox3.Controls.Add(this.RHeightBox);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.RWidthBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.HeightBox);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.WidthBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.groupBox3.Location = new System.Drawing.Point(371, 159);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 195);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "显示设定";
            // 
            // SaveGraphics
            // 
            this.SaveGraphics.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.SaveGraphics.Location = new System.Drawing.Point(326, 148);
            this.SaveGraphics.Name = "SaveGraphics";
            this.SaveGraphics.Size = new System.Drawing.Size(75, 23);
            this.SaveGraphics.TabIndex = 13;
            this.SaveGraphics.Text = "保存";
            this.SaveGraphics.UseVisualStyleBackColor = true;
            this.SaveGraphics.Click += new System.EventHandler(this.SaveGraphics_Click);
            // 
            // DirectXCheck
            // 
            this.DirectXCheck.AutoSize = true;
            this.DirectXCheck.Location = new System.Drawing.Point(271, 101);
            this.DirectXCheck.Name = "DirectXCheck";
            this.DirectXCheck.Size = new System.Drawing.Size(111, 21);
            this.DirectXCheck.TabIndex = 12;
            this.DirectXCheck.Text = "启用DirectX 11";
            this.DirectXCheck.UseVisualStyleBackColor = true;
            // 
            // MLAACheck
            // 
            this.MLAACheck.AutoSize = true;
            this.MLAACheck.Location = new System.Drawing.Point(66, 101);
            this.MLAACheck.Name = "MLAACheck";
            this.MLAACheck.Size = new System.Drawing.Size(61, 21);
            this.MLAACheck.TabIndex = 11;
            this.MLAACheck.Text = "MLAA";
            this.MLAACheck.UseVisualStyleBackColor = true;
            this.MLAACheck.CheckedChanged += new System.EventHandler(this.MLAACheck_CheckedChanged);
            // 
            // IRCheck
            // 
            this.IRCheck.AutoSize = true;
            this.IRCheck.Location = new System.Drawing.Point(133, 101);
            this.IRCheck.Name = "IRCheck";
            this.IRCheck.Size = new System.Drawing.Size(135, 21);
            this.IRCheck.TabIndex = 10;
            this.IRCheck.Text = "启用内部渲染分辨率";
            this.IRCheck.UseVisualStyleBackColor = true;
            // 
            // TAACheck
            // 
            this.TAACheck.AutoSize = true;
            this.TAACheck.Location = new System.Drawing.Point(10, 101);
            this.TAACheck.Name = "TAACheck";
            this.TAACheck.Size = new System.Drawing.Size(50, 21);
            this.TAACheck.TabIndex = 9;
            this.TAACheck.Text = "TAA";
            this.TAACheck.UseVisualStyleBackColor = true;
            this.TAACheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // RHeightBox
            // 
            this.RHeightBox.Location = new System.Drawing.Point(258, 55);
            this.RHeightBox.Name = "RHeightBox";
            this.RHeightBox.Size = new System.Drawing.Size(91, 23);
            this.RHeightBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "X";
            // 
            // RWidthBox
            // 
            this.RWidthBox.Location = new System.Drawing.Point(139, 55);
            this.RWidthBox.Name = "RWidthBox";
            this.RWidthBox.Size = new System.Drawing.Size(91, 23);
            this.RWidthBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "内部渲染分辨率";
            // 
            // HeightBox
            // 
            this.HeightBox.Location = new System.Drawing.Point(258, 24);
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.Size = new System.Drawing.Size(91, 23);
            this.HeightBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "X";
            // 
            // WidthBox
            // 
            this.WidthBox.Location = new System.Drawing.Point(139, 24);
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.Size = new System.Drawing.Size(91, 23);
            this.WidthBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "游戏分辨率";
            // 
            // ToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 441);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Logs);
            this.Controls.Add(this.Launch);
            this.Controls.Add(this.Web);
            this.Controls.Add(this.Delete);
            this.Controls.Add(this.ClearDNS);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ToolBox";
            this.Text = "Project DIVA Online Tool Box";
            this.Load += new System.EventHandler(this.ToolBox_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClearDNS;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Web;
        private System.Windows.Forms.Button Launch;
        private System.Windows.Forms.TextBox Logs;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Fast;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label Player;
        private System.Windows.Forms.Label Stage;
        private System.Windows.Forms.TextBox GameServer;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.Button SaveGameServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HeightBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WidthBox;
        private System.Windows.Forms.CheckBox TAACheck;
        private System.Windows.Forms.TextBox RHeightBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RWidthBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox MLAACheck;
        private System.Windows.Forms.CheckBox IRCheck;
        private System.Windows.Forms.Label API;
        private System.Windows.Forms.CheckBox DirectXCheck;
        private System.Windows.Forms.Button SaveGraphics;
    }
}

