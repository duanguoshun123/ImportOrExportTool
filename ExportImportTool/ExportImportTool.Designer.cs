namespace ExportImportTool
{
    partial class ExportImportTool
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
            this.labelDataSource = new System.Windows.Forms.Label();
            this.btn_ChooseFile = new System.Windows.Forms.Button();
            this.FileSourceText = new System.Windows.Forms.TextBox();
            this.btn_Import = new System.Windows.Forms.Button();
            this.LogInfoText = new System.Windows.Forms.RichTextBox();
            this.lbl_ImportDataType = new System.Windows.Forms.Label();
            this.cmb_ImportDataType = new System.Windows.Forms.ComboBox();
            this.lbl_LogInfo = new System.Windows.Forms.Label();
            //this.lblDataBaseInstance = new System.Windows.Forms.Label();
            //this.txt_DatabaseInstance = new System.Windows.Forms.TextBox();
            //this.txt_DataBaseName = new System.Windows.Forms.TextBox();
            //this.txt_DataBaseLoginUser = new System.Windows.Forms.TextBox();
            //this.txt_DataBaseLoginPwd = new System.Windows.Forms.TextBox();
            //this.lbl_DataBaseName = new System.Windows.Forms.Label();
            //this.lbl_DataBaseLoginUser = new System.Windows.Forms.Label();
            //this.lbl_DataBaseLoginPwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDataSource
            // 
            this.labelDataSource.AutoSize = true;
            this.labelDataSource.Location = new System.Drawing.Point(83, 26);
            this.labelDataSource.Name = "labelDataSource";
            this.labelDataSource.Size = new System.Drawing.Size(41, 12);
            this.labelDataSource.TabIndex = 0;
            this.labelDataSource.Text = "数据源";
            // 
            // btn_ChooseFile
            // 
            this.btn_ChooseFile.Location = new System.Drawing.Point(557, 21);
            this.btn_ChooseFile.Name = "btn_ChooseFile";
            this.btn_ChooseFile.Size = new System.Drawing.Size(75, 23);
            this.btn_ChooseFile.TabIndex = 1;
            this.btn_ChooseFile.Text = "选择文件";
            this.btn_ChooseFile.UseVisualStyleBackColor = true;
            this.btn_ChooseFile.Click += new System.EventHandler(this.btn_ChooseFile_Click);
            // 
            // FileSourceText
            // 
            this.FileSourceText.Location = new System.Drawing.Point(145, 21);
            this.FileSourceText.Name = "FileSourceText";
            this.FileSourceText.Size = new System.Drawing.Size(406, 21);
            this.FileSourceText.TabIndex = 2;
            // 
            // btn_Import
            // 
            this.btn_Import.Location = new System.Drawing.Point(654, 21);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(85, 23);
            this.btn_Import.TabIndex = 3;
            this.btn_Import.Text = "开始导入";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // LogInfoText
            // 
            this.LogInfoText.BackColor = System.Drawing.Color.AliceBlue;
            this.LogInfoText.Location = new System.Drawing.Point(32, 142);
            this.LogInfoText.Name = "LogInfoText";
            this.LogInfoText.Size = new System.Drawing.Size(620, 330);
            this.LogInfoText.TabIndex = 4;
            this.LogInfoText.Text = "";
            // 
            // lbl_ImportDataType
            // 
            this.lbl_ImportDataType.AutoSize = true;
            this.lbl_ImportDataType.Location = new System.Drawing.Point(47, 60);
            this.lbl_ImportDataType.Name = "lbl_ImportDataType";
            this.lbl_ImportDataType.Size = new System.Drawing.Size(77, 12);
            this.lbl_ImportDataType.TabIndex = 5;
            this.lbl_ImportDataType.Text = "导入数据类型";
            // 
            // cmb_ImportDataType
            // 
            this.cmb_ImportDataType.FormattingEnabled = true;
            this.cmb_ImportDataType.Location = new System.Drawing.Point(145, 60);
            this.cmb_ImportDataType.Name = "cmb_ImportDataType";
            this.cmb_ImportDataType.Size = new System.Drawing.Size(237, 20);
            this.cmb_ImportDataType.TabIndex = 6;
            // 
            // lbl_LogInfo
            // 
            this.lbl_LogInfo.AutoSize = true;
            this.lbl_LogInfo.Location = new System.Drawing.Point(30, 127);
            this.lbl_LogInfo.Name = "lbl_LogInfo";
            this.lbl_LogInfo.Size = new System.Drawing.Size(53, 12);
            this.lbl_LogInfo.TabIndex = 7;
            this.lbl_LogInfo.Text = "日志输出";
            //// 
            //// lblDataBaseInstance
            //// 
            //this.lblDataBaseInstance.AutoSize = true;
            //this.lblDataBaseInstance.Location = new System.Drawing.Point(59, 98);
            //this.lblDataBaseInstance.Name = "lblDataBaseInstance";
            //this.lblDataBaseInstance.Size = new System.Drawing.Size(65, 12);
            //this.lblDataBaseInstance.TabIndex = 8;
            //this.lblDataBaseInstance.Text = "数据库地址";
            //// 
            //// txt_DatabaseInstance
            //// 
            //this.txt_DatabaseInstance.Location = new System.Drawing.Point(145, 95);
            //this.txt_DatabaseInstance.Name = "txt_DatabaseInstance";
            //this.txt_DatabaseInstance.Size = new System.Drawing.Size(141, 21);
            //this.txt_DatabaseInstance.TabIndex = 9;
            //// 
            //// txt_DataBaseName
            //// 
            //this.txt_DataBaseName.Location = new System.Drawing.Point(363, 95);
            //this.txt_DataBaseName.Name = "txt_DataBaseName";
            //this.txt_DataBaseName.Size = new System.Drawing.Size(100, 21);
            //this.txt_DataBaseName.TabIndex = 10;
            //// 
            //// txt_DataBaseLoginUser
            //// 
            //this.txt_DataBaseLoginUser.Location = new System.Drawing.Point(576, 95);
            //this.txt_DataBaseLoginUser.Name = "txt_DataBaseLoginUser";
            //this.txt_DataBaseLoginUser.Size = new System.Drawing.Size(117, 21);
            //this.txt_DataBaseLoginUser.TabIndex = 11;
            //// 
            //// txt_DataBaseLoginPwd
            //// 
            //this.txt_DataBaseLoginPwd.Location = new System.Drawing.Point(812, 95);
            //this.txt_DataBaseLoginPwd.Name = "txt_DataBaseLoginPwd";
            //this.txt_DataBaseLoginPwd.Size = new System.Drawing.Size(108, 21);
            //this.txt_DataBaseLoginPwd.TabIndex = 12;
            //// 
            //// lbl_DataBaseName
            //// 
            //this.lbl_DataBaseName.AutoSize = true;
            //this.lbl_DataBaseName.Location = new System.Drawing.Point(292, 98);
            //this.lbl_DataBaseName.Name = "lbl_DataBaseName";
            //this.lbl_DataBaseName.Size = new System.Drawing.Size(65, 12);
            //this.lbl_DataBaseName.TabIndex = 13;
            //this.lbl_DataBaseName.Text = "数据库名称";
            //// 
            //// lbl_DataBaseLoginUser
            //// 
            //this.lbl_DataBaseLoginUser.AutoSize = true;
            //this.lbl_DataBaseLoginUser.Location = new System.Drawing.Point(469, 98);
            //this.lbl_DataBaseLoginUser.Name = "lbl_DataBaseLoginUser";
            //this.lbl_DataBaseLoginUser.Size = new System.Drawing.Size(101, 12);
            //this.lbl_DataBaseLoginUser.TabIndex = 14;
            //this.lbl_DataBaseLoginUser.Text = "数据库登录用户名";
            //// 
            //// lbl_DataBaseLoginPwd
            //// 
            //this.lbl_DataBaseLoginPwd.AutoSize = true;
            //this.lbl_DataBaseLoginPwd.Location = new System.Drawing.Point(717, 98);
            //this.lbl_DataBaseLoginPwd.Name = "lbl_DataBaseLoginPwd";
            //this.lbl_DataBaseLoginPwd.Size = new System.Drawing.Size(89, 12);
            //this.lbl_DataBaseLoginPwd.TabIndex = 15;
            //this.lbl_DataBaseLoginPwd.Text = "数据库登录密码";
            // 
            // ExportImportTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 503);
            //this.Controls.Add(this.lbl_DataBaseLoginPwd);
            //this.Controls.Add(this.lbl_DataBaseLoginUser);
            //this.Controls.Add(this.lbl_DataBaseName);
            //this.Controls.Add(this.txt_DataBaseLoginPwd);
            //this.Controls.Add(this.txt_DataBaseLoginUser);
            //this.Controls.Add(this.txt_DataBaseName);
            //this.Controls.Add(this.txt_DatabaseInstance);
            //this.Controls.Add(this.lblDataBaseInstance);
            this.Controls.Add(this.lbl_LogInfo);
            this.Controls.Add(this.cmb_ImportDataType);
            this.Controls.Add(this.lbl_ImportDataType);
            this.Controls.Add(this.LogInfoText);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.FileSourceText);
            this.Controls.Add(this.btn_ChooseFile);
            this.Controls.Add(this.labelDataSource);
            this.MaximizeBox = false;
            this.Name = "ExportImportTool";
            this.Text = "导入导出小工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDataSource;
        private System.Windows.Forms.Button btn_ChooseFile;
        private System.Windows.Forms.TextBox FileSourceText;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.RichTextBox LogInfoText;
        private System.Windows.Forms.Label lbl_ImportDataType;
        private System.Windows.Forms.ComboBox cmb_ImportDataType;
        private System.Windows.Forms.Label lbl_LogInfo;
        //private System.Windows.Forms.Label lblDataBaseInstance;
        //private System.Windows.Forms.TextBox txt_DatabaseInstance;
        //private System.Windows.Forms.TextBox txt_DataBaseName;
        //private System.Windows.Forms.TextBox txt_DataBaseLoginUser;
        //private System.Windows.Forms.TextBox txt_DataBaseLoginPwd;
        //private System.Windows.Forms.Label lbl_DataBaseName;
        //private System.Windows.Forms.Label lbl_DataBaseLoginUser;
        //private System.Windows.Forms.Label lbl_DataBaseLoginPwd;
    }
}

