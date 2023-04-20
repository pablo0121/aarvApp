using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI;

namespace aarvApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InicioPage : ContentPage
    {
        public InicioPage()
        {
            InitializeComponent();
        }
        /* Nombre: Angel Armando Ramirez Vazquez No.Control:1221100627 */
        private async void MaterialCard_Clicked(object sender, EventArgs e)
        {
            try
            {
                string opcion = ((MaterialCard)sender).BindingContext as string;
                //Dependiendo de la opcion selecciona se realiza la navegación a la pagina
                switch (opcion)
                {
                    case "1":    //Navegación ver datos 
                        await Navigation.PushAsync(new VerDatosPage());
                        break;
                    case "2":    //Dispositivos IoT
                        await Navigation.PushAsync(new DispositivosPage());
                        break;
                    case "3":    //Navegación On/Off
                        await Navigation.PushAsync(new EncenderPage());
                        break; 
                    case "4":    //Navgeación Información 
                        await Navigation.PushAsync(new InformacionPage());
                        break;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}