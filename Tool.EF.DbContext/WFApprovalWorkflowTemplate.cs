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
    
    public partial class WFApprovalWorkflowTemplate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WFApprovalWorkflowTemplate()
        {
            this.WFApprovalWorkflowStepTemplate = new HashSet<WFApprovalWorkflowStepTemplate>();
            this.WFApprovalWorkflowTemplateRole = new HashSet<WFApprovalWorkflowTemplateRole>();
            this.WFCorporationApprovalWFTemplate = new HashSet<WFCorporationApprovalWFTemplate>();
        }
    
        public int WFApprovalWorkflowTemplateId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<int> WorkflowType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFApprovalWorkflowStepTemplate> WFApprovalWorkflowStepTemplate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFApprovalWorkflowTemplateRole> WFApprovalWorkflowTemplateRole { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WFCorporationApprovalWFTemplate> WFCorporationApprovalWFTemplate { get; set; }
    }
}
