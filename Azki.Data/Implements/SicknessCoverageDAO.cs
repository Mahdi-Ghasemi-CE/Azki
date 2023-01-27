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
    public class SicknessCoverageDAO:BaseRepository , Repository<SicknessCoverage,int>
    {

        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[SicknessCoverage] where SicknessCoverageId = {id}";
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
                var query = $"delete from [dbo].[SicknessCoverage] where SicknessCoverageId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<SicknessCoverage> findAll()
        {
            var query = "SELECT [SicknessCoverageId]" +
                ",[SicknessCoverageTypesId]" +
                ",[Price]" +
                ",[SupplementaryHealthInsuranceId]" +
                "FROM [dbo].[SicknessCoverage]";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);

            return data.Read<SicknessCoverage>().ToList();
        }

        public SicknessCoverage findById(int id)
        {
            var query = "SELECT [SicknessCoverageId]" +
                ",[SicknessCoverageTypesId]" +
                ",[Price]" +
                ",[SupplementaryHealthInsuranceId]" +
                $"FROM [dbo].[SicknessCoverage] where InsuranceCompanyId = {id}";
            var data = Connection.Query<SicknessCoverage>(query);
            return data.SingleOrDefault();
        }

        public List<SicknessCoverage> findByIDs(List<int> ids)
        {
            var query = "SELECT [SicknessCoverageId]" +
                ",[SicknessCoverageTypesId]" +
                ",[Price]" +
                ",[SupplementaryHealthInsuranceId]" +
                $"FROM [dbo].[SicknessCoverage] where SicknessCoverageId in ({ids})";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<SicknessCoverage>().ToList();
        }

        public SicknessCoverage save(SicknessCoverage E)
        {
            var query = "";
            if (E.SicknessCoverageId == 0)
            {
                query = $"INSERT INTO [dbo].[SicknessCoverage]([SicknessCoverageTypesId],[Price],[SupplementaryHealthInsuranceId])" +
                                   $"VALUES ({E.SicknessCoverageTypesId},{E.Price},{E.SupplementaryHealthInsuranceId})" +
                                   $"SELECT * from [dbo].[SicknessCoverage] where SicknessCoverageId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[SicknessCoverage]" +
                    $"SET [SicknessCoverageTypesId] = {E.SicknessCoverageTypesId}," +
                    $"[Price] = {E.Price},[SupplementaryHealthInsuranceId] = {E.SupplementaryHealthInsuranceId}" +
                    $"WHERE SicknessCoverageId = {E.SicknessCoverageId}" +
                    "SELECT [SicknessCoverageId]" +
                    ",[SicknessCoverageTypesId]" +
                    ",[Price]" +
                    ",[SupplementaryHealthInsuranceId]" +
                    $"FROM [dbo].[SicknessCoverage] where InsuranceCompanyId = {E.SicknessCoverageId}";
            }
            var data = Connection.Query<SicknessCoverage>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
