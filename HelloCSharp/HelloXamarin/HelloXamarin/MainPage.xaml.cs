using System;
using Xamarin.Forms;

namespace HelloXamarin
{
    public partial class MainPage : ContentPage
    {
        private IAcs _acs;

        public MainPage(IAcs acs)
        {
            InitializeComponent();

            _acs = acs;
        }

        private async void MyButton_Clicked(object sender, EventArgs e)
        {
            await _acs.Initialize(AcsConnectionStringEntry.Text);

            var token = await _acs.CreateUserAccessToken(AcsCallerIdEntry.Text, TimeSpan.FromHours(2));

            await _acs.StartCall(token, AcsCalleeIdEntry.Text, TimeSpan.FromHours(2));
        }
    }
}
