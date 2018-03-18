using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCreek.SysAdmin.Dto
{

   

    public  class FieldInput
    {
        public int id { get; set; }
        public string ColName { get; set; }
        public string ColType { get; set; }
        public bool IsNull { get; set; }
        public int Order { get; set; }
        

        public string MenuItemDefine_MenuGuid { get; set; }
    }
}
