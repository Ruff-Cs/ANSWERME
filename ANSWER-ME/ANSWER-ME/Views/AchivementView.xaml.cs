using ANSWER_ME.Models;
using ANSWER_ME.ViewModels;

namespace ANSWER_ME.Views;

public partial class AchivementView : ContentPage
{
    AchivementsViewModel viewModel;
    public AchivementView()
    {
        InitializeComponent();
        viewModel = new AchivementsViewModel();
        BindingContext = viewModel;
    }

    private async void Image_Loaded(object sender, EventArgs e)
    {
        await Task.Delay(100);
        ((Image)sender).IsAnimationPlaying = false;
        await Task.Delay(100);
        ((Image)sender).IsAnimationPlaying = true;
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        AchivementDatabase.CreateAchivements();
    }

    private void CollectionView_Loaded(object sender, EventArgs e)
    {
        // AchivementDatabase.CreateAchivements();
    }
}