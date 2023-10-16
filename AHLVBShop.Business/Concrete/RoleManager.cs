using AHLVBShop.Business.Abstract;
using AHLVBShop.DataAccess.Abstract.DataManagement;
using AHLVBShop.Entity.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IUnitOfWork _uow;

        public RoleManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Role> AddAsync(Role Entity)
        {
            await _uow.RoleRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Role>> GetAllAsync(Expression<Func<Role, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.RoleRepository.GetAllAsync(Filter, IncludeProperties);

        }

        public async Task<Role> GetAsync(Expression<Func<Role, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.RoleRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Role Entity)
        {
            await _uow.RoleRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();

        }

        public async Task UpdateAsync(Role Entity)
        {
            await _uow.RoleRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
