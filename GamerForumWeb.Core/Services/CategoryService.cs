using AutoMapper.QueryableExtensions;
using AutoMapper;
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
        private readonly IMapper mapper;
        public CategoryService(IRepository _repo, IMapper _mapper)
        {
            repo = _repo;
            mapper = _mapper;
        }

        public async Task<IEnumerable<CategoryQueryModel>> GetAllCategory()
        {
            return await repo.AllReadonly<Category>()
                .ProjectTo<CategoryQueryModel>(mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
