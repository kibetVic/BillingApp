//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BillingApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Message()
        {
            this.Customers = new HashSet<Customer>();
        }
    
        public int MessageId { get; set; }
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.DateTime> TrxDate { get; set; }
        public string Message1 { get; set; }
        public Nullable<int> Type { get; set; }
        public string OutIn { get; set; }
        public Nullable<int> UserId { get; set; }
        public System.DateTime AuditDatetime { get; set; }
        public Nullable<System.DateTime> SendTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual User User { get; set; }
    }
}
