namespace GamerForumWeb.Db.Data.Common
{
    public class DataValidationConstants
    {
        public class User
        {
            public const int MaxUserNameLenght = 20;
            public const int MinUserNameLenght = 5;

            public const int MaxEmailLenght = 60;
            public const int MinEmailLenght = 10;

            public const int MaxPasswordLenght = 20;
            public const int MinPasswordLenght = 5;

            public const int MaxUserFirstNameLenght = 20;
            public const int MinUserFirstNameLenght = 5;

            public const int MaxUserLastNameLenght = 20;
            public const int MinUserLastNameLenght = 5;

            public const int MaxCountryNameLenght = 20;
            public const int MinCountryNameLenght = 5;
        }

        public class Game
        {
            public const int MaxTitleLenght = 50;
            public const int MinTitleLenght = 10;

            public const int MaxStudioLenght = 50;
            public const int MinStudioLenght = 5;

            public const int MaxDescriptionLenght = 5000;
            public const int MinDescriptionLenght = 5;

            public const decimal MaxRating = 10.00m;
            public const decimal MinRating = 0.00m;
        }

        public class Category
        {
            public const int MaxCategoryNameLenght = 50;
            public const int MinCategoryNameLenght = 5;
        }

        public class Post
        {
            public const int MaxTitleLenght = 50;
            public const int MinTitleLenght = 10;

            public const int MaxContentLenght = 5000;
            public const int MinContentLenght = 5;

        }

        public class PostComment
        {
            public const int MaxContentLenght = 1000;
            public const int MinContentLenght = 5;

        }
    }
}
