using ANSWER_ME.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Net;

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

        [ObservableProperty]
        public Category selectedCategory;

        [ObservableProperty]
        public List<Category> categories = Category.CreateCategories();

        public Trivia t;
        public string end;

        public HomeViewModel()
        {
            SetDifficulty("any");
        }

        [RelayCommand]
        public void SetDifficulty(string diff)
        {
            Difficulty = diff;
        }

        public void SliderMoved(double newValue)
        {
            RoundValue = newValue;
            RoundText = $"{(int)RoundValue} rounds";
        }

        public void CallTrivia()
        {
            end = $"{SelectedCategory.Title};{Difficulty};{(int)RoundValue}";
            string Url = "https://opentdb.com/api.php?";
            Url += $"amount={(int)RoundValue}";

            switch (SelectedCategory.Title)
            {
                case "All":
                    break;
                case "Random":
                    Random rnd = new();
                    int r = rnd.Next(9, 33);
                    Url += $"&category={r}";
                    break;
                default:
                    int categoryId = SelectedCategory.ID;
                    Url += $"&category={categoryId}";
                    break;
            }

            switch (Difficulty)
            {
                case "easy":
                    Url += "&difficulty=easy";
                    break;
                case "medium":
                    Url += "&difficulty=medium";
                    break;
                case "hard":
                    Url += "&difficulty=hard";
                    break;
            }

            t = ApiCalls.GetTrivia(Url).Result;
            try
            {
                foreach (TriviaResult res in t.results.ToList())
                {
                    res.category = WebUtility.HtmlDecode(res.category);
                    res.question = WebUtility.HtmlDecode(res.question);
                    res.correct_answer = WebUtility.HtmlDecode(res.correct_answer);
                    for (int i = 0; i < res.incorrect_answers.Length; i++)
                    {
                        res.incorrect_answers[i] = WebUtility.HtmlDecode(res.incorrect_answers[i]);
                    }

                    if (res.category.Contains("Science: ")) res.category = res.category[9..];
                    else if (res.category.Contains("Entertainment: ")) res.category = res.category[15..];

                    if (res.type == "boolean") res.type = "True or False";
                    else res.type = "Choose One";

                    res.difficulty = $"{res.difficulty[0]}".ToUpper() + res.difficulty[1..];
                }
            }
            catch (Exception)
            {
                t = null;
            }
        }
    }
}
