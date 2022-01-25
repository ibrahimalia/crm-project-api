namespace Meta.IntroApp.DTOs
{
    public class DTO_Response
    {
        public bool IsSuccess { get; set; }
        public string ArabicMessage { get; set; }
        public string Message { get; set; }
        public object ResponseData { get; set; }
        public int MessageCode { get; set; }

        public DTO_Response(bool status, int MessageCode, string message, string ArabicMessage, object data)
        {
            IsSuccess = status;
            this.MessageCode = MessageCode;
            this.Message = message;
            ResponseData = data;
        }
    }
}