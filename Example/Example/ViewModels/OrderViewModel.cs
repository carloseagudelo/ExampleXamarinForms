/*
 * 
 * @author Carlos Enrique Agudelo Giraldo
 * @email carloskikea@gmail.com
 * @description ViewModel de los formularios asociados a las ordenes
 * @date 18/02/2017 
 *  
 */

namespace Example.ViewModels
{
    using Example.Models;
    using Example.Services;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    class OrderViewModel
    {
        ApiService apiService;
        DialogService dialogService;

        public OrderViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            DeliveryDate = DateTime.Today;
        }

        // Define las propiedades del viewModel
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryInformation { get; set; }
        public string Client { get; set; }

        public ICommand SaveCommand // //Define el comando que manejera el evento del boton guardar en el formulario
        {
            get { return new RelayCommand(Save); } // Asocia la funcion al comando
        }

        /// <summary>
        /// Metodo que realiza el almacenamiento de la información en el servidor
        /// </summary>
        private async void Save()
        {
             try
            {
                await apiService.CreateOrder(new Order() //Realiza la peticion al servdor para guardar la información parametrizada
                {
                    Id = Guid.NewGuid().ToString(),
                    Title = this.Title,
                    Client = this.Client,
                    DeliveryDate = this.DeliveryDate,
                    DeliveryInformation = this.DeliveryInformation,
                    Description = this.Description,
                    IsDelivered = false
                });

                await dialogService.ShowMessage("El pedido ha sido creado.", "Información"); // en caso de no tener error muestra el mensaje al usuario de exito
            }
            catch 

            {
                await dialogService.ShowMessage("Ha ocuarrido un error inesperado.", "Error"); // en caso de algun fallo, muestra e mensaje al usuario de error
            }
        }
    }
}
