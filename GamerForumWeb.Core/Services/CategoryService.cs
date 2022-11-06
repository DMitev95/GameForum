using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Models.Categories;
using GamerForumWeb.Db.Data.Entities;
using GamerForumWeb.Db.Repository;
using Microsoft.EntityFrameworkCore;

namespace GamerForumWeb.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;
        public CategoryService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<IEnumerable<CategoryQueryModel>> GetAllCategory()
        {
            return await repo.AllReadonly<Category>().Select(c => new CategoryQueryModel()
            {
                Id = c.Id,
                Name = c.Name,

            }).ToListAsync();
        }
    }
}
