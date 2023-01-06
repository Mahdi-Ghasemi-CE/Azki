using Azki.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Implements
{
    public class UsersDAO:BaseRepository,Repository<User,int>
    {
        public bool deleteByID(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"delete from [dbo].[User] where UserId = {id}";
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
                cmd.CommandText = $"delete from [dbo].[User] where UserId in ({ids})";
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

        public List<User> findAll()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from [dbo].[User]";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<User>)res;
        }

        public User findById(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[User] where UserId = {id}";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (User)res;
        }

        public List<User> findByIDs(List<int> ids)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = $"select * from [dbo].[User] where UserId in ({ids})";
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();
            return (List<User>)res;
        }

        public User save(User E)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (E.UserId == 0)
            {

            cmd.CommandText = $"INSERT INTO [dbo].[Users]([Name],[Family],[UserName],[Password],[NationalCode]," +
                              $"[CreateDate],[InvitationCode],[InvitationCodeUsageNumber])" +
                               $"VALUES({E.Name},{E.Family},{E.UserName},{E.Password},{E.NationalCode}," +
                               $"{E.CreateDate},{E.InvitationCode},{E.InvitationCodeUsageNumber})" +
                               $"SELECT * from [dbo].[User] where UserId = scope_identity()";
            }
            else
            {
                    
            cmd.CommandText = $"UPDATE [dbo].[Users]" +
                    $"SET [Name] = {E.Name},[Family] = {E.Family}" +
                    $",[UserName] = {E.UserName},[Password] = {E.Password}" +
                    $",[NationalCode] = {E.NationalCode},[CreateDate] = {E.CreateDate}" +
                    $",[InvitationCode] = {E.InvitationCode}" +
                    $",[InvitationCodeUsageNumber] = {E.InvitationCodeUsageNumber}" +
                    $"WHERE UserId = {E.UserId}" +
                               $"SELECT * from [dbo].[User] where UserId = scope_identity()";
            }
            cmd.Connection = Connection;
            Connection.Open();
            var res = cmd.ExecuteScalar();
            Connection.Close();

            return (User)res;
        }
    }
}
