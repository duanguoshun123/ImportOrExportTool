using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFRolePrivilege_Dto
    {
        public int WFRolePrivilegeId { get; set; }
        public int Privilege { get; set; }
        public int WFRoleInfoId { get; set; }
        public Nullable<int> CorporationId { get; set; }
        public Nullable<short> TradeType { get; set; }
        public Nullable<int> Module { get; set; }

        public virtual WFRoleInfo_Dto WFRoleInfo { get; set; }
        /// <summary>
        /// 冗余-岗位清单名称
        /// </summary>
        public List<string> WFRoleInfoNames { get; set; }
        /// <summary>
        /// 冗余-模块名称
        /// </summary>
        public string ModuleName { get; set; }
        /// <summary>
        ///冗余- 权限名称
        /// </summary>
        public string PermissionName { get; set; }
    }
}
