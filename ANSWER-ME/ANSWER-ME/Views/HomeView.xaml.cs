using ANSWER_ME.ViewModels;

namespace ANSWER_ME.Views;

public partial class HomeView : ContentPage
{
    HomeViewModel vm;
    public HomeView()
    {
        InitializeComponent();
        vm = new HomeViewModel();
        BindingContext = vm;
        roundSLDR.Value = 10;
        AnyBTN.IsEnabled = false;
    }

    private async void AchivementsBTN_Clicked(object sender, EventArgs e)
    {
        // await Navigation.PushAsync(new AchivementView());
        await Shell.Current.GoToAsync(nameof(AchivementView));
    }

    private void RoundSLDR_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        vm.SliderMoved(e.NewValue);
    }

    private void DiffBTN_Clicked(object sender, EventArgs e)
    {
        AnyBTN.IsEnabled = EasyBTN.IsEnabled = MediumBTN.IsEnabled = HardBTN.IsEnabled = true;
        ((Button)sender).IsEnabled = false;

        //CategoryCV.ItemsSource = vm.Categories;
    }

    private async void PlayBTN_Clicked(object sender, EventArgs e)
    {
        PlayBTN.IsEnabled = false;
        try
        {
            vm.CallTrivia();
        }
        catch (Exception x)
        {
            await DisplayAlert("Something went wrong", $"{x}", "Ok");
        }

        if (vm.t != null && vm.t.response_code == 0) await Navigation.PushAsync(new TriviaView(vm.t, vm.end));
        else await DisplayAlert("Ooops", "Something went wrong", "Ok");

        PlayBTN.IsEnabled = true;
    }
}