using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using wxRobot.Services;
using wxRobot.Util.Enums;
using wxRobot.Util.Utils;

namespace wxRobot
{
    public partial class AuthForm : CCSkinMain
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        private void btnAuth_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtAuthCode.Text))
            {
                MessageBox.Show("请输入代理商给的授权码");
                return;
            }
            else
            {
                ServiceRecordSvc recordSvc = new ServiceRecordSvc();
                OperResult result = recordSvc.Auth(this.txtAuthCode.Text, this.lblMCCode.Text);
                if (result.Code!= ResultCodeEnums.Auth)
                {
                    MessageBox.Show(result.Msg);
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        private void AuthForm_Load(object sender, EventArgs e)
        {
            this.lblMCCode.Text =Guid.NewGuid().ToString("n");
            SetSendContent();
        }

        private void TxtMessage_Enter(object sender, EventArgs e)
        {
            if (this.txtAuthCode.Text == "请输入你要发送的信息")
            {
                this.txtAuthCode.Text = string.Empty;
                this.txtAuthCode.ForeColor = Color.Black;
            }
        }

        private void TxtMessage_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtAuthCode.Text))
            {
                this.txtAuthCode.Text = "请输入代理商给的授权码";
                this.txtAuthCode.ForeColor = Color.Gray;
            }

        }

        private void SetSendContent()
        {
            if (this.txtAuthCode.Text == "请输入代理商给的授权码")
            {
                this.txtAuthCode.Text = string.Empty;
                this.txtAuthCode.ForeColor = Color.Black;
            }
        }

        private void txtAuthCode_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
