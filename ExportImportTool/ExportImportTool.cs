using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tool.BL.BussinessLayer.Tool.BL.BussinessLayer.Interface;
using Tool.BL.BussinessLayer.Tool.BL.BussinessLayer.Manager;
using Tool.Common.CommonHelper;
using Tool.ExportImport.ExportImportHelper;
using static Tool.Common.CommonHelper.EnumHelper.Enums;
namespace ExportImportTool
{
    public partial class ExportImportTool : Form
    {
        public IImportManager importManager = new ImportManager();
        public ExportImportTool()
        {
            InitializeComponent();
            IntialImportDataType();
        }

        private void btn_ChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "所有文件(*xls*)|*.xls*"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string file = fileDialog.FileName;//返回文件的完整路径   
                this.FileSourceText.Text = file;
                ShowInfo("选择文件", MsgType.Warning, LogInfoText);
            }
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="txtInfo"></param>
        /// <param name="Info"></param>
        public static void ShowInfo(string Info, MsgType msgType, System.Windows.Forms.RichTextBox textInfo)
        {
            switch (msgType)
            {
                case MsgType.Default:
                    textInfo.SelectionColor = Color.Black;
                    break;
                case MsgType.Err:
                    textInfo.SelectionColor = Color.Red;
                    break;
                case MsgType.Warning:
                    textInfo.SelectionColor = Color.Orange;
                    break;
                default:
                    textInfo.SelectionColor = Color.Black;
                    break;
            }

            textInfo.AppendText($"【{DateTime.Now}】 {Info}");
            textInfo.AppendText(Environment.NewLine);
            textInfo.ScrollToCaret();
        }

        private void btn_Import_Click(object sender, EventArgs e)
        {
            try
            {
                //ConfigConnectionStrings();
                if (string.IsNullOrEmpty(this.FileSourceText.Text))
                {
                    throw new Exception("未选中导入文件");
                }
                ShowInfo("开始导入指定文件", MsgType.Default, LogInfoText);
                NPOI_ImportHelper nPOI_ImportHelper = new NPOI_ImportHelper(this.FileSourceText.Text);
                var result = nPOI_ImportHelper.ExcelToDataTable((ImportType)this.cmb_ImportDataType.SelectedValue);
                var isSuccess = importManager.Import(result);
                if (isSuccess.Item1)
                {
                    ShowInfo($"导入成功【{isSuccess.Item2}】", isSuccess.Item3, LogInfoText);
                }
                else
                {
                    ShowInfo($"导入失败【{isSuccess.Item2}】", MsgType.Err, LogInfoText);
                }
            }
            catch (Exception ex)
            {
                ShowInfo(ex.Message, MsgType.Warning, LogInfoText);
                MessageBoxEx.Show(this, ex.Message, "ERROR");
            }
        }
        private void IntialImportDataType()
        {
            this.cmb_ImportDataType.DataSource = Extension.GetDataTable<ImportType>();
            this.cmb_ImportDataType.DisplayMember = "Name";
            this.cmb_ImportDataType.ValueMember = "Value";
        }
        //public void ConfigConnectionStrings()
        //{
        //    string newName = "OperationSystem_HBMSEntities";
        //    string newConnectionString = "";
        //    if (string.IsNullOrEmpty(this.txt_DatabaseInstance.Text.Trim()))
        //    {
        //        throw new Exception("数据库服务地址不能为空");
        //    }
        //    if (string.IsNullOrEmpty(this.txt_DataBaseName.Text.Trim()))
        //    {
        //        throw new Exception("数据库必须指定");
        //    }
        //    if (string.IsNullOrEmpty(this.txt_DataBaseLoginUser.Text.Trim()) && string.IsNullOrEmpty(this.txt_DataBaseLoginPwd.Text.Trim()))
        //    {
        //        newConnectionString = $"Data Source={this.txt_DatabaseInstance.Text.Trim()};Initial Catalog={this.txt_DatabaseInstance.Text.Trim()};Integrated Security=true;";
        //    }
        //    else
        //    {
        //        if (string.IsNullOrEmpty(this.txt_DataBaseLoginUser.Text.Trim()))
        //        {
        //            throw new Exception("数据库登录角色名不能为空");
        //        }
        //        else if (string.IsNullOrEmpty(this.txt_DataBaseLoginPwd.Text.Trim()))
        //        {
        //            throw new Exception("数据库登录密码不能为空");
        //        }
        //    }
        //    newConnectionString = $"metadata=res://*/ModelHBMS.csdl|res://*/ModelHBMS.ssdl|res://*/ModelHBMS.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source={this.txt_DatabaseInstance.Text.Trim()};initial catalog={this.txt_DataBaseName.Text.Trim()};persist security info=True;user id={this.txt_DataBaseLoginUser.Text.Trim()};password={this.txt_DataBaseLoginPwd.Text.Trim()};MultipleActiveResultSets=True;App=EntityFramework&quot;";
        //    bool isModified = false;    //记录该连接串是否已经存在
        //    // 读取程序集的配置文件
        //    string assemblyConfigFile = Assembly.GetEntryAssembly().Location;

        //    //ConnectionStringSettings
        //    if (ConfigurationManager.ConnectionStrings[newName] != null)
        //    {
        //        isModified = true;
        //    }
        //    // 新建一个连接字符串实例
        //    ConnectionStringSettings mySettings = new ConnectionStringSettings(newName, newConnectionString, "System.Data.EntityClient");
        //    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        //    // 如果连接串已存在，首先删除它
        //    if (isModified)
        //    {
        //        config.ConnectionStrings.ConnectionStrings.Remove(newName);
        //    }
        //    // 将新的连接串添加到配置文件中.
        //    config.ConnectionStrings.ConnectionStrings.Add(mySettings);
        //    // 保存对配置文件所作的更改
        //    config.Save(ConfigurationSaveMode.Modified);
        //    // 强制重新载入配置文件的ConnectionStrings配置节
        //    ConfigurationManager.RefreshSection("connectionStrings");
        //}

    }
}
