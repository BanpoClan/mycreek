using Abp.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CRMModule
{
    public class CRMSysModule : AbpModule
    {
        //
        // 摘要:
        //     This method is used to register dependencies for this module.
        public override void Initialize()
        {
            //这行代码的写法基本上是不变的。它的作用是把当前程序集的特定类或接口注册到依赖注入容器中。
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
        //
        // 摘要:
        //     This method is called lastly on application startup.
        public override void PostInitialize()
        {

        }
        //
        // 摘要:
        //     This is the first event called on application startup. Codes can be placed here
        //     to run before dependency injection registrations.
        public override void PreInitialize()
        {

        }
        //
        // 摘要:
        //     This method is called when the application is being shutdown.
        public override void Shutdown()
        {

        }
    }
}
