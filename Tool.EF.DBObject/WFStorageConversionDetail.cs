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
    
    public partial class WFStorageConversionDetail
    {
        public int WFStorageConversionDetailId { get; set; }
        public int WFStorageConversionId { get; set; }
        public int BrandId { get; set; }
        public int SpecificationId { get; set; }
        public string GroupCode { get; set; }
        public string StorageCode { get; set; }
        public Nullable<decimal> Weight { get; set; }
        public bool IsDeleted { get; set; }
    
        public virtual WFStorageConversion WFStorageConversion { get; set; }
    }
}
