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
    
    public partial class WFTradeInstructionDetail
    {
        public int WFTradeInstructionDetailId { get; set; }
        public Nullable<int> WFTradeInstructionId { get; set; }
        public Nullable<decimal> SubjectQuantity { get; set; }
        public Nullable<decimal> PremiumDiscount { get; set; }
        public Nullable<decimal> SettlementPrice { get; set; }
        public Nullable<decimal> BasePrice { get; set; }
        public string Notes { get; set; }
    
        public virtual WFTradeInstruction WFTradeInstruction { get; set; }
    }
}
