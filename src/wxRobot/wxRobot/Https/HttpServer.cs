using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using wxRobot.Model.Dto;

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

        public static byte[] SendPostRequest(string url, string body, string filetype, string ContentType, string mediatype, FileInfo fi)
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

            postbody += fi.LastWriteTime.ToString("ddd MMM dd yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US")) + " GMT+0800 (中国标准时间)" + "\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"size\"\r\n\r\n";
            postbody += filesize + "\r\n";
            postbody += "------WebKitFormBoundaryq0powRpu8bd9gwTG\r\n";
            postbody += "Content-Disposition: form-data; name=\"mediatype\"\r\n\r\n";
            postbody += "" + mediatype + "\r\n";
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

        public static byte[] SendPostRequestByVideo2(string url, string body, FileInfo fi, byte[] buffer, double chunks, int chunk)
        {
            Cookie webwx_data_ticket = HttpServer.GetCookie("webwx_data_ticket");
            string filename = fi.Name;
            long filesize = fi.Length;
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.Accept = "*/*";
            if (url.Contains("wx2"))
            {
                request.Host = "file.wx2.qq.com";
                request.Referer = "https://wx2.qq.com/";
                request.Headers.Add("Origin", "https://wx2.qq.com");
            }
            else
            {
                request.Host = "file.wx.qq.com";
                request.Referer = "https://wx.qq.com/";
                request.Headers.Add("Origin", "https://wx.qq.com");
            }
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Trident/5.0)";
            request.KeepAlive = true;
            var boundary = Guid.NewGuid().ToString("N");
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
            request.ContentType = "multipart/form-data; boundary=----"+ boundary + "";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Method = "POST";
            request.ServicePoint.Expect100Continue = false;
            string postbody = "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"id\"\r\n\r\n";
            postbody += "WU_FILE_2\r\n";
            postbody += "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"name\"\r\n\r\n";
            postbody += filename + "\r\n";
            postbody += "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"type\"\r\n\r\n";
            postbody += "video/mp4\r\n";
            postbody += "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"lastModifiedDate\"\r\n\r\n";

            postbody += fi.LastWriteTime.ToString("ddd MMM dd yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US")) + " GMT+0800 (中国标准时间)" + "\r\n";
            postbody += "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"size\"\r\n\r\n";
            postbody += filesize + "\r\n";

            if (chunks > 1)
            {
                postbody += "------"+ boundary + "\r\n";
                postbody += "Content-Disposition: form-data; name=\"chunks\"\r\n\r\n";
                postbody += chunks + "\r\n";
                postbody += "------"+ boundary + "\r\n";
                postbody += "Content-Disposition: form-data; name=\"chunk\"\r\n\r\n";
                postbody += chunk + "\r\n";
            }
            postbody += "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"mediatype\"\r\n\r\n";
            postbody += "video\r\n";
            postbody += "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"uploadmediarequest\"\r\n\r\n";
            postbody += body + "\r\n";
            postbody += "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"webwx_data_ticket\"\r\n\r\n";
            postbody += webwx_data_ticket.Value + "\r\n";
            postbody += "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"pass_ticket\"\r\n\r\n";
            postbody += "undefined\r\n";
            postbody += "------"+ boundary + "\r\n";
            postbody += "Content-Disposition: form-data; name=\"filename\"; filename=\"" + filename + "\"\r\n";
            postbody += "Content-Type: application/octet-stream\r\n\r\n";
            try
            {
                var sw = new StreamWriter(request.GetRequestStream());
                sw.Write(postbody);
                sw.Flush();
                sw.BaseStream.Write(buffer, 0, buffer.Length);
                sw.Write("\r\n------"+ boundary + "--\r\n");
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
                response_stream.Close();
                return buf;
            }
            catch
            {
                return null;
            }

        }

        public static byte[] SendPostRequestByFile(UpoladType upload)
        {
            Cookie webwx_data_ticket = HttpServer.GetCookie("webwx_data_ticket");
            string filename = upload.FileInfo.Name;
            long filesize = upload.FileInfo.Length;
            var request = WebRequest.Create(upload.Url) as HttpWebRequest;
            request.Accept = "*/*";
            if (upload.Url.Contains("wx2"))
            {
                request.Host = "file.wx2.qq.com";
                request.Headers.Add("request", "https://wx2.qq.com");
                request.Referer = "https://wx2.qq.com/";
                request.Headers.Add("Origin", "https://wx2.qq.com");
            }
            else
            {
                request.Host = "file.wx.qq.com";
                request.Headers.Add("request", "https://wx.qq.com");
                request.Referer = "https://wx.qq.com/";
                request.Headers.Add("Origin:", "https://wx.qq.com");
            }
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8,en;q=0.6,zh-TW;q=0.4");
            request.Headers.Add("Accept-Encoding", "gzip,deflate");
            request.ContentType = "multipart/form-data; boundary=----WebKitFormBoundaryLcLGZdwXomd67JVF";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            request.Method = "POST";
            request.ServicePoint.Expect100Continue = false;
            string postbody = "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"id\"\r\n\r\n";
            postbody += "WU_FILE_2\r\n";
            postbody += "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"name\"\r\n\r\n";
            postbody += filename + "\r\n";
            postbody += "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"type\"\r\n\r\n";
            postbody += ""+ upload .type+ "\r\n";
            postbody += "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"lastModifiedDate\"\r\n\r\n";

            postbody += upload.FileInfo.LastWriteTime.ToString("ddd MMM dd yyyy HH:mm:ss", CultureInfo.CreateSpecificCulture("en-US")) + " GMT+0800 (中国标准时间)" + "\r\n";
            postbody += "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"size\"\r\n\r\n";
            postbody += filesize + "\r\n";
            postbody += "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"mediatype\"\r\n\r\n";
            postbody += ""+ upload .mediatype+ "\r\n";
            postbody += "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"uploadmediarequest\"\r\n\r\n";
            postbody += upload.uploadmediarequest + "\r\n";
            postbody += "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"webwx_data_ticket\"\r\n\r\n";
            postbody += webwx_data_ticket.Value + "\r\n";
            postbody += "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"pass_ticket\"\r\n\r\n";
            postbody += "undefined\r\n";
            postbody += "------WebKitFormBoundaryLcLGZdwXomd67JVF\r\n";
            postbody += "Content-Disposition: form-data; name=\"filename\"; filename=\"" + filename + "\"\r\n";
            postbody += "Content-Type: "+ upload .ContentType+ "\r\n\r\n";

            FileStream fs = upload.FileInfo.OpenRead();
            try
            {
                var sw = new StreamWriter(request.GetRequestStream());
                sw.Write(postbody); sw.Flush();
                //文件数据不能读为string，要直接读byte
                byte[] buffer = new byte[1024];
                int bytesRead = 0;
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) != 0)
                {
                    sw.BaseStream.Write(buffer, 0, bytesRead);
                }
                sw.Write("\r\n------WebKitFormBoundaryLcLGZdwXomd67JVF--\r\n");
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
                response_stream.Close();
                return buf;
            }
            catch
            {
                return null;
            }
            finally
            {
                fs.Close();
            }

        }

        /// <summary>
        /// 设置代理
        /// </summary>
        /// <param name="item">参数对象</param>
        private static void SetProxy(HttpItem item,HttpWebRequest request)
        {
            bool isIeProxy = false;
            if (!string.IsNullOrWhiteSpace(item.ProxyIp))
            {
                isIeProxy = item.ProxyIp.ToLower().Contains("ieproxy");
            }
            if (!string.IsNullOrWhiteSpace(item.ProxyIp) && !isIeProxy)
            {
                //设置代理服务器
                if (item.ProxyIp.Contains(":"))
                {
                    string[] plist = item.ProxyIp.Split(':');
                    WebProxy myProxy = new WebProxy(plist[0].Trim(), Convert.ToInt32(plist[1].Trim()));
                    //建议连接
                    myProxy.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
                    //给当前请求对象
                    request.Proxy = myProxy;
                }
                else
                {
                    WebProxy myProxy = new WebProxy(item.ProxyIp, false);
                    //建议连接
                    myProxy.Credentials = new NetworkCredential(item.ProxyUserName, item.ProxyPwd);
                    //给当前请求对象
                    request.Proxy = myProxy;
                }
            }
            else if (isIeProxy)
            {
                //设置为IE代理
            }
            else
            {
                request.Proxy = item.WebProxy;
            }
        }

        public class HttpItem
        {
            /// <summary>
            /// 代理Proxy 服务器用户名
            /// </summary>
            public string ProxyUserName { get; set; }
            /// <summary>
            /// 代理 服务器密码
            /// </summary>
            public string ProxyPwd { get; set; }
            /// <summary>
            /// 代理 服务IP,如果要使用IE代理就设置为ieproxy
            /// </summary>
            public string ProxyIp { get; set; }
            /// <summary>
            /// 设置代理对象，不想使用IE默认配置就设置为Null，而且不要设置ProxyIp
            /// </summary>
            public WebProxy WebProxy { get; set; }
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

        public static Cookie SetCookie(string name, string value, string domain)
        {
            Cookie cookie = new Cookie();
            cookie.Domain = domain;
            cookie.Name = name;
            cookie.Value = value;
            cookie.Expires.AddDays(1);
            return cookie;
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
