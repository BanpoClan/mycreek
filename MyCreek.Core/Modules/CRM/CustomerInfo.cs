using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.Modules.CRM
{
    /// <summary>
    /// FullAuditedEntity实现IFullAudited所有接口。对数据的增删改都会在数据表中有记录
    /// abp框架中的Audit，审计功能，其实就是对数据操作的记录过程
    /// </summary>
    public class CustomerInfo : FullAuditedEntity
    {
        public string CustomerGuid { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNum { get; set; }
        public string CustomerCategory { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Contacts { get; set; }
        public string Email { get; set; }

    }
}
