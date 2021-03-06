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
    
    public partial class WFOurPlantTransferWarehouseNotification
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFOurPlantTransferWarehouseNotification()
        {
            this.WFOurPlantTransferWarehouseNotificationDetail = new HashSet<WFOurPlantTransferWarehouseNotificationDetail>();
        }
    
        public int WFOurPlantTransferWarehouseNotificationId { get; set; }
        public Nullable<int> WFStorageConversionId { get; set; }
        public bool IsDeleted { get; set; }
        public int CorporationId { get; set; }
        public int SourceWarehouseId { get; set; }
        public int TargetWarehouseId { get; set; }
        public int CommodityId { get; set; }
        public int UnitId { get; set; }
        public System.DateTime BillDate { get; set; }
        public System.DateTime PostingDate { get; set; }
        public int MaterialDocumentYear { get; set; }
        public string MaterialDocumentCode { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int SourceInventoryId { get; set; }
        public int SourceBatchId { get; set; }
        public decimal TotalWeight { get; set; }
    
        public virtual WFStorageConversion WFStorageConversion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFOurPlantTransferWarehouseNotificationDetail> WFOurPlantTransferWarehouseNotificationDetail { get; set; }
    }
}
