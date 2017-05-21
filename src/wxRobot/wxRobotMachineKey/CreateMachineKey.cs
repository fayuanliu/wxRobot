using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using wxRobot.Util.Utils;

namespace wxRobotMachineKey
{
    public partial class CreateMachineKey : Skin_Metro
    {
        public CreateMachineKey()
        {
            InitializeComponent();
        }

        private void txtCreaterCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMachineKey.Text))
            {
                MessageBox.Show("请输入机器码！");
                return;
            }
            int count = 0;
            if (!int.TryParse(txtCreaterCount.Text,out count))
            {
                MessageBox.Show("请输入正确的生成资数（必须为数字）！");
                return;
            }
            this.lblAuthCode.Text = GetAESInfo.Set(txtCreaterCount.Text, txtMachineKey.Text);
        }
    }
}
