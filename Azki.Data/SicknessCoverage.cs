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
    
    public partial class SicknessCoverage
    {
        public int SicknessCoverageId { get; set; }
        public int SicknessCoverageTypesId { get; set; }
        public long Price { get; set; }
        public int SupplementaryHealthInsuranceId { get; set; }
    
        public virtual SicknessCoverageType SicknessCoverageType { get; set; }
        public virtual SupplementaryHealthInsurance SupplementaryHealthInsurance { get; set; }
        public virtual SicknessCoverageType SicknessCoverageType1 { get; set; }
    }
}
