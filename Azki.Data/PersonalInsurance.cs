//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Azki.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonalInsurance
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PersonalInsurance()
        {
            this.LifeInsurances = new HashSet<LifeInsurance>();
            this.SupplementaryHealthInsurances = new HashSet<SupplementaryHealthInsurance>();
        }
    
        public int PersonalInsuranceId { get; set; }
        public int IncreasePercent { get; set; }
        public int PaymentPeriodType { get; set; }
        public int InsuranceId { get; set; }
    
        public virtual Insurance Insurance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LifeInsurance> LifeInsurances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplementaryHealthInsurance> SupplementaryHealthInsurances { get; set; }
    }
}