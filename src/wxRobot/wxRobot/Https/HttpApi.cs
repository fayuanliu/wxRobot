using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wxRobot.Https
{
    public class HttpApi
    {
        public static Hashtable Api = new Hashtable();

        public void SetWX()
        {
            Api.Clear();
            //获取好友头像
            Api.Add("_geticon_url", "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxgeticon?username=");
            //获取群聊（组）头像
            Api.Add("_getheadimg_url", "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxgetheadimg?username=");
            //获取好友列表
            Api.Add("_getcontact_url", "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxgetcontact");
            //微信初始化url
            Api.Add("_init_url", "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxinit?r=884513456464");
            //发送消息url
            Api.Add("_sendmsg_url", "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsg?sid=");
            //上传文件
            Api.Add("_uplpadFileUrl", "https://file.wx.qq.com/cgi-bin/mmwebwx-bin/webwxuploadmedia?f=json");
            //发送图片消息
            Api.Add("_sendmsgimg", "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsgimg?fun=async&f=json");
            //发送视频消息
            Api.Add("_sendvideomsg", "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxsendvideomsg?fun=async&f=json");
        }

        public void SetWX2()
        {
            Api.Clear();
            //获取好友头像
            Api.Add("_geticon_url", "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxgeticon?username=");
            //获取群聊（组）头像
            Api.Add("_getheadimg_url", "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxgetheadimg?username=");
            //获取好友列表
            Api.Add("_getcontact_url", "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxgetcontact");
            //微信初始化url
            Api.Add("_init_url", "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxinit?r=884513456464");
            //发送消息url
            Api.Add("_sendmsg_url", "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsg?sid=");
            //上传文件
            Api.Add("_uplpadFileUrl", "https://file.wx2.qq.com/cgi-bin/mmwebwx-bin/webwxuploadmedia?f=json");
            //发送图片消息
            Api.Add("_sendmsgimg", "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsgimg?fun=async&f=json");
            //发送视频消息
            Api.Add("_sendvideomsg", "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxsendvideomsg?fun=async&f=json");
        }

        public void InitApi(string url)
        {
            if (url.Contains("wx2"))
            {
                SetWX2();
            }
            else
            {
                SetWX();
            }
        }
    }
}
