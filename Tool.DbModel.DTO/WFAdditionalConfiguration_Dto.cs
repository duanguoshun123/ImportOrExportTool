using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFAdditionalConfiguration_Dto
    {
        public int WFAdditionalConfigurationId { get; set; }
        public short AdditionalConfigurationType { get; set; }
        public string SAPCode { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Nullable<short> Direction { get; set; }
        public Nullable<short> TaxCodeType { get; set; }
        public Nullable<decimal> TaxRate { get; set; }
        public Nullable<short> FeeConditionTypeCategory { get; set; }
        public string QctKey { get; set; }
        public Nullable<int> SortPriority { get; set; }
    }
}
