using ANSWER_ME.Data;
using ANSWER_ME.Models;
using ANSWER_ME.ViewModels;

namespace ANSWER_ME.Views;

public partial class FormView : ContentPage
{
    FormViewModel vm;
    public FormView(string Info)
    {
        InitializeComponent();
        vm = new(Info);
        BindingContext = vm;
    }
    protected override bool OnBackButtonPressed()
    {
        Navigation.PopToRootAsync();
        return base.OnBackButtonPressed();
    }

    private async void Image_Loaded(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ((Image)sender).IsAnimationPlaying = false;
        await Task.Delay(100);
        ((Image)sender).IsAnimationPlaying = true;
    }

    private void Image_Unloaded(object sender, EventArgs e)
    {
        ((Image)sender).IsAnimationPlaying = false;
    }

    private async void TrashBTN_Clicked(object sender, EventArgs e)
    {
        TrashBTN.IsEnabled = SaveBTN.IsEnabled = false;
        await Navigation.PopToRootAsync();
        await Task.Delay(250);
        TrashBTN.IsEnabled = SaveBTN.IsEnabled = true;
    }

    private async void SaveBTN_Clicked(object sender, EventArgs e)
    {
        TrashBTN.IsEnabled = SaveBTN.IsEnabled = false;
        if (!String.IsNullOrWhiteSpace(vm.Name))
        {
            await Database.SaveScoreAsync(vm.Score);
            await Navigation.PushAsync(new HistoryView());
        }
        else
            await DisplayAlert("Missing name!", "Please give a name to this record", "Ok");

        await Task.Delay(250);
        TrashBTN.IsEnabled = SaveBTN.IsEnabled = true;
    }

    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        vm.NameChanged();
    }
}
