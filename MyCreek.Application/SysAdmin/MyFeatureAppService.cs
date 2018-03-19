using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCreek.Modules.SysAdmin;

namespace MyCreek.SysAdmin
{
    public class MyFeatureAppService : MyCreekAppServiceBase, IMyFeatureAppService
    {
        private readonly IMenuMgrAppService _menuMgrAppService;
        public MyFeatureAppService(IMenuMgrAppService menuMgrAppService)
        {
            _menuMgrAppService = menuMgrAppService;
        }
        public Task<CustomFeatureCoreStruct> GetMenuInfo(string menuGuid)
        {
            var info = _menuMgrAppService.GetMenuInfo(menuGuid);
            return info;
        }
    }
}
