using ANSWER_ME.Views;

namespace ANSWER_ME
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            MainPage = new NavigationPage(new HomePage());
        }
    }
}