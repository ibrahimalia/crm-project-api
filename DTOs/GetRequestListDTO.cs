using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs
{
    public class GetRequestListDTO
    {
        public int Id { get; set; }      
        public string SubService { get; set; }  
   
        public string Title { get; set; }
        public string RequestedDate { get; set; }
        public string RequestedTime { get; set; }
        public string State { get; set; }
        public string Notes { get; set; }
    }
}
