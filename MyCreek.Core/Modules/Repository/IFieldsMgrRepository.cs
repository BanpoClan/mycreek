using Abp.Domain.Repositories;
using MyCreek.Modules.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Modules.Repository
{
    public interface IFieldsMgrRepository : IRepository<Field>
    {
        Task<List<Field>> GetFields(string menuGuid);
    }
}
