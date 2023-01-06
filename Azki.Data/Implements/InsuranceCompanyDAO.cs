using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class InsuranceCompanyDAO : BaseRepository, Repository<InsuranceCompany, int>
    {
        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[InsuranceCompany] where InsuranceCompanyId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[InsuranceCompany] where InsuranceCompanyId in ({ids})";
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

        public List<InsuranceCompany> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[InsuranceCompany]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<InsuranceCompany>)res;

        }

        public InsuranceCompany findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[InsuranceCompany] where InsuranceCompanyId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (InsuranceCompany)res;

        }

        public List<InsuranceCompany> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[InsuranceCompany] where InsuranceCompanyId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<InsuranceCompany>)res;

        }

        public InsuranceCompany save(InsuranceCompany E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (E.InsuranceCompanyId == 0)
            {
                cmd.CommandText = $"INSERT INTO [dbo].[InsuranceCompany]([Name])" +
                                   $"VALUES ({E.Name})" +
                                   $"SELECT * from [dbo].[InsuranceCompany] where InsuranceCompanyId = scope_identity()";
            }
            else
            {
                cmd.CommandText = $"UPDATE [dbo].[InsuranceCompany]" +
                                  $"SET [Name] = {E.Name}" +
                                  $"WHERE InsuranceCompanyId = {E.InsuranceCompanyId}" +
                                   $"SELECT * from [dbo].[InsuranceCompany] where InsuranceCompanyId = scope_identity()";

            }
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (InsuranceCompany)res;
        }
    }
}
