using Azki.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Azki.Data.Implements
{
    public class InsuranceCompanyDAO : BaseRepository, Repository<InsuranceCompany, int>
    {
        public bool deleteByID(int id)
        {
            var query = $"delete from [dbo].[InsuranceCompany] where InsuranceCompanyId = {id}";
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
                var query  = $"delete from [dbo].[InsuranceCompany] where InsuranceCompanyId in ({ids})";
                var data = Connection.Query(query, null, commandType: CommandType.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<InsuranceCompany> findAll()
        {
            var query = "SELECT [InsuranceCompanyId],[Name] FROM[dbo].[InsuranceCompany]";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<InsuranceCompany>().ToList();
        }

        public InsuranceCompany findById(int id)
        {
            var query = $"select * from [dbo].[InsuranceCompany] where InsuranceCompanyId = {id}";
            var data = Connection.Query<InsuranceCompany>(query);
            return data.SingleOrDefault();
        }

        public List<InsuranceCompany> findByIDs(List<int> ids)
        {
            var query = $"select * from [dbo].[InsuranceCompany] where InsuranceCompanyId in ({ids})";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<InsuranceCompany>().ToList();
        }

        public InsuranceCompany save(InsuranceCompany E)
        {
            var query = "";
            if (E.InsuranceCompanyId == 0)
            {
                query = $"INSERT INTO [dbo].[InsuranceCompany]([Name])" +
                                   $"VALUES (N'{E.Name}')" +
                                   $"SELECT * from [dbo].[InsuranceCompany] where InsuranceCompanyId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[InsuranceCompany]" +
                                  $"SET [Name] = N'{E.Name}'" +
                                  $"WHERE InsuranceCompanyId = {E.InsuranceCompanyId}" +
                                   $"\nSELECT [InsuranceCompanyId],[Name] FROM[dbo].[InsuranceCompany] where InsuranceCompanyId = {E.InsuranceCompanyId}";
            }
            var data = Connection.Query<InsuranceCompany>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
