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
    
    public partial class LifeInsurance
    {
        public int LifeInsuranceId { get; set; }
        public long RedemptionValue { get; set; }
        public long AbilityToPay { get; set; }
        public long MedicalExpenses { get; set; }
        public long DeathCapital { get; set; }
        public int PersonalInsuranceId { get; set; }
    
        public virtual PersonalInsurance PersonalInsurance { get; set; }
    }
}
