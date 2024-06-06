using ANSWER_ME.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ANSWER_ME.ViewModels
{
    public partial class TriviaViewModel : ObservableObject
    {
        public Trivia trivia;

        [ObservableProperty]
        public string difficulty;
        [ObservableProperty]
        public string type;
        [ObservableProperty]
        public string currentIndex;

        private int index;

        public void SetQ()
        {
            Difficulty = trivia.results.FirstOrDefault()?.difficulty;
            Type = trivia.results.FirstOrDefault()?.type;
            CurrentIndex = $"{index + 1}/{trivia.results.Count()}";
        }
    }
}
