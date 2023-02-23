using Chess_FromZeroToHero.Contracts.Dtos.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.Contracts.Helpers
{
    public static class PaginationHelper
    {
        public static IQueryable<T> Paginate<T>(IQueryable<T> query, PaginationParams paginationParams)
        {
            int elements = query.Count();
            int skip = (paginationParams.Page - 1) * paginationParams.ItemsPerPage;
            int take = paginationParams.Page * paginationParams.ItemsPerPage > elements
                ? paginationParams.Page * paginationParams.ItemsPerPage - elements
                : paginationParams.ItemsPerPage;

            if (elements <= skip)
            {
                throw new ArgumentException("Not enough data for the current page");
            }

            return query.Skip(skip).Take(take);
        }
    }
}
