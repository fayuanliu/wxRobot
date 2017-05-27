namespace wxRobot
{
    partial class AuthForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel3 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel4 = new CCWin.SkinControl.SkinLabel();
            this.txtAuthCode = new CCWin.SkinControl.SkinTextBox();
            this.skinLabel5 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel6 = new CCWin.SkinControl.SkinLabel();
            this.skinLabel7 = new CCWin.SkinControl.SkinLabel();
            this.btnAuth = new CCWin.SkinControl.SkinButton();
            this.lblMCCode = new CCWin.SkinControl.SkinTextBox();
            this.SuspendLayout();
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(83, 134);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(47, 17);
            this.skinLabel1.TabIndex = 0;
            this.skinLabel1.Text = "机器码:";
            // 
            // skinLabel3
            // 
            this.skinLabel3.AutoSize = true;
            this.skinLabel3.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel3.BorderColor = System.Drawing.Color.White;
            this.skinLabel3.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel3.ForeColor = System.Drawing.Color.Red;
            this.skinLabel3.Location = new System.Drawing.Point(62, 28);
            this.skinLabel3.Name = "skinLabel3";
            this.skinLabel3.Size = new System.Drawing.Size(84, 20);
            this.skinLabel3.TabIndex = 2;
            this.skinLabel3.Text = "授权流程：";
            // 
            // skinLabel4
            // 
            this.skinLabel4.AutoSize = true;
            this.skinLabel4.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel4.BorderColor = System.Drawing.Color.White;
            this.skinLabel4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel4.Location = new System.Drawing.Point(83, 172);
            this.skinLabel4.Name = "skinLabel4";
            this.skinLabel4.Size = new System.Drawing.Size(47, 17);
            this.skinLabel4.TabIndex = 3;
            this.skinLabel4.Text = "授权码:";
            // 
            // txtAuthCode
            // 
            this.txtAuthCode.BackColor = System.Drawing.Color.Transparent;
            this.txtAuthCode.DownBack = null;
            this.txtAuthCode.Icon = null;
            this.txtAuthCode.IconIsButton = false;
            this.txtAuthCode.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtAuthCode.IsPasswordChat = '\0';
            this.txtAuthCode.IsSystemPasswordChar = false;
            this.txtAuthCode.Lines = new string[] {
        "请输入代理商给的授权码"};
            this.txtAuthCode.Location = new System.Drawing.Point(161, 161);
            this.txtAuthCode.Margin = new System.Windows.Forms.Padding(0);
            this.txtAuthCode.MaxLength = 32767;
            this.txtAuthCode.MinimumSize = new System.Drawing.Size(28, 28);
            this.txtAuthCode.MouseBack = null;
            this.txtAuthCode.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.txtAuthCode.Multiline = false;
            this.txtAuthCode.Name = "txtAuthCode";
            this.txtAuthCode.NormlBack = null;
            this.txtAuthCode.Padding = new System.Windows.Forms.Padding(5);
            this.txtAuthCode.ReadOnly = false;
            this.txtAuthCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtAuthCode.Size = new System.Drawing.Size(312, 28);
            // 
            // 
            // 
            this.txtAuthCode.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAuthCode.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtAuthCode.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.txtAuthCode.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.txtAuthCode.SkinTxt.Name = "BaseText";
            this.txtAuthCode.SkinTxt.Size = new System.Drawing.Size(302, 18);
            this.txtAuthCode.SkinTxt.TabIndex = 0;
            this.txtAuthCode.SkinTxt.Text = "请输入代理商给的授权码";
            this.txtAuthCode.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtAuthCode.SkinTxt.WaterText = "";
            this.txtAuthCode.TabIndex = 4;
            this.txtAuthCode.Text = "请输入代理商给的授权码";
            this.txtAuthCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtAuthCode.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.txtAuthCode.WaterText = "";
            this.txtAuthCode.WordWrap = true;
            this.txtAuthCode.Enter += new System.EventHandler(this.TxtMessage_Enter);
            this.txtAuthCode.Leave += new System.EventHandler(this.TxtMessage_Leave);
            this.txtAuthCode.MouseEnter += new System.EventHandler(this.TxtMessage_Enter);
            this.txtAuthCode.MouseLeave += new System.EventHandler(this.TxtMessage_Leave);
            this.txtAuthCode.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtAuthCode_MouseUp);
            // 
            // skinLabel5
            // 
            this.skinLabel5.AutoSize = true;
            this.skinLabel5.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel5.BorderColor = System.Drawing.Color.White;
            this.skinLabel5.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.skinLabel5.Location = new System.Drawing.Point(158, 55);
            this.skinLabel5.Name = "skinLabel5";
            this.skinLabel5.Size = new System.Drawing.Size(135, 17);
            this.skinLabel5.TabIndex = 5;
            this.skinLabel5.Text = "1、复制机器码给代理商";
            // 
            // skinLabel6
            // 
            this.skinLabel6.AutoSize = true;
            this.skinLabel6.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel6.BorderColor = System.Drawing.Color.White;
            this.skinLabel6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.skinLabel6.Location = new System.Drawing.Point(158, 75);
            this.skinLabel6.Name = "skinLabel6";
            this.skinLabel6.Size = new System.Drawing.Size(258, 17);
            this.skinLabel6.TabIndex = 6;
            this.skinLabel6.Text = "2、将代理商给的rpdc授权码粘贴到授权码框内";
            // 
            // skinLabel7
            // 
            this.skinLabel7.AutoSize = true;
            this.skinLabel7.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel7.BorderColor = System.Drawing.Color.White;
            this.skinLabel7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.skinLabel7.Location = new System.Drawing.Point(158, 98);
            this.skinLabel7.Name = "skinLabel7";
            this.skinLabel7.Size = new System.Drawing.Size(99, 17);
            this.skinLabel7.TabIndex = 7;
            this.skinLabel7.Text = "3、点击授权按钮";
            // 
            // btnAuth
            // 
            this.btnAuth.BackColor = System.Drawing.Color.Transparent;
            this.btnAuth.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.btnAuth.DownBack = null;
            this.btnAuth.Location = new System.Drawing.Point(398, 207);
            this.btnAuth.MouseBack = null;
            this.btnAuth.Name = "btnAuth";
            this.btnAuth.NormlBack = null;
            this.btnAuth.Size = new System.Drawing.Size(75, 23);
            this.btnAuth.TabIndex = 8;
            this.btnAuth.Text = " 授 权 ";
            this.btnAuth.UseVisualStyleBackColor = false;
            this.btnAuth.Click += new System.EventHandler(this.btnAuth_Click);
            // 
            // lblMCCode
            // 
            this.lblMCCode.BackColor = System.Drawing.Color.Transparent;
            this.lblMCCode.DownBack = null;
            this.lblMCCode.Icon = null;
            this.lblMCCode.IconIsButton = false;
            this.lblMCCode.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.lblMCCode.IsPasswordChat = '\0';
            this.lblMCCode.IsSystemPasswordChar = false;
            this.lblMCCode.Lines = new string[] {
        "0000-0000-0000-0000-0000"};
            this.lblMCCode.Location = new System.Drawing.Point(161, 123);
            this.lblMCCode.Margin = new System.Windows.Forms.Padding(0);
            this.lblMCCode.MaxLength = 32767;
            this.lblMCCode.MinimumSize = new System.Drawing.Size(28, 28);
            this.lblMCCode.MouseBack = null;
            this.lblMCCode.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.lblMCCode.Multiline = false;
            this.lblMCCode.Name = "lblMCCode";
            this.lblMCCode.NormlBack = null;
            this.lblMCCode.Padding = new System.Windows.Forms.Padding(5);
            this.lblMCCode.ReadOnly = true;
            this.lblMCCode.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.lblMCCode.Size = new System.Drawing.Size(312, 28);
            // 
            // 
            // 
            this.lblMCCode.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblMCCode.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMCCode.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.lblMCCode.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.lblMCCode.SkinTxt.Name = "BaseText";
            this.lblMCCode.SkinTxt.ReadOnly = true;
            this.lblMCCode.SkinTxt.Size = new System.Drawing.Size(302, 18);
            this.lblMCCode.SkinTxt.TabIndex = 0;
            this.lblMCCode.SkinTxt.Text = "0000-0000-0000-0000-0000";
            this.lblMCCode.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.lblMCCode.SkinTxt.WaterText = "";
            this.lblMCCode.TabIndex = 9;
            this.lblMCCode.Text = "0000-0000-0000-0000-0000";
            this.lblMCCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.lblMCCode.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.lblMCCode.WaterText = "";
            this.lblMCCode.WordWrap = true;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 246);
            this.Controls.Add(this.lblMCCode);
            this.Controls.Add(this.btnAuth);
            this.Controls.Add(this.skinLabel7);
            this.Controls.Add(this.skinLabel6);
            this.Controls.Add(this.skinLabel5);
            this.Controls.Add(this.txtAuthCode);
            this.Controls.Add(this.skinLabel4);
            this.Controls.Add(this.skinLabel3);
            this.Controls.Add(this.skinLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuthForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "授权";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AuthForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinLabel skinLabel3;
        private CCWin.SkinControl.SkinLabel skinLabel4;
        private CCWin.SkinControl.SkinTextBox txtAuthCode;
        private CCWin.SkinControl.SkinLabel skinLabel5;
        private CCWin.SkinControl.SkinLabel skinLabel6;
        private CCWin.SkinControl.SkinLabel skinLabel7;
        private CCWin.SkinControl.SkinButton btnAuth;
        private CCWin.SkinControl.SkinTextBox lblMCCode;
    }
}