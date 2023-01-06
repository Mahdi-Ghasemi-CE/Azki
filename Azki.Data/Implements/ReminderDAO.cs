using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class ReminderDAO:BaseRepository,Repository<Reminder,int>
    {
        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[Reminder] where ReminderId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            cmd.ExecuteNonQuery();
            Connection.Close();

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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = $"delete from [dbo].[Reminder] where ReminderId in ({ids})";
                cmd.Connection = Connection;
                Connection.Open();
                cmd.ExecuteNonQuery();
                Connection.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<Reminder> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[Reminder]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<Reminder>)res;
        }

        public Reminder findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[Reminder] where ReminderId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (Reminder)res;
        }

        public List<Reminder> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[Reminder] where ReminderId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<Reminder>)res;
        }

        public Reminder save(Reminder E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"INSERT INTO [dbo].[Reminder]([UserId],[InsuranceId],[Date])" +
                               $"VALUES (<{E.UserId}>,<{E.InsuranceId}>,<{E.Date}>)" +
                               $"SELECT * from [dbo].[Reminder] where ReminderId = scope_identity()";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (Reminder)res;
        }
    }
}
