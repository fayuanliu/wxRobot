using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using wxRobot.Https;
using wxRobot.Model.Dto;
using wxRobot.Util.Utils;

namespace wxRobot.Services
{
    public class WXServices
    {
        private static Dictionary<string, string> _syncKey = new Dictionary<string, string>();
        /// <summary>
        /// 微信初始化url
        /// </summary>
        private string _init_url = HttpApi.Api["_init_url"].ToString();
        //private static string _init_url="https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxinit?r=884513456464";

        /// <summary>
        /// 发送消息url
        /// </summary>
        //private static string _sendmsg_url="https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsg?sid=";
        private string _sendmsg_url = HttpApi.Api["_sendmsg_url"].ToString();
        /// <summary>
        /// 上传文件
        /// </summary>
        //private static string _uplpadFileUrl="https://file.wx.qq.com/cgi-bin/mmwebwx-bin/webwxuploadmedia?f=json";
        private string _uplpadFileUrl = HttpApi.Api["_uplpadFileUrl"].ToString();
        /// <summary>
        /// 发送图片消息
        /// </summary>
       // private static string _sendmsgimg="https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxsendmsgimg?fun=async&f=json";
        private string _sendmsgimg = HttpApi.Api["_sendmsgimg"].ToString();
        /// <summary>
        /// 发送视频消息
        /// </summary>
        //private static string _sendvideomsg="https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxsendvideomsg?fun=async&f=json";
        private string _sendvideomsg = HttpApi.Api["_sendvideomsg"].ToString();
        // private string _webwxgetmsgimg = "https://wx.qq.com/cgi-bin/mmwebwx-bin/webwxgetmsgimg?&MsgID=7328271055096700186&skey=%40crypt_9b7cdeb2_e9026299b97c735745e082c98f1340e5&type=slave";
        private string _webwxgetmsgimg = HttpApi.Api["_webwxgetmsgimg"].ToString();
        //发送文件
       // private string _webwxsendappmsg = "https://wx2.qq.com/cgi-bin/mmwebwx-bin/webwxsendappmsg?fun=async&f=json&lang=zh_CN";
        private string _webwxsendappmsg = HttpApi.Api["_webwxsendappmsg"].ToString();
        /// <summary>
        /// 微信初始化
        /// </summary>
        /// <returns></returns>
        public JObject WxInit()
        {
            string init_json = "{{\"BaseRequest\":{{\"Uin\":\"{0}\",\"Sid\":\"{1}\",\"Skey\":\"{2}\",\"DeviceID\":\"e{3}\"}}}}";
            Cookie sid = HttpServer.GetCookie("wxsid");
            Cookie uin = HttpServer.GetCookie("wxuin");

            if (sid != null && uin != null)
            {
                init_json = string.Format(init_json, uin.Value, sid.Value, LoginService.SKey, Utils.GetTimeSpan());
                byte[] bytes = HttpServer.SendPostRequest(_init_url + "&lang=zh_CN&pass_ticket=" + LoginService.Pass_Ticket, init_json);
                string init_str = Encoding.UTF8.GetString(bytes);

                JObject init_result = JsonConvert.DeserializeObject(init_str) as JObject;

                foreach (JObject synckey in init_result["SyncKey"]["List"])  //同步键值
                {
                    _syncKey.Add(synckey["Key"].ToString(), synckey["Val"].ToString());
                }
                return init_result;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="msg">内容</param>
        /// <param name="from">来</param>
        /// <param name="to">到</param>
        /// <param name="type">类型(文本为1)</param>
        public void SendMessage(string msg, string from, string to, int type)
        {
            string msg_json = "{{" +
           "\"BaseRequest\":{{" +
               "\"DeviceID\" : \"e{10}\"," +
               "\"Sid\" : \"{0}\"," +
               "\"Skey\" : \"{6}\"," +
               "\"Uin\" : \"{1}\"" +
           "}}," +
           "\"Msg\" : {{" +
               "\"ClientMsgId\" : {8}," +
               "\"Content\" : \"{2}\"," +
               "\"FromUserName\" : \"{3}\"," +
               "\"LocalID\" : {9}," +
               "\"ToUserName\" : \"{4}\"," +
               "\"Type\" : {5}" +
           "}}," +
           "\"rr\" : {7}" +
           "}}";

            Cookie sid = HttpServer.GetCookie("wxsid");
            Cookie uin = HttpServer.GetCookie("wxuin");

            if (sid != null && uin != null)
            {
                msg_json = string.Format(msg_json, sid.Value, uin.Value, msg, from, to, type, LoginService.SKey, DateTime.Now.Millisecond, DateTime.Now.Millisecond, DateTime.Now.Millisecond, Utils.GetTimeSpan());

                byte[] bytes = HttpServer.SendPostRequest(_sendmsg_url + sid.Value + "&lang=zh_CN&pass_ticket=" + LoginService.Pass_Ticket, msg_json);

                string send_result = Encoding.UTF8.GetString(bytes);
            }
        }


        public void SendVideo(string MediaId, string from, string to)
        {
            string msg_json = "{{" +
          "\"BaseRequest\":{{" +
              "\"DeviceID\" : \"e{0}\"," +
              "\"Sid\" : \"{1}\"," +
              "\"Skey\" : \"{2}\"," +
              "\"Uin\" : \"{3}\"" +
          "}}," +
          "\"Msg\" : {{" +
              "\"ClientMsgId\" : {4}," +
               "\"MediaId\":\"{5}\"," +
              "\"Content\" : \"{6}\"," +
              "\"FromUserName\" : \"{7}\"," +
              "\"LocalID\" : {8}," +
              "\"ToUserName\" : \"{9}\"," +
              "\"Type\" : 43" +
          "}}," +
          "\"rr\" : {10}" +
          "}}";
            Cookie sid = HttpServer.GetCookie("wxsid");
            Cookie uin = HttpServer.GetCookie("wxuin");
            if (sid != null && uin != null)
            {
                msg_json = string.Format(msg_json, Utils.GetTimeSpan(), sid.Value, LoginService.SKey, uin.Value, Utils.GetTimeSpan(), MediaId, string.Empty, from, Utils.GetTimeSpan(), to, Utils.GetTimeSpan());
                byte[] bytes = HttpServer.SendPostRequest(_sendvideomsg, msg_json);
                string send_result = Encoding.UTF8.GetString(bytes);
                JObject obj = JsonConvert.DeserializeObject(send_result) as JObject;
                string MsgID = obj["MsgID"].ToString();
                if (!string.IsNullOrEmpty(MsgID))
                {
                    string url = string.Format("{0}&MsgID={1}&skey={2}&type=slave", _webwxgetmsgimg, MsgID, LoginService.SKey);
                    byte[] bytesvideo = HttpServer.SendPostRequest(url, string.Empty);
                }
            }
        }

        public string UploadImage(string path)
        {
            Cookie sid = HttpServer.GetCookie("wxsid");
            Cookie uin = HttpServer.GetCookie("wxuin");
            FileInfo file = new FileInfo(path);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{{\"UploadType\":2,\"BaseRequest\":{{\"Uin\":{0},\"Sid\":\"{1}\",\"Skey\":\"{2}\",\"DeviceID\":\"e{3}\"}},", uin.Value, sid.Value, LoginService.SKey, Utils.GetTimeSpan());
            sb.AppendFormat("\"ClientMediaId\":{3},\"TotalLen\":{0},\"StartPos\":0,\"DataLen\":{1},\"MediaType\":4,\"FileMd5\":\"{2}\"}}", file.Length, file.Length, GetFileMD5Hash.GetMD5Hash(path), Utils.GetTimeSpan());
            byte[] bytes = HttpServer.SendPostRequest(_uplpadFileUrl, sb.ToString(), "image/jpeg", "image/jpeg", "pic", file);
            string send_result = string.Empty;
            if (bytes != null)
            {
                send_result = Encoding.UTF8.GetString(bytes);
            }
            return send_result;
        }

        public string UploadFile(string path)
        {
            Cookie sid = HttpServer.GetCookie("wxsid");
            Cookie uin = HttpServer.GetCookie("wxuin");
            FileInfo file = new FileInfo(path);
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{{\"UploadType\":2,\"BaseRequest\":{{\"Uin\":{0},\"Sid\":\"{1}\",\"Skey\":\"{2}\",\"DeviceID\":\"e{3}\"}},", uin.Value, sid.Value, LoginService.SKey, Utils.GetTimeSpan());
            sb.AppendFormat("\"ClientMediaId\":{3},\"TotalLen\":{0},\"StartPos\":0,\"DataLen\":{1},\"MediaType\":4,\"FileMd5\":\"{2}\"}}", file.Length, file.Length, GetFileMD5Hash.GetMD5Hash(path), Utils.GetTimeSpan());
            UpoladType uploadType = GetUpooadType(file);
            uploadType.uploadmediarequest = sb.ToString();
            uploadType.Url = _uplpadFileUrl;
            byte[] bytes = HttpServer.SendPostRequestByFile(uploadType);
            string send_result = string.Empty;
            if (bytes != null)
            {
                send_result = Encoding.UTF8.GetString(bytes);
            }
            return send_result;
        }

        public void SendFile(string MediaId,string totallen,string title,string fileext, string from, string to)
        {
            string msg_json = "{{" +
          "\"BaseRequest\":{{" +
              "\"DeviceID\" : \"e{0}\"," +
              "\"Sid\" : \"{1}\"," +
              "\"Skey\" : \"{2}\"," +
              "\"Uin\" : \"{3}\"" +
          "}}," +
          "\"Msg\" : {{" +
              "\"ClientMsgId\" : {4}," +
              "\"Content\" : \"{5}\"," +
              "\"FromUserName\" : \"{6}\"," +
              "\"LocalID\" : {7}," +
              "\"ToUserName\" : \"{8}\"," +
              "\"Type\" : 6" +
          "}}," +
          "\"rr\" : {9}" +
          "}}";
            string content = "<appmsg appid='wxeb7ec651dd0aefa9' sdkver=''>< title > " + title + " </ title >< des ></ des >< action ></ action >< type > 6 </ type >< content ></ content >< url ></ url >< lowurl ></ lowurl >< appattach >< totallen > "+ totallen + " </ totallen >< attachid > "+MediaId+" </ attachid >< fileext > "+ fileext + " </ fileext ></ appattach >< extinfo ></ extinfo ></ appmsg > ";
            Cookie sid = HttpServer.GetCookie("wxsid");
            Cookie uin = HttpServer.GetCookie("wxuin");
            if (sid != null && uin != null)
            {
                msg_json = string.Format(msg_json, Utils.GetTimeSpan(), sid.Value, LoginService.SKey, uin.Value, Utils.GetTimeSpan(), content, from, Utils.GetTimeSpan(), to, Utils.GetTimeSpan());
                byte[] bytes = HttpServer.SendPostRequest(_sendvideomsg+ "&pass_ticket=" + LoginService.Pass_Ticket, msg_json);
                string send_result = Encoding.UTF8.GetString(bytes);
            }
        }

        private UpoladType GetUpooadType(FileInfo fi)
        {
            UpoladType upoladType = new UpoladType();
            upoladType.FileInfo = fi;
            string fileExtension = fi.Extension;
            switch (fileExtension.ToLower())
            {
                case ".jpg":
                case ".jpge":
                    upoladType.type = "image/jpg";
                    upoladType.ContentType = "image/jpg";
                    upoladType.mediatype = "pic";
                    break;
                case "gif":
                    upoladType.type = "image/gif";
                    upoladType.ContentType = "image/gif";
                    upoladType.mediatype = "doc";
                    break;
                case ".mp4":
                    upoladType.type = "video/mp4";
                    upoladType.ContentType = "video/mp4";
                    upoladType.mediatype = "video";
                    break;
                case ".doc":
                case ".docx":
                case ".ppt":
                case ".pptx":
                case ".xls":
                case ".xlsx":
                    upoladType.type = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                    upoladType.ContentType = "image/gif";
                    upoladType.mediatype = "application/vnd.openxmlformats-officedocument.presentationml.presentation";
                    break;
                case ".txt":
                    upoladType.type = "text/plain";
                    upoladType.ContentType = "text/plain";
                    upoladType.mediatype = "doc";
                    break;
                default:
                    upoladType.type = "application/octet-stream";
                    upoladType.ContentType = "application/octet-stream";
                    upoladType.mediatype = "doc";
                    break;
            }
            return upoladType;
        }


        public void SendImage(string MediaId, string from, string to)
        {
            string msg_json = "{{\"BaseRequest\":" +
                             "{{ \"Uin\":{0},\"Sid\":\"{1}\",\"Skey\":\"{2}\",\"DeviceID\":\"e{8}\"}}," +
                                "\"Msg\":{{\"Type\":3," +
                                "\"MediaId\":\"{3}\"," +
                                "\"Content\":\"\"," +
                                "\"FromUserName\":\"{4}\"," +
                                "\"ToUserName\":\"{5}\"," +
                                "\"LocalID\":\"{6}\"," +
                                "\"ClientMsgId\":\"{7}\"}}," +
                                "\"Scene\":2}} ";
            Cookie sid = HttpServer.GetCookie("wxsid");
            Cookie uin = HttpServer.GetCookie("wxuin");
            if (sid != null && uin != null)
            {
                msg_json = string.Format(msg_json, uin.Value, sid.Value, LoginService.SKey, MediaId, from, to, Utils.GetTimeSpan(), Utils.GetTimeSpan(), Utils.GetTimeSpan());
                byte[] bytes = HttpServer.SendPostRequest(_sendmsgimg, msg_json);
                string send_result = Encoding.UTF8.GetString(bytes);
            }
        }

    }
}
