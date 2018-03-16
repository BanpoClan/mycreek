using MyCreek.EntityFramework;
using EntityFramework.DynamicFilters;

namespace MyCreek.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly MyCreekDbContext _context;

        public InitialHostDbBuilder(MyCreekDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();

            new DefaultEditionsCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
        }
    }
}
