using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFDepartmentAccountEntity_Dto
    {
        public int DepartmentId { get; set; }
        public int AccountEntityId { get; set; }
        public int WFDepartmentAccountEntityId { get; set; }
        public string SAPCode { get; set; }

        public virtual WFAccountEntity_Dto Department { get; set; }
        public virtual WFAccountEntity_Dto AccountEntity { get; set; }
    }
}
