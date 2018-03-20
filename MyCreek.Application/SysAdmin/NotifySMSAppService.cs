using Abp.Dependency;
using Abp.Events.Bus;
using Abp.Events.Bus.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.SysAdmin
{
    public class NotifySMSAppService : MyCreekAppServiceBase, INotifySMSAppService
    {
        public IEventBus EventBus { get; set; }

        public NotifySMSAppService()
        {
            EventBus = NullEventBus.Instance;
        }

        public void CompleteTask()
        {
            //TODO: 完成task的数据库操作...
            EventBus.Trigger(new TaskCompletedEventData { TaskId = 42 });
        }
    }

    public class TaskCompletedEventData : EventData
    {
        public int TaskId { get; set; }
    }


    public class ActivityWriter : IEventHandler<TaskCompletedEventData>, ITransientDependency
    {
        public void HandleEvent(TaskCompletedEventData eventData)
        {
           
        }
    }




}
