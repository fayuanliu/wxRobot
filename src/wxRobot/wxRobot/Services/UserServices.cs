using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using wxRobot.Https;

namespace wxRobot.Services
{
    public class UserServices
    {
        //获取好友头像
        private static string _geticon_url = "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxgeticon?username=";
        //获取群聊（组）头像
        private static string _getheadimg_url = "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxgetheadimg?username=";
        //获取好友列表
        private static string _getcontact_url = "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxgetcontact";



        /// <summary>
        /// 获取微信讨论组头像
        /// </summary>
        /// <param name="usename"></param>
        /// <returns></returns>
        public Image GetHeadImg(string usename)
        {
            byte[] bytes = HttpServer.SendGetRequest(_getheadimg_url + usename);

            return Image.FromStream(new MemoryStream(bytes));
        }

        /// <summary>
        /// 获取好友头像
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public Image GetIcon(string username)
        {
            //if (string.IsNullOrEmpty(username))
            //{
            //    return null;
            //}
            try
            {
                byte[] bytes = HttpServer.SendGetRequest(_geticon_url + username);

                return Image.FromStream(new MemoryStream(bytes));
            }
            catch
            {
                return null;

            }

        }

        /// <summary>
        /// 获取好友列表
        /// </summary>
        /// <returns></returns>
        public JObject GetContact()
        {
            byte[] bytes = HttpServer.SendGetRequest(_getcontact_url);
            string contact_str = Encoding.UTF8.GetString(bytes);

            return JsonConvert.DeserializeObject(contact_str) as JObject;
        }
    }
}
