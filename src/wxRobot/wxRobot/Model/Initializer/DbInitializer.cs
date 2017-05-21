using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace wxRobot.Model.Initializer
{
    public class DbInitializer : SqliteDropCreateDatabaseAlways<RobotContext>
    {
        public DbInitializer(DbModelBuilder modelBuilder)
            :base(modelBuilder)
        {

        }
        protected override void Seed(RobotContext context)
        {
            base.Seed(context);
        }

    }
}
