namespace Meta.IntroApp.DTOs
{
    public class APIResult<T> : BaseAPIResult
    {
        public T Data { get; set; }
    }
}