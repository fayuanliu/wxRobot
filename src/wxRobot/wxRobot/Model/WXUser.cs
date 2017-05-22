using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using wxRobot.Model.Dto;
using wxRobot.Services;

namespace wxRobot.Model
{
    public class WXUser
    {
        /// <summary>
        /// ID
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }

        /// <summary>
        /// 头像url
        /// </summary>
        public string HeadImgUrl { get; set; }

        /// <summary>
        /// 备注名
        /// </summary>
        public string RemarkName { get; set; }

        /// <summary>
        /// 性别 男1 女2 其他0
        /// </summary>
        public string Sex { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }

        /// <summary>
        /// 昵称全拼
        /// </summary>
        public string PYQuanPin { get; set; }

        /// <summary>
        /// 备注名全拼
        /// </summary>
        public string RemarkPYQuanPin { get; set; }

        private bool _loading_icon = false;

        private Image _icon;

        /// <summary>
        /// 头像
        /// </summary>
        public Image Icon
        {
            get
            {
                if (_icon == null && !_loading_icon)
                {
                    _loading_icon = true;
                    ((Action)(delegate ()
                    {
                        UserServices wxs = new UserServices();
                        if (UserName.Contains("@@"))  //讨论组
                        {
                            _icon = wxs.GetHeadImg(UserName);
                        }
                        else if (UserName.Contains("@"))  //好友
                        {
                            _icon = wxs.GetIcon(UserName);
                        }
                        else
                        {
                            _icon = wxs.GetIcon(UserName);
                        }
                        _loading_icon = false;
                    })).BeginInvoke(null, null);
                }
                return _icon;
            }
        }



        /// <summary>
        /// 显示的拼音全拼
        /// </summary>
        public string ShowPinYin
        {
            get
            {
                return (RemarkPYQuanPin == null || RemarkPYQuanPin == "") ? PYQuanPin : RemarkPYQuanPin;
            }
        }

        /// <summary>
        /// 显示名称
        /// </summary>
        public string ShowName
        {
            get
            {
                return (RemarkName == null || RemarkName == "") ? NickName : RemarkName;
            }
        }

        /// <summary>
        /// 向该用户发送消息
        /// </summary>
        /// <param name="msg"></param>
        public void SendMsg(WXMesssage msg)
        {
            WXServices wxs = new WXServices();
            wxs.SendMessage(msg.Msg, msg.From, msg.To, msg.Type);
        }

        public void SendVideo(WXMesssage msg)
        {
            WXServices wxs = new WXServices();
            wxs.SendVideo(msg.MediaId, msg.From, msg.To);
        }
    }
}
