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

    private void RoundSLDR_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        vm.SliderMoved(e.NewValue);
    }

    private void DiffBTN_Clicked(object sender, EventArgs e)
    {
        AnyBTN.IsEnabled = EasyBTN.IsEnabled = MediumBTN.IsEnabled = HardBTN.IsEnabled = true;
        ((Button)sender).IsEnabled = false;
    }

    private async void PlayBTN_Clicked(object sender, EventArgs e)
    {
        PlayBTN.IsEnabled = false;
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        if (accessType == NetworkAccess.Internet)
        {
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
        }
        else
            await DisplayAlert("Ohh noo", "There's no internet connection!", "Ok");

        PlayBTN.IsEnabled = true;
    }

    private async void AchivementsBTN_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AchivementView));
    }

    private async void HistoryBTN_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(HistoryView));
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        ToggleShake();
    }

    private void ContentPage_Unfocused(object sender, FocusEventArgs e)
    {
        ToggleShake();
    }

    private void ToggleShake()
    {
        if (Accelerometer.Default.IsSupported)
        {
            if (!Accelerometer.Default.IsMonitoring)
            {
                // Turn on accelerometer
                Accelerometer.Default.ShakeDetected += Accelerometer_ShakeDetected;
                Accelerometer.Default.Start(SensorSpeed.Game);
            }
            else
            {
                // Turn off accelerometer
                Accelerometer.Default.Stop();
                Accelerometer.Default.ShakeDetected -= Accelerometer_ShakeDetected;
            }
        }
    }
    private async void Accelerometer_ShakeDetected(object sender, EventArgs e)
    {
        ToggleShake();
        // Randomise quiz settings and play button color
        PlayBTN.BackgroundColor = new Color(Random.Shared.Next(256), Random.Shared.Next(256), Random.Shared.Next(256));

        Random rnd = new();
        List<Button> buttons = new() { EasyBTN, MediumBTN, HardBTN, AnyBTN };
        int buttonRND = rnd.Next(4);
        DiffBTN_Clicked(buttons[buttonRND], e);
        vm.SetDifficulty(buttons[buttonRND].Text);

        int categoryRND = rnd.Next(vm.Categories.Count);
        CategoryCV.ScrollTo(categoryRND, -1, ScrollToPosition.Center);
        CategoryCV.CurrentItem = vm.Categories[categoryRND];

        int sliderRND = rnd.Next(5, 31);
        roundSLDR.Value = sliderRND;
        vm.SliderMoved(sliderRND);
        await Task.Delay(250);
        ToggleShake();
    }
    // loaded, focused are not as good as appearing
    private void ContentPage_Appearing(object sender, EventArgs e)
    {
        ToggleShake();
    }

    private void ContentPage_Disappearing(object sender, EventArgs e)
    {
        ToggleShake();
    }
}