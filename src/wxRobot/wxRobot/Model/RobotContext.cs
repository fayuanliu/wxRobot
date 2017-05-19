using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace wxRobot.Model
{
    public class RobotContext : DbContext
    {
        public RobotContext() 
            :base("RobotDb")
        {

        }

        public DbSet<ServiceRecord> Record { get; set; }

        public DbSet<OperLog> OperLog { get; set; }

        public DbSet<Machine> Machine { get; set; }

    }
}
