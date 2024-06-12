using ANSWER_ME.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Diagnostics;

namespace ANSWER_ME.ViewModels
{
    public partial class TriviaViewModel : ObservableObject
    {
        public Trivia trivia;

        [ObservableProperty]
        public string difficulty;
        [ObservableProperty]
        public string type;
        [ObservableProperty]
        public string currentIndex;
        [ObservableProperty]
        public string category;
        [ObservableProperty]
        public string question;

        [ObservableProperty]
        public string picture;

        [ObservableProperty]
        public string buttonA;
        [ObservableProperty]
        public string buttonB;
        [ObservableProperty]
        public string buttonC;
        [ObservableProperty]
        public string buttonD;

        public int index = 0;
        public int Points = 0;

        public Stopwatch Time = new();

        public void MakeTriviaRound()
        {
            SetTriviaInfo();
            SetButtons();
        }

        private void SetTriviaInfo()
        {
            Difficulty = trivia.results[index].difficulty;
            Type = trivia.results[index].type;
            CurrentIndex = $"{index + 1}/{trivia.results.Length}";

            Category = trivia.results[index].category;
            Question = trivia.results[index].question;

            Picture = (Category.Contains(' ') ? Category.Split(' ')[0] : Category) + ".png";
        }

        private void SetButtons()
        {
            if (Type == "Choose One")
            {
                List<string> answers = new()
                {
                    trivia.results[index].correct_answer,
                    trivia.results[index].incorrect_answers[0],
                    trivia.results[index].incorrect_answers[1],
                    trivia.results[index].incorrect_answers[2]
                };

                Random rnd = new();
                answers = answers.OrderBy(x => rnd.Next()).ToList();

                ButtonA = answers[0];
                ButtonB = answers[1];
                ButtonC = answers[2];
                ButtonD = answers[3];
            }
            else
            {
                ButtonC = "True";
                ButtonD = "False";
            }

        }

        public void CheckAnswer(Button sender)
        {
            if (sender.Text == trivia.results[index].correct_answer) Points++;

            index++;
            if (index <= trivia.results.Length - 1)
            {
                if (index == 1) Time.Start();
                MakeTriviaRound();
            }
            else
            {
                Time.Stop();
            }
        }
    }
}
