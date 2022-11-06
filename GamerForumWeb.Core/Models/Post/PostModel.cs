using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.Post;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerForumWeb.Core.Models.Post
{
    public class PostModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxTitleLenght)]
        public string Title { get; set; }

        [Required]
        [MaxLength(MaxContentLenght)]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int GameId { get; set; }

    }
}
