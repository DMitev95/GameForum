using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GamerForumWeb.Db.Data.Common.DataValidationConstants.Category;

namespace GamerForumWeb.Db.Data.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxCategoryNameLenght)]
        public string Name { get; set; }

        public List<Game> GamesCategories { get; set; } = new List<Game>();


    }
}
