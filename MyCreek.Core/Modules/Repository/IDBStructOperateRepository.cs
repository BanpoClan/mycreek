using Abp.Domain.Repositories;
using MyCreek.Modules.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Modules.Repository
{
    /// <summary>
    /// 数据库结构操作
    /// </summary>
    public interface IDBStructOperateRepository : IRepository<CustomFeatureCoreStruct>
    {
        Task CreateDbStruct(CustomFeatureCoreStruct customFeatureCoreStruct);
    }
}
