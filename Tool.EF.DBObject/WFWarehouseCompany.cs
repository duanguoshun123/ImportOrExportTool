//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tool.EF.DBObject
{
    using System;
    using System.Collections.Generic;
    
    public partial class WFWarehouseCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFWarehouseCompany()
        {
            this.WFSystemFeeConfiguration = new HashSet<WFSystemFeeConfiguration>();
            this.WFWarehouseCalculateFeeType = new HashSet<WFWarehouseCalculateFeeType>();
            this.WFWarehouseCardCodePrefix = new HashSet<WFWarehouseCardCodePrefix>();
            this.WFWarehouseDetail = new HashSet<WFWarehouseDetail>();
        }
    
        public int WFCompanyId { get; set; }
        public Nullable<int> LegacyWarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public Nullable<System.DateTime> SignDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Address { get; set; }
        public string StorageFee { get; set; }
        public string TransferFee { get; set; }
        public string EntryFee { get; set; }
        public string Contacter { get; set; }
        public string Phone { get; set; }
        public string FaxNumber { get; set; }
        public string SecondContacter { get; set; }
        public string SecondPhone { get; set; }
        public string Area { get; set; }
        public string Note { get; set; }
        public bool IsFeeDuringPledgeOwnedByUs { get; set; }
        public string EnglishAddress { get; set; }
        public Nullable<int> SpecialWarehouse { get; set; }
        public Nullable<int> RelatedVirtualWarehouseId { get; set; }
    
        public virtual WFCompany WFCompany { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFSystemFeeConfiguration> WFSystemFeeConfiguration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFWarehouseCalculateFeeType> WFWarehouseCalculateFeeType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFWarehouseCardCodePrefix> WFWarehouseCardCodePrefix { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFWarehouseDetail> WFWarehouseDetail { get; set; }
    }
}
