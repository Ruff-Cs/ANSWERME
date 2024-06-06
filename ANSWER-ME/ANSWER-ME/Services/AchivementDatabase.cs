using SQLite;

namespace ANSWER_ME.Models
{
    public static class AchivementDatabase
    {
        static SQLiteAsyncConnection Database;
        static AchivementDatabase()
        {
            // Init();
        }

        public static void Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = Database.CreateTableAsync<Achivement>().ConfigureAwait(false);
        }

        public static List<Achivement> GetItemsAsync()
        {
            Init();
            return Database.Table<Achivement>().ToListAsync().Result;
        }

        public static async Task<int> UpdateItemAsync(Achivement ach)
        {
            Init();
            return await Database.UpdateAsync(ach);
        }

        public static async void CreateAchivements()
        {
            Init();
            int x = Database.Table<Achivement>().ToListAsync().Result.Count;
            if (x == 0)
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
}
