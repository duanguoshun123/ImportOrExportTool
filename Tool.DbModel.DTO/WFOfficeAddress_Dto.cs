using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFOfficeAddress_Dto
    {
        public int WFOfficeAddressId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string EnglishAddress { get; set; }
        public string PostCode { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFUser_Dto> WFUser { get; set; }
    }
}
