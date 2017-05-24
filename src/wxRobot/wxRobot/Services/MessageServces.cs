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
                TxtContent = "点击选择文件!"
            });
            list.Add(new MessageType()
            {
                SendType = "视频",
                TxtContent = "点击选择文件!"
            });
            return list;

        }
    }

}
