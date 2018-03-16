using System.Linq;
using MyCreek.EntityFramework;
using MyCreek.MultiTenancy;

namespace MyCreek.Migrations.SeedData
{
    public class DefaultTenantCreator
    {
        private readonly MyCreekDbContext _context;

        public DefaultTenantCreator(MyCreekDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateUserAndRoles();
        }

        private void CreateUserAndRoles()
        {
            //Default tenant

            var defaultTenant = _context.Tenants.FirstOrDefault(t => t.TenancyName == Tenant.DefaultTenantName);
            if (defaultTenant == null)
            {
                _context.Tenants.Add(new Tenant {TenancyName = Tenant.DefaultTenantName, Name = Tenant.DefaultTenantName});
                _context.SaveChanges();
            }
        }
    }
}
