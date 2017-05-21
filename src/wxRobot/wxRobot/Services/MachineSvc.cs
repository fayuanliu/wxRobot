using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxRobot.Model;

namespace wxRobot.Services
{
    public class MachineSvc
    {
        /// <summary>
        /// 新增唯一机器码
        /// </summary>
        public void Add(string code)
        {
            Machine mc = new Machine();
            mc.MachineCode = code;
            using (RobotContext db = new RobotContext())
            {
                db.Set<Machine>().Add(mc);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// 获取机器码
        /// </summary>
        /// <returns></returns>
        public Machine Get()
        {
            using (RobotContext db = new RobotContext())
            {
                return db.Set<Machine>().FirstOrDefault();
            }
        }
    }
}
