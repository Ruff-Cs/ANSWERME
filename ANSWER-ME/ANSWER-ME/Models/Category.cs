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
                new Category(){ID=7, ImgSource = "all.png", Title = "All"},
                new Category(){ID=8, ImgSource = "random.png", Title = "Random"},
                new Category(){ID=9, ImgSource = "general.png", Title = "General Knowledge", FntSize = 30},
                new Category(){ID=10, ImgSource = "books.png", Title = "Books"},
                new Category(){ID=11, ImgSource = "film.png", Title = "Film"},

                new Category(){ID=12, ImgSource = "music.png", Title = "Music"},
                new Category(){ID=13, ImgSource = "musicals.png", Title = "Musicals & Theatres", FntSize = 30},
                new Category(){ID=14, ImgSource = "television.png", Title = "Television"},
                new Category(){ID=15, ImgSource = "video.png", Title = "Video Games"},
                new Category(){ID=16, ImgSource = "board.png", Title = "Board Games"},

                new Category(){ID=17, ImgSource = "science.png", Title = "Science & Nature"},
                new Category(){ID=18, ImgSource = "computers.png", Title = "Computers"},
                new Category(){ID=19, ImgSource = "mathematics.png", Title = "Mathematics"},
                new Category(){ID=20, ImgSource = "mythology.png", Title = "Mythology"},
                new Category(){ID=21, ImgSource = "sports.png", Title = "Sports"},

                new Category(){ID=22, ImgSource = "geography.png", Title = "Geography"},
                new Category(){ID=23, ImgSource = "history.png", Title = "History"},
                new Category(){ID=24, ImgSource = "politics.png", Title = "Politics"},
                new Category(){ID=25, ImgSource = "art.png", Title = "Art"},
                new Category(){ID=26, ImgSource = "celebrities.png", Title = "Celebrities"},

                new Category(){ID=27, ImgSource = "animals.png", Title = "Animals"},
                new Category(){ID=28, ImgSource = "vehicles.png", Title = "Vehicles"},
                new Category(){ID=29, ImgSource = "comics.png", Title = "Comics"},
                new Category(){ID=30, ImgSource = "gadgets.png", Title = "Gadgets"},
                new Category(){ID=31, ImgSource = "japanese.png", Title = "Anime & Manga"},

                new Category(){ID=32, ImgSource = "cartoon.png", Title = "Cartoon & Animations", FntSize = 30}
            };
        }

    }
}
