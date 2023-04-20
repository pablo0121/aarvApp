using aarvApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace aarvApp.Services
{
    public class AppService
    {
        public static AppService Instancia = new AppService();
        /* Nombre: Angel Armando Ramirez Vazquez No.Control:1221100627 */
        public async Task<string> IniciarSesionAsync(string usuario, string password)
        {
            string result = "";

            //GENERAR EL BODY PARA EL ENVIO DE LOS DATOS 
            Login login = new Login()
            {
                username = usuario,
                password = password
            };
            // GENERAR LA ESTRCUTURA JSON DEL OBJETO LOGIN 
            string json = JsonConvert.SerializeObject(login);

            //CONIGURAR LA PETICIÓN PARA EL ENVIO DE LOS DATOS
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            //ENVIAR LA PETICIÓN POST
            var handler = new HttpClientHandler();
            handler.UseProxy = false;

            HttpClient client = new HttpClient(handler);
            var reponse = await client.PostAsync($"{Utils.Utils.API_URL}/auth", content);
            result = await reponse.Content.ReadAsStringAsync();

            return result;
        }
    }
}
