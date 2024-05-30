using ANSWER_ME.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ANSWER_ME.ViewModels
{
    public partial class AchivementsViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Achivement> achivements;

        private AchivementDatabase Database;

        public AchivementsViewModel()
        {
            Achivements = new List<Achivement>();
            Database = new AchivementDatabase();
            Load();
        }

        public void Load()
        {
            Achivements = new List<Achivement>(Database.GetItemsAsync());
        }
    }
}
