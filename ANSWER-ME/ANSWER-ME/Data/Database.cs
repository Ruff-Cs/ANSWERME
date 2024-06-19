using ANSWER_ME.Models;
using SQLite;

namespace ANSWER_ME.Data
{
    public static class Database
    {
        static SQLiteAsyncConnection db;

        public static async void Init()
        {
            if (db is not null)
                return;

            db = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await db.CreateTablesAsync<Achivement, Score>();
        }

        public static Task<List<Score>> GetScoresAsync()
        {
            Init();
            if (db is not null)
                return db.Table<Score>().ToListAsync();
            return null;
        }

        public static Task<List<Achivement>> GetAchivementsAsync()
        {
            Init();
            if (db is not null)
                return db.Table<Achivement>().ToListAsync();
            return null;
        }

        public static async Task<int?> SaveScoreAsync(Score score)
        {
            Init();
            if (db is not null)
                return await db.InsertAsync(score);
            return null;
        }

        public static int? UpdateAchivementAsync(Achivement ach)
        {
            Init();
            if (db is not null)
                return db.UpdateAsync(ach).Result;
            return null;
        }

        public static async Task<int?> DeleteScoreAsync(Score score)
        {
            Init();
            if (db is not null)
                return await db.DeleteAsync(score);
            return null;
        }

        public static async void CreateAchivements()
        {
            Init();
            int x = db.Table<Achivement>().ToListAsync().Result.Count;
            if (x == 0)
            {
                List<Achivement> achivements = new()
                {
                    // right answers
                    new Achivement("Baby steps", "Get 10 answers right"),
                    new Achivement("Not an idiot", "Get 20 answers right"),
                    new Achivement("Feels good", "Get 30 answers right"),
                    new Achivement("Let me cook", "Get 50 answers right"),
                    new Achivement("I got potential", "Get 100 answers right"),
                    new Achivement("Dedication", "Get 250 answers right"),
                    new Achivement("Maaan It's too easy", "Get 1000 answers right"),
                    // wrong answers
                    new Achivement("-10", "Get 10 answers wrong"),
                    new Achivement("Down the Toilet", "Get 30 answers wrong"),
                    new Achivement("You shall not pass!", "Get 100 answers wrong"),
                    new Achivement("Let There Be Darkness!", "Get 250 answers wrong"),
                    new Achivement("Does the suffering end?!?", "Get 500 answers wrong"),
                    new Achivement("It's time to delete...", "Get 1000 answers wrong"),
                    // games played
                    new Achivement("The journey begins", "Complete 1 game"),
                    new Achivement("Warming up", "Complete 10 games"),
                    new Achivement("Laying the road", "Complete 30 games"),
                    new Achivement("Solid workflow", "Complete 100 games"),
                    new Achivement("Disciplined", "Complete 250 games"),
                    new Achivement("Working hard for it", "Complete 500 games"),
                    // time based
                    new Achivement("Run Forest, RUN!!", "Complete a round quickly"),
                    new Achivement("Fastetst in the west", "100% a round in little time"),
                    new Achivement("It's not a race", "Spend 20 minutes on one round"),
                    // 100% 
                    new Achivement("Check me out", "Get 100% in a 10 round quiz"),
                    new Achivement("Where's my Nobel Prize", "Get 100% in a 30 round quiz"),
                    // 0%
                    new Achivement("Achived Failure", "To rise you must first realize you have fallen"),
                    // 50%
                    new Achivement("Half way there", "Score 50%, half wrong half right"),
                    // miscellaneous
                    new Achivement("Gotta catch'em all", "Collect all the achivements!!!"),
                    new Achivement("And perhaps what is this?", "Play every category"),
                    new Achivement("The Polymath", "Get 100% in every category")
                };
                await db.InsertAllAsync(achivements);
            }
        }
    }
}
