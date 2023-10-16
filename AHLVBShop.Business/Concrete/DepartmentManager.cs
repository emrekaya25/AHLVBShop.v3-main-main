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
    public class DepartmentManager : IDepartmentService
    {
        private readonly IUnitOfWork _uow;

        public DepartmentManager(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Department> AddAsync(Department Entity)
        {
            await _uow.DepartmentRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Department>> GetAllAsync(Expression<Func<Department, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.DepartmentRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Department> GetAsync(Expression<Func<Department, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.DepartmentRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Department Entity)
        {
            await _uow.DepartmentRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Department Entity)
        {
            await _uow.DepartmentRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
