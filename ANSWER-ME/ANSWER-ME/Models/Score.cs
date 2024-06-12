using Microsoft.Maui.Platform;

namespace ANSWER_ME.Models
{
    public class Score
    {
        public string Category { get; set; }
        public string Difficulty { get; set; }
        public int Rounds { get; set; }
        public double Points { get; set; }
        public double Percent { get; set; }
        public TimeSpan Time { get; set; }
        public string Description { get; set; }

        public Score(string RoundInfo)
        {
            string[] Infos = RoundInfo.Split(';');
            Category = Infos[0];
            Difficulty = Infos[1];
            Rounds = int.Parse(Infos[2]);
            Points = double.Parse(Infos[3]);
            Percent = Points / Rounds * 100;
            Time = TimeSpan.Parse(Infos[4]);
            Description =
                (Category == "All" ? $"{Category} categorys" : $"{Category} category")
                + $", {Difficulty} difficulty, "
                + (Points == 1 ? $"{Points} point" : $"{Points} points")
                + $" out of {Rounds} rounds in {Time.ToFormattedString("mm:ss.fff")} time.";
        }
    }
}
