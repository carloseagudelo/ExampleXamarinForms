/*
 * 
 * @author Carlos Enrique Agudelo Giraldo
 * @email carloskikea@gmail.com
 * @description ViewModel de la vista del menu
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
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Input;

    public class MenuItemViewModel
    {
        NavigationService navigationService;

        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
        }

        // Define las propiedades del viewModel
        public string Icon { get; set; }
        public string Tittle { get; set; }
        public string PageName { get; set; }

        public ICommand NavigateCommand //Define el comando que majera el evento de navegavion en la pagina
        {
            get { return new RelayCommand(() => navigationService.Navigate(PageName)); } // Define el metodo del comando
        }
    }   
}
