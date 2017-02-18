/*
 *
 * @author Carlos Enrique Agudelo Giraldo
 * @email carloskikea @gmail.com
 * @description Clase que contiene los mensajes que se presentan al usuario
 * @date 10/17/206 
 *  
 */

namespace Example.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DialogService
    {
        /// <summary>
        /// Metodo que presenta al usuario el mensaje especifico
        /// </summary>
        /// <param name="message">Contenido del mensaje</param>
        /// <param name="title">Titulo del mensaje</param>
        public async Task ShowMessage(string message, string title)
        {
            await App.Navigator.DisplayAlert(title, message, "OK"); // Renderza el mensaje
        }
    }
}
