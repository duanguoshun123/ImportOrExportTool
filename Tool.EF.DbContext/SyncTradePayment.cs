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
    
    public partial class SyncTradePayment
    {
        public long Id { get; set; }
        public Nullable<System.DateTime> TradeDate { get; set; }
        public Nullable<int> ContractId { get; set; }
        public string Direction { get; set; }
        public Nullable<decimal> Volume { get; set; }
        public string PayType { get; set; }
        public string PayCurrency { get; set; }
        public Nullable<decimal> PayVolume { get; set; }
        public string BillCode { get; set; }
        public string BillCurrency { get; set; }
        public Nullable<decimal> BillAmount { get; set; }
        public Nullable<decimal> DiscountCost { get; set; }
        public Nullable<int> AmountRecordId { get; set; }
        public bool Unavailable { get; set; }
        public System.DateTime CreationTime { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
    }
}
