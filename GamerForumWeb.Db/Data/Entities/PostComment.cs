﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.PostComment;


namespace GamerForumWeb.Db.Data.Entities
{
    public class PostComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(MaxContentLenght)]
        public string Content { get; set; } = null!;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public DateTime? UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public int PostId { get; set; }

        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = null!;

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; } = null!;

        public virtual ICollection<Vote> Votes { get; set; } = new HashSet<Vote>();
    }
}
