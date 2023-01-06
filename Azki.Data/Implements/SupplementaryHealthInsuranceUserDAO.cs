using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class SupplementaryHealthInsuranceUserDAO : BaseRepository, Repository<SupplementaryHealthInsuranceUser, int>
    {
        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[SupplementaryHealthInsuranceUser] where SupplementaryHealthInsuranceUserId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[SupplementaryHealthInsuranceUser] where SupplementaryHealthInsuranceUserId in ({ids})";
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

        public List<SupplementaryHealthInsuranceUser> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[SupplementaryHealthInsuranceUser]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<SupplementaryHealthInsuranceUser>)res;
        }

        public SupplementaryHealthInsuranceUser findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[SupplementaryHealthInsuranceUser] where SupplementaryHealthInsuranceUserId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (SupplementaryHealthInsuranceUser)res;
        }

        public List<SupplementaryHealthInsuranceUser> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[SupplementaryHealthInsuranceUser] where SupplementaryHealthInsuranceUserId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<SupplementaryHealthInsuranceUser>)res;
        }

        public SupplementaryHealthInsuranceUser save(SupplementaryHealthInsuranceUser E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (E.SupplementaryHealthInsuranceUserId == 0)
            {
                cmd.CommandText = $"INSERT INTO [dbo].[SupplementaryHealthInsuranceUser]([AgeRange],[RelationshipWithSupervisor],[PaiedInsuranceId])" +
                                   $"VALUES({E.AgeRange},{E.RelationshipWithSupervisor},{E.PaiedInsuranceId})" +
                                   $"SELECT * from [dbo].[SupplementaryHealthInsuranceUser] where SupplementaryHealthInsuranceUserId = scope_identity()";
            }
            else
            {
                cmd.CommandText = $"UPDATE [dbo].[SupplementaryHealthInsuranceUser]" +
                    $"SET [AgeRange] = {E.AgeRange},[RelationshipWithSupervisor] = {E.RelationshipWithSupervisor}" +
                    $",[PaiedInsuranceId] = {E.PaiedInsuranceId}" +
                    $"WHERE SupplementaryHealthInsuranceUserId = {E.SupplementaryHealthInsuranceUserId}" +
                                    $"SELECT * from [dbo].[SupplementaryHealthInsuranceUser] where SupplementaryHealthInsuranceUserId = scope_identity()";
            }
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (SupplementaryHealthInsuranceUser)res;
        }
    }
}
