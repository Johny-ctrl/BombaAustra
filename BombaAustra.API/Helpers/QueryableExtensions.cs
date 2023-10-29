using BombaAustra.Shared.DTOs;

namespace BombaAustra.API.Helpers
{
    public static class QueryableExtensions
    {
        //Esta api sera para controlar la paginacion
        public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable,
            PaginacionDTO pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.RecordsNumber)
                .Take(pagination.RecordsNumber);
        }
    }

}
