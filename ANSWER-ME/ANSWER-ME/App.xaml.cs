using ANSWER_ME.Views;

namespace ANSWER_ME
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Current.UserAppTheme = AppTheme.Light;

            MainPage = new HomeView();
            Routing.RegisterRoute(nameof(TriviaView), typeof(TriviaView));
            Routing.RegisterRoute(nameof(AchivementView), typeof(AchivementView));

            // category list
        }
    }
}