﻿namespace GamerForumWeb.Core.Models.Game
{
    public class GamesQueryModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Studio { get; set; }

        public string Description { get; set; }

        public decimal Rating { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }
    }
}
