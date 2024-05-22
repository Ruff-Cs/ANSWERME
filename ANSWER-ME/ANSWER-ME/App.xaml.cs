using ANSWER_ME.ViewModels;
using ANSWER_ME.Views;

namespace ANSWER_ME
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            Current.UserAppTheme = AppTheme.Light;
            HomeViewModel vm = new HomeViewModel();
            MainPage = new NavigationPage(new HomeView(vm));
            Routing.RegisterRoute(nameof(TriviaView), typeof(TriviaView));
            Routing.RegisterRoute(nameof(AchivementView), typeof(AchivementView));

            // category list
        }
    }
}