using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
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
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId in ({ids})";
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

        public List<SupplementaryHealthInsurance> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[SupplementaryHealthInsurance]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<SupplementaryHealthInsurance>)res;
        }

        public SupplementaryHealthInsurance findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (SupplementaryHealthInsurance)res;
        }

        public List<SupplementaryHealthInsurance> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<SupplementaryHealthInsurance>)res;
        }

        public SupplementaryHealthInsurance save(SupplementaryHealthInsurance E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"INSERT INTO [dbo].[SupplementaryHealthInsurance]([TypeId],[PersonalInsuranceId])" +
                               $"VALUES (<{E.TypeId}>,<{E.PersonalInsuranceId}>)" +
                               $"SELECT * from [dbo].[SupplementaryHealthInsurance] where SupplementaryHealthInsuranceId = scope_identity()";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (SupplementaryHealthInsurance)res;
        }
    }
}
