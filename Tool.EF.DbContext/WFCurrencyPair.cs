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
    
    public partial class WFCurrencyPair
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFCurrencyPair()
        {
            this.WFDefaultExchangeSetting = new HashSet<WFDefaultExchangeSetting>();
            this.WFExchangeRate = new HashSet<WFExchangeRate>();
        }
    
        public int WFCurrencyPairId { get; set; }
        public int BaseCurrencyId { get; set; }
        public int CounterCurrencyId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFDefaultExchangeSetting> WFDefaultExchangeSetting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFExchangeRate> WFExchangeRate { get; set; }
    }
}
