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
    public class WealthInsuranceDAO : BaseRepository, Repository<WealthInsurance, int>
    {
        public bool deleteByID(int id)
        {

            var query = $"delete from [dbo].[WealthInsurance] where WealthInsuranceId = {id}";
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
                var query = $"delete from [dbo].[WealthInsurance] where WealthInsuranceId in ({ids})";

                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<WealthInsurance> findAll()
        {
            var query =
                "SELECT [WealthInsuranceId],[InsuranceId]," +
                "[WealthValue],[ProvinceName],[CityName]," +
                "[WealthInsuranceTypeId],[Meterage],[BuildingAge]," +
                "[RoofNumbers],[WealthTypeId],[ValuePerMeter]" +
                " FROM [dbo].[WealthInsurance]";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);

            return data.Read<WealthInsurance>().ToList();
        }

        public WealthInsurance findById(int id)
        {
            var query =
                "SELECT [WealthInsuranceId],[InsuranceId]," +
                "[WealthValue],[ProvinceName],[CityName]," +
                "[WealthInsuranceTypeId],[Meterage],[BuildingAge]," +
                "[RoofNumbers],[WealthTypeId],[ValuePerMeter]" +
                $" FROM [dbo].[WealthInsurance] where WealthInsuranceId = {id}";

            var data = Connection.Query<WealthInsurance>(query);

            return data.SingleOrDefault();
        }

        public List<WealthInsurance> findByIDs(List<int> ids)
        {
            var query =
                "SELECT [WealthInsuranceId],[InsuranceId]," +
                "[WealthValue],[ProvinceName],[CityName]," +
                "[WealthInsuranceTypeId],[Meterage],[BuildingAge]," +
                "[RoofNumbers],[WealthTypeId],[ValuePerMeter]" +
                $" FROM [dbo].[WealthInsurance] where WealthInsuranceId in ({ids})";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);

            return data.Read<WealthInsurance>().ToList();
        }

        public WealthInsurance save(WealthInsurance E)
        {
            var query = "";
            if (E.WealthInsuranceId == 0)
            {
                query = $"INSERT INTO [dbo].[WealthInsurance]([InsuranceId],[WealthValue],[ProvinceName]," +
                    $"[CityName],[WealthInsuranceTypeId],[Meterage],[BuildingAge],[RoofNumbers],[WealthTypeId],[ValuePerMeter])" +
                                   $"VALUES({E.InsuranceId},{E.WealthValue},N'{E.ProvinceName}'" +
                                   $",N'{E.CityName}',{E.WealthInsuranceTypeId},{E.Meterage},{E.BuildingAge},{E.RoofNumbers},{E.WealthTypeId},{E.ValuePerMeter})" +
                                   $"SELECT * from [dbo].[WealthInsurance] where WealthInsuranceId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[WealthInsurance]" +
                    $"SET [InsuranceId] = {E.InsuranceId},[WealthValue] = {E.WealthValue}," +
                    $"[ProvinceName] = N'{E.ProvinceName}',[CityName] = N'{E.CityName}'," +
                    $"[WealthInsuranceTypeId] = {E.WealthInsuranceTypeId}," +
                    $"[Meterage] = {E.Meterage},[BuildingAge] = {E.BuildingAge}," +
                    $"[RoofNumbers] = {E.RoofNumbers},[WealthTypeId] = {E.WealthTypeId}," +
                    $"[ValuePerMeter] = {E.ValuePerMeter}" +
                    $"WHERE WealthInsuranceId = {E.WealthInsuranceId}" +
                    "SELECT [WealthInsuranceId],[InsuranceId]," +
                    "[WealthValue],[ProvinceName],[CityName]," +
                    "[WealthInsuranceTypeId],[Meterage],[BuildingAge]," +
                    "[RoofNumbers],[WealthTypeId],[ValuePerMeter]" +
                    $" FROM [dbo].[WealthInsurance] where WealthInsuranceId = {E.WealthInsuranceId}";
            }

            var data = Connection.Query<WealthInsurance>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
