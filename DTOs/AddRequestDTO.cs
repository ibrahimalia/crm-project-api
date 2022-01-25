using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meta.IntroApp.DTOs
{
    public class AddRequestDTO
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        //public int ServiceID { get; set; }
        public int SubServiceID { get; set; }
        public string Notes { get; set; }
        public string FilePath { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }

    }
}
