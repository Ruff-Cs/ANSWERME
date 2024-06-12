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
}
