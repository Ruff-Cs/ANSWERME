using ANSWER_ME.ViewModels;

namespace ANSWER_ME.Views;

public partial class HomeView : ContentPage
{
    public HomeView(HomeViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;


    }

    private async void AchivementsBTN_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AchivementView());
    }
}