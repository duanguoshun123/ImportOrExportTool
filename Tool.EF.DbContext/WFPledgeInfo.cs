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
    
    public partial class WFPledgeInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFPledgeInfo()
        {
            this.WFUnPledgeInfo = new HashSet<WFUnPledgeInfo>();
        }
    
        public int WFPledgeInfoId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> CorporationId { get; set; }
        public int UnitId { get; set; }
        public int CurrencyId { get; set; }
        public Nullable<int> CommodityId { get; set; }
        public Nullable<decimal> TotalWeight { get; set; }
        public Nullable<decimal> PledgeRate { get; set; }
        public Nullable<decimal> PledgeWeight { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> PledgeAmount { get; set; }
        public Nullable<decimal> PledgeInterestRate { get; set; }
        public Nullable<decimal> PledgeInterest { get; set; }
        public bool IsUnPledgeFinished { get; set; }
        public Nullable<System.DateTime> PledgeStartDate { get; set; }
        public Nullable<System.DateTime> PledgeEndDate { get; set; }
        public Nullable<int> RequestorId { get; set; }
        public Nullable<int> ExcutorId { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> LastModifiedTime { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> PledgeType { get; set; }
        public Nullable<int> AccountEntityId { get; set; }
        public bool IsSpotPledge { get; set; }
        public Nullable<int> ThirdPartyCustomer { get; set; }
        public Nullable<int> PurchaseContractId { get; set; }
        public bool IsFeeDuringPledgeOwnedByUs { get; set; }
        public Nullable<int> ExchangeId { get; set; }
        public short TradeType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFUnPledgeInfo> WFUnPledgeInfo { get; set; }
    }
}
