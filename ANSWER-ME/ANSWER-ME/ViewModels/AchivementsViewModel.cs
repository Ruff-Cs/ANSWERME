using ANSWER_ME.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ANSWER_ME.ViewModels
{
    public partial class AchivementsViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Achivement> achivements;


        public AchivementsViewModel()
        {
            Achivements = new List<Achivement>();
            Load();
        }

        public void Load()
        {
            Achivements = new List<Achivement>(AchivementDatabase.GetItemsAsync());
        }
    }
}
