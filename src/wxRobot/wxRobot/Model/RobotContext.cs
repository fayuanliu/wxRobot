using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using wxRobot.Model.Initializer;

namespace wxRobot.Model
{
    public class RobotContext : DbContext
    {
        public RobotContext() 
            :base("RobotDb")
        {
            Configure();
        }

        private void Configure()
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.AddFromAssembly(typeof(RobotContext).Assembly);
            Database.SetInitializer(new DbInitializer(modelBuilder));
        }

    }
}
