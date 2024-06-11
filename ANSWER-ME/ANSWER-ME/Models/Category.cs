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
                new Category(){ID=7, ImgSource = "generalknowledge.png", Title = "All"},
                new Category(){ID=8, ImgSource = "random.png", Title = "Random"},
                new Category(){ID=9, ImgSource = "generalknowledge.png", Title = "General Knowledge", FntSize = 30},
                new Category(){ID=10, ImgSource = "books.png", Title = "Books"},
                new Category(){ID=11, ImgSource = "film.png", Title = "Film"},

                new Category(){ID=12, ImgSource = "generalknowledge.png", Title = "Music"},
                new Category(){ID=13, ImgSource = "generalknowledge.png", Title = "Musicals & Theatres", FntSize = 30},
                new Category(){ID=14, ImgSource = "generalknowledge.png", Title = "Television"},
                new Category(){ID=15, ImgSource = "generalknowledge.png", Title = "Video Games"},
                new Category(){ID=16, ImgSource = "generalknowledge.png", Title = "Board Games"},

                new Category(){ID=17, ImgSource = "generalknowledge.png", Title = "Science & Nature"},
                new Category(){ID=18, ImgSource = "generalknowledge.png", Title = "Computers"},
                new Category(){ID=19, ImgSource = "generalknowledge.png", Title = "Mathematics"},
                new Category(){ID=20, ImgSource = "generalknowledge.png", Title = "Mythology"},
                new Category(){ID=21, ImgSource = "generalknowledge.png", Title = "Sports"},

                new Category(){ID=22, ImgSource = "generalknowledge.png", Title = "Geography"},
                new Category(){ID=23, ImgSource = "generalknowledge.png", Title = "History"},
                new Category(){ID=24, ImgSource = "generalknowledge.png", Title = "Politics"},
                new Category(){ID=25, ImgSource = "generalknowledge.png", Title = "Art"},
                new Category(){ID=26, ImgSource = "generalknowledge.png", Title = "Celebrities"},

                new Category(){ID=27, ImgSource = "generalknowledge.png", Title = "Animals"},
                new Category(){ID=28, ImgSource = "generalknowledge.png", Title = "Vehichles"},
                new Category(){ID=29, ImgSource = "generalknowledge.png", Title = "Comics"},
                new Category(){ID=30, ImgSource = "generalknowledge.png", Title = "Gadgets"},
                new Category(){ID=31, ImgSource = "generalknowledge.png", Title = "Anime & Manga"},

                new Category(){ID=32, ImgSource = "generalknowledge.png", Title = "Cartoon & Animations", FntSize = 30}
            };
        }

    }
}
