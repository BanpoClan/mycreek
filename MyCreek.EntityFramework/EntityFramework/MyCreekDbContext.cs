using System.Data.Common;
using Abp.Zero.EntityFramework;
using MyCreek.Authorization.Roles;
using MyCreek.Authorization.Users;
using MyCreek.MultiTenancy;
using MyCreek.Modules.CRM;
using System.Data.Entity;

namespace MyCreek.EntityFramework
{
    public class MyCreekDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */

        public virtual IDbSet<CustomerInfo> CustomerInfoes { get; set; }

        public MyCreekDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in MyCreekDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of MyCreekDbContext since ABP automatically handles it.
         */
        public MyCreekDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public MyCreekDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public MyCreekDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
