using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFCorporationTypeConfiguration_Dto
    {
        public int WFCorporationTypeConfigurationId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> WFCompanyId { get; set; }
        public Nullable<int> CorporationType { get; set; }
        public bool IsDisabled { get; set; }
        public Nullable<decimal> PledgeInterestRate { get; set; }
        public Nullable<decimal> PledgeProportion { get; set; }
        public Nullable<int> ExchangeTypeId { get; set; }
        public string TimeZoneId { get; set; }

        public virtual WFCompany_Dto WFCompany { get; set; }
    }
}
