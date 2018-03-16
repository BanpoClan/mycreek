using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using MyCreek.EntityFramework;

namespace MyCreek.Migrator
{
    [DependsOn(typeof(MyCreekDataModule))]
    public class MyCreekMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<MyCreekDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}