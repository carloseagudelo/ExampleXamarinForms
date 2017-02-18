/*
 * 
 * @author Carlos Enrique Agudelo Giraldo
 * @email carloskikea@gmail.com
 * @description Clase que contiene los metodos de navegacion en la aplicación
 * @date 18/02/2017 
 *  
 */

namespace Example.Services
{
    using Example.Pages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;

    class NavigationService
    {
        /// <summary>
        /// Metodo que estable la navegación entre los formualrios del aplicativo
        /// </summary>
        /// <param name="PageName">Nombre de la pagina a la cual se desa navegar</param>
        public async void Navigate(string PageName)
        {
            App.Master.IsPresented = false;
            switch (PageName) // Switch sobre el nombre la pagina ingresado
            {
                case "AlarmsPage":
                    await Navigate(new AlarmsPage());
                    break;
                case "NewOrderPage":
                    await Navigate(new NewOrderPage());
                    break;
                case "ClientsPage":
                    await Navigate(new ClientsPage());
                    break;
                case "SettingsPage":
                    await Navigate(new SettingsPage());
                    break;
                case "MainPage":
                    await App.Navigator.PopAsync();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Realiza la instancia de la pagina a la cual se desea abrir
        /// </summary>
        /// <typeparam name="T">Tipo de formulario</typeparam>
        /// <param name="page">Nombre del formulario</param>
        private static async Task Navigate<T>(T page) where T : Page
        {
            NavigationPage.SetHasBackButton(page, true); // elimina el boton back del MainPage
            //NavigationPage.SetBackButtonTitle(page, "Atrás"); //iOS
            await App.Navigator.PushAsync(page); // Lanza elformulario a motrar
        }

        /// <summary>
        /// Establece la pagina principal del aplicativo
        /// </summary>
        /// <param name="page">Nombre del formulario</param>
        public void SetMainPage(string page)
        {
            switch (page) // Switch sobre el nombre la pagina ingresado
            {
                case "MainPage":
                    App.Current.MainPage = new MasterPage();
                        break;
                default:
                    break;
            }
        }
    }
}
