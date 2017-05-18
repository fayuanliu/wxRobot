using CCWin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using wxRobot.Enums;

namespace wxRobot
{
    public partial class FormMain : CCSkinMain
    {
        private const String DEFAULT_TEXT = "请输入你要发送的信息";
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadMessageTypeCombo(this.cbxMsgType);
            SetSendContent();
            WindowInit();
        }

        private void cbxMsgType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetSendContent();
        }

        public void LoadMessageTypeCombo(ComboBox cbo)
        {
            cbo.DataSource = Enum.GetValues(typeof(MessageTypeEnum))
            .Cast<Enum>()
            .Select(value => new
            {
                (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                value
            })
            .OrderBy(item => item.value)
            .ToList();
            cbo.DisplayMember = "Description";
            cbo.ValueMember = "value";
        }

        private void SetSendContent()
        {
            string type = this.cbxMsgType.SelectedValue.ToString();
            if (type == MessageTypeEnum.Text.ToString())
            {
                this.btnFile.Enabled = false;
                this.TxtMessage.Enabled = true;
            }
            else if (type == MessageTypeEnum.Image.ToString())
            {
                this.TxtMessage.Text = string.Empty;
                this.TxtMessage.Enabled = false;
                this.btnFile.Enabled = true;
            }
            else if (type == MessageTypeEnum.Video.ToString())
            {
                this.TxtMessage.Text = string.Empty;
                this.TxtMessage.Enabled = false;
                this.btnFile.Enabled = true;
            }
        }

        private void WindowInit()
        {
            this.TxtMessage.Text = DEFAULT_TEXT;
            this.TxtMessage.ForeColor = Color.Gray;
        }

        private void TxtMessage_Enter(object sender, EventArgs e)
        {
            if (this.TxtMessage.Text == "请输入你要发送的信息")
            {
                this.TxtMessage.Text = string.Empty;
                this.TxtMessage.ForeColor = Color.Black;
            }
        }

        private void TxtMessage_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TxtMessage.Text))
            {
                this.TxtMessage.Text = DEFAULT_TEXT;
                this.TxtMessage.ForeColor = Color.Gray;
            }

        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            string type = this.cbxMsgType.SelectedValue.ToString();
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string extension = Path.GetExtension(fileDialog.FileName);
                if (type == MessageTypeEnum.Image.ToString())
                {
                    JudgedImage(fileDialog, extension);
                }
                else if(type == MessageTypeEnum.Video.ToString())
                {
                    JudgedVideo(fileDialog, extension);
                }
            }
        }

        private  void JudgedImage(OpenFileDialog fileDialog, string extension)
        {
            string[] str = new string[] { ".gif", ".jpge", ".jpg" };
            if (!str.Contains(extension))
            {
                MessageBox.Show("仅能上传gif,jpge,jpg格式的图片！");
            }
            else
            {
                //获取用户选择的文件，并判断文件大小不能超过2M，fileInfo.Length是以字节为单位的
                FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                if (fileInfo.Length > 1024 * 2 * 1000)
                {
                    MessageBox.Show("上传的图片不能大于2M");
                }
                else
                {
                    //在这里就可以写获取到正确文件后的代码了
                }
            }
        }

        private void JudgedVideo(OpenFileDialog fileDialog, string extension)
        {
            string[] str = new string[] { ".mp4", ".flv", ".f4v",".rm", ".rmvb", ".wmv", ".avi", ".3gp"};
            if (!str.Contains(extension))
            {
                MessageBox.Show("仅能上传mp4,flv,f4v,rm,rmvb,wmv,avi,3gp格式的视频！");
            }
            else
            {
                //获取用户选择的文件，并判断文件大小不能超过20M，fileInfo.Length是以字节为单位的
                FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                if (fileInfo.Length > 1024 * 2 * 1000*10)
                {
                    MessageBox.Show("上传的图片不能大于2M");
                }
                else
                {
                    //在这里就可以写获取到正确文件后的代码了
                }
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {

        }
    }
}
