using Microsoft.Maui.Platform;
using SQLite;

namespace ANSWER_ME.Models
{
    public class Score
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(15), NotNull]
        public string Name { get; set; }
        [MaxLength(30), NotNull]
        public string Category { get; set; }
        [MaxLength(10), NotNull]
        public string Difficulty { get; set; }
        [NotNull]
        public int Rounds { get; set; }
        [NotNull]
        public double Points { get; set; }
        [NotNull]
        public double Percent { get; set; }
        [MaxLength(10), NotNull]
        public string Stat { get; set; }
        [MaxLength(15), NotNull]
        public string TimeString { get; set; }
        [MaxLength(15), NotNull]
        public TimeSpan Time { get; set; }
        [MaxLength(150), NotNull]
        public string Description { get; set; }

        public Score(string RoundInfo, string name)
        {
            string[] Infos = RoundInfo.Split(';');
            Category = Infos[0] == "All" ? $"{Infos[0]} categorys" : Infos[0];
            Difficulty = Infos[1].ToUpper();
            Rounds = int.Parse(Infos[2]);
            Points = double.Parse(Infos[3]);
            Percent = Points / Rounds * 100;
            Stat = $"{Points}/{Rounds}";
            Time = TimeSpan.Parse(Infos[4]);
            TimeString = Time.ToFormattedString("mm:ss:FFF");
            TimeString = TimeSpan.Parse(Infos[4]).ToFormattedString("mm:ss:FFF");
            Description =
                (Category == "All categorys" ? Category : $"{Category} category")
                + $", {Difficulty.ToLower()} difficulty, "
                + (Points == 1 ? $"{Points} point" : $"{Points} points")
                + $" out of {Rounds} rounds in {TimeString} time.";
            Name = name ?? "error";
        }

        public Score()
        {

        }
    }
}
