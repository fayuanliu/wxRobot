using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wxRobot.Model
{
   public class ServiceRecord : BaseEntity
    {

        /// <summary>
        /// 可使用总条数
        /// </summary>
        public string Total { get; set; }

        /// <summary>
        /// 剩余条数
        /// </summary>
        public string SurplusTotal { get; set; }

        /// <summary>
        /// 最后操作时间
        /// </summary>
        public DateTime LastOperTime { get; set; }

        /// <summary>
        /// 是否受权
        /// </summary>
        public bool IsAuth { get; set; }
    }
}
