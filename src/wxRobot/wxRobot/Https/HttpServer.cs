using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace wxRobot.Https
{
    public class HttpServer
    {
        /// <summary>
        /// 访问服务器时的cookies
        /// </summary>
        public static CookieContainer CookiesContainer;
        private static CookieCollection WxCookies;

        /// <summary>
        /// 向服务器发送get请求  返回服务器回复数据
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static byte[] SendGetRequest(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "get";

                if (CookiesContainer == null)
                {
                    CookiesContainer = new CookieContainer();
                }

                request.CookieContainer = CookiesContainer;  //启用cookie
                request.AllowAutoRedirect = false;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream response_stream = response.GetResponseStream();
                int count = (int)response.ContentLength;
                int offset = 0;
                byte[] buf = new byte[count];
                while (count > 0)  //读取返回数据
                {
                    int n = response_stream.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                }
                response_stream.Close();
                return buf;
            }
            catch
            {
                return null;
            }
        }

        public static byte[] SendPostRequest(string url, string body, string filetype,string ContentType, string mediatype, FileInfo fi)
        {
            Cookie webwx_data_ticket = HttpServer.GetCookie("webwx_data_ticket");
            string filename = fi.Name;
            long filesize = fi.Length;
            var request = WebRequest.Create(url) as HttpWebRequest;
            if (CookiesContainer == null)
            {
                CookiesContainer = new CookieContainer();
            }
            request.CookieContainer = CookiesContainer;  //启用cookie
            request.Accept = "*/*";
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.ContentType = "multipart/form-data; boundary=----WebKitFormBoundaryq0powRpu8bd9gwTG";
            if (url.Contains("wx2"))
            {
                request.Headers.Add("Origin", "https://wx2.qq.com");
                request.Referer = "https://wx2.qq.com/?t=v2/index&lang=zh_CN";
            }
            else
            {
                request.Headers.Add("Origin", "https://wx.qq.com");
                request.Referer = "https://wx.qq.com/?t=v2/index&lang=zh_CN";
            }
            //request.UserAgent = USER_AGENT;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Method = "POST";
            request.ServicePoint.Expect100Continue = false;
            string postbody = "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"id\"\r\n\r\n";
            postbody += "WU_FILE_2\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"name\"\r\n\r\n";
            postbody += filename + "\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"type\"\r\n\r\n";
            postbody += filetype + "\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"lastModifiedDate\"\r\n\r\n";

            postbody += DateTime.Now.ToString("ddd MMM dd yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US")) + " GMT+0800 (中国标准时间)" + "\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"size\"\r\n\r\n";
            postbody += filesize + "\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"mediatype\"\r\n\r\n";
            postbody += ""+ mediatype + "\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"uploadmediarequest\"\r\n\r\n";
            postbody += body + "\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"webwx_data_ticket\"\r\n\r\n";
            postbody += webwx_data_ticket.Value + "\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"filename\"; filename=\"" + filename + "\"\r\n";
            postbody += "Content-Type: " + ContentType + "\r\n\r\n";

            try
            {
                var sw = new StreamWriter(request.GetRequestStream());
                sw.Write(postbody); sw.Flush();
                //文件数据不能读为string，要直接读byte
                FileStream fs = fi.OpenRead();
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
                {
                    sw.BaseStream.Write(buffer, 0, bytesRead);
                }
                sw.Write("\r\n------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n");
                sw.Flush();
                sw.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream response_stream = response.GetResponseStream();

                int count = (int)response.ContentLength;
                int offset = 0;
                byte[] buf = new byte[count];
                while (count > 0)  //读取返回数据
                {
                    int n = response_stream.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                }
                fs.Close();
                response_stream.Close();
                return buf;
            }
            catch
            {
                return null;
            }

        }

        public static byte[] SendPostRequestByVideo(string url, string body, FileInfo fi)
        {
            Cookie webwx_data_ticket = HttpServer.GetCookie("webwx_data_ticket");
            string filename = fi.Name;
            long filesize = fi.Length;
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Accept = "*/*";
            if (url.Contains("wx2"))
            {
                request.Host = "file.wx2.qq.com";
                request.Headers.Add("request", "https://wx2.qq.com");
                request.Referer = "https://wx2.qq.com/";
            }
            else
            {
                request.Host = "file.wx.qq.com";
                request.Headers.Add("request", "https://wx.qq.com");
                request.Referer = "https://wx.qq.com/";
            }
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.ContentType = "multipart/form-data; boundary=----WebKitFormBoundaryBYwQxyZI1AKKWAow";

            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Method = "POST";
            request.ServicePoint.Expect100Continue = false;
            string postbody = "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"id\"\r\n\r\n";
            postbody += "WU_FILE_2\r\n";
            postbody += "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"name\"\r\n\r\n";
            postbody += filename + "\r\n";
            postbody += "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"type\"\r\n\r\n";
            postbody += "video/mp4\r\n";
            postbody += "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"lastModifiedDate\"\r\n\r\n";

            postbody += DateTime.Now.ToString("ddd MMM dd yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US")) + " GMT+0800 (中国标准时间)" + "\r\n";
            postbody += "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"size\"\r\n\r\n";
            postbody += filesize + "\r\n";
            postbody += "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"mediatype\"\r\n\r\n";
            postbody += "video/mp4\r\n";
            postbody += "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"uploadmediarequest\"\r\n\r\n";
            postbody += body + "\r\n";
            postbody += "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"webwx_data_ticket\"\r\n\r\n";
            postbody += webwx_data_ticket.Value + "\r\n";
            postbody += "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"pass_ticket\"\r\n\r\n";
            postbody += "undefined\r\n";
            postbody += "------WebKitFormBoundaryBYwQxyZI1AKKWAow\r\n";
            postbody += "Content-Disposition: form-data; name=\"filename\"; filename=\"" + filename + "\"\r\n";
            postbody += "Content-Type:video/mp4\r\n\r\n";

            try
            {
                var sw = new StreamWriter(request.GetRequestStream());
                sw.Write(postbody); sw.Flush();
                //文件数据不能读为string，要直接读byte
                FileStream fs = fi.OpenRead();
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
                {
                    sw.BaseStream.Write(buffer, 0, bytesRead);
                }
                sw.Write("\r\n------WebKitFormBoundaryBYwQxyZI1AKKWAow--\r\n");
                sw.Flush();
                sw.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream response_stream = response.GetResponseStream();

                int count = (int)response.ContentLength;
                int offset = 0;
                byte[] buf = new byte[count];
                while (count > 0)  //读取返回数据
                {
                    int n = response_stream.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                }
                fs.Close();
                response_stream.Close();
                return buf;
            }
            catch
            {
                return null;
            }

        }

        public static byte[] SendPostRequestV2(string url, string body)
        {
            try
            {
                byte[] request_body = Encoding.UTF8.GetBytes(body);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Accept = "application/json,text/plain,*/*";
                if (url.Contains("wx2"))
                {
                    request.Host = "wx2.qq.com";
                    request.Referer = "https://wx2.qq.com/";
                    request.Headers.Add("Origin","https://wx2.qq.com");
                }
                else
                {
                    request.Host = "wx.qq.com";
                    request.Headers.Add("Origin", "https://wx.qq.com");
                    request.Referer = "https://wx.qq.com/";
                }
                request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
                request.Headers.Add("Accept-Encoding", "gzip,deflate");
                request.ContentLength = request_body.Length;
                CookieContainer cookies = new CookieContainer();
                if (CookiesContainer == null)
                {
                    CookiesContainer = new CookieContainer();
                }
                request.CookieContainer = CookiesContainer;  //启用cookie
                request.Method = "post";
                Stream request_stream = request.GetRequestStream();
                request_stream.Write(request_body, 0, request_body.Length);
                request_stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream response_stream = response.GetResponseStream();
                int count = (int)response.ContentLength;
                int offset = 0;
                byte[] buf = new byte[count];
                while (count > 0)  //读取返回数据
                {
                    int n = response_stream.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                }
                response_stream.Close();
                return buf;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 向服务器发送post请求 返回服务器回复数据
        /// </summary>
        /// <param name="url"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static byte[] SendPostRequest(string url, string body)//, CookieCollection cc)
        {
            try
            {
                byte[] request_body = Encoding.UTF8.GetBytes(body);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.ContentLength = request_body.Length;
                CookieContainer cookies = new CookieContainer();
                if (CookiesContainer == null)
                {
                    CookiesContainer = new CookieContainer();
                }
                request.CookieContainer = CookiesContainer;  //启用cookie
                request.Method = "post";
                Stream request_stream = request.GetRequestStream();
                request_stream.Write(request_body, 0, request_body.Length);
                request_stream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream response_stream = response.GetResponseStream();
                int count = (int)response.ContentLength;
                int offset = 0;
                byte[] buf = new byte[count];
                while (count > 0)  //读取返回数据
                {
                    int n = response_stream.Read(buf, offset, count);
                    if (n == 0) break;
                    count -= n;
                    offset += n;
                }
                response_stream.Close();
                return buf;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取指定cookie
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Cookie GetCookie(string name)
        {
            List<Cookie> cookies = GetAllCookies(CookiesContainer);
            foreach (Cookie c in cookies)
            {
                if (c.Name == name)
                {
                    return c;
                }
            }
            return null;
        }

        private static List<Cookie> GetAllCookies(CookieContainer cc)
        {
            List<Cookie> lstCookies = new List<Cookie>();

            Hashtable table = (Hashtable)cc.GetType().InvokeMember("m_domainTable",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField |
                System.Reflection.BindingFlags.Instance, null, cc, new object[] { });

            foreach (object pathList in table.Values)
            {
                SortedList lstCookieCol = (SortedList)pathList.GetType().InvokeMember("m_list",
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.GetField
                    | System.Reflection.BindingFlags.Instance, null, pathList, new object[] { });
                foreach (CookieCollection colCookies in lstCookieCol.Values)
                    foreach (Cookie c in colCookies) lstCookies.Add(c);
            }
            return lstCookies;
        }
    }
}
