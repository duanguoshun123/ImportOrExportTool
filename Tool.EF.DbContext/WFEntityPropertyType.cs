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
    
    public partial class WFEntityPropertyType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFEntityPropertyType()
        {
            this.WFEntityProperty = new HashSet<WFEntityProperty>();
        }
    
        public int WFEntityPropertyTypeId { get; set; }
        public int EntityType { get; set; }
        public string PropertyName { get; set; }
        public bool IsBuiltIn { get; set; }
        public Nullable<int> BuiltInKey { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFEntityProperty> WFEntityProperty { get; set; }
    }
}
