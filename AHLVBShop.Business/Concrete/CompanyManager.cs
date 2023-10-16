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
    public class CompanyManager : ICompanyService
    {
        private readonly IUnitOfWork _uow;
        public CompanyManager(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<Company> AddAsync(Company Entity)
        {
            await _uow.CompanyRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Company>> GetAllAsync(Expression<Func<Company, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.CompanyRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Company> GetAsync(Expression<Func<Company, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.CompanyRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Company Entity)
        {
            await _uow.CompanyRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
        }

        public async Task UpdateAsync(Company Entity)
        {
            await _uow.CompanyRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
