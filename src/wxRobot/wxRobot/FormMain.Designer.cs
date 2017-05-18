namespace wxRobot
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.cbxMsgType = new CCWin.SkinControl.SkinComboBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.TxtMessage = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.btnFile = new CCWin.SkinControl.SkinButton();
            this.btnEnter = new CCWin.SkinControl.SkinButton();
            this.SuspendLayout();
            // 
            // cbxMsgType
            // 
            this.cbxMsgType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbxMsgType.FormattingEnabled = true;
            this.cbxMsgType.Location = new System.Drawing.Point(202, 34);
            this.cbxMsgType.Name = "cbxMsgType";
            this.cbxMsgType.Size = new System.Drawing.Size(253, 22);
            this.cbxMsgType.TabIndex = 2;
            this.cbxMsgType.WaterText = "";
            this.cbxMsgType.SelectedIndexChanged += new System.EventHandler(this.cbxMsgType_SelectedIndexChanged);
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(67, 39);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(92, 17);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = "发送消息类型：";
            // 
            // TxtMessage
            // 
            this.TxtMessage.BackColor = System.Drawing.Color.Transparent;
            this.TxtMessage.DownBack = null;
            this.TxtMessage.Icon = null;
            this.TxtMessage.IconIsButton = false;
            this.TxtMessage.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.TxtMessage.IsPasswordChat = '\0';
            this.TxtMessage.IsSystemPasswordChar = false;
            this.TxtMessage.Lines = new string[0];
            this.TxtMessage.Location = new System.Drawing.Point(202, 81);
            this.TxtMessage.Margin = new System.Windows.Forms.Padding(0);
            this.TxtMessage.MaxLength = 32767;
            this.TxtMessage.MinimumSize = new System.Drawing.Size(28, 28);
            this.TxtMessage.MouseBack = null;
            this.TxtMessage.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.TxtMessage.Multiline = true;
            this.TxtMessage.Name = "TxtMessage";
            this.TxtMessage.NormlBack = null;
            this.TxtMessage.Padding = new System.Windows.Forms.Padding(5);
            this.TxtMessage.ReadOnly = false;
            this.TxtMessage.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TxtMessage.Size = new System.Drawing.Size(253, 72);
            // 
            // 
            // 
            this.TxtMessage.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtMessage.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtMessage.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.TxtMessage.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.TxtMessage.SkinTxt.Multiline = true;
            this.TxtMessage.SkinTxt.Name = "BaseText";
            this.TxtMessage.SkinTxt.Size = new System.Drawing.Size(243, 62);
            this.TxtMessage.SkinTxt.TabIndex = 0;
            this.TxtMessage.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtMessage.SkinTxt.WaterText = "";
            this.TxtMessage.TabIndex = 4;
            this.TxtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.TxtMessage.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.TxtMessage.WaterText = "";
            this.TxtMessage.WordWrap = true;
            this.TxtMessage.Enter += new System.EventHandler(this.TxtMessage_Enter);
            this.TxtMessage.Leave += new System.EventHandler(this.TxtMessage_Leave);
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(91, 111);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(68, 17);
            this.skinLabel2.TabIndex = 5;
            this.skinLabel2.Text = "消息内容：";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.Location = new System.Drawing.Point(91, 189);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(68, 17);
            this.skinLabel3.TabIndex = 6;
            this.skinLabel3.Text = "选择文件：";
            // 
            // btnFile
            // 
            this.btnFile.BackColor = System.Drawing.Color.Transparent;
            this.btnFile.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnFile.DownBack = null;
            this.btnFile.Location = new System.Drawing.Point(202, 189);
            this.btnFile.MouseBack = null;
            this.btnFile.Name = "btnFile";
            this.btnFile.NormlBack = null;
            this.btnFile.Size = new System.Drawing.Size(181, 23);
            this.btnFile.TabIndex = 7;
            this.btnFile.Text = "选择你要发送的图片或视频";
            this.btnFile.UseVisualStyleBackColor = false;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Transparent;
            this.btnEnter.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnEnter.DownBack = null;
            this.btnEnter.Location = new System.Drawing.Point(368, 243);
            this.btnEnter.MouseBack = null;
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.NormlBack = null;
            this.btnEnter.Size = new System.Drawing.Size(146, 23);
            this.btnEnter.TabIndex = 8;
            this.btnEnter.Text = "确认信息后点击并扫码";
            this.btnEnter.UseVisualStyleBackColor = false;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 282);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.btnFile);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.TxtMessage);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.cbxMsgType);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "微信机器人";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinComboBox cbxMsgType;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinTextBox TxtMessage;
        private CCWin.SkinControl.SkinLabel skinLabel2;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinButton btnFile;
        private CCWin.SkinControl.SkinButton btnEnter;
    }
}

