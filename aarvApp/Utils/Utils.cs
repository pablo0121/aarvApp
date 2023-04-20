using System;
using System.Collections.Generic;
using System.Text;

namespace aarvApp.Utils
{
    public class Utils
    {
        /* Nombre: Angel Armando Ramirez Vazquez No.Control:1221100627 */
        public const string API_URL = "http://192.168.200.116:3000/api";
        private readonly static Utils _instance = new Utils();
        public static Utils Instance
        { 
            get
            {
                return _instance;
            }
        }
    }
}
