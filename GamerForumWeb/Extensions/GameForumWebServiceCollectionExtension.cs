using GamerForumWeb.Core.Contracts;
using GamerForumWeb.Core.Services;
using GamerForumWeb.Db.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class GameForumWebServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
