using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFAccountEntity_Dto
    {
        public int WFAccountEntityId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Nullable<int> ParentDepartmentId { get; set; }
        public Nullable<short> Type { get; set; }
        public bool IsAccounting { get; set; }
        public bool IsDeleted { get; set; }
        public string AccountingName { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastManipulationTime { get; set; }
        public bool IsDisabled { get; set; }
        public int Indicator { get; set; }
        public Nullable<bool> IsAtomicAccounting { get; set; }
        public Nullable<bool> IsHedgeAccounting { get; set; }

        public ICollection<WFDepartmentAccountEntity_Dto> AccountEntities { get; set; } = new HashSet<WFDepartmentAccountEntity_Dto>();

        public ICollection<WFDepartmentAccountEntity_Dto> Departments { get; set; } = new HashSet<WFDepartmentAccountEntity_Dto>();

        public ICollection<WFCorporationDepartment_Dto> WFCorporationDepartments { get; set; } = new HashSet<WFCorporationDepartment_Dto>();

        /// <summary>
        /// partial
        /// </summary>
        //public ICollection<WFBusiness_Dto> WFBusinesses { get; set; } = new HashSet<WFBusiness_Dto>();

        /// <summary>
        /// 核算主体关联的部门
        /// </summary>
        public List<WFAccountEntity_Dto> RelationDepartments { get; set; } = new List<WFAccountEntity_Dto>();

        /// <summary>
        /// partial 部门关联的核算主体
        /// </summary>
        public List<WFAccountEntity_Dto> RelationAccountEntities { get; set; } = new List<WFAccountEntity_Dto>();

        /// <summary>
        /// 利润中心下级利润中心
        /// </summary>
        public List<WFAccountEntity_Dto> SubAccountEntities { get; set; } = new List<WFAccountEntity_Dto>();

        /// <summary>
        /// 上级利润中心/部门
        /// </summary>
        public WFAccountEntity_Dto ParentAccountEntity { get; set; }
        /// <summary>
        /// 冗余-父级利润中心名称
        /// </summary>
        public string ParentAccountEntityName { set; get; }
        /// <summary>
        /// 冗余-业务版块
        /// </summary>
        public string BusinessPlateName { get; set; }
        /// <summary>
        /// 冗余-利润中心层次 
        /// </summary>
        public int Level { get; set; }
        public List<string> Indicatornames { get; set; }
    }
}
