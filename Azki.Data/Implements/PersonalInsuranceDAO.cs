using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class PersonalInsuranceDAO : BaseRepository, Repository<PersonalInsurance, int>
    {
        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[PersonalInsurance] where PersonalInsuranceId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[PersonalInsurance] where PersonalInsuranceId in ({ids})";
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

        public List<PersonalInsurance> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[PersonalInsurance]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<PersonalInsurance>)res;
        }

        public PersonalInsurance findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[PersonalInsurance] where PersonalInsuranceId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (PersonalInsurance)res;
        }

        public List<PersonalInsurance> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[PersonalInsurance] where PersonalInsuranceId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<PersonalInsurance>)res;
        }

        public PersonalInsurance save(PersonalInsurance E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (E.PersonalInsuranceId == 0)
            {
            cmd.CommandText = $"INSERT INTO [dbo].[PersonalInsurance]([IncreasePercent],[PaymentPeriodType],[InsuranceId])" +
                               $"VALUES ({E.IncreasePercent},{E.PaymentPeriodType},{E.InsuranceId})" +
                               $"SELECT * from [dbo].[PersonalInsurance] where PersonalInsuranceId = scope_identity()";
            }
            else
            {
            cmd.CommandText = $"UPDATE [dbo].[PersonalInsurance]" +
                    $"SET [IncreasePercent] = {E.IncreasePercent},[PaymentPeriodType] = {E.PaymentPeriodType},[InsuranceId] = {E.InsuranceId}" +
                    $"WHERE PersonalInsuranceId = {E.PersonalInsuranceId}" +
                               $"SELECT * from [dbo].[PersonalInsurance] where PersonalInsuranceId = scope_identity()";
            }
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (PersonalInsurance)res;
        }
    }
}
