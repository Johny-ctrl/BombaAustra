namespace BombaAustra.WEB.Repositories
{
    //Inyeccion de la interfaz
    public interface IRepository
    {
        Task<HttpResponseWrapper<T>> Get<T>(string url);//<--Devuelve metodo de T

        Task<HttpResponseWrapper<object>> Post<T>(string url, T model);//<-- Post que no devuelve nada

        Task<HttpResponseWrapper<TResponse>> Post<T, TResponse>(string url, T model);//<-- Post que devuelve algo

        Task<HttpResponseWrapper<object>> Delete(string url);

        Task<HttpResponseWrapper<object>> Put<T>(string url, T model);

        Task<HttpResponseWrapper<TResponse>> Put<T, TResponse>(string url, T model);

        Task<HttpResponseWrapper<object>> Get(string url);

    }

}
