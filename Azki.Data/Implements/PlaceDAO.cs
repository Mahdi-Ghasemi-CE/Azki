using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class PlaceDAO:BaseRepository,Repository<Place,int>
    {
        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[Place] where PlaceId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[Place] where PlaceId in ({ids})";
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

        public List<Place> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[Place]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<Place>)res;
        }

        public Place findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[Place] where PlaceId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (Place)res;
        }

        public List<Place> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[Place] where PlaceId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<Place>)res;
        }

        public Place save(Place E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"INSERT INTO [dbo].[Place]([Address],[PostalCode],[Roof],[Phone],[Plate],[Unit],[PaiedInsuranceId])" +
                               $"VALUES(<{E.Address}>,<{E.PostalCode}>,<{E.Roof}>,<{E.Phone}>,<{E.Plate}>,<{E.Unit}>,<{E.PaiedInsuranceId}>)" +
                               $"SELECT * from [dbo].[Place] where PlaceId = scope_identity()";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (Place)res;
        }
    }
}
