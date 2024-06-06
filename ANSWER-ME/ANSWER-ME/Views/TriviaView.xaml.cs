using ANSWER_ME.Models;
using ANSWER_ME.ViewModels;

namespace ANSWER_ME.Views;

public partial class TriviaView : ContentPage
{
    TriviaViewModel vm;
    public TriviaView(Trivia trivia)
    {
        InitializeComponent();
        vm = new TriviaViewModel();
        BindingContext = vm;
        vm.trivia = trivia;
    }

    private void Label_Loaded(object sender, EventArgs e)
    {
        vm.SetQ();
    }
}