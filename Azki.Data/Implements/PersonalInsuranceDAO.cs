using Azki.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class PersonalInsuranceDAO : BaseRepository, Repository<PersonalInsurance, int>
    {
        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[PersonalInsurance] where PersonalInsuranceId = {id}";
            var data = Connection.Query(query, null, commandType: CommandType.Text);

            try
            {
                var model = findById(id);
                if (!(model is null))
                { return true; }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteByIDs(List<int> ids)
        {
            try
            {
                var query = $"delete from [dbo].[PersonalInsurance] where PersonalInsuranceId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PersonalInsurance> findAll()
        {
            var query = "SELECT [PersonalInsuranceId]" +
                ",[IncreasePercent]" +
                ",[PaymentPeriodType]" +
                ",[InsuranceId] " +
                "FROM [dbo].[PersonalInsurance]";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);

            return data.Read<PersonalInsurance>().ToList();
        }

        public PersonalInsurance findById(int id)
        {
            var query = "SELECT [PersonalInsuranceId]" +
                ",[IncreasePercent]" +
                ",[PaymentPeriodType]" +
                ",[InsuranceId] " +
                $"FROM [dbo].[PersonalInsurance] where PersonalInsuranceId = {id}";

            var data = Connection.Query<PersonalInsurance>(query);

            return data.SingleOrDefault(); ;
        }

        public List<PersonalInsurance> findByIDs(List<int> ids)
        {
            var query = "SELECT [PersonalInsuranceId]" +
               ",[IncreasePercent]" +
               ",[PaymentPeriodType]" +
               ",[InsuranceId] " +
               $"FROM [dbo].[PersonalInsurance] where InsuranceCompanyId in ({ids})";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<PersonalInsurance>().ToList();
        }

        public PersonalInsurance save(PersonalInsurance E)
        {
            var query = "";
            if (E.PersonalInsuranceId == 0)
            {
                query = $"INSERT INTO [dbo].[PersonalInsurance]([IncreasePercent],[PaymentPeriodType],[InsuranceId])" +
                                   $"VALUES ({E.IncreasePercent},{E.PaymentPeriodType},{E.InsuranceId})" +
                                    $"SELECT * FROM [dbo].[PersonalInsurance] where PersonalInsuranceId =  scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[PersonalInsurance]" +
                        $"SET [IncreasePercent] = {E.IncreasePercent},[PaymentPeriodType] = {E.PaymentPeriodType},[InsuranceId] = {E.InsuranceId}" +
                        $"WHERE PersonalInsuranceId = {E.PersonalInsuranceId}" + "SELECT [PersonalInsuranceId]" +
                        ",[IncreasePercent]" +
                        ",[PaymentPeriodType]" +
                        ",[InsuranceId] " +
                        $"FROM [dbo].[PersonalInsurance] where PersonalInsuranceId = {E.PersonalInsuranceId}";
            }
            var data = Connection.Query<PersonalInsurance>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
