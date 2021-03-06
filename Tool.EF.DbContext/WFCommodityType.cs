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
    
    public partial class WFCommodityType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFCommodityType()
        {
            this.WFCommodity = new HashSet<WFCommodity>();
            this.WFCommodityTypeQuantityUnit = new HashSet<WFCommodityTypeQuantityUnit>();
            this.WFInstrument = new HashSet<WFInstrument>();
            this.WFInstrumentCategory = new HashSet<WFInstrumentCategory>();
        }
    
        public int WFCommodityTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string AccountingName { get; set; }
        public int OrderIndex { get; set; }
        public string EnglishName { get; set; }
        public Nullable<int> WFCommodityCategoryId { get; set; }
        public Nullable<int> DefaultUnitId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastManipulationTime { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsFundamentalComponent { get; set; }
        public bool IsPricing { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFCommodity> WFCommodity { get; set; }
        public virtual WFCommodityCategory WFCommodityCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFCommodityTypeQuantityUnit> WFCommodityTypeQuantityUnit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFInstrument> WFInstrument { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFInstrumentCategory> WFInstrumentCategory { get; set; }
    }
}
