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
                StringBuilder msg = new StringBuilder();
                result.OrderBy(x => x.Item3)?.ToList()?.ForEach(x =>
                  {
                      switch (x.Item2)
                      {
                          case ImportType.All:
                              break;
                          case ImportType.Corportation:
                              msg = new StringBuilder();
                              msg.AppendLine("【开始导入法人主数据】");
                              var isSuccessForCorpo = importManager.Import(x);
                              msg.AppendLine("【导入法人主数据结束】");
                              if (isSuccessForCorpo.Item1)
                              {
                                  msg = msg.AppendLine("法人主数据导入成功").AppendLine(isSuccessForCorpo.Item2);
                                  ShowInfo(msg.ToString(), isSuccessForCorpo.Item3, LogInfoText);
                              }
                              else
                              {
                                  msg = msg.AppendLine("法人主数据导入失败").AppendLine(isSuccessForCorpo.Item2);
                                  ShowInfo(msg.ToString(), MsgType.Err, LogInfoText);
                              }
                              break;
                          case ImportType.ProfitCenter:
                              msg = new StringBuilder();
                              msg.AppendLine("【开始导入利润中心主数据】");
                              var isSuccessForProfitCenter = importManager.Import(x);
                              msg.AppendLine("【导入利润中心主数据结束】");
                              if (isSuccessForProfitCenter.Item1)
                              {
                                  msg = msg.AppendLine("利润中心主数据导入成功").AppendLine(isSuccessForProfitCenter.Item2);
                                  ShowInfo(msg.ToString(), isSuccessForProfitCenter.Item3, LogInfoText);
                              }
                              else
                              {
                                  msg = msg.AppendLine("利润中心主数据导入失败").AppendLine(isSuccessForProfitCenter.Item2);
                                  ShowInfo(msg.ToString(), MsgType.Err, LogInfoText);
                              }
                              break;
                          case ImportType.Post:
                              msg = new StringBuilder();
                              msg.AppendLine("【开始导入岗位主数据】");
                              var isSuccessForPost = importManager.Import(x);
                              msg.AppendLine("【导入岗位主数据结束】");
                              if (isSuccessForPost.Item1)
                              {
                                  msg = msg.AppendLine("岗位主数据导入成功").AppendLine(isSuccessForPost.Item2);
                                  ShowInfo(msg.ToString(), isSuccessForPost.Item3, LogInfoText);
                              }
                              else
                              {
                                  msg = msg.AppendLine("岗位主数据导入失败").AppendLine(isSuccessForPost.Item2);
                                  ShowInfo(msg.ToString(), MsgType.Err, LogInfoText);
                              }
                              break;
                          case ImportType.Permission:
                              msg = new StringBuilder();
                              msg.AppendLine("【开始导入权限主数据】");
                              var isSuccessForPermission = importManager.Import(x);
                              msg.AppendLine("【导入权限主数据结束】");
                              if (isSuccessForPermission.Item1)
                              {
                                  msg = msg.AppendLine("权限主数据导入成功").AppendLine(isSuccessForPermission.Item2);
                                  ShowInfo(msg.ToString(), isSuccessForPermission.Item3, LogInfoText);
                              }
                              else
                              {
                                  msg = msg.AppendLine("权限主数据导入失败").AppendLine(isSuccessForPermission.Item2);
                                  ShowInfo(msg.ToString(), MsgType.Err, LogInfoText);
                              }
                              break;
                          case ImportType.UserInfo:
                              msg = new StringBuilder();
                              msg.AppendLine("【开始导入用户主数据】");
                              var isSuccessForUserInfo = importManager.Import(x);
                              msg.AppendLine("【导入用户主数据结束】");
                              if (isSuccessForUserInfo.Item1)
                              {
                                  msg = msg.AppendLine("用户主数据导入成功").AppendLine(isSuccessForUserInfo.Item2);
                                  ShowInfo(msg.ToString(), isSuccessForUserInfo.Item3, LogInfoText);
                              }
                              else
                              {
                                  msg = msg.AppendLine("用户主数据导入失败").AppendLine(isSuccessForUserInfo.Item2);
                                  ShowInfo(msg.ToString(), MsgType.Err, LogInfoText);
                              }
                              break;
                          case ImportType.Commodity:
                              msg = new StringBuilder();
                              msg.AppendLine("【开始导入品种主数据】");
                              var isSuccessForCommodity = importManager.Import(x);
                              msg.AppendLine("【导入品种主数据结束】");
                              if (isSuccessForCommodity.Item1)
                              {
                                  msg = msg.AppendLine("品种主数据导入成功").AppendLine(isSuccessForCommodity.Item2);
                                  ShowInfo(msg.ToString(), isSuccessForCommodity.Item3, LogInfoText);
                              }
                              else
                              {
                                  msg = msg.AppendLine("品种主数据导入失败").AppendLine(isSuccessForCommodity.Item2);
                                  ShowInfo(msg.ToString(), MsgType.Err, LogInfoText);
                              }
                              break;
                          case ImportType.SPRolePermission:
                              msg = new StringBuilder();
                              msg.AppendLine("【开始导入标准岗位角色权限主数据】");
                              var isSuccessForSPRolePermission = importManager.Import(x);
                              msg.AppendLine("【导入标准岗位角色权限主数据结束】");
                              if (isSuccessForSPRolePermission.Item1)
                              {
                                  msg = msg.AppendLine("标准岗位角色权限主数据导入成功").AppendLine(isSuccessForSPRolePermission.Item2);
                                  ShowInfo(msg.ToString(), isSuccessForSPRolePermission.Item3, LogInfoText);
                              }
                              else
                              {
                                  msg = msg.AppendLine("标准岗位角色权限主数据导入失败").AppendLine(isSuccessForSPRolePermission.Item2);
                                  ShowInfo(msg.ToString(), MsgType.Err, LogInfoText);
                              }
                              break;
                          default:
                              break;
                      }
                  });
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
