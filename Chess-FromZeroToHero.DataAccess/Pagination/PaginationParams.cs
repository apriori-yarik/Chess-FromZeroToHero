namespace Chess_FromZeroToHero.DataAccess.Pagination
{
    // TODO: make immutable
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
