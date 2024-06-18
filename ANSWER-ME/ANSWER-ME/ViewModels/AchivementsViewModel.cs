using ANSWER_ME.Data;
using ANSWER_ME.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace ANSWER_ME.ViewModels
{
    public partial class AchivementsViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<Achivement> achivements;
        [ObservableProperty]
        private List<bool> reds;


        public AchivementsViewModel()
        {
            Achivements = new List<Achivement>();
            Load();
        }

        public void Load()
        {
            Database.CreateAchivements();
            Achivements = Database.GetAchivementsAsync().Result;
            Achivements.OrderBy(x => x.ID);
        }

        public async void UpdateAchived(string sender)
        {
            foreach (Achivement ach in Achivements)
            {
                if (ach.Title == sender)
                {
                    ach.Date = DateTime.Now.Date;
                    await Database.UpdateItemAsync(ach);
                    Load();
                    break;
                }
            }
        }
    }
}
