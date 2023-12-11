using System.Net;
namespace BombaAustra.Movil.Repositories
{
    public class HttpResponseWrapper<T> //< T es una clase generica, se reemplaza por lo que estas haciendo.(Antes aqui habia una T, explicacion del porque xD)
    {
        //Este es el constructor
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage) //<-- Recoge las respuestas y las maneja
        {
            
            Error = error;
            Response = response;
            HttpResponseMessage = httpResponseMessage;
        }
        //Estas son las propiedades
        public bool Error { get; set; }

        public T? Response { get; set; }

        public HttpResponseMessage HttpResponseMessage { get; set; }

        public async Task<string?> GetErrorMessageAsync()
        {
            if (!Error)
            {
                return null;
            }

            var statusCode = HttpResponseMessage.StatusCode; //<-- Ligado a las respuestas de HTTP y sus mensajes
            if (statusCode == HttpStatusCode.NotFound)//<-- Cuando no se encuentre, mostrara el mensaje de abajo
            {
                return "Recurso no encontrado";
            }
            else if (statusCode == HttpStatusCode.BadRequest)//<-- CUando sea un bad request mostrara todo para obtener toda la informacion 
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            else if (statusCode == HttpStatusCode.Unauthorized)//<-- Cuando sea no authorizado pedira logeo
            {
                return "Tienes que logearte para hacer esta operación";
            }
            else if (statusCode == HttpStatusCode.Forbidden)//<-- Error cuando no se tenga permiso 
            {
                return "No tienes permisos para hacer esta operación";
            }

            return "Ha ocurrido un error inesperado";//<-- en el caso de no ser ninguno mostrar un error inesperado.
        }
    }

}
