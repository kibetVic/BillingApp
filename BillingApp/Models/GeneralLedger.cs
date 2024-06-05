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
    
    public partial class GeneralLedger
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GeneralLedger()
        {
            this.ChartsOfAccounts = new HashSet<ChartsOfAccount>();
        }
    
        public int TransactionId { get; set; }
        public int BillId { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public string Description { get; set; }
        public Nullable<int> DebitAccount { get; set; }
        public Nullable<int> CreditAccount { get; set; }
        public decimal Amount { get; set; }
        public string ReferenceId { get; set; }
        public int UserId { get; set; }
        public string Remarks { get; set; }
        public System.DateTime AuditDatetime { get; set; }
    
        public virtual Billing Billing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChartsOfAccount> ChartsOfAccounts { get; set; }
        public virtual User User { get; set; }
    }
}
