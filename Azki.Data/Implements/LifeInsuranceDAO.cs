using Azki.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Azki.Data.Implements
{
    public class LifeInsuranceDAO : BaseRepository, Repository<LifeInsurance, int>
    {
        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[LifeInsurance] where LifeInsuranceId = {id}";
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
                var query = $"delete from [dbo].[LifeInsurance] where LifeInsuranceId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<LifeInsurance> findAll()
        {
            var query = "SELECT [LifeInsuranceId]" +
                ",[RedemptionValue]" +
                ",[AbilityToPay]" +
                ",[MedicalExpenses]" +
                ",[DeathCapital]" +
                ",[PersonalInsuranceId]" +
                "FROM [dbo].[LifeInsurance]";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<LifeInsurance>().ToList();
        }

        public LifeInsurance findById(int id)
        {
            var query = "SELECT [LifeInsuranceId]" +
                ",[RedemptionValue]" +
                ",[AbilityToPay]" +
                ",[MedicalExpenses]" +
                ",[DeathCapital]" +
                ",[PersonalInsuranceId]" +
                "FROM [dbo].[LifeInsurance]";
            var data = Connection.Query<LifeInsurance>(query);

            return data.SingleOrDefault();
        }

        public List<LifeInsurance> findByIDs(List<int> ids)
        {

            var query = "SELECT [LifeInsuranceId]" +
                   ",[RedemptionValue]" +
                   ",[AbilityToPay]" +
                   ",[MedicalExpenses]" +
                   ",[DeathCapital]" +
                   ",[PersonalInsuranceId]" +
                   $"FROM [dbo].[LifeInsurance] where LifeInsuranceId in ({ids})";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);

            return data.Read<LifeInsurance>().ToList();
        }

        public LifeInsurance save(LifeInsurance E)
        {
            var query = "";
            if (E.LifeInsuranceId == 0)
            {
                query = $"INSERT INTO [dbo].[LifeInsurance]([RedemptionValue],[AbilityToPay],[MedicalExpenses],[DeathCapital],[PersonalInsuranceId])" +
                                   $"VALUES (<{E.RedemptionValue}>,<{E.AbilityToPay}>,<{E.MedicalExpenses}>,<{E.DeathCapital}>,<{E.PersonalInsuranceId}>)" +
                                   $"SELECT * from [dbo].[LifeInsurance] where LifeInsuranceId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[LifeInsurance]" +
                                   $"SET [RedemptionValue] = {E.RedemptionValue}," +
                                   $"[AbilityToPay] = {E.AbilityToPay}," +
                                   $"[MedicalExpenses] = {E.MedicalExpenses}" +
                                   $",[DeathCapital] = {E.DeathCapital}" +
                                   $",[PersonalInsuranceId] = {E.PersonalInsuranceId}" +
                                   $"WHERE LifeInsuranceId = {E.LifeInsuranceId}" +
                                    "SELECT [LifeInsuranceId]" +
                                    ",[RedemptionValue]" +
                                    ",[AbilityToPay]" +
                                    ",[MedicalExpenses]" +
                                    ",[DeathCapital]" +
                                    ",[PersonalInsuranceId]" +
                                    $"FROM [dbo].[LifeInsurance] where LifeInsuranceId = {E.LifeInsuranceId}";
            }
            var data = Connection.Query<LifeInsurance>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
