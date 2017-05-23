﻿using CCWin;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using wxRobot.Util.Enums;
using wxRobot.Model;
using wxRobot.Model.Dto;
using wxRobot.Services;

namespace wxRobot
{
    public partial class FormMain : CCSkinMain
    {
        private const String DEFAULT_TEXT = "请输入你要发送的信息";

        private static List<object> _contact_all = new List<object>();
        private static List<WXUser> contact_all = new List<WXUser>();

        /// <summary>
        /// 当前登录微信用户
        /// </summary>
        private static WXUser _me;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            WindowInit();
        }

        

        private void WindowInit()
        {
            skinTabControl1.TabPages[1].Select();
            BindMessageGrid();
            //扫码
            GetLoginQRCode();
        }

        public void IsAuth()
        {
            ServiceRecordSvc recordSvc = new ServiceRecordSvc();
            var OperResult = recordSvc.IsAuth();
            if (OperResult.Code == ResultCodeEnums.Auth)
            {
                GetLoginQRCode();
            }
            else if (OperResult.Code == ResultCodeEnums.AuthExpire)
            {
                MessageBox.Show(OperResult.Msg);
            }
            else if (OperResult.Code == ResultCodeEnums.UnAuth)
            {
                var result = MessageBox.Show(OperResult.Msg + "，是否现在进行授权", "系统提示", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    AuthForm authForm = new AuthForm();
                    authForm.ShowDialog();
                }
                else
                {
                    Application.Exit();
                }
            }
        }

