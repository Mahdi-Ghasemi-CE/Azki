using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    internal class SicknessCoverageDAO:BaseRepository , Repository<SicknessCoverage,int>
    {

        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[SicknessCoverage] where SicknessCoverageId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[SicknessCoverage] where SicknessCoverageId in ({ids})";
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

        public List<SicknessCoverage> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[SicknessCoverage]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<SicknessCoverage>)res;
        }

        public SicknessCoverage findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[SicknessCoverage] where SicknessCoverageId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (SicknessCoverage)res;
        }

        public List<SicknessCoverage> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[SicknessCoverage] where SicknessCoverageId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<SicknessCoverage>)res;
        }

        public SicknessCoverage save(SicknessCoverage E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (E.SicknessCoverageId == 0)
            {
                cmd.CommandText = $"INSERT INTO [dbo].[SicknessCoverage]([SicknessCoverageTypesId],[Price],[SupplementaryHealthInsuranceId])" +
                                   $"VALUES ({E.SicknessCoverageTypesId},{E.Price},{E.SupplementaryHealthInsuranceId})" +
                                   $"SELECT * from [dbo].[SicknessCoverage] where SicknessCoverageId = scope_identity()";

            }
            else
            {
                cmd.CommandText = $"UPDATE [dbo].[SicknessCoverage]" +
                    $"SET [SicknessCoverageTypesId] = {E.SicknessCoverageTypesId},[Price] = {E.Price},[SupplementaryHealthInsuranceId] = {E.SupplementaryHealthInsuranceId}" +
                    $"WHERE SicknessCoverageId = {E.SicknessCoverageId}" +
                                   $"SELECT * from [dbo].[SicknessCoverage] where SicknessCoverageId = scope_identity()";

            }
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (SicknessCoverage)res;
        }
    }
}
