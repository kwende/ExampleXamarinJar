using Xamarin.Forms;

namespace HelloXamarin
{
    public partial class App : Application
    {
        public App(IAcs acs)
        {
            InitializeComponent();

            MainPage = new MainPage(acs);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
