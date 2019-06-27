using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFUnit_Dto
    {
        public int WFUnitId { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public string EnglishName { get; set; }
        public int QuantityKind { get; set; }
        public string InformalSymbol { get; set; }
        public string InformalName { get; set; }
        public string InformalEnglishName { get; set; }
        public string SapCode { get; set; }
        public string AccountingName { get; set; }
        public Nullable<int> SpecialUnit { get; set; }
    }
}
