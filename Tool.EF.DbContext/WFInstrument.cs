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
    
    public partial class WFInstrument
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFInstrument()
        {
            this.WFInstrumentSettlementPrice = new HashSet<WFInstrumentSettlementPrice>();
            this.WFPriceInstrument = new HashSet<WFPriceInstrument>();
        }
    
        public int WFInstrumentId { get; set; }
        public Nullable<int> WFCommodityTypeId { get; set; }
        public string InstrumentCode { get; set; }
        public Nullable<int> ExchangeId { get; set; }
        public Nullable<System.DateTime> CurrentStartDate { get; set; }
        public Nullable<System.DateTime> LastTradingDay { get; set; }
        public short InstrumentType { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<int> WFInstrumentCategoryId { get; set; }
        public Nullable<System.DateTime> PromptDate { get; set; }
        public bool IsDeleted { get; set; }
        public string QctKey { get; set; }
        public string FriendlyName { get; set; }
        public Nullable<System.DateTime> FirstTradingDate { get; set; }
        public Nullable<decimal> InstrumentTaxRate { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastManipulationTime { get; set; }
    
        public virtual WFCommodityType WFCommodityType { get; set; }
        public virtual WFCompany WFCompany { get; set; }
        public virtual WFInstrumentCategory WFInstrumentCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFInstrumentSettlementPrice> WFInstrumentSettlementPrice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFPriceInstrument> WFPriceInstrument { get; set; }
    }
}
