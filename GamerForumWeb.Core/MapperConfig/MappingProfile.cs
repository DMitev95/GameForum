using AutoMapper;
using GamerForumWeb.Core.Models.Categories;
using GamerForumWeb.Core.Models.Comment;
using GamerForumWeb.Core.Models.Game;
using GamerForumWeb.Core.Models.Post;
using GamerForumWeb.Core.Models.Users;
using GamerForumWeb.Db.Data.Entities;

namespace GamerForumWeb.Core.MapperConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            //Game Mapping
            this.CreateMap<Game, GamesQueryModel>();
            this.CreateMap<GameModel, Game>();
            this.CreateMap<Game, GameModel>();

            //Category Mapping
            this.CreateMap<Category, CategoryQueryModel>();

            //Comment Mapping
            this.CreateMap<CommentModel, PostComment>();
            this.CreateMap<PostComment, CommentModel>();
            this.CreateMap<PostComment, CommentQueryModel>();

            //Post Mapping
            this.CreateMap<Post, PostQueryModel>().ForMember(p => p.PostId, opt => opt.MapFrom(src => src.Id));
            this.CreateMap<PostModel, Post>().ForMember(p => p.UserId, opt => opt.MapFrom(src => src.UserId));

            //User Mapping
            this.CreateMap<User, UserEditModel>();
            this.CreateMap<User, UserQueryModel>();
            
        }
    }
}
