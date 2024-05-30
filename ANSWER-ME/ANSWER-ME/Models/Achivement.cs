using SQLite;

namespace ANSWER_ME.Models
{
    public class Achivement
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public bool Achived { get; set; } = false;

        public Achivement(string title, string desc, string img)
        {
            Title = title;
            Description = desc;
            ImgUrl = img;
        }
        public Achivement()
        {

        }
    }
}
