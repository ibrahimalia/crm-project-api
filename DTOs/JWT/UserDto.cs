namespace Meta.IntroApp.DTOs.JWT
{
    public class UserDTO
    {
        public long Id { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Image { get; set; }
        public TokenDTO Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}