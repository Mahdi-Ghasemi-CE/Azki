using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class WealthInsuranceDAO:BaseRepository,Repository<WealthInsurance,int>
    {
        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[WealthInsurance] where WealthInsuranceId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[WealthInsurance] where WealthInsuranceId in ({ids})";
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

        public List<WealthInsurance> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[WealthInsurance]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<WealthInsurance>)res;
        }

        public WealthInsurance findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[WealthInsurance] where WealthInsuranceId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (WealthInsurance)res;
        }

        public List<WealthInsurance> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[WealthInsurance] where WealthInsuranceId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<WealthInsurance>)res;
        }

        public WealthInsurance save(WealthInsurance E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"INSERT INTO [dbo].[WealthInsurance]([InsuranceId],[WealthValue],[ProvinceName]," +
                $"[CityName],[WealthInsuranceTypeId],[Meterage],[BuildingAge],[RoofNumbers],[WealthTypeId],[ValuePerMeter])" +
                               $"VALUES(<{E.InsuranceId}>,<{E.WealthValue}>,<{E.ProvinceName}>" +
                               $",<{E.CityName}>,<{E.WealthInsuranceTypeId}>,<{E.Meterage}>,<{E.BuildingAge}>,<{E.RoofNumbers}>,<{E.WealthTypeId}>,<{E.ValuePerMeter}>)" +
                               $"SELECT * from [dbo].[WealthInsurance] where WealthInsuranceId = scope_identity()";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (WealthInsurance)res;
        }
    }
}
