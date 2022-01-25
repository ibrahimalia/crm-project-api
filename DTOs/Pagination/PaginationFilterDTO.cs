namespace Meta.IntroApp.DTOs.Pagination
{
    public class PaginationFilterDTO
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int ElementsToBeEscaped => (RequestedPageNumber - 1) * RequestedPageLength;
        public int RequestedPageNumber => PageNumber <= 0 ? 0 : PageNumber;

        public int RequestedPageLength => PageSize <= 10 ? 10 : RequestedPageLength;
        //public int? State { get; set; }
        //public int? Category { get; set; }
        //public string ClientName { get; set; }

        public PaginationFilterDTO()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        public PaginationFilterDTO(int PageNumber, int PageSize)
        {
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;
        }
    }
}