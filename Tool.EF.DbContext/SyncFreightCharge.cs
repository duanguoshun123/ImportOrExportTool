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
    
    public partial class SyncFreightCharge
    {
        public int Id { get; set; }
        public bool Unavailable { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastManipulationTime { get; set; }
        public Nullable<int> DeliveryOutRecordId { get; set; }
        public Nullable<int> FreightPriceId { get; set; }
        public Nullable<int> ContractId { get; set; }
        public string WarehouseOutType { get; set; }
        public string DeliveryType { get; set; }
        public Nullable<System.DateTime> DeliveryOutDate { get; set; }
        public string DeliveryUnit { get; set; }
        public Nullable<decimal> DeliveryQuantity { get; set; }
        public string SrcLogisticsPlace { get; set; }
        public string DstLogisticsPlace { get; set; }
        public string VehicleTransportSpec { get; set; }
        public string FreightPriceType { get; set; }
        public string VehicleNumber { get; set; }
        public string TransportNumber { get; set; }
        public string LogisticsCompany { get; set; }
        public string FreightCurrency { get; set; }
        public Nullable<decimal> ComputedFreightPrice { get; set; }
        public Nullable<decimal> ComputedFreightCharge { get; set; }
        public Nullable<System.DateTime> LastUpdateTime { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<decimal> DeliveryVolume { get; set; }
        public Nullable<decimal> FreightCharge { get; set; }
        public Nullable<decimal> FreightAmount { get; set; }
    }
}
