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
    
    public partial class WFCreditRatingDetail
    {
        public int WFCreditRatingDetailId { get; set; }
        public Nullable<int> WFCreditRatingId { get; set; }
        public Nullable<int> WFCommodityId { get; set; }
        public short CreditRatingDetailType { get; set; }
        public Nullable<decimal> AmountQuota { get; set; }
        public Nullable<decimal> QuantityQuota { get; set; }
        public string Note { get; set; }
        public Nullable<bool> IsTradeAllowed { get; set; }
    
        public virtual WFCommodity WFCommodity { get; set; }
        public virtual WFCreditRating WFCreditRating { get; set; }
    }
}
