/*
 * 
 * @author Carlos Enrique Agudelo Giraldo
 * @email carloskikea@gmail.com
 * @description Clase de tipo modelo de tipo Ordenes que representa a nivel de codigo la entidd ordenes del model de datos
 * @date 10/17/206 
 *  
 */

namespace Example.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Order
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryInformation { get; set; }
        public string Client { get; set; }
        public string Phone { get; set; }
        public bool? IsDelivered { get; set; }
    }
}
