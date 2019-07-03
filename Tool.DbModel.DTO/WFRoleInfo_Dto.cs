using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFRoleInfo_Dto
    {
        public int WFRoleInfoId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Nullable<int> WFDepartmentId { get; set; }
        public Nullable<int> WFPostId { get; set; }
        public Nullable<int> CorporationId { get; set; }
        public Nullable<int> CommodityId { get; set; }
        public Nullable<int> TradeType { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> RoleType { get; set; }
        public string QctKey { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public Nullable<int> Module { get; set; }

        public virtual WFPost_Dto WFPost { get; set; }
        //public virtual ICollection<WFRolePrivilege_Dto> WFRolePrivileges { get; set; }
        //public virtual ICollection<WFRoleBusiness_Dto> WFRoleBusinesses { get; set; }
        /// <summary>
        /// 岗位可操作利润中心[本法人]
        /// </summary>
        public List<string> OurCorporationAccountEntitiesNames { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        public List<string> UserNames { get; set; }
        /// <summary>
        /// 冗余-法人名称
        /// </summary>
        public string CorportionName { get; set; }
        /// <summary>
        ///冗余- 是否限制法人
        /// </summary>
        public bool IsForbiddenCorporation { get; set; }
        /// <summary>
        /// 冗余-岗位分类名称
        /// </summary>
        public List<string> PostNames { get; set; }
        /// <summary>
        /// 岗位其他可见利润中心
        /// </summary>
        public List<string> OtherAccountEntitiesNames { get; set; }
        /// <summary>
        /// 岗位其他可见利润中心
        /// </summary>
        public string OtherCorporationName { get; set; }
    }
}
