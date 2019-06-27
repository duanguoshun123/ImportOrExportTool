using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFUserRole_Dto
    {
        public int WFUserRoleId { get; set; }
        public Nullable<int> WFUserId { get; set; }
        public Nullable<int> WFRoleInfoId { get; set; }

        public virtual WFRoleInfo_Dto WFRoleInfo { get; set; }
        public virtual WFUser_Dto WFUser { get; set; }
        public string UserName { get; set; }
        public string DepartmentName { get; set; }
    }
}
