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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Azki_DBEntities : DbContext
    {
        public Azki_DBEntities()
            : base("name=Azki_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Insurance> Insurances { get; set; }
        public virtual DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public virtual DbSet<LifeInsurance> LifeInsurances { get; set; }
        public virtual DbSet<PaiedInsurance> PaiedInsurances { get; set; }
        public virtual DbSet<PersonalInsurance> PersonalInsurances { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }
        public virtual DbSet<SicknessCoverage> SicknessCoverages { get; set; }
        public virtual DbSet<SicknessCoverageType> SicknessCoverageTypes { get; set; }
        public virtual DbSet<SupplementaryHealthInsurance> SupplementaryHealthInsurances { get; set; }
        public virtual DbSet<SupplementaryHealthInsuranceUser> SupplementaryHealthInsuranceUsers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<WealthInsurance> WealthInsurances { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<spNameCompanyAsc_Result> spNameCompanyAsc(string province)
        {
            var provinceParameter = province != null ?
                new ObjectParameter("Province", province) :
                new ObjectParameter("Province", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spNameCompanyAsc_Result>("spNameCompanyAsc", provinceParameter);
        }
    
        public virtual ObjectResult<spTwoInsurances_Result> spTwoInsurances(Nullable<int> fist_insurance, Nullable<int> second_insurance)
        {
            var fist_insuranceParameter = fist_insurance.HasValue ?
                new ObjectParameter("fist_insurance", fist_insurance) :
                new ObjectParameter("fist_insurance", typeof(int));
    
            var second_insuranceParameter = second_insurance.HasValue ?
                new ObjectParameter("second_insurance", second_insurance) :
                new ObjectParameter("second_insurance", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spTwoInsurances_Result>("spTwoInsurances", fist_insuranceParameter, second_insuranceParameter);
        }
    
        public virtual int spUpdateInsurance(Nullable<int> y, Nullable<int> baseInsurance)
        {
            var yParameter = y.HasValue ?
                new ObjectParameter("Y", y) :
                new ObjectParameter("Y", typeof(int));
    
            var baseInsuranceParameter = baseInsurance.HasValue ?
                new ObjectParameter("baseInsurance", baseInsurance) :
                new ObjectParameter("baseInsurance", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spUpdateInsurance", yParameter, baseInsuranceParameter);
        }
    
        public virtual ObjectResult<spuserCompanyInsurance_Result> spuserCompanyInsurance(string insuranceCompanyName, string insuranceName)
        {
            var insuranceCompanyNameParameter = insuranceCompanyName != null ?
                new ObjectParameter("InsuranceCompanyName", insuranceCompanyName) :
                new ObjectParameter("InsuranceCompanyName", typeof(string));
    
            var insuranceNameParameter = insuranceName != null ?
                new ObjectParameter("InsuranceName", insuranceName) :
                new ObjectParameter("InsuranceName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spuserCompanyInsurance_Result>("spuserCompanyInsurance", insuranceCompanyNameParameter, insuranceNameParameter);
        }
    
        public virtual ObjectResult<string> spUserInvitation(Nullable<int> inventionCodeNumber, Nullable<int> paidInsuranceNumber)
        {
            var inventionCodeNumberParameter = inventionCodeNumber.HasValue ?
                new ObjectParameter("InventionCodeNumber", inventionCodeNumber) :
                new ObjectParameter("InventionCodeNumber", typeof(int));
    
            var paidInsuranceNumberParameter = paidInsuranceNumber.HasValue ?
                new ObjectParameter("PaidInsuranceNumber", paidInsuranceNumber) :
                new ObjectParameter("PaidInsuranceNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spUserInvitation", inventionCodeNumberParameter, paidInsuranceNumberParameter);
        }
    
        public virtual ObjectResult<spUserMaxInsurance_Result> spUserMaxInsurance(Nullable<long> price)
        {
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spUserMaxInsurance_Result>("spUserMaxInsurance", priceParameter);
        }
    
        public virtual ObjectResult<string> spUserNotOrder()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spUserNotOrder");
        }
    
        public virtual ObjectResult<string> spUserReminder(Nullable<int> paymentPeriodType)
        {
            var paymentPeriodTypeParameter = paymentPeriodType.HasValue ?
                new ObjectParameter("PaymentPeriodType", paymentPeriodType) :
                new ObjectParameter("PaymentPeriodType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("spUserReminder", paymentPeriodTypeParameter);
        }
    }
}
