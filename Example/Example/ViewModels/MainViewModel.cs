/*
 * 
 * @author Carlos Enrique Agudelo Giraldo
 * @email carloskikea@gmail.com
 * @description ViewModel proncipal que carga la información inicial de los formularios
 * @date 18/02/2017 
 *  
 */

namespace Example.ViewModels
{
    using Example.Pages;
    using Example.Services;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    class MainViewModel
    {
        NavigationService navigationService;
        ApiService apiService;

        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            navigationService = new NavigationService();
            apiService = new ApiService();

            LoadMenu(); // Carga el meú
        }       

        public ObservableCollection<OrderViewModel> Orders { get; set; } // Define un ObservableColletion de tipo Ordenes que se comunica con el formulario de ordenes

        public ObservableCollection<MenuItemViewModel> Menu { get; set; } // Define un ObservableColletion de tipo Menu que se comunica con el formulario del menú

        public OrderViewModel NewOrder { get; private set; } // Define un ObservableColletion de tipo Ordenes que se comunica con el formulario de crear un menú

        public ICommand GoToCommand // Define el comando GoToCommand para manejar el evento del navegador
        {
            get { return new RelayCommand<string>(GoTo); } // Enlaza el evento al metodo GoTo
        }  

        public ICommand StartCommand // Define el comando StartCommand para manejar el evento del boton de la pagina de inicio
        {
            get { return new RelayCommand(Start); } // Enlaza el evento al metodo Start
        }                

        /// <summary>
        /// Metodo que realiza la navegacion entre las paginas
        /// </summary>
        /// <param name="pageName">Nombre de la pagina</param>
        private void GoTo(string pageName)
        {
            switch (pageName) // Switch de la pagina a mostrasr con el fin de inicializar los componentes necesarios
            {
                case "NewOrderPage":
                    NewOrder = new OrderViewModel();
                    break;
                default:
                    break;
            }
            navigationService.Navigate(pageName); // Invca el metodo de navegación
        }

        /// <summary>
        /// Metodo que inicializa la información necesaria del formulario de inicial
        /// </summary>
        private async void Start()
        {
            var lista = await apiService.GetAllOrders(); // Obtiene la información de las ordenes almacenadas

            foreach (var item in lista) // itera sobre la lista
            {
                Orders.Add(new OrderViewModel() // Agrega la informacion a mostrar
                {
                    Title = item.Title,
                    DeliveryDate = item.DeliveryDate,
                    Description = item.Description
                });
            }

            navigationService.SetMainPage("MainPage"); // Inicializa la pagina
        }

        /// <summary>
        /// Metodo que carga la informacion del menú
        /// </summary>
        private void LoadMenu()
        {
            Menu = new ObservableCollection<MenuItemViewModel>(); // Inicializa el ObservableCollection de tipo menu
            //Agrega los items del menú
            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_order",
                Tittle= "Pedidos",
                PageName = "MainPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_clock",
                Tittle = "Alarmas",
                PageName = "AlarmsPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_client",
                Tittle = "Clientes",
                PageName = "ClientsPage"
            });

            Menu.Add(new MenuItemViewModel()
            {
                Icon = "ic_settings",
                Tittle = "Configuración",
                PageName = "SettingsPage"
            });
        }
    }
}
