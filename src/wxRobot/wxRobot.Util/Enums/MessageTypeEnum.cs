using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace wxRobot.Util.Enums
{
    public enum MessageTypeEnum
    {
        [Description("文本")]
        Text,
        [Description("图片")]
        Image,
        [Description("视频")]
        Video
    }
}
