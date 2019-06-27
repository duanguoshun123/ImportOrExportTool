using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFCommodityTypeQuantityUnit_Dto
    {
        public int WFCommodityTypeQuantityUnitId { get; set; }
        public Nullable<int> WFCommodityTypeId { get; set; }
        public Nullable<int> WFQuantityTypeId { get; set; }
        public Nullable<int> WFUnitId { get; set; }
        public Nullable<short> Scale { get; set; }
        public Nullable<short> Priority { get; set; }

        public virtual WFCommodityType_Dto WFCommodityType { get; set; }
        public virtual WFUnit_Dto WFUnit { get; set; }
    }
}
