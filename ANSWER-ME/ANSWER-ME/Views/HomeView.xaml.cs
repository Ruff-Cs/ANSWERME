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
        await Navigation.PushAsync(new AchivementView());
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
    }
}