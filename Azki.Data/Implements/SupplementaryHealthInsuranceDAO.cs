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
    public class SupplementaryHealthInsuranceDAO:BaseRepository,Repository<SupplementaryHealthInsurance,int>
    {

        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId = {id}";
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
                var query = $"delete from [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<SupplementaryHealthInsurance> findAll()
        {
            var query = "SELECT [SupplementaryHealthInsuranceId]" +
                ",[TypeId]" +
                ",[PersonalInsuranceId]" +
                ",[BaseInsuranceId]" +
                ",[number]" +
                "FROM [dbo].[SupplementaryHealthInsurance]";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<SupplementaryHealthInsurance>().ToList();
        }

        public SupplementaryHealthInsurance findById(int id)
        {
            var query = "SELECT [SupplementaryHealthInsuranceId]" +
                ",[TypeId]" +
                ",[PersonalInsuranceId]" +
                ",[BaseInsuranceId]" +
                ",[number]" +
                "FROM [dbo].[SupplementaryHealthInsurance]" +
                $" where InsuranceCompanyId = {id}";
            var data = Connection.Query<SupplementaryHealthInsurance>(query);
            return data.SingleOrDefault();
        }

        public List<SupplementaryHealthInsurance> findByIDs(List<int> ids)
        {


            var query = "SELECT [SupplementaryHealthInsuranceId]" +
                            ",[TypeId]" +
                            ",[PersonalInsuranceId]" +
                            ",[BaseInsuranceId]" +
                            ",[number]" +
                            $"FROM [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId in ({ids})";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<SupplementaryHealthInsurance>().ToList();
        }

        public SupplementaryHealthInsurance save(SupplementaryHealthInsurance E)
        {
            var query = "";
            if (E.SupplementaryHealthInsuranceId ==0)
            {
                query = $"INSERT INTO [dbo].[SupplementaryHealthInsurance]([TypeId],[PersonalInsuranceId],[BaseInsuranceId])" +
                               $"VALUES ({E.TypeId},{E.PersonalInsuranceId},{E.BaseInsuranceId})" +
                               $"SELECT * from [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[SupplementaryHealthInsurance]" +
                                  $"SET [TypeId] = {E.TypeId},[PersonalInsuranceId] = {E.PersonalInsuranceId},[BaseInsuranceId] = {E.BaseInsuranceId} " +
                                  $"WHERE SupplementaryHealthInsuranceId = {E.SupplementaryHealthInsuranceId}" + "SELECT [SupplementaryHealthInsuranceId]" +
                                ",[TypeId]" +
                                ",[PersonalInsuranceId]" +
                                ",[BaseInsuranceId]" +
                                ",[number]" +
                                $"FROM [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId = {E.SupplementaryHealthInsuranceId}";
            }
            var data = Connection.Query<SupplementaryHealthInsurance>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
