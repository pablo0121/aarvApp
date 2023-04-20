using aarvApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace aarvApp
{
    public partial class App : Application
    {
        public App()
        {
        /* Nombre: Angel Armando Ramirez Vazquez No.Control:1221100627 */
            InitializeComponent();
            XF.Material.Forms.Material.Init(this);
            if (Application.Current.Properties.ContainsKey("usuario"))
            {
                MainPage = new NavigationPage(new InicioPage());
            }
            else
            {
                MainPage = new LoginPage();
            }
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
