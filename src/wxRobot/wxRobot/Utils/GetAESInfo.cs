using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wxRobot.Utils
{
    public  class GetAESInfo
    {
        public static string Get(string data)
        {
            AESCrypt aes = new AESCrypt();
            aes.ContainKey = true;
           return aes.Encrypt(data);
        }

        public static string Get(string data,string key)
        {
            AESCrypt aes = new AESCrypt();
            aes.ContainKey = false;
            return aes.Encrypt(data,key);
        }

        public static string Set(string data)
        {
            AESCrypt aes = new AESCrypt();
            aes.ContainKey = true;
            return aes.Encrypt(data);
        }

        public static string Set(string data, string key)
        {
            AESCrypt aes = new AESCrypt();
            aes.ContainKey = false;
            return aes.Encrypt(data, key);
        }


    }
}
