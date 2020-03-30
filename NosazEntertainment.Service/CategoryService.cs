using Microsoft.EntityFrameworkCore;
using NosazEntertainment.Data;
using NosazEntertainment.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NosazEntertainment.Service
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task<List<Category>> GetAll();
    }
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }
        public Task<List<Category>> GetAll()
        {
            return _dbSet.ToListAsync();
        }
    }
}
