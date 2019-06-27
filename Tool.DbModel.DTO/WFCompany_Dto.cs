using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFCompany_Dto
    {
        public int WFCompanyId { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public string LegalRepresentative { get; set; }
        public string NatureText { get; set; }
        public Nullable<System.DateTime> FoundDate { get; set; }
        public string Telphone { get; set; }
        public string Fax { get; set; }
        public string TaxCode { get; set; }
        public string OpenBillAddress { get; set; }
        public string OpenBillTelphone { get; set; }
        public string MailingAddress { get; set; }
        public string PostCode { get; set; }
        public string LinkMan { get; set; }
        public string LinkPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Note { get; set; }
        public Nullable<int> Type { get; set; }
        public bool IsDeleted { get; set; }
        public string Abbreviation { get; set; }
        public Nullable<int> GroupId { get; set; }
        public Nullable<short> CreditRatingModificationStatus { get; set; }
        public Nullable<int> BuyWFCreditRatingId { get; set; }
        public Nullable<int> SaleWFCreditRatingId { get; set; }
        public Nullable<int> CorporationRank { get; set; }
        public string EnglishFullName { get; set; }
        public string EnglishShortName { get; set; }
        public string EnglishOpenBillAddress { get; set; }
        public string EnglishMailingAddress { get; set; }
        public bool IsDisabled { get; set; }
        public Nullable<decimal> RegistCapital { get; set; }
        public Nullable<int> RegisteredCapitalCurrencyId { get; set; }
        public Nullable<bool> IsDomestic { get; set; }
        public int LockSettings { get; set; }
        public Nullable<int> MetaCompanyType { get; set; }
        public Nullable<int> RelationCategory { get; set; }
        public string AccountingName { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastManipulationTime { get; set; }
        public Nullable<int> OurCorporationFunctionalCurrencyId { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFCorporationTypeConfiguration_Dto> WFCorporationTypeConfiguration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFInstrument_Dto> WFInstrument { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFInstrumentCategory_Dto> WFInstrumentCategory { get; set; }
        public string TimeZone { get; set; }
        public string ExchangeTypeName { get; set; }
        public List<string> CommodityNames { get; set; }
        public List<string> InstrumentNames { get; set; }
        public string OurCorporationFunctionalCurrencyName { get; set; }
    }
}
