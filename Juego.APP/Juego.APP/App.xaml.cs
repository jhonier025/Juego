using Juego.APP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Juego.APP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainJuego();
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
