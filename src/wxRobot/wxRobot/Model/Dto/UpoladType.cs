using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace wxRobot.Model.Dto
{
    public class UpoladType
    {
        /// <summary>
        /// 文件类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 媒体文件类型
        /// </summary>
        public string mediatype { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string uploadmediarequest { get; set; }

        /// <summary>
        /// 上传路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 上传的文件
        /// </summary>
        public FileInfo FileInfo { get; set; }
    }
}
