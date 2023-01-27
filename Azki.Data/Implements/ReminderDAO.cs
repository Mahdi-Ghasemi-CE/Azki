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
    public class ReminderDAO : BaseRepository, Repository<Reminder, int>
    {
        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[Reminder] where ReminderId = {id}";
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
                var query = $"delete from [dbo].[Reminder] where ReminderId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Reminder> findAll()
        {
            var query = "SELECT [ReminderId]" +
                ",[UserId]" +
                ",[InsuranceId]" +
                ",[Date]" +
                "FROM [dbo].[Reminder]";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<Reminder>().ToList();
        }

        public Reminder findById(int id)
        {
            var query = "SELECT [ReminderId]" +
                ",[UserId]" +
                ",[InsuranceId]" +
                ",[Date]" +
                $"FROM [dbo].[Reminder] where ReminderId = {id}";
            var data = Connection.Query<Reminder>(query);
            return data.SingleOrDefault();
        }

        public List<Reminder> findByIDs(List<int> ids)
        {
            var query = "SELECT [ReminderId]" +
                ",[UserId]" +
                ",[InsuranceId]" +
                ",[Date]" +
                $"FROM [dbo].[Reminder] where InsuranceCompanyId in ({ids})";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<Reminder>().ToList();
        }

        public Reminder save(Reminder E)
        {
            var query = "";
            if (E.ReminderId == 0)
            {
                query = $"INSERT INTO [dbo].[Reminder]([UserId],[InsuranceId],[Date])" +
                                   $"VALUES ({E.UserId},{E.InsuranceId},{E.Date})" +
                                   $"SELECT * from [dbo].[Reminder] where ReminderId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[Reminder]" +
                                    $"SET [UserId] = {E.UserId},[InsuranceId] = {E.InsuranceId}" +
                                    $",[Date] = {E.Date}" +
                                    $"WHERE ReminderId = {E.ReminderId}" +
                                    "SELECT [ReminderId]" +
                                    ",[UserId]" +
                                    ",[InsuranceId]" +
                                    ",[Date]" +
                                    $"FROM [dbo].[Reminder] where ReminderId = {E.ReminderId}";
            }
            var data = Connection.Query<Reminder>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
