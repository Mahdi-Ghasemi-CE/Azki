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
    public class SicknessCoverageTypesDAO : BaseRepository, Repository<SicknessCoverageType, int>
    {
        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[SicknessCoverageType] where SicknessCoverageTypeId = {id}";
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
                var query = $"delete from [dbo].[SicknessCoverageType] where SicknessCoverageTypeId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<SicknessCoverageType> findAll()
        {
            var query = "SELECT [SicknessCoverageTypesId]" +
                ",[Title]" +
                "FROM [dbo].[SicknessCoverageTypes]";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<SicknessCoverageType>().ToList();
        }

        public SicknessCoverageType findById(int id)
        {
            var query = "SELECT [SicknessCoverageTypesId]" +
                        ",[Title]" +
                        $"FROM [dbo].[SicknessCoverageTypes] where InsuranceCompanyId = {id}";
            var data = Connection.Query<SicknessCoverageType>(query);
            return data.SingleOrDefault();
        }

        public List<SicknessCoverageType> findByIDs(List<int> ids)
        {
            var query = "SELECT [SicknessCoverageTypesId]" +
                                    ",[Title]" +
                                    $"FROM [dbo].[SicknessCoverageTypes] where SicknessCoverageTypeId in ({ids})";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<SicknessCoverageType>().ToList();
        }

        public SicknessCoverageType save(SicknessCoverageType E)
        {
            var query = "";
            if (true)
            {
                query = $"INSERT INTO [dbo].[SicknessCoverageTypes]([Title])" +
                                   $"VALUES (N'{E.Title})'" +
                                   $"SELECT * from [dbo].[SicknessCoverageType] where SicknessCoverageTypeId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[SicknessCoverageTypes]" +
                                    $"SET [Title] = N'{E.Title}'" +
                                    $"WHERE SicknessCoverageTypesId = {E.SicknessCoverageTypesId}" +
                                    "SELECT [SicknessCoverageTypesId]" +
                                    ",[Title]" +
                                    $"FROM [dbo].[SicknessCoverageTypes] where SicknessCoverageTypeId = {E.SicknessCoverageTypesId}";
            }
            var data = Connection.Query<SicknessCoverageType>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
