using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFPost_Dto
    {
        public int WFPostId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public Nullable<short> EnumValue { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFRoleInfo_Dto> WFRoleInfo { get; set; }
    }
}
