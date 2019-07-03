using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFRoleBusiness_Dto
    {
        public int WFRoleBusinessId { get; set; }
        public int WFRoleInfoId { get; set; }
        public Nullable<int> WFBusinessId { get; set; }
        public bool IsDisabled { get; set; }
        public Nullable<int> CorporationId { get; set; }
        public Nullable<int> AccountEntityId { get; set; }
        public Nullable<int> CommodityTypeId { get; set; }
        public Nullable<int> CommodityId { get; set; }
        public Nullable<int> Module { get; set; }
        public string Note { get; set; }

        //public virtual WFBusiness_Dto WFBusiness { get; set; } 
        public string DepartmentName { get; set; }
        public string AccoutingName { get; set; }
    }
}
