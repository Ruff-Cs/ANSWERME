using ANSWER_ME.Models;
using ANSWER_ME.ViewModels;

namespace ANSWER_ME.Views;

public partial class TriviaView : ContentPage
{
    TriviaViewModel vm;
    string Info;
    public TriviaView(Trivia trivia, string end)
    {
        InitializeComponent();
        vm = new() { trivia = trivia };
        vm.MakeTriviaRound();
        BindingContext = vm;
        MakeItGood();
        Info = end;
    }

    private async void AnswerButton_Clicked(object sender, EventArgs e)
    {
        ButtonOnOff(false);

        await ColorButtonsAsync((Button)sender);
        vm.CheckAnswer((Button)sender);
        CheckEnd();
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
        for (int i = 0; i < 4; i++) ((Button)AnswerGRID.Children[i]).IsEnabled = OnOff;
        // foreach (Button b in AnswerGRID.Children.Cast<Button>()) b.IsEnabled = OnOff;
    }

    private async Task ColorButtonsAsync(Button pressed)
    {
        if (pressed.Text != vm.trivia.results[vm.index].correct_answer)
            for (int i = 4; i < 8; i++) if (((Button)AnswerGRID.Children[i]).Text == pressed.Text + "Back") ((Button)AnswerGRID.Children[i]).BackgroundColor = Color.FromArgb("#FD9B71");
        for (int i = 4; i < 8; i++) if (((Button)AnswerGRID.Children[i]).Text == vm.trivia.results[vm.index].correct_answer + "Back") ((Button)AnswerGRID.Children[i]).BackgroundColor = Color.FromArgb("#A6FD71");
        await Task.Delay(1400);
        for (int i = 4; i < 8; i++) if (((Button)AnswerGRID.Children[i]).Text.Contains("Back")) ((Button)AnswerGRID.Children[i]).BackgroundColor = Color.FromArgb("#5F7645");
    }

    private void CheckTruefalse()
    {
        bool b;
        if (((Button)(AnswerGRID.Children[2])).Text == "True") b = false;
        else b = true;

        ((Button)(AnswerGRID.Children[0])).IsVisible =
        ((Button)(AnswerGRID.Children[1])).IsVisible =
        ((Button)(AnswerGRID.Children[4])).IsVisible =
        ((Button)(AnswerGRID.Children[5])).IsVisible = b;
    }

    private void SetButtonSize()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!string.IsNullOrWhiteSpace(((Button)(AnswerGRID.Children[i])).Text))
            {
                switch (((Button)(AnswerGRID.Children[i])).Text.Length)
                {
                    case <= 5: ((Button)(AnswerGRID.Children[i])).FontSize = 33; break;
                    case < 9: ((Button)(AnswerGRID.Children[i])).FontSize = 29; break;
                    case < 17: ((Button)(AnswerGRID.Children[i])).FontSize = 26; break;
                    case < 25: ((Button)(AnswerGRID.Children[i])).FontSize = 23; break;
                    case > 35: ((Button)(AnswerGRID.Children[i])).FontSize = 19; break;
                }
            }
            else ((Button)(AnswerGRID.Children[i])).FontSize = 21;
        }
    }

    private void CheckEnd()
    {
        if (vm.index == vm.trivia.results.Length)
        {
            string FormInfo = $"{Info};{vm.Points};{vm.Time.Elapsed}";
            // await Navigation.PushAsync(new EndView(FormInfo));
        }
    }

}