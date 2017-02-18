using Example.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Example
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; } // Define la propiedad publica para la navegación en la aplicación
        public static MasterPage Master { get; internal set; } // Define la propiedad publica de la master page en la aplicación

        public App()
        {
            InitializeComponent();            
            MainPage = new WelcomePage(); // Define la pagina de inicio de la aplicación
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
