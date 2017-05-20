using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxRobot.Model.Dto;

namespace wxRobot.Services
{
    public class MessageServces
    {
        public List<MessageType> GetDefultMessage()
        {
            List<MessageType> list = new List<MessageType>();
            list.Add(new MessageType()
            {
                SendType = "文本",
                TxtContent = "测试批量发送信息"
            });
            list.Add(new MessageType()
            {
                SendType = "图片",
                TxtContent = "请输入图片所在电脑的磁盘路径包含文件名"
            });
            list.Add(new MessageType()
            {
                SendType = "视频",
                TxtContent = "请输入图片所在电脑的磁盘路径包含文件名"
            });
            return list;

        }
    }

}
