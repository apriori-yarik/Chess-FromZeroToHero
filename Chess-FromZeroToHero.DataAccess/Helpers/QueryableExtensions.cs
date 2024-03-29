﻿using Chess_FromZeroToHero.DataAccess.Pagination;
using Microsoft.EntityFrameworkCore;

namespace Chess_FromZeroToHero.Contracts.Helpers
{
    public static class QueryableExtensions
    {
        public static async Task<List<T>> PaginateAsync<T>(this IQueryable<T> query, PaginationParams paginationParams)
        {
            int elements = await query.CountAsync();
            int skip = (paginationParams.Page - 1) * paginationParams.ItemsPerPage;

            if (elements <= skip)
            {
                return new List<T>();
            }

            return await query.Skip(skip).Take(paginationParams.ItemsPerPage).ToListAsync();
        }
    }
}
