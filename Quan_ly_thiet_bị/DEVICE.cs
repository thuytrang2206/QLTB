//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quan_ly_thiet_bị
{
    using System;
    using System.Collections.Generic;
    
    public partial class DEVICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEVICE()
        {
            this.HISTORies = new HashSet<HISTORY>();
        }
    
        public string Id { get; set; }
        public string FullCode { get; set; }
        public string ScortCode { get; set; }
        public Nullable<bool> IsUsing { get; set; }
        public string DeviceGroup { get; set; }
        public string DeviceName { get; set; }
        public string Model { get; set; }
        public string Serial { get; set; }
        public string VendorName { get; set; }
        public string Purpose { get; set; }
        public string Creator { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> DateMaintenance { get; set; }
        public string Updater { get; set; }
        public Nullable<System.DateTime> Updatetime { get; set; }
        public Nullable<int> Qty { get; set; }
        public string Remark { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
    
        public virtual GROUP_DEVICE GROUP_DEVICE { get; set; }
        public virtual USER USER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HISTORY> HISTORies { get; set; }
    }
}
