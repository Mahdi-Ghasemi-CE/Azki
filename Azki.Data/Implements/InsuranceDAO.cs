using Azki.Data.Interfaces;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
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
            var query = $"delete from [dbo].[Insurance] where InsuranceId = {id}";
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
                var query = $"delete from [dbo].[Insurance] where InsuranceId in ({ids})";

                var data = Connection.Query(query, null, commandType: CommandType.Text);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Insurance> findAll()
        {
            var query = "SELECT [InsuranceId],[OfferName],[ContractTime] ,[Price] " +
                ",[InsuranceCompanyId],[DiscountPercent]FROM [dbo].[Insurance]";
            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);
            return data.Read<Insurance>().ToList();
        }

        public Insurance findById(int id)
        {

            var query = $"SELECT [InsuranceId],[OfferName],[ContractTime] ,[Price] " +
                $",[InsuranceCompanyId],[DiscountPercent]FROM [dbo].[Insurance] where InsuranceId = {id}";

            var data = Connection.Query<Insurance>(query);

            return data.SingleOrDefault();
        }

        public List<Insurance> findByIDs(List<int> ids)
        {
            var query = $"SELECT [InsuranceId],[OfferName],[ContractTime] ,[Price] " +
                  $",[InsuranceCompanyId],[DiscountPercent]FROM [dbo].[Insurance] where InsuranceId in ({ids})";

            var data = Connection.QueryMultiple(query, null, commandType: CommandType.Text);

            return data.Read<Insurance>().ToList();
        }

        public Insurance save(Insurance E)
        {
            var query = "";
            if (E.InsuranceCompanyId == 0)
            {
                query = $"INSERT INTO [dbo].[Insurance]([OfferName],[ContractTime],[Price],[InsuranceCompanyId],[DiscountPercent])" +
                               $"VALUES(N'{E.OfferName}',{E.ContractTime},{E.Price},{E.InsuranceCompanyId},{E.DiscountPercent})" +
                               $"SELECT * from [dbo].[Insurance] where InsuranceId = scope_identity()";
            }
            else
            {
                query = $"UPDATE [dbo].[Insurance]" +
                                    $"SET [OfferName] = N'{E.OfferName}' ,[ContractTime] = {E.ContractTime},[Price] = {E.Price},[InsuranceCompanyId] = {E.InsuranceCompanyId},[DiscountPercent] = {E.DiscountPercent}" +
                                    $"WHERE InsuranceId = {E.InsuranceId}" +
                                $"SELECT * from [dbo].[Insurance] where InsuranceId = scope_identity()";
            }
            var data = Connection.Query<Insurance>(query, null, commandType: CommandType.Text);
            return data.SingleOrDefault();
        }
    }
}
