/*
 * 
 * @author Carlos Enrique Agudelo Giraldo
 * @email carloskikea@gmail.com
 * @description Defina una clase local que solo se instaciara una ves para acceder a los componentes de las capas del proyecto
 * @date 10/17/206 
 *  
 */

namespace Example.Infrastructure
{
    using Example.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class InstanceLocator
    {
        public InstanceLocator()
        {
            Main = new MainViewModel();     
        }

        public MainViewModel Main { get; set; }
    }
}
