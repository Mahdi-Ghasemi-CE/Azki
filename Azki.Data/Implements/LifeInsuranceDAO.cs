using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class LifeInsuranceDAO : BaseRepository, Repository<LifeInsurance, int>
    {
        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[LifeInsurance] where LifeInsuranceId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[LifeInsurance] where LifeInsuranceId in ({ids})";
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

        public List<LifeInsurance> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[LifeInsurance]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<LifeInsurance>)res;

        }

        public LifeInsurance findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[LifeInsurance] where LifeInsuranceId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (LifeInsurance)res;
        }

        public List<LifeInsurance> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[LifeInsurance] where LifeInsuranceId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<LifeInsurance>)res;
        }

        public LifeInsurance save(LifeInsurance E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (E.LifeInsuranceId == 0)
            {

                cmd.CommandText = $"INSERT INTO [dbo].[LifeInsurance]([RedemptionValue],[AbilityToPay],[MedicalExpenses],[DeathCapital],[PersonalInsuranceId])" +
                                   $"VALUES (<{E.RedemptionValue}>,<{E.AbilityToPay}>,<{E.MedicalExpenses}>,<{E.DeathCapital}>,<{E.PersonalInsuranceId}>)" +
                                   $"SELECT * from [dbo].[LifeInsurance] where LifeInsuranceId = scope_identity()";
            }
            else
            {
                cmd.CommandText = $"UPDATE [dbo].[LifeInsurance]" +
                                   $"SET [RedemptionValue] = {E.RedemptionValue}," +
                                   $"[AbilityToPay] = {E.AbilityToPay}," +
                                   $"[MedicalExpenses] = {E.MedicalExpenses}" +
                                   $",[DeathCapital] = {E.DeathCapital}" +
                                   $",[PersonalInsuranceId] = {E.PersonalInsuranceId}" +
                                   $"WHERE LifeInsuranceId = {E.LifeInsuranceId}" +
                                     $"SELECT * from [dbo].[LifeInsurance] where LifeInsuranceId = scope_identity()";

            }

            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (LifeInsurance)res;
        }
    }
}
