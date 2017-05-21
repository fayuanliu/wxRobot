using System;
using System.Management;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace wxRobot.Util.Utils
{
    /// <summary> 
    /// register 的摘要说明。 
    /// 注册软件所用到的类 
    /// 作者:xtx 
    /// QQ:283570270 Email:xutingxiang@126.com 
    /// </summary> 
    public static class Register
    {

        #region 获取cpu序列号 硬盘ID 网卡硬地址 
        /// <summary> 
        /// 获取cpu序列号 
        /// </summary> 
        /// <returns> string </returns> 
        public static string GetCpuInfo()
        {
            string cpuInfo ="";
            ManagementClass cimobject = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = cimobject.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
            }
            return cpuInfo.ToString();
        }
        /// <summary> 
        /// 获取硬盘ID 
        /// </summary> 
        /// <returns> string </returns> 
        public static string GetHDid()
        {
            string HDid ="";
            ManagementClass cimobject1 = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc1 = cimobject1.GetInstances();
            foreach (ManagementObject mo in moc1)
            {
                HDid = (string)mo.Properties["Model"].Value;
            }
            return HDid.ToString();
        }

        /// <summary> 
        /// 获取网卡硬件地址 
        /// </summary> 
        /// <returns> string </returns> 
        public static string GetMoAddress()
        {
            string MoAddress ="";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if ((bool)mo["IPEnabled"] == true)
                    MoAddress = mo["MacAddress"].ToString();
                mo.Dispose();
            }
            return MoAddress.ToString();
        }
        #endregion
    }
}