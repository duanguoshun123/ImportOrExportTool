using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFCurrency_Dto
    {
        public int WFCurrencyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string EnglishName { get; set; }
        public string Symbol { get; set; }
        public Nullable<int> TradingFlag { get; set; }
        public Nullable<int> DomesticIndex { get; set; }
        public Nullable<int> InterIndex { get; set; }
        public string ShortName { get; set; }
        public Nullable<short> Scale { get; set; }
        public string AccountingName { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastManipulationTime { get; set; }
    }
}
