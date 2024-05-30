using SQLite;

namespace ANSWER_ME.Models
{
    public class AchivementDatabase
    {
        SQLiteAsyncConnection Database;
        public AchivementDatabase()
        {

        }

        void Init()
        {
            if (Database is not null)
            {
                return;
            }
            else
            {
                Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
                var result = Database.CreateTableAsync<Achivement>().ConfigureAwait(false);
            }
        }

        public List<Achivement> GetItemsAsync()
        {
            Init();
            return Database.Table<Achivement>().ToListAsync().Result;
        }

        public async Task<int> UpdateItemAsync(Achivement ach)
        {
            Init();
            return await Database.UpdateAsync(ach);
        }

        private async void CreateAchivements()
        {
            List<Achivement> achivements = new List<Achivement>
            {
                new Achivement("10 failed", "10 incorrect answers", "achivements.png"),
                new Achivement("20 right", "20 good answers", "achivements.png"),
                new Achivement("Egg hunter", "find the hidden", "achivements.png"),
                new Achivement("Mastermind", "get 30/30 right answers", "achivements.png"),
                new Achivement("Title", "Description", "achivements.png")
            };

            await Database.InsertAllAsync(achivements);
        }
    }
}
