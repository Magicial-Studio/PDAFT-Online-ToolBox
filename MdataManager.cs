using System;
using System.Windows.Forms;
using System.IO;
using System.Windows;
using MessageBox = System.Windows.MessageBox;

namespace PDAFT_Online_ToolBox
{
    public partial class MdataManager : Form
    {
        public MdataManager()
        {
            InitializeComponent();
        }
        private void RefreshMdata()
        {
            DisabledMdataListBox.Items.Clear();
            EnabledMdataListBox.Items.Clear();
            DirectoryInfo EnabledMdataDirectory=new DirectoryInfo(Directory.GetCurrentDirectory()+"\\mdata");
            DirectoryInfo DisabledMdataDirectory=new DirectoryInfo(Directory.GetCurrentDirectory()+"\\mdata\\Disabled");
            try
            {
                foreach (DirectoryInfo EnabledMdata in EnabledMdataDirectory.GetDirectories())
                {
                    EnabledMdataListBox.Items.Add(EnabledMdata.ToString().Replace(Directory.GetCurrentDirectory(),""));
                }
                EnabledMdataListBox.Items.Remove("Disabled");
                foreach (DirectoryInfo DisabledMdata in DisabledMdataDirectory.GetDirectories())
                {
                    DisabledMdataListBox.Items.Add(DisabledMdata.ToString()
                        .Replace(Directory.GetCurrentDirectory() + "\\mdata", ""));
                }


            }
            catch(Exception Error)
            {
                MessageBox.Show(Error.Message);
            }
        }

        private void MdataManager_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Directory.GetCurrentDirectory() + "\\mdata\\Disabled")) Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\mdata\\Disabled");
            RefreshMdata();
        }

        private void EnableMdata_Click(object sender, EventArgs e)
        {
            if (DisabledMdataListBox.SelectedItem != null)
            {
                try
                {
                    Directory.Move(
                        Directory.GetCurrentDirectory() + "\\mdata\\Disabled\\" + DisabledMdataListBox.SelectedItem,
                        Directory.GetCurrentDirectory() + "\\mdata\\" + DisabledMdataListBox.SelectedItem);
                    RefreshMdata();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "在移动文件夹时发生错误", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("你没有选择任何Mdata","在移动Mdata文件夹时发生错误",MessageBoxButton.OK,MessageBoxImage.Question);
            }
        }

        private void DisableMdata_Click(object sender, EventArgs e)
        {
            if (EnabledMdataListBox.SelectedItem!=null)
            {
                try
                {
                    Directory.Move(Directory.GetCurrentDirectory()+"\\mdata\\"+EnabledMdataListBox.SelectedItem ,
                        Directory.GetCurrentDirectory()+"\\mdata\\Disabled\\"+EnabledMdataListBox.SelectedItem);
                    RefreshMdata();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(),"在移动文件夹时发生错误",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("你没有选择任何Mdata","在移动Mdata文件夹时发生错误",MessageBoxButton.OK,MessageBoxImage.Question);
            }
            
        }
        
    } 
}