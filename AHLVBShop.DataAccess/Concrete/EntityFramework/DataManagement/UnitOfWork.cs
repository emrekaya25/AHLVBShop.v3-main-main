using AHLVBShop.DataAccess.Abstract.DataManagement;
using AHLVBShop.DataAccess.Abstract;
using AHLVBShop.Entity.Base;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AHLVBShop.DataAccess.Concrete.EntityFramework.Context;

namespace AHLVBShop.DataAccess.Concrete.EntityFramework.DataManagement
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VBContext _VBContext;
        public UnitOfWork(VBContext VBContext)
        {
            _VBContext = VBContext;

            BrandRepository = new BrandRepository(_VBContext);
            CategoryRepository = new CategoryRepository(_VBContext);
            CompanyRepository = new CompanyRepository(_VBContext);
            DepartmentRepository = new DepartmentRepository(_VBContext);
            EmployeeRepository = new EmployeeRepository(_VBContext);
            OfferRepository = new OfferRepository(_VBContext);
            ProductRepository = new ProductRepository(_VBContext);
            RequestRepository = new RequestRepository(_VBContext);
            RoleRepository = new RoleRepository(_VBContext);
            UserRepository = new UserRepository(_VBContext);

        }

        public IBrandRepository BrandRepository { get;  }
        public ICategoryRepository CategoryRepository { get; }
        public ICompanyRepository CompanyRepository { get;  }
        public IDepartmentRepository DepartmentRepository { get;  }
        public IEmployeeRepository  EmployeeRepository { get;  }
        public IOfferRepository OfferRepository { get;  }
        public IProductRepository ProductRepository { get;  }
        public IRequestRepository RequestRepository { get; }
        public IRoleRepository RoleRepository { get; }
        public IUserRepository UserRepository { get; }


        public async Task<int> SaveChangeAsync()
        {
            foreach (EntityEntry<BaseEntity> item in _VBContext.ChangeTracker.Entries<BaseEntity>())
            {
                if (item.State == Microsoft.EntityFrameworkCore.EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.Id = Guid.NewGuid();

                    if (item.Entity.IsActive == null)
                    {
                        item.Entity.IsActive = true;
                    }
                    item.Entity.IsDeleted = false;
                }

                else if (item.State == Microsoft.EntityFrameworkCore.EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                }
            }
            return await _VBContext.SaveChangesAsync();
        }
    }
}
