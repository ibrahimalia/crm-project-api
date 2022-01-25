namespace Meta.IntroApp.DTOs
{
    public class BaseAPIResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public int? Code { get; set; }
    }
}