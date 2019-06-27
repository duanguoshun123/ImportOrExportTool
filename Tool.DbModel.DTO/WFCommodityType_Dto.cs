using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFCommodityType_Dto
    {
        public int WFCommodityTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string AccountingName { get; set; }
        public int OrderIndex { get; set; }
        public string EnglishName { get; set; }
        public Nullable<int> WFCommodityCategoryId { get; set; }
        public Nullable<int> DefaultUnitId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastManipulationTime { get; set; }
        public bool IsDisabled { get; set; }
        public bool IsFundamentalComponent { get; set; }
        public bool IsPricing { get; set; }
        public virtual WFCommodityCategory_Dto WFCommodityCategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFCommodityTypeQuantityUnit_Dto> WFCommodityTypeQuantityUnit { get; set; }
        public string WFCommodityCategoryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string WFUnitName { get; set; }

    }
}
