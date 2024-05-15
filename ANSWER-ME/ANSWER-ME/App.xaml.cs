using ANSWER_ME.Views;

namespace ANSWER_ME
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new HomeView());
            Application.Current.UserAppTheme = AppTheme.Light;
        }
    }
}