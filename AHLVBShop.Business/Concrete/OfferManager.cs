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
    public class OfferManager : IOfferService
    {
        private readonly IUnitOfWork _uow;
        public OfferManager(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<Offer> AddAsync(Offer Entity)
        {
            await _uow.OfferRepository.AddAsync(Entity);
            await _uow.SaveChangeAsync();
            return Entity;
        }

        public async Task<IEnumerable<Offer>> GetAllAsync(Expression<Func<Offer, bool>> Filter = null, params string[] IncludeProperties)
        {
            return await _uow.OfferRepository.GetAllAsync(Filter, IncludeProperties);
        }

        public async Task<Offer> GetAsync(Expression<Func<Offer, bool>> Filter, params string[] IncludeProperties)
        {
            return await _uow.OfferRepository.GetAsync(Filter, IncludeProperties);
        }

        public async Task RemoveAsync(Offer Entity)
        {
            await _uow.OfferRepository.RemoveAsync(Entity);
            await _uow.SaveChangeAsync();
            
        }

        public async Task UpdateAsync(Offer Entity)
        {
            await _uow.OfferRepository.UpdateAsync(Entity);
            await _uow.SaveChangeAsync();
        }
    }
}
