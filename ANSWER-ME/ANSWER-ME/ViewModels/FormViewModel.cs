using ANSWER_ME.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ANSWER_ME.ViewModels
{
    public partial class FormViewModel : ObservableObject
    {
        [ObservableProperty]
        public Score score;
        [ObservableProperty]
        public string pointsRound;
        [ObservableProperty]
        public string message;
        [ObservableProperty]
        public string catSource;

        public FormViewModel(string RoundInfo)
        {
            Score = new Score(RoundInfo);
            PointsRound = $"{Score.Points}/{Score.Rounds}";
            Message = SetMessageOrImage(Messages);
            CatSource = SetMessageOrImage(CatImages) + ".gif";
        }

        private List<List<string>> Messages = new()
        {
            new List<string> () { "Terrible", "Awful", "aww maaan...", "U stupid?" },
            new List<string> () { "Well Done", "Not bad", "Getting better", "Nice luck" },
            new List<string> () { "Amazing!!", "Fantastic", "Hell yeaah", "Geniooous" }
        };

        private List<List<string>> CatImages = new()
        {
            new List<string> () { "badx", "bady", "badz" },
            new List<string> () { "midx", "midy", "midz" },
            new List<string> () { "goodx", "goody", "goodz" }
        };

        private string SetMessageOrImage(List<List<string>> list)
        {
            Random rnd = new();
            return Score.Percent switch
            {
                0 => "Horrific",
                <= 33 => list[0][rnd.Next(0, list[0].Count)],
                <= 66 => list[1][rnd.Next(0, list[1].Count)],
                < 100 => list[2][rnd.Next(0, list[2].Count)],
                100 => "Omniscient",
                _ => "Interesting"
            };
        }
    }
}
