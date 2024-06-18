namespace ANSWER_ME.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ImgSource { get; set; }
        public double FntSize { get; set; } = 35;

        public static List<Category> CreateCategories()
        {
            return new List<Category>()
            {
                new Category(){ID=7, ImgSource = "general.png", Title = "All"},
                new Category(){ID=8, ImgSource = "random.png", Title = "Random"},
                new Category(){ID=9, ImgSource = "general.png", Title = "General Knowledge", FntSize = 30},
                new Category(){ID=10, ImgSource = "books.png", Title = "Books"},
                new Category(){ID=11, ImgSource = "film.png", Title = "Film"},

                new Category(){ID=12, ImgSource = "general.png", Title = "Music"},
                new Category(){ID=13, ImgSource = "general.png", Title = "Musicals & Theatres", FntSize = 30},
                new Category(){ID=14, ImgSource = "general.png", Title = "Television"},
                new Category(){ID=15, ImgSource = "general.png", Title = "Video Games"},
                new Category(){ID=16, ImgSource = "general.png", Title = "Board Games"},

                new Category(){ID=17, ImgSource = "general.png", Title = "Science & Nature"},
                new Category(){ID=18, ImgSource = "general.png", Title = "Computers"},
                new Category(){ID=19, ImgSource = "general.png", Title = "Mathematics"},
                new Category(){ID=20, ImgSource = "general.png", Title = "Mythology"},
                new Category(){ID=21, ImgSource = "general.png", Title = "Sports"},

                new Category(){ID=22, ImgSource = "general.png", Title = "Geography"},
                new Category(){ID=23, ImgSource = "general.png", Title = "History"},
                new Category(){ID=24, ImgSource = "general.png", Title = "Politics"},
                new Category(){ID=25, ImgSource = "general.png", Title = "Art"},
                new Category(){ID=26, ImgSource = "general.png", Title = "Celebrities"},

                new Category(){ID=27, ImgSource = "general.png", Title = "Animals"},
                new Category(){ID=28, ImgSource = "general.png", Title = "Vehichles"},
                new Category(){ID=29, ImgSource = "general.png", Title = "Comics"},
                new Category(){ID=30, ImgSource = "general.png", Title = "Gadgets"},
                new Category(){ID=31, ImgSource = "general.png", Title = "Anime & Manga"},

                new Category(){ID=32, ImgSource = "general.png", Title = "Cartoon & Animations", FntSize = 30}
            };
        }

    }
}
