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
    
    public partial class WFConditionProperty
    {
        public int WFConditionPropertyId { get; set; }
        public Nullable<int> ConditionType { get; set; }
        public Nullable<int> ApprovalType { get; set; }
        public string PropertyName { get; set; }
        public string DisplayName { get; set; }
        public bool IsDeleted { get; set; }
        public int SideType { get; set; }
        public bool SupportDynamicValue { get; set; }
        public int ValueType { get; set; }
        public string ValueRanges { get; set; }
        public int AvailableOperators { get; set; }
    }
}
