using Azki.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Azki.Data.Implements
{
    public class SupplementaryHealthInsuranceUserDAO : BaseRepository, Repository<SupplementaryHealthInsuranceUser, int>
    {
        public bool deleteByID(int id)
        {

            var query = $"delete from [dbo].[SupplementaryHealthInsuranceUser] where SupplementaryHealthInsuranceUserId = {id}";
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
                var query = $"delete from [dbo].[SupplementaryHealthInsuranceUser] " +
                    $"where SupplementaryHealthInsuranceUserId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<SupplementaryHealthInsuranceUser> findAll()
        {
            var query = "SELECT [SupplementaryHealthInsuranceUserId]" +
                ",[AgeRange]" +
                ",[RelationshipWithSupervisor]" +
                ",[PaiedInsuranceId]" +
                "FROM [dbo].[SupplementaryHealthInsuranceUser]";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<SupplementaryHealthInsuranceUser>().ToList();
        }

        public SupplementaryHealthInsuranceUser findById(int id)
        {
            var query = "SELECT [SupplementaryHealthInsuranceUserId]" +
                ",[AgeRange]" +
                ",[RelationshipWithSupervisor]" +
                ",[PaiedInsuranceId]" +
                "FROM [dbo].[SupplementaryHealthInsuranceUser] " +
                $"where SupplementaryHealthInsuranceUserId = {id}";
            var data = Connection.Query<SupplementaryHealthInsuranceUser>(query);
            return data.SingleOrDefault();
        }

        public List<SupplementaryHealthInsuranceUser> findByIDs(List<int> ids)
        {
            var query = "SELECT [SupplementaryHealthInsuranceUserId]" +
                ",[AgeRange]" +
                ",[RelationshipWithSupervisor]" +
                ",[PaiedInsuranceId]" +
                $"FROM [dbo].[SupplementaryHealthInsuranceUser] where SupplementaryHealthInsuranceUserId in ({ids})";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<SupplementaryHealthInsuranceUser>().ToList();
        }

        public SupplementaryHealthInsuranceUser save(SupplementaryHealthInsuranceUser E)
        {
            var query = "";
            if (E.SupplementaryHealthInsuranceUserId == 0)
            {
                query = $"INSERT INTO [dbo].[SupplementaryHealthInsuranceUser]([AgeRange],[RelationshipWithSupervisor],[PaiedInsuranceId])" +
                                   $"VALUES({E.AgeRange},{E.RelationshipWithSupervisor},{E.PaiedInsuranceId})" +
                                   $"SELECT * from [dbo].[SupplementaryHealthInsuranceUser] where SupplementaryHealthInsuranceUserId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[SupplementaryHealthInsuranceUser]" +
                    $"SET [AgeRange] = {E.AgeRange},[RelationshipWithSupervisor] = {E.RelationshipWithSupervisor}" +
                    $",[PaiedInsuranceId] = {E.PaiedInsuranceId}" +
                    $"WHERE SupplementaryHealthInsuranceUserId = {E.SupplementaryHealthInsuranceUserId}" + "SELECT [SupplementaryHealthInsuranceUserId]" +
                ",[AgeRange]" +
                ",[RelationshipWithSupervisor]" +
                ",[PaiedInsuranceId]" +
                "FROM [dbo].[SupplementaryHealthInsuranceUser] " +
                $"where SupplementaryHealthInsuranceUserId = {E.SupplementaryHealthInsuranceUserId}";
            }
            var data = Connection.Query<SupplementaryHealthInsuranceUser>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
