using Azki.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Azki.Data.Implements
{
    public class PlaceDAO : BaseRepository, Repository<Place, int>
    {
        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[Place] where PlaceId = {id}";
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
                var query = $"delete from [dbo].[Place] where PlaceId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Place> findAll()
        {
            var query = "SELECT [PlaceId]" +
                ",[Address]" +
                ",[PostalCode]" +
                ",[Roof]" +
                ",[Phone]" +
                ",[Plate]" +
                ",[Unit]" +
                ",[PaiedInsuranceId]" +
                "FROM [dbo].[Place]";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<Place>().ToList();
        }

        public Place findById(int id)
        {
            var query = "SELECT [PlaceId]" +
                 ",[Address]" +
                 ",[PostalCode]" +
                 ",[Roof]" +
                 ",[Phone]" +
                 ",[Plate]" +
                 ",[Unit]" +
                 ",[PaiedInsuranceId]" +
                 $"FROM [dbo].[Place] where PlaceId = {id}";
            var data = Connection.Query<Place>(query);
            return data.SingleOrDefault();
        }

        public List<Place> findByIDs(List<int> ids)
        {
            var query = "SELECT [PlaceId]" +
                ",[Address]" +
                ",[PostalCode]" +
                ",[Roof]" +
                ",[Phone]" +
                ",[Plate]" +
                ",[Unit]" +
                ",[PaiedInsuranceId]" +
                $"FROM [dbo].[Place] where PlaceId in ({ids})";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<Place>().ToList();
        }

        public Place save(Place E)
        {
            var query = "";
            if (E.PlaceId == 0)
            {
                query = $"INSERT INTO [dbo].[Place]([Address],[PostalCode],[Roof],[Phone],[Plate],[Unit],[PaiedInsuranceId])" +
                                   $"VALUES(N'{E.Address}',{E.PostalCode},{E.Roof},N'{E.Phone}',{E.Plate},{E.Unit},{E.PaiedInsuranceId})" +
                                   $"SELECT * from [dbo].[Place] where PlaceId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[Place]" +
                        $" SET [Address] =N'{E.Address}',[PostalCode] = {E.PostalCode}" +
                        $",[Roof] = {E.Roof},[Phone] = N'{E.Phone}',[Plate] = {E.Plate}" +
                        $",[Unit] = {E.Unit},[PaiedInsuranceId] = {E.PaiedInsuranceId}" +
                        $"WHERE PlaceId = {E.PlaceId}" + 
                        "SELECT [PlaceId]" +
                        ",[Address]" +
                        ",[PostalCode]" +
                        ",[Roof]" +
                        ",[Phone]" +
                        ",[Plate]" +
                        ",[Unit]" +
                        ",[PaiedInsuranceId]" +
                        $"FROM [dbo].[Place] where PlaceId = {E.PlaceId}";
            }
            var data = Connection.Query<Place>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}