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
    
    public partial class WFAvgPriceDetail
    {
        public int WFPriceDetailId { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<int> PriceCalculateType { get; set; }
        public Nullable<int> PriceMarket { get; set; }
        public Nullable<int> DayCount { get; set; }
        public Nullable<int> SettlementPriceType { get; set; }
        public Nullable<int> ContinuousInstrument { get; set; }
        public Nullable<int> InstrumentCategoryId { get; set; }
        public Nullable<int> FinalPriceCalculateType { get; set; }
    
        public virtual WFPriceDetail WFPriceDetail { get; set; }
    }
}
