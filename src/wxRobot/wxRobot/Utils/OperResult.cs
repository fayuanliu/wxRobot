using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wxRobot.Enums;

namespace wxRobot.Utils
{
    public class OperResult
    {
        public OperResult()
        {

        }

        public OperResult(ResultCodeEnums code, string msg)
        {
            this.Code = code;
            this.Msg = msg;
        }

        public ResultCodeEnums Code { get; set; }

        public string Msg { get; set; }

        public object Data { get; set; }
    }
}
