//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tool.EF.DBObject
{
    using System;
    using System.Collections.Generic;
    
    public partial class WFBusinessBillTemplate
    {
        public int WFBusinessBillTemplateId { get; set; }
        public Nullable<int> WFBillTemplateId { get; set; }
        public Nullable<int> WFConditionId { get; set; }
        public Nullable<int> CommodityId { get; set; }
        public Nullable<int> DepartmentId { get; set; }
        public Nullable<int> CorporationId { get; set; }
        public Nullable<int> TradeType { get; set; }
        public Nullable<int> AttachmentObjectType { get; set; }
    
        public virtual WFBillTemplate WFBillTemplate { get; set; }
        public virtual WFCondition WFCondition { get; set; }
    }
}
