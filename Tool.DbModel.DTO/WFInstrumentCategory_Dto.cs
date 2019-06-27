using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFInstrumentCategory_Dto
    {
        public int WFInstrumentCategoryId { get; set; }
        public Nullable<int> MarketId { get; set; }
        public Nullable<int> WFCommodityTypeId { get; set; }
        public Nullable<int> WFCurrencyId { get; set; }
        public Nullable<int> WFUnitId { get; set; }
        public Nullable<int> InstrumentPeriodType { get; set; }
        public bool IsDeleted { get; set; }
        public string Code { get; set; }
        public Nullable<int> FinancialInstrumentType { get; set; }
        public string QctKey { get; set; }
        public string FriendlyName { get; set; }
        public Nullable<decimal> PriceUnitMultiple { get; set; }
        public Nullable<decimal> LotSize { get; set; }
        public Nullable<decimal> TickSize { get; set; }
        public Nullable<int> InstrumentContractFormatId { get; set; }
        public Nullable<decimal> InstrumentTaxRate { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastManipulationTime { get; set; }
        public Nullable<decimal> HedgingCoefficient { get; set; }
        public virtual WFCommodityType_Dto WFCommodityType { get; set; }
        public virtual WFCompany_Dto WFCompany { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFInstrument_Dto> WFInstrument { get; set; }
        public virtual WFUnit_Dto WFUnit { get; set; }
    }
}
