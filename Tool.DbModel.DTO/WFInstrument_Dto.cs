using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFInstrument_Dto
    {
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

        public virtual WFCommodityType_Dto WFCommodityType { get; set; }
        public virtual WFCompany_Dto WFCompany { get; set; }
        public virtual WFInstrumentCategory_Dto WFInstrumentCategory { get; set; }
    }
}
