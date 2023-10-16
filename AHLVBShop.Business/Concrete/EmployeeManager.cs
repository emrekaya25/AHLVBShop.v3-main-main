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
    public class EmployeeManager : IEmployeeService
    {
        private readonly IUnitOfWork _uow;
        public EmployeeManager(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<Employee> AddAsync(Employee Entity)
        {
            await _uow.EmployeeRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync(Expression<Func<Employee, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.EmployeeRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Employee> GetAsync(Expression<Func<Employee, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.EmployeeRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Employee Entity)
        {
            await _uow.EmployeeRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Employee Entity)
        {
            await _uow.EmployeeRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
