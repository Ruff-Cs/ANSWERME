using SQLite;

namespace ANSWER_ME.Models
{
    public class Achivement
    {
        [PrimaryKey]
        [AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50), NotNull]
        public string Title { get; set; }
        [MaxLength(120), NotNull]
        public string Description { get; set; }
        public DateTime? Date { get; set; }
        [NotNull]
        public bool Achived { get; set; } = false;

        public Achivement(string title, string desc)
        {
            Title = title;
            Description = desc;
        }
        public Achivement()
        {

        }
    }
}