        private void JudgedImage(OpenFileDialog fileDialog, string extension)
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
            string[] str = new string[] { ".mp4", ".flv", ".f4v", ".rm", ".rmvb", ".wmv", ".avi", ".3gp" };
            if (!str.Contains(extension))
            {
                MessageBox.Show("仅能上传mp4,flv,f4v,rm,rmvb,wmv,avi,3gp格式的视频！");
            }
            else
            {
                //获取用户选择的文件，并判断文件大小不能超过20M，fileInfo.Length是以字节为单位的
                FileInfo fileInfo = new FileInfo(fileDialog.FileName);
                if (fileInfo.Length > 1024 * 2 * 1000 * 10)
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

        public void BindMessageGrid()
        {
            MessageServces servces = new MessageServces();
            this.DataGridMessage.DataSource = servces.GetDefultMessage();
        }

        public void GetLoginQRCode()
        {
            picQRCode.Image = null;
            picQRCode.SizeMode = PictureBoxSizeMode.Zoom;
            lblTip.Text = "手机微信扫一扫以登录";
            ((Action)(delegate ()
            {
                //异步加载二维码
                LoginService ls = new LoginService();
                Image qrcode = ls.GetQRCode();
                if (qrcode != null)
                {
                    this.BeginInvoke((Action)delegate ()
                    {
                        picQRCode.Image = qrcode;
                    });

                    object login_result = null;
                    while (true)  //循环判断手机扫面二维码结果
                    {
                        login_result = ls.LoginCheck();
                        if (login_result is Image) //已扫描 未登录
                        {
                            this.BeginInvoke((Action)delegate ()
                            {
                                lblTip.Text = "请点击手机上登录按钮";
                                picQRCode.SizeMode = PictureBoxSizeMode.CenterImage;  //显示头像
                                picQRCode.Image = login_result as Image;
                            });
                        }
                        if (login_result is string)  //已完成登录
                        {
                            this.BeginInvoke((Action)delegate ()
                            {
                                lblTip.Text = "登录成功！";
                            });

                            //访问登录跳转URL
                            ls.GetSidUid(login_result as string);
                            //获取好友和并绑定
                            UserServices userServices = new UserServices();
                            WXServices wxServices = new WXServices();
                            JObject initResult = wxServices.WxInit();
                            if (initResult != null)
                            {
                                _me = new WXUser();
                                _me.UserName = initResult["User"]["UserName"].ToString();
                                _me.City = "";
                                _me.HeadImgUrl = initResult["User"]["HeadImgUrl"].ToString();
                                _me.NickName = initResult["User"]["NickName"].ToString();
                                _me.Province = "";
                                _me.PYQuanPin = initResult["User"]["PYQuanPin"].ToString();
                                _me.RemarkName = initResult["User"]["RemarkName"].ToString();
                                _me.RemarkPYQuanPin = initResult["User"]["RemarkPYQuanPin"].ToString();
                                _me.Sex = initResult["User"]["Sex"].ToString();
                                _me.Signature = initResult["User"]["Signature"].ToString();
                            }

                            JObject contact_result = userServices.GetContact(); //通讯录
                            if (contact_result != null)
                            {
                                foreach (JObject contact in contact_result["MemberList"])  //完整好友名单
                                {
                                    WXUser user = new WXUser();
                                    user.UserName = contact["UserName"].ToString();
                                    user.City = contact["City"].ToString();
                                    user.HeadImgUrl = contact["HeadImgUrl"].ToString();
                                    user.NickName = contact["NickName"].ToString();
                                    user.Province = contact["Province"].ToString();
                                    user.PYQuanPin = contact["PYQuanPin"].ToString();
                                    user.RemarkName = contact["RemarkName"].ToString();
                                    user.RemarkPYQuanPin = contact["RemarkPYQuanPin"].ToString();
                                    user.Sex = contact["Sex"].ToString();
                                    user.Signature = contact["Signature"].ToString();
                                    contact_all.Add(user);
                                }
                            }
                            IOrderedEnumerable<WXUser> list_all = contact_all.OrderBy(e => (e as WXUser).ShowPinYin);

                            WXUser wx;
                            string start_char;
                            foreach (object o in list_all)
                            {
                                wx = o as WXUser;
                                start_char = wx.ShowPinYin == "" ? "" : wx.ShowPinYin.Substring(0, 1);
                                if (!_contact_all.Contains(start_char.ToUpper()))
                                {
                                    _contact_all.Add(start_char.ToUpper());
                                }
                                _contact_all.Add(o);
                            }
                            //等待结束
                            this.BeginInvoke((Action)(delegate ()
                            {
                                //通讯录
                                wFriendsList1.Items.AddRange(_contact_all.ToArray());
                                BindOwer(_me);
                            }));
                            return;
                        }
                    }
                }
            })).BeginInvoke(null, null);
        }

        public void BindOwer(WXUser me)
        {
            picImage.Image = me.Icon;
            lblNick.Text = me.NickName;
            lblArea.Text = me.City + "，" + me.Province;
            lblSignature.Text = me.Signature;
            picSexImage.Image = me.Sex == "1" ? Properties.Resources.male : Properties.Resources.female;
            picSexImage.Location = new Point(lblNick.Location.X + lblNick.Width + 4, picSexImage.Location.Y);
            if (me.Icon == null)
            {
                picImage.Image = picQRCode.Image;
            }
            else
            {
                picImage.Image = me.Icon;
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            List<MessageType> message = new List<MessageType>();
            int count = DataGridMessage.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)DataGridMessage.Rows[i].Cells[0];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)
                {
                    MessageType msgType = new MessageType()
                    {
                        SendType = this.DataGridMessage.Rows[i].Cells[1].Value.ToString(),
                        TxtContent = this.DataGridMessage.Rows[i].Cells[2].Value.ToString()
                    };
                    message.Add(msgType);
                }
            }
            if (message.Count <= 0)
            {
                MessageBox.Show("请选择好你要发送的消息！");
                return;
            }
            WXMesssage msg = new WXMesssage();
            var data = message.FirstOrDefault();
            //发消息
            foreach (var item in contact_all)
            {
                msg.From = _me.UserName;
                msg.Msg = data.TxtContent;
                msg.Readed = false;
                msg.To = item.UserName;
                msg.Type = 1;
                msg.MediaId = "@crypt_2e1753f0_6d7f7788f14a11f6025562357a09f892d485997c12e4a53388ba004bc8ca26cf0db6a1e365e2848b6cd18fcaf98dec1d70c286a3b8efd8e211d40e14b4dfde3723760919e21c707aca71d7ab3551adf7a9ff0e50fa286420cf2cf8fa11152f9d6b02c21791bf468eb76b827a5fbcfb2faaf9d2b69c739db92006f9b1bc873e26ba3c372913619c1da7beccf9d3f85fe16ae9925648dd25268cfe7500cf3d623ef95b1b71bd1367707e5bf9e4e1e298378c3e9f09983751bac8df085f18c7f1a84f226694cb920b7ea99e5b6c778e501bde423b020293c8318fc149a54b039a637135f46dc154c4fb4da3d0608fbf7523ad8efc1af1571e2ecb73b827a4e932c21972b82c77966c3196165c10ddc4ee963496a79f159f30f6281f3634701e001eab878ecd9b2342cec6d6d2cf863ab6e9";
                msg.Time = DateTime.Now;
                if (item.NickName != "胡永乐" && item.NickName != "研发基地2")
                {
                    item.SendMsg(msg);
                }
            }

        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("你确定要关闭吗！", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                e.Cancel = false;  //点击OK
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
           // IsAuth();
        }
    }
}
