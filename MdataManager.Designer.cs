using System.ComponentModel;

namespace PDAFT_Online_ToolBox
{
    partial class MdataManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MdataManager));
            this.EnabledMdataListBox = new System.Windows.Forms.ListBox();
            this.DisabledMdataListBox = new System.Windows.Forms.ListBox();
            this.EnabledMdataLabel = new System.Windows.Forms.Label();
            this.DisabledMdataLabel = new System.Windows.Forms.Label();
            this.DisableMdata = new System.Windows.Forms.Button();
            this.EnableMdata = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EnabledMdataListBox
            // 
            this.EnabledMdataListBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.EnabledMdataListBox.FormattingEnabled = true;
            this.EnabledMdataListBox.ItemHeight = 17;
            this.EnabledMdataListBox.Location = new System.Drawing.Point(12, 55);
            this.EnabledMdataListBox.Name = "EnabledMdataListBox";
            this.EnabledMdataListBox.Size = new System.Drawing.Size(170, 276);
            this.EnabledMdataListBox.TabIndex = 0;
            // 
            // DisabledMdataListBox
            // 
            this.DisabledMdataListBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.DisabledMdataListBox.FormattingEnabled = true;
            this.DisabledMdataListBox.ItemHeight = 17;
            this.DisabledMdataListBox.Location = new System.Drawing.Point(346, 55);
            this.DisabledMdataListBox.Name = "DisabledMdataListBox";
            this.DisabledMdataListBox.Size = new System.Drawing.Size(170, 276);
            this.DisabledMdataListBox.TabIndex = 1;
            // 
            // EnabledMdataLabel
            // 
            this.EnabledMdataLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.EnabledMdataLabel.Location = new System.Drawing.Point(12, 21);
            this.EnabledMdataLabel.Name = "EnabledMdataLabel";
            this.EnabledMdataLabel.Size = new System.Drawing.Size(134, 16);
            this.EnabledMdataLabel.TabIndex = 2;
            this.EnabledMdataLabel.Text = "已启用Mdata";
            // 
            // DisabledMdataLabel
            // 
            this.DisabledMdataLabel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.DisabledMdataLabel.Location = new System.Drawing.Point(346, 21);
            this.DisabledMdataLabel.Name = "DisabledMdataLabel";
            this.DisabledMdataLabel.Size = new System.Drawing.Size(134, 16);
            this.DisabledMdataLabel.TabIndex = 3;
            this.DisabledMdataLabel.Text = "未启用Mdata";
            // 
            // DisableMdata
            // 
            this.DisableMdata.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (134)));
            this.DisableMdata.Location = new System.Drawing.Point(210, 137);
            this.DisableMdata.Name = "DisableMdata";
            this.DisableMdata.Size = new System.Drawing.Size(104, 24);
            this.DisableMdata.TabIndex = 4;
            this.DisableMdata.Text = "停用Mdata→";
            this.DisableMdata.UseVisualStyleBackColor = true;
            this.DisableMdata.Click += new System.EventHandler(this.DisableMdata_Click);
            // 
            // EnableMdata
            // 
            this.EnableMdata.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.EnableMdata.Location = new System.Drawing.Point(210, 167);
            this.EnableMdata.Name = "EnableMdata";
            this.EnableMdata.Size = new System.Drawing.Size(104, 24);
            this.EnableMdata.TabIndex = 5;
            this.EnableMdata.Text = "←启用Mdata";
            this.EnableMdata.UseVisualStyleBackColor = true;
            this.EnableMdata.Click += new System.EventHandler(this.EnableMdata_Click);
            // 
            // MdataManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.EnableMdata);
            this.Controls.Add(this.DisableMdata);
            this.Controls.Add(this.DisabledMdataLabel);
            this.Controls.Add(this.EnabledMdataLabel);
            this.Controls.Add(this.DisabledMdataListBox);
            this.Controls.Add(this.EnabledMdataListBox);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "MdataManager";
            this.Text = "Mdata管理器";
            this.Load += new System.EventHandler(this.MdataManager_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button DisableMdata;
        private System.Windows.Forms.Button EnableMdata;

        private System.Windows.Forms.Label DisabledMdataLabel;
        private System.Windows.Forms.Label EnabledMdataLabel;
        private System.Windows.Forms.ListBox DisabledMdataListBox;

        private System.Windows.Forms.ListBox EnabledMdataListBox;

        #endregion
    }
}