using System.Text.Json.Serialization;

namespace Chess_FromZeroToHero.DataAccess.Pagination
{
    public class PaginationParams
    {
        private const int maxItemsPerPage = 25;

        public int Page { get; }

        public int ItemsPerPage { get; }

        [JsonConstructor]
        public PaginationParams(int page, int itemsPerPage)
        {
            Page = page;
            ItemsPerPage = itemsPerPage > maxItemsPerPage ? maxItemsPerPage : itemsPerPage;
        }
    }
}
