using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wxRobot.Model
{
    public class OperLog
    {
        /// <summary>
        /// 主键
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// wx号
        /// </summary>
        public string wxId { get; set; }

        /// <summary>
        /// 微信名称
        /// </summary>
        public string WxName { get; set; }

        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperDate { get; set; }

        /// <summary>
        /// 机器
        /// </summary>
        public string MCInfo { get; set; }
    }
}
