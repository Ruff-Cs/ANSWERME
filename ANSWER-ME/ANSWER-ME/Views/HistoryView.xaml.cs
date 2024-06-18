using ANSWER_ME.Data;
using ANSWER_ME.Models;
using ANSWER_ME.ViewModels;

namespace ANSWER_ME.Views;

public partial class HistoryView : ContentPage
{
    HistoryViewModel vm;
    public HistoryView()
    {
        InitializeComponent();
        vm = new();
        BindingContext = vm;
    }

    private async void HomeBTN_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }

    protected override bool OnBackButtonPressed()
    {
        Navigation.PopToRootAsync();
        return base.OnBackButtonPressed();
    }

    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        vm.Load();
    }
}