using System.Collections.Generic;

namespace Meta.IntroApp.DTOs.UploadFile
{
    public class UploadFileDTO
    {
        public string Url { get; set; }
    }


    public class UploadFilesDTO
    {
        public IEnumerable<string> Urls { get; set; }
    }
}
