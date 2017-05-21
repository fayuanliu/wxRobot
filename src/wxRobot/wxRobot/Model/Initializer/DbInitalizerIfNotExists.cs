using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace wxRobot.Model.Initializer
{
    public class DbInitalizerIfNotExists : SqliteCreateDatabaseIfNotExists<RobotContext>
    {
        public DbInitalizerIfNotExists(DbModelBuilder modelBuilder)
            :base( modelBuilder)
        {

        }
        protected override void Seed(RobotContext context)
        {
            base.Seed(context);
        }
    }
}
