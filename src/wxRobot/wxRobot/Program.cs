using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using wxRobot.Model;

namespace wxRobot
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //using (var context = new RobotContext())
            //{
            //    context.Set<Machine>().Add(new Machine() { MachineCode="123" });
            //    context.SaveChanges();
            //}
            Application.Run(new FormMain());
        }
    }
}
