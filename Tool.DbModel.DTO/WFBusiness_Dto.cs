using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFBusiness_Dto
    {
        public WFBusiness_Dto()
        {
            //this.WFCompanyBankInfoCommodityAccountEntities = new HashSet<WFCompanyBankInfoCommodityAccountEntity_Dto>();
            //this.WFContactCommodityAccountEntities = new HashSet<WFContactCommodityAccountEntity_Dto>();
            //this.WFCompanyBusinesses = new HashSet<WFCompanyBusiness_Dto>();
            //this.WFUserBusinesses = new HashSet<WFUserBusiness_Dto>();
            //this.WFRoleBusinesses = new HashSet<WFRoleBusiness_Dto>();
        }

        public int WFBusinessId { get; set; }
        public Nullable<int> WFCommodityId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> CorporationId { get; set; }
        public Nullable<short> TradeType { get; set; }
        public bool IsDisabled { get; set; }

        public virtual WFAccountEntity_Dto Department { get; set; }
        public virtual WFCompany_Dto Corporation { get; set; }
        //public virtual ICollection<WFCompanyBankInfoCommodityAccountEntity_Dto> WFCompanyBankInfoCommodityAccountEntities { get; set; }
        //public virtual WFCommodity_Dto WFCommodity { get; set; }
        //public virtual ICollection<WFContactCommodityAccountEntity_Dto> WFContactCommodityAccountEntities { get; set; }
        //public virtual ICollection<WFCompanyBusiness_Dto> WFCompanyBusinesses { get; set; }
        //public virtual ICollection<WFUserBusiness_Dto> WFUserBusinesses { get; set; }
        //public virtual ICollection<WFRoleBusiness_Dto> WFRoleBusinesses { get; set; }


    }
}
