using ANSWER_ME.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ANSWER_ME.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        public double roundValue;

        [ObservableProperty]
        public string roundText;

        [ObservableProperty]
        private string difficulty;

        public HomeViewModel()
        {
            SliderMoved(10);
            SetDifficulty("any");
        }

        public void SliderMoved(double newValue)
        {
            RoundValue = newValue;
            RoundText = $"{(int)RoundValue} rounds";
        }

        [RelayCommand]
        public void SetDifficulty(string diff)
        {
            Difficulty = diff;
        }
    }
}
