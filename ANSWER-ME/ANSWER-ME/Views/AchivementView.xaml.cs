using ANSWER_ME.Models;
using ANSWER_ME.ViewModels;

namespace ANSWER_ME.Views;

public partial class AchivementView : ContentPage
{
    AchivementsViewModel vm;
    public AchivementView()
    {
        InitializeComponent();
        vm = new();
        BindingContext = vm;
    }

    private async void HomeBTN_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        vm.Update();
    }
}