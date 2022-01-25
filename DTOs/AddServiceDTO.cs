namespace Meta.IntroApp.DTOs
{
    public class AddServiceDTO
    {

        public string Title { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string ServiceImage { get; set; }
 
    }

    public class EditServiceDTO : AddServiceDTO
    {
        //public int Id { get; set; }

    }
}