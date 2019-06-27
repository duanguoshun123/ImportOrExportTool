using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFCorporationDepartment_Dto
    {
        public int WFCorporationDepartmentId { get; set; }
        public Nullable<int> WFAccountEntityId { get; set; }
        public Nullable<int> CorporationId { get; set; }
        public string Name { get; set; }

        public virtual WFAccountEntity_Dto WFAccountEntity { get; set; }
    }
}
