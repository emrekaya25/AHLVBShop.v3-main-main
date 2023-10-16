using AHLVBShop.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Business.Abstract.Generic
{
    public interface IGenericService<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> Filter, params string[] IncludeProperties);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> Filter = null, params string[] IncludeProperties);

        Task<T> AddAsync(T Entity);

        Task UpdateAsync(T Entity);

        Task RemoveAsync(T Entity);
    }
}
