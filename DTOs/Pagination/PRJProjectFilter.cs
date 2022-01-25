using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs.Pagination
{
    public class PRJProjectFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int ElementsToBeEscaped => (RequestedPageNumber - 1) * RequestedPageLength;
        public int RequestedPageNumber => PageNumber <= 0 ? 0 : PageNumber;

        public int RequestedPageLength => PageSize <= 10 ? 10 : RequestedPageLength;
        public string State { get; set; }
        public string Category { get; set; }
        public string ClientName { get; set; }

        public PRJProjectFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }

        public PRJProjectFilter(int PageNumber, int PageSize)
        {
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;
        }
    }
    public class PRJTaskFilter
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int ElementsToBeEscaped => (RequestedPageNumber - 1) * RequestedPageLength;
        public int RequestedPageNumber => PageNumber <= 0 ? 0 : PageNumber;

        public int RequestedPageLength => PageSize <= 10 ? 10 : RequestedPageLength;
        public string Status { get; set; }
        //public int? Category { get; set; }
        //public string ClientName { get; set; }
        public DateTime? DueDate  { get; set; }

        public PRJTaskFilter()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
            this.DueDate = null;
            this.Status = null;
        }

        public PRJTaskFilter(int PageNumber, int PageSize , DateTime? DueDate , string Status)
        {
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;
            this.DueDate = DueDate;
            this.Status = Status;
        }
    }
}