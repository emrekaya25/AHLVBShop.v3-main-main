using AHLVBShop.DataAccess.Abstract;
using AHLVBShop.DataAccess.Concrete.EntityFramework.DataManagement;
using AHLVBShop.Entity.Poco;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AHLVBShop.DataAccess.Concrete.EntityFramework
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(DbContext context) : base(context)
        {
        }
    }
}
