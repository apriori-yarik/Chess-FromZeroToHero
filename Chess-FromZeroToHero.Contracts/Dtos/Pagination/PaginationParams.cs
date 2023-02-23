using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.Contracts.Dtos.Pagination
{
    public class PaginationParams
    {
        private const int maxItemsPerPage = 25;
        private int _itemsPerPage;

        public int Page { get; set; } = 1;
        public int ItemsPerPage 
        { 
            get => _itemsPerPage;
            set => _itemsPerPage = value > maxItemsPerPage ? maxItemsPerPage : _itemsPerPage;
        }
    }
}
