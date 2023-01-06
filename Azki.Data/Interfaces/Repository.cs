using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azki.Data.Interfaces
{
    public interface Repository<TEntity, TId>
    {
        TEntity findById(TId id);
        List<TEntity> findByIDs(List<TId> ids);
        List<TEntity> findAll();
        bool deleteByID(TId id);
        bool DeleteByIDs(List<TId> ids);
        TEntity save(TEntity E);
    }
}
