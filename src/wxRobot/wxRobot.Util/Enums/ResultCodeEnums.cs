using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wxRobot.Util.Enums
{
    public enum ResultCodeEnums
    {
        /// <summary>
        /// 授权成功
        /// </summary>
        Auth,
        /// <summary>
        /// 未授权
        /// </summary>
        UnAuth,
        /// <summary>
        /// 未授权过期
        /// </summary>
        AuthExpire,
        /// <summary>
        /// 出错
        /// </summary>
        Error,
        /// <summary>
        /// 提醒
        /// </summary>
        warning,
        /// <summary>
        /// 提醒
        /// </summary>
        info,
        /// <summary>
        /// 成功
        /// </summary>
        success,

    }
}
