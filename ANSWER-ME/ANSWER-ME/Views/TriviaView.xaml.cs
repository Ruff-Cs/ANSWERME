using ANSWER_ME.Models;
using ANSWER_ME.ViewModels;

namespace ANSWER_ME.Views;

public partial class TriviaView : ContentPage
{
    TriviaViewModel vm;
    string Info;
    public List<Button> AnswerButtons;
    public TriviaView(Trivia trivia, string end)
    {
        InitializeComponent();
        vm = new() { trivia = trivia };
        vm.MakeTriviaRound();
        BindingContext = vm;
        AnswerButtons = AnswerGRID.Children.Cast<Button>().ToList();
        MakeItGood();
        Info = end;
    }

    private async void AnswerButton_Clicked(object sender, EventArgs e)
    {
        ButtonOnOff(false);

        await ColorButtonsAsync((Button)sender);
        vm.CheckAnswer((Button)sender);
        await CheckEndAsync();
        MakeItGood();

        ButtonOnOff(true);
    }

    private void MakeItGood()
    {
        SetButtonSize();
        CheckTruefalse();
    }

    private void ButtonOnOff(bool OnOff)
    {
        for (int i = 0; i < 4; i++) AnswerButtons[i].IsEnabled = OnOff;
    }

    private async Task ColorButtonsAsync(Button pressed)
    {
        if (pressed.Text != vm.trivia.results[vm.index].correct_answer)
            for (int i = 4; i < 8; i++) if (AnswerButtons[i].Text == pressed.Text + "Back") AnswerButtons[i].BackgroundColor = Color.FromArgb("#FD9B71");
        for (int i = 4; i < 8; i++) if (AnswerButtons[i].Text == vm.trivia.results[vm.index].correct_answer + "Back") AnswerButtons[i].BackgroundColor = Color.FromArgb("#A6FD71");
        if (pressed.Text != vm.trivia.results[vm.index].correct_answer) await Task.Delay(1400);
        else await Task.Delay(600);
        for (int i = 4; i < 8; i++) if (AnswerButtons[i].Text.Contains("Back")) AnswerButtons[i].BackgroundColor = Color.FromArgb("#5c783b");
    }

    private void CheckTruefalse()
    {
        bool b;
        if (AnswerButtons[2].Text == "True") b = false;
        else b = true;

        AnswerButtons[0].IsVisible =
        AnswerButtons[1].IsVisible =
        AnswerButtons[4].IsVisible =
        AnswerButtons[5].IsVisible = b;
    }

    private void SetButtonSize()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!string.IsNullOrWhiteSpace(AnswerButtons[i].Text))
            {
                switch (AnswerButtons[i].Text.Length)
                {
                    case <= 5: AnswerButtons[i].FontSize = 33; break;
                    case < 9: AnswerButtons[i].FontSize = 29; break;
                    case < 19: AnswerButtons[i].FontSize = 25; break;
                    case < 25: AnswerButtons[i].FontSize = 23; break;
                    case > 37: AnswerButtons[i].FontSize = 19; break;
                    default: AnswerButtons[i].FontSize = 21; break;
                }
            }
            else AnswerButtons[i].FontSize = 21;
        }
    }

    private async Task CheckEndAsync()
    {
        if (vm.index == vm.trivia.results.Length)
        {
            string FormInfo = $"{Info};{vm.Points};{vm.Time.Elapsed}";
            await Navigation.PushAsync(new FormView(FormInfo));
        }
    }

}