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
    public class PaiedInsuranceDAO : BaseRepository, Repository<PaiedInsurance, int>
    {
        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[PaiedInsurance] where PaiedInsuranceId = {id}";
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
                var query = $"delete from [dbo].[PaiedInsurance] where PaiedInsuranceId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<PaiedInsurance> findAll()
        {
            var query = "SELECT [PaiedInsuranceId]" +
                ",[InsuranceType]" +
                ",[InsuranceId]" +
                ",[UserId]" +
                ",[Point]" +
                "FROM [dbo].[PaiedInsurance]";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<PaiedInsurance>().ToList();
        }

        public PaiedInsurance findById(int id)
        {
            var query = "SELECT [PaiedInsuranceId]" +
                            ",[InsuranceType]" +
                            ",[InsuranceId]" +
                            ",[UserId]" +
                            ",[Point]" +
                            $"FROM [dbo].[PaiedInsurance]  where PaiedInsuranceId = {id}";
            var data = Connection.Query<PaiedInsurance>(query);
            return data.SingleOrDefault();
        }

        public List<PaiedInsurance> findByIDs(List<int> ids)
        {
            var query = "SELECT [PaiedInsuranceId]" +
                ",[InsuranceType]" +
                ",[InsuranceId]" +
                ",[UserId]" +
                ",[Point]" +
                "FROM [dbo].[PaiedInsurance]  where PaiedInsuranceId in ({ids})";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<PaiedInsurance>().ToList();
        }

        public PaiedInsurance save(PaiedInsurance E)
        {
            var query = "";
            if (E.PaiedInsuranceId == 0)
            {
                query = $"INSERT INTO [dbo].[PaiedInsurance]([InsuranceType],[InsuranceId],[UserId],[Point])" +
                                   $"VALUES ({E.InsuranceType},{E.InsuranceId},{E.UserId},{E.Point})" +
                                   $"SELECT * from [dbo].[PaiedInsurance] where PaiedInsuranceId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[PaiedInsurance]" +
                                    $"SET [InsuranceType] = {E.InsuranceType},[InsuranceId] = {E.InsuranceId},[UserId] = {E.UserId},[Point] = {E.Point}" +
                                    $"WHERE PaiedInsuranceId = {E.PaiedInsuranceId}" +
                                    "SELECT [PaiedInsuranceId]" +
                                    ",[InsuranceType]" +
                                    ",[InsuranceId]" +
                                    ",[UserId]" +
                                    ",[Point]" +
                                    $"FROM [dbo].[PaiedInsurance]  where PaiedInsuranceId = {E.PaiedInsuranceId}";
            }
            var data = Connection.Query<PaiedInsurance>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
