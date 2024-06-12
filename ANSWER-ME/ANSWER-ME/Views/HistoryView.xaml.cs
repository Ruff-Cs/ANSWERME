namespace ANSWER_ME.Views;

public partial class HistoryView : ContentPage
{
    public HistoryView()
    {
        InitializeComponent();
    }

    private async void HomeBTN_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}