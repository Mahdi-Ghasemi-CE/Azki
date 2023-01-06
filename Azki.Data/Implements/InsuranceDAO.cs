using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class InsuranceDAO : BaseRepository, Repository<Insurance, int>
    {

        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[Insurance] where InsuranceId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[Insurance] where InsuranceId in ({ids})";
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

        public List<Insurance> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[Insurance]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<Insurance>)res;
        }

        public Insurance findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[Insurance] where InsuranceId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (Insurance)res;
        }

        public List<Insurance> findByIDs(List<int> ids)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[Insurance] where InsuranceId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<Insurance>)res;
        }

        public Insurance save(Insurance E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (E.InsuranceCompanyId == 0)
            {
                cmd.CommandText = $"INSERT INTO [dbo].[Insurance]([OfferName],[ContractTime],[Price],[InsuranceCompanyId],[DiscountPercent])" +
                               $"VALUES({E.OfferName},{E.ContractTime},{E.Price},{E.InsuranceCompanyId},{E.DiscountPercent})" +
                               $"SELECT * from [dbo].[Insurance] where InsuranceId = scope_identity()";
            }
            else
            {
                cmd.CommandText = $"UPDATE [dbo].[Insurance]" +
                                    $"SET [OfferName] = {E.OfferName} ,[ContractTime] = {E.ContractTime},[Price] = {E.Price},[InsuranceCompanyId] = {E.InsuranceCompanyId},[DiscountPercent] = {E.DiscountPercent}" +
                                    $"WHERE InsuranceId = {E.InsuranceId}" +
                                $"SELECT * from [dbo].[Insurance] where InsuranceId = scope_identity()";
            }
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (Insurance)res;
        }
    }
}
