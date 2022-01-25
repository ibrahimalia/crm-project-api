namespace Meta.IntroApp.DTOs
{
    public class LoginInformationDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }


    public class RegisterClientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }
    }
    public class EditClientDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }

    }

    public class RegisterUserResultDTO
    {
        public long? UserId { get; set; }
    }


}