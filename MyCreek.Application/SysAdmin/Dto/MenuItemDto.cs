using Abp.AutoMapper;
using MyCreek.Modules.SysAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.SysAdmin.Dto
{
    
    public class MenuItemDto
    {
        public string id { get; set; }
        public string pId { get; set; }
        public string name { get; set; }
        public bool open { get; set; }

    }
}
