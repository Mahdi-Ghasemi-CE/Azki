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
    
    public partial class WealthInsurance
    {
        public int WealthInsuranceId { get; set; }
        public int InsuranceId { get; set; }
        public long WealthValue { get; set; }
        public string ProvinceName { get; set; }
        public string CityName { get; set; }
        public int WealthInsuranceTypeId { get; set; }
        public int Meterage { get; set; }
        public int BuildingAge { get; set; }
        public Nullable<int> RoofNumbers { get; set; }
        public int WealthTypeId { get; set; }
        public long ValuePerMeter { get; set; }
    
        public virtual Insurance Insurance { get; set; }
    }
}
