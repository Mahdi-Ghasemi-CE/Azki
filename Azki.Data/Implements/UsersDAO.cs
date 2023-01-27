using Azki.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Azki.Data.Implements
{
    public class UsersDAO : BaseRepository, Repository<User, int>
    {
        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[Users] where UserId = {id}";
            var data = Connection.Query(query, null, commandType: CommandType.Text);

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
                var query = $"delete from [dbo].[Users] where UserId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<User> findAll()
        {
            var query = "SELECT [UserId]" +
                        ",[Name]," +
                        "[Family]," +
                        "[UserName]," +
                        "[Password]," +
                        "[NationalCode]," +
                        "[InvitationCode]," +
                        "[InvitationCodeUsageNumber]" +
                        "FROM [dbo].[Users]";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<User>().ToList();
        }

        public User findById(int id)
        {

            var query = "SELECT [UserId]" +
                 ",[Name]," +
                 "[Family]," +
                 "[UserName]," +
                 "[Password]," +
                 "[NationalCode]," +
                 "[InvitationCode]," +
                 "[InvitationCodeUsageNumber]" +
                 $"FROM [dbo].[Users]  where UserId = {id}";

            var data = Connection.Query<User>(query);

            return data.SingleOrDefault();
        }

        public List<User> findByIDs(List<int> ids)
        {
            var query = "SELECT [UserId]" +
             ",[Name]," +
             "[Family]," +
             "[UserName]," +
             "[Password]," +
             "[NationalCode]," +
             "[InvitationCode]," +
             "[InvitationCodeUsageNumber]" +
             $"FROM [dbo].[Users]  where UserId = {ids}";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);

            return data.Read<User>().ToList();
        }

        public User save(User E)
        {
            var query = "";
            if (E.UserId == 0)
            {
                query = $"INSERT INTO [dbo].[Users]([Name],[Family],[UserName],[Password],[NationalCode]," +
                                  $"[InvitationCode],[InvitationCodeUsageNumber])" +
                                   $"VALUES(N'{E.Name}',N'{E.Family}',N'{E.UserName}',N'{E.Password}',N'{E.NationalCode}'," +
                                   $"N'{E.InvitationCode}',{E.InvitationCodeUsageNumber})" +
                                   $"SELECT * from [dbo].[Users] where UserId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[Users]" +
                        $"SET [Name] = N'{E.Name}',[Family] = N'{E.Family}'" +
                        $",[UserName] = N'{E.UserName}',[Password] = N'{E.Password}'" +
                        $",[NationalCode] = N'{E.NationalCode}'" +
                        $",[InvitationCode] = N'{E.InvitationCode}'" +
                        $",[InvitationCodeUsageNumber] = {E.InvitationCodeUsageNumber}" +
                        $"WHERE UserId = {E.UserId}" +
                        $"SELECT [UserId]" +
                        ",[Name]," +
                        "[Family]," +
                        "[UserName]," +
                        "[Password]," +
                        "[NationalCode]," +
                        "[InvitationCode]," +
                        "[InvitationCodeUsageNumber]  " +
                        $"from [dbo].[Users] where UserId = {E.UserId}";
            }
            var data = Connection.Query<User>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
