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

        private void MyButton_Clicked(object sender, EventArgs e)
        {
        }
    }
}
