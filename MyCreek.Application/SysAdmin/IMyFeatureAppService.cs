using Abp.Application.Services;
using MyCreek.Modules.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.SysAdmin
{
    public interface IMyFeatureAppService: IApplicationService
    {
        Task<CustomFeatureCoreStruct> GetMenuInfo(string menuGuid);
    }
}
