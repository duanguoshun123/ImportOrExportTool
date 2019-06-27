using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFCommodityCategory_Dto
    {
        public int WFCommodityCategoryId { get; set; }
        public string QctKey { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastManipulationTime { get; set; }
        public bool IsBuiltIn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFCommodityType_Dto> WFCommodityType { get; set; }
    }
}
