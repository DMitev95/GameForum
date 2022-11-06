using GamerForumWeb.Core.Models.Categories;

namespace GamerForumWeb.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryQueryModel>> GetAllCategory();
    }
}
