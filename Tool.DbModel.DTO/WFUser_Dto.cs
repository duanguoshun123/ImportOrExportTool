using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tool.DbModel.DTO
{
    public class WFUser_Dto
    {
        public int WFUserId { get; set; }
        public string Password { get; set; }
        public string LoginName { get; set; }
        public string Name { get; set; }
        public string MailAddress { get; set; }
        public Nullable<bool> IsOutofOffice { get; set; }
        public bool IsDeleted { get; set; }
        public string OfficePhone { get; set; }
        public string Fax { get; set; }
        public string WXUserId { get; set; }
        public string TrustedDevice { get; set; }
        public int NotifyingAgents { get; set; }
        public string EnglishName { get; set; }
        public Nullable<int> WFOfficeAddressId { get; set; }
        public bool IsDisabled { get; set; }
        public string SAPCode { get; set; }
        public string DdId { get; set; }
        public System.DateTime CreationTime { get; set; }
        public System.DateTime LastManipulationTime { get; set; }

        public virtual WFOfficeAddress_Dto WFOfficeAddress { get; set; }
        /// <summary>
        /// 冗余
        /// </summary>
        public string WFOfficeAddressName { get; set; }
    }
}
