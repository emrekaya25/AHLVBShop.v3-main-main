using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.DataAccess.Abstract.DataManagement
{
    public interface IUnitOfWork
    {
        IBrandRepository BrandRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICompanyRepository CompanyRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IOfferRepository OfferRepository { get; }
        IProductRepository ProductRepository { get; }
        IRequestRepository RequestRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
