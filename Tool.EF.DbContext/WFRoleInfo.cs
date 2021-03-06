//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tool.EF.DbContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class WFRoleInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFRoleInfo()
        {
            this.WFRoleBusiness = new HashSet<WFRoleBusiness>();
            this.WFRolePrivilege = new HashSet<WFRolePrivilege>();
            this.WFUserRole = new HashSet<WFUserRole>();
        }
    
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
    
        public virtual WFPost WFPost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFRoleBusiness> WFRoleBusiness { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFRolePrivilege> WFRolePrivilege { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFUserRole> WFUserRole { get; set; }
    }
}
