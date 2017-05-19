namespace wxRobotMachineKey
{
    partial class CreateMachineKey
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
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.txtMachineKey = new CCWin.SkinControl.RtfRichTextBox();
            this.btnCreate = new CCWin.SkinControl.SkinButton();
            this.txtAuthCode = new CCWin.SkinControl.RtfRichTextBox();
            this.skinLabel2 = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(34, 27);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(56, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "机器码：";
            // 
            // txtMachineKey
            // 
            this.txtMachineKey.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.txtMachineKey.Location = new System.Drawing.Point(120, 21);
            this.txtMachineKey.Name = "txtMachineKey";
            this.txtMachineKey.Size = new System.Drawing.Size(286, 27);
            this.txtMachineKey.TabIndex = 1;
            this.txtMachineKey.Text = "";
            this.txtMachineKey.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.Transparent;
            this.btnCreate.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnCreate.DownBack = null;
            this.btnCreate.Location = new System.Drawing.Point(435, 25);
            this.btnCreate.MouseBack = null;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.NormlBack = null;
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "生成授权码";
            this.btnCreate.UseVisualStyleBackColor = false;
            // 
            // txtAuthCode
            // 
            this.txtAuthCode.HiglightColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.White;
            this.txtAuthCode.Location = new System.Drawing.Point(120, 73);
            this.txtAuthCode.Name = "txtAuthCode";
            this.txtAuthCode.Size = new System.Drawing.Size(286, 26);
            this.txtAuthCode.TabIndex = 3;
            this.txtAuthCode.Text = "";
            this.txtAuthCode.TextColor = CCWin.SkinControl.RtfRichTextBox.RtfColor.Black;
            // 
            // skinLabel2
            // 
            this.skinLabel2.AutoSize = true;
            this.skinLabel2.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel2.BorderColor = System.Drawing.Color.White;
            this.skinLabel2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel2.Location = new System.Drawing.Point(34, 82);
            this.skinLabel2.Name = "skinLabel2";
            this.skinLabel2.Size = new System.Drawing.Size(56, 17);
            this.skinLabel2.TabIndex = 4;
            this.skinLabel2.Text = "授权码：";
            // 
            // CreateMachineKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 111);
            this.Controls.Add(this.skinLabel2);
            this.Controls.Add(this.txtAuthCode);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtMachineKey);
            this.Controls.Add(this.skinLabel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateMachineKey";
            this.Text = "授权码生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.RtfRichTextBox txtMachineKey;
        private CCWin.SkinControl.SkinButton btnCreate;
        private CCWin.SkinControl.RtfRichTextBox txtAuthCode;
        private CCWin.SkinControl.SkinLabel skinLabel2;
    }
}

