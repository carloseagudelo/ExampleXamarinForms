/*
 * 
 * @author Carlos Enrique Agudelo Giraldo
 * @email carloskikea@gmail.com
 * @description Clase que contiene los metodos de acceso al serviodro de aplicacion externo
 * @date 18/02/2017 
 *  
 */

namespace Example.Services
{
    using System;
    using Example.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net.Http;
    using Newtonsoft.Json;

    public class ApiService
    {
        /// <summary>
        /// Metodo asincrono [espera la respuesta del servidor que puede tardar algunos segundos] para obtener del servicio la lista de ordenes registradas
        /// </summary>
        /// <returns>Lista de tipo ordenes con el resultado de la petición</returns>
        public async Task<List<Order>> GetAllOrders()
        {
            using (HttpClient client = new HttpClient()) // Implementa la libreria HttpCliente para la  comunicación con el servideor
            {
                string url = "http://ninjatips.azurewebsites.net/tables/Orders"; // Agrega la url de la petición en el servidor
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0"); // Agrega el header por defecto
                var result = await client.GetAsync(url);  // Obtiene el resultado realizando la consulta al servidor a traves de un metodo GET

                string data = await result.Content.ReadAsStringAsync(); // Lee el resultado

                if (result.IsSuccessStatusCode) // Valida si el resultado de la petición fue exitoso
                {
                    return JsonConvert.DeserializeObject<List<Order>>(data); // Retorma el resultado en fomra de lista de tipo Ordenes en caso de ser exitoso
                }
                else
                    return new List<Order>(); // Retorna una ista de tipo Order vacia
            }
        }

        /// <summary>
        /// Metodo asincrono [espera la respuesta del servidor que puede tardar algunos segundos] para almacenar la orden parametrizada en el servidor
        /// </summary>
        /// <param name="newOrder">Modelo de tipo Order con la información a almacenar</param>
        /// <returns></returns>
        public async Task<Order> CreateOrder(Order newOrder)
        {
            using (HttpClient client = new HttpClient()) // Implementa la libreria HttpCliente para la  comunicación con el servideor
            {
                string url = "http://ninjatips.azurewebsites.net/tables/Orders"; // Agrega la url de la petición en el servidor
                client.DefaultRequestHeaders.Add("ZUMO-API-VERSION", "2.0.0"); // Agrega el header por defecto

                string content = JsonConvert.SerializeObject(newOrder); // Parametriza la información a enviar al servidor
                StringContent body = new StringContent(content, Encoding.UTF8, "application/json"); // Agrega otro header a la peticion donde especifica la información de la petición
                var result = await client.PostAsync(url, body); // REaliza la petición al servidor de almacenamientode la información a traves de un metodo POST

                string data = await result.Content.ReadAsStringAsync(); // Lee el resultado 

                if (result.IsSuccessStatusCode) // Valida si el resultado de la petición fue exitoso
                {
                    return JsonConvert.DeserializeObject<Order>(data); // Retorna la información de ñla petición
                }
                else
                    return null; // Retorna nulo
            }
        }
    }
}
