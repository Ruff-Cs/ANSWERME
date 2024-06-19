using ANSWER_ME.Models;

namespace ANSWER_ME.Data
{
    public class CheckAchivements
    {

        public CheckAchivements()
        {
            try
            {
                Preferences.Default.Get("RightAnswers", 0);
            }
            catch
            {
                Preferences.Default.Set("RightAnswers", 0);
                Preferences.Default.Set("WrongAnswers", 0);
                Preferences.Default.Set("GamesComplete", 0);
                Preferences.Default.Set("QuickRound", false);
                Preferences.Default.Set("QuickGoodRound", false);

                Preferences.Default.Set("TwentyMinutes", false);
                Preferences.Default.Set("PerfectTen", false);
                Preferences.Default.Set("PerfectThirty", false);
                Preferences.Default.Set("ZeroPercent", false);
                Preferences.Default.Set("FiftyFifty", false);

                Preferences.Default.Set("PlayCategory", "");
                Preferences.Default.Set("WinCategory", "");
                Preferences.Default.Set("AllDone", false);
            }
        }


        public void CheckAll(Score score)
        {
            int x = Preferences.Default.Get<int>("RightAnswers", 0) + (int)score.Points;
            Preferences.Default.Set("RightAnswers", x);
            x = Preferences.Default.Get<int>("WrongAnswers", 0) + (int)(score.Rounds - score.Points);
            Preferences.Default.Set("WrongAnswers", x);
            x = Preferences.Default.Get<int>("GamesComplete", 0) + 1;
            Preferences.Default.Set("GamesComplete", x);

            TimeSpan quick = TimeSpan.FromSeconds(score.Rounds * 1.2);
            if (score.Time < quick)
            {
                Preferences.Default.Set("QuickRound", true);
                updates.Add(0);
                if (score.Percent == 100.0)
                {
                    Preferences.Default.Set("QuickGoodRound", true);
                    updates.Add(1);
                }
            }

            double actual = double.Parse(score.Time.TotalMinutes.ToString());
            if (actual >= 20)
            {
                Preferences.Default.Set("TwentyMinutes", true);
                updates.Add(2);
            }

            if (score.Percent == 100)
            {
                if (score.Rounds == 10)
                {
                    Preferences.Default.Set("PerfectTen", true);
                    updates.Add(3);
                }
                else if (score.Rounds == 30)
                {
                    Preferences.Default.Set("PerfectThirty", true);
                    updates.Add(4);
                }

                string winpref = Preferences.Default.Get("WinCategory", "");
                string[] perfectCategorys = winpref.Split(';');
                if (!perfectCategorys.Contains(score.Category))
                    Preferences.Default.Get("WinCategory", winpref + $"{score.Category};");
                else
                    updates.Add(9);

            }
            if (score.Percent == 0)
            {
                Preferences.Default.Set("ZeroPercent", true);
                updates.Add(5);
            }

            if (score.Percent == 50)
            {
                Preferences.Default.Set("FiftyFifty", true);
                updates.Add(6);
            }

            string playpref = Preferences.Default.Get("PlayCategory", "");
            string[] playedCategorys = playpref.Split(';');
            if (!playedCategorys.Contains(score.Category))
                Preferences.Default.Get("PlayCategory", playpref + $"{score.Category};");
            else
                updates.Add(8);

            List<Achivement> achivements = Database.GetAchivementsAsync().Result;
            Update(achivements);
        }

        public readonly Dictionary<int, string> IdTitle = new()
        {
            { 0, "Run Forest, RUN!!" },
            { 1, "Fastetst in the west" },
            { 2, "It's not a race" },
            { 3, "Check me out" },
            { 4, "Where's my Nobel Prize" },

            { 5, "Achived Failure" },
            { 6, "Half way there" },
            { 7, "Gotta catch'em all" },
            { 8, "And perhaps what is this?" },
            { 9, "The Polymath" }
        };

        List<int> updates = new();

        public List<Achivement> Update(List<Achivement> achivements)
        {
            foreach (Achivement currentACH in achivements)
            {
                if (!currentACH.Achived)
                {
                    if (currentACH.Description.Contains("answers right"))
                    {
                        int right = Preferences.Default.Get("RightAnswers", 0);
                        if (right >= int.Parse(currentACH.Description.Split(' ')[1]))
                        {
                            currentACH.Achived = true;
                            currentACH.Date = DateTime.Now;
                        }
                    }

                    else if (currentACH.Description.Contains("answers wrong"))
                    {
                        int wrong = Preferences.Default.Get("WrongAnswers", 0);
                        if (wrong >= int.Parse(currentACH.Description.Split(' ')[1]))
                        {
                            currentACH.Achived = true;
                            currentACH.Date = DateTime.Now;
                        }
                    }

                    else if (currentACH.Description.Contains("game"))
                    {
                        int games = Preferences.Default.Get("GamesComplete", 0);
                        if (games >= int.Parse(currentACH.Description.Split(' ')[1]))
                        {
                            currentACH.Achived = true;
                            currentACH.Date = DateTime.Now;
                        }
                    }

                    else
                    {
                        if (updates.Count != 0)
                        {
                            for (int i = 0; i < updates.Count; i++)
                            {
                                if (currentACH.Title == IdTitle[updates[i]])
                                {
                                    currentACH.Achived = true;
                                    currentACH.Date = DateTime.Now;
                                }
                            }
                        }
                    }
                    Database.UpdateAchivementAsync(currentACH);
                }
            }
            return achivements;
        }
    }
}
