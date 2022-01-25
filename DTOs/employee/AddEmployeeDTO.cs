using System.Collections.Generic;

namespace Meta.IntroApp.DTOs.employee
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public IEnumerable<string> Images { get; set; }
    }

    public class AddEmployeeDTO
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public IEnumerable<string> Images { get; set; }
    }
}