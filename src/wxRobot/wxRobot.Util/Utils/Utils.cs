using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;

namespace wxRobot.Util.Utils
{
    /// <summary>
    /// byte 数组组合
    /// </summary>
    public static class Utils
    {
        public static byte[] ComposeArrays(byte[] Array1, byte[] Array2)
        {
            byte[] Temp = new byte[Array1.Length + Array2.Length];
            Array1.CopyTo(Temp, 0);
            Array2.CopyTo(Temp, Array1.Length);
            return Temp;
        }

        /// <summary>
        /// 图片转Byte数组
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public static byte[] ImageToBytesFromFilePath(string FilePath)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Image Img = Image.FromFile(FilePath))
                {
                    using (Bitmap Bmp = new Bitmap(Img))
                    {
                        Bmp.Save(ms, Img.RawFormat);
                    }
                }
                return ms.ToArray();
            }
        }

        public static string GetTimeSpan()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalMilliseconds).ToString();
        }

        /// <summary>
        /// 为指定用户组，授权目录指定完全访问权限
        /// </summary>
        /// <param name="user">用户组，如Users</param>
        /// <param name="folder">实际的目录</param>
        /// <returns></returns>
        private static bool SetAccess(string user, string folder)
        {
            //定义为完全控制的权限
            const FileSystemRights Rights = FileSystemRights.FullControl;

            //添加访问规则到实际目录
            var AccessRule = new FileSystemAccessRule(user, Rights,
                InheritanceFlags.None,
                PropagationFlags.NoPropagateInherit,
                AccessControlType.Allow);

            var Info = new DirectoryInfo(folder);
            var Security = Info.GetAccessControl(AccessControlSections.Access);

            bool Result;
            Security.ModifyAccessRule(AccessControlModification.Set, AccessRule, out Result);
            if (!Result) return false;

            //总是允许再目录上进行对象继承
            const InheritanceFlags iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;

            //为继承关系添加访问规则
            AccessRule = new FileSystemAccessRule(user, Rights,
                iFlags,
                PropagationFlags.InheritOnly,
                AccessControlType.Allow);

            Security.ModifyAccessRule(AccessControlModification.Add, AccessRule, out Result);
            if (!Result) return false;

            Info.SetAccessControl(Security);

            return true;
        }
    }
}
