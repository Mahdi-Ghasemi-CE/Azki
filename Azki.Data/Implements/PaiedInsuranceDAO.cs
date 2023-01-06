using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
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
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[PaiedInsurance] where PaiedInsuranceId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[PaiedInsurance] where PaiedInsuranceId in ({ids})";
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

        public List<PaiedInsurance> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[PaiedInsurance]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<PaiedInsurance>)res;
        }

        public PaiedInsurance findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[PaiedInsurance] where PaiedInsuranceId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (PaiedInsurance)res;
        }

        public List<PaiedInsurance> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[PaiedInsurance] where PaiedInsuranceId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<PaiedInsurance>)res;
        }

        public PaiedInsurance save(PaiedInsurance E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (E.PaiedInsuranceId == 0)
            {
                cmd.CommandText = $"INSERT INTO [dbo].[PaiedInsurance]([InsuranceType],[InsuranceId],[UserId],[Point])" +
                                   $"VALUES ({E.InsuranceType},{E.InsuranceId},{E.UserId},{E.Point})" +
                                   $"SELECT * from [dbo].[PaiedInsurance] where PaiedInsuranceId = scope_identity()";

            }
            else
            {

                cmd.CommandText = $"UPDATE [dbo].[PaiedInsurance]" +
                                    $"SET [InsuranceType] = {E.InsuranceType},[InsuranceId] = {E.InsuranceId},[UserId] = {E.UserId},[Point] = {E.Point}" +
                                    $"WHERE PaiedInsuranceId = {E.PaiedInsuranceId}" +
                                   $"SELECT * from [dbo].[PaiedInsurance] where PaiedInsuranceId = scope_identity()";
            }
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (PaiedInsurance)res;
        }
    }
}
