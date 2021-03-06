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
    
    public partial class WFAmountRecordDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFAmountRecordDetail()
        {
            this.WFAmountRecordSubDetail = new HashSet<WFAmountRecordSubDetail>();
        }
    
        public int WFAmountRecordDetailId { get; set; }
        public Nullable<int> WFAmountRecordId { get; set; }
        public Nullable<int> WFContractInfoId { get; set; }
        public Nullable<int> ObjectId { get; set; }
        public Nullable<decimal> SettleCurrencyPresentValue { get; set; }
        public Nullable<decimal> SettleCurrencyFutureValue { get; set; }
        public Nullable<System.Guid> WholeAmountDetailUid { get; set; }
        public Nullable<int> ObjectType { get; set; }
        public Nullable<int> ObjectCurrencyId { get; set; }
        public Nullable<int> ExchangeRateId { get; set; }
        public Nullable<int> TempExchangeRateId { get; set; }
        public Nullable<decimal> ObjectCurrencyDiscount { get; set; }
        public bool ObjectAmountIncludeDiscount { get; set; }
        public Nullable<int> SapAmountTransaction { get; set; }
    
        public virtual WFAmountRecord WFAmountRecord { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFAmountRecordSubDetail> WFAmountRecordSubDetail { get; set; }
        public virtual WFContractInfo WFContractInfo { get; set; }
    }
}
