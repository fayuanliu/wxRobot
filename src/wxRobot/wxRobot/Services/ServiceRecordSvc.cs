using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxRobot.Model;
using wxRobot.Util.Enums;
using wxRobot.Util.Utils;

namespace wxRobot.Services
{
    public class ServiceRecordSvc
    {
        /// <summary>
        /// 判断是否有受权记录或已受权
        /// </summary>
        /// <returns></returns>
        public OperResult IsAuth()
        {
            ServiceRecord record = null;
            string key = string.Empty;
            using (RobotContext db = new RobotContext())
            {
                record = db.Set<ServiceRecord>().FirstOrDefault();
                var mc = db.Set<Machine>().FirstOrDefault();
                if (mc != null)
                {
                    key = mc.MachineCode;
                }
            }
            OperResult result = new OperResult();
            if (record == null)
            {
                result.Msg = "应用未授权";
                result.Code = ResultCodeEnums.UnAuth;
            }
            else if (record.IsAuth == false)
            {
                result.Msg = "应用未授权";
                result.Code = ResultCodeEnums.UnAuth;
            }
            else if (int.Parse(GetAESInfo.Get(record.SurplusTotal, key)) <= 0)
            {
                result.Msg = "应用使用次数已用完";
                result.Code = ResultCodeEnums.AuthExpire;
            }
            else
            {
                result.Msg = "应用已授权";
                result.Code = ResultCodeEnums.Auth;
            }
            return result;
        }

        /// <summary>
        /// 授权应用
        /// </summary>
        /// <returns></returns>
        public OperResult Auth(string authCode, string mcCode)
        {
            OperResult result = new OperResult();
            result.Code = ResultCodeEnums.warning;
            result.Msg = "授权未完成";
            MachineSvc svc = new MachineSvc();
            svc.Add(mcCode);
            if (string.IsNullOrEmpty(mcCode))
            {
                result.Code = ResultCodeEnums.Error;
                result.Msg = "未能获取到机器码！";
                return result;
            }
            int count = 0;
            if (!int.TryParse(GetAESInfo.Get(authCode, mcCode), out count))
            {
                result.Code = ResultCodeEnums.warning;
                result.Msg = "无效的授权码，请输入有效的授权码！";
                return result;
            }
            ServiceRecord Record = new ServiceRecord();
            Record.IsAuth = true;
            Record.LastOperTime = DateTime.Now;
            Record.SurplusTotal = authCode;
            Record.Total = authCode;
            using (RobotContext db = new RobotContext())
            {
                var data = db.Set<ServiceRecord>().Where(a => true).FirstOrDefault();
                if (null == data)
                {
                    db.Set<ServiceRecord>().Add(Record);
                }
                else
                {
                    data.IsAuth = true;
                    data.LastOperTime = DateTime.Now;
                    data.SurplusTotal = authCode;
                    data.Total = authCode;
                }
                int res = db.SaveChanges();
                if (res > 0)
                {
                    result.Code = ResultCodeEnums.success;
                    result.Msg = "授权成功！";
                    return result;
                }
            }
            return result;
        }

        /// <summary>
        /// 更新使用次数
        /// </summary>
        /// <returns></returns>
        public void SetRecord()
        {
            MachineSvc svc = new MachineSvc();
            var machine = svc.Get();
            using (RobotContext db = new RobotContext())
            {
                var data = db.Set<ServiceRecord>().FirstOrDefault();
                int now = int.Parse(GetAESInfo.Get(data.SurplusTotal, machine.MachineCode));
                now--;
                data.SurplusTotal = GetAESInfo.Set(now.ToString(), machine.MachineCode);
                data.LastOperTime = DateTime.Now;
                db.SaveChanges();
            }
        }


    }
}
