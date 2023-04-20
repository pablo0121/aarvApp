using aarvApp.Models;
using aarvApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI.Dialogs;

namespace aarvApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        /* Nombre: Angel Armando Ramirez Vazquez No.Control:1221100627 */
        public LoginPage()
        {
            InitializeComponent();
        }
        private async void BtnIngresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool esValido = ValidarFormulario();
                if (esValido == true)
                {
                    using (await MaterialDialog.Instance.LoadingDialogAsync("Espere por favor"))
                    {
                        string usuario = TxtUsuario.Text;
                        string password = TxtPassword.Text;
                        string json = await AppService.Instancia.IniciarSesionAsync(usuario, password);
                        Auth auth = JsonConvert.DeserializeObject<Auth>(json);
                        await MaterialDialog.Instance.SnackbarAsync(auth.mensaje);

                        // REDIRECCION A LA PAGINA DE INICIO
                        if (!string.IsNullOrEmpty(auth.token))
                        {
                            // Guardar la información  del usuario 

                            // Verificar que la clave 'usuario' no exista , si existe se debe de eliminar 
                            if (Application.Current.Properties.ContainsKey("usuario"))
                            {
                                Application.Current.Properties.Remove("usuario");
                            }
                            // Guardar la información de un formato de tipo json => variable json 
                            Application.Current.Properties.Add("usuario", json);
                            // Realizar la persistencia de los datos
                            await Application.Current.SavePropertiesAsync();
                            // Se redireccionaa  al pantalla de inicio 
                            Application.Current.MainPage = new InicioPage();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                await MaterialDialog.Instance.AlertAsync(ex.Message, "Error", "Aceptar");
            }
        }
        private bool ValidarFormulario()
        {
            TxtUsuario.HasError = false;
            TxtPassword.HasError = false;
            bool bandera = true;
            if (TxtUsuario.Text.Trim() == "")
            {

                bandera = false;
                TxtUsuario.HasError = true;
                TxtUsuario.ErrorText = "El usuario es requerdio";

            }
            // Validar el usuario
            if (TxtUsuario.Text.Trim() == "")
            {
                bandera = false;
                TxtPassword.HasError = true;
                TxtPassword.ErrorText = "La contraseña es requerida";
            }
            return bandera;
        }

    }
}