using ANSWER_ME.Data;
using ANSWER_ME.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ANSWER_ME.ViewModels
{
    public partial class HistoryViewModel : ObservableObject
    {
        [ObservableProperty]
        List<Score> scoreList;
        [ObservableProperty]
        bool isEmpty;

        public void Load()
        {
            ScoreList = Database.GetScoresAsync().Result;
            IsEmpty = ScoreList.Count == 0;
        }

        [RelayCommand]
        async Task Delete(Score SelectedScore)
        {
            if (SelectedScore != null)
            {
                await Database.DeleteScoreAsync(SelectedScore);
                Load();
            }
            SelectedScore = null;
        }
    }
}
