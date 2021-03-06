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
    
    public partial class WFLetterOfCredit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFLetterOfCredit()
        {
            this.WFExchangeBill = new HashSet<WFExchangeBill>();
            this.WFLcContract = new HashSet<WFLcContract>();
        }
    
        public int WFLetterOfCreditId { get; set; }
        public bool IsDeleted { get; set; }
        public int ApplicantId { get; set; }
        public int IssuingBankId { get; set; }
        public int AdvisingBankId { get; set; }
        public int BeneficiaryId { get; set; }
        public string Code { get; set; }
        public bool IsSight { get; set; }
        public int CustomerId { get; set; }
        public int CorporationId { get; set; }
        public int AccountingEntityId { get; set; }
        public int CurrencyId { get; set; }
        public decimal Amount { get; set; }
        public decimal AvailableAmount { get; set; }
        public bool IsPay { get; set; }
        public int Status { get; set; }
        public Nullable<System.DateTime> PresentationExpiryDate { get; set; }
        public Nullable<int> CommodityId { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<short> FloatingInterestRateType { get; set; }
        public Nullable<decimal> DiscountRate { get; set; }
        public Nullable<int> DiscountDays { get; set; }
        public Nullable<System.DateTime> ExpirationDate { get; set; }
        public Nullable<decimal> PositiveFloatingAmountRatio { get; set; }
        public Nullable<decimal> NegativeFloatingAmountRatio { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFExchangeBill> WFExchangeBill { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFLcContract> WFLcContract { get; set; }
    }
}
