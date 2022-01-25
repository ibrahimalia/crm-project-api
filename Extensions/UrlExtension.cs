using Meta.IntroApp.FixedValues;

namespace Meta.IntroApp.Extensions
{
    public static class UrlExtension
    {
        /// <summary>
        /// Wrap the url to form a full url
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string WrapContentUrl(this string image)
        {
            if (image == null) 
            {
                return "";
            }
                if (image.StartsWith("\"http:"))
            {
                return image;
            }
            if (image.StartsWith("http:"))
            {
                return image;
            }
            else if (!image.StartsWith("\"http:") && image != "")
            {
                return AppRuntimeConstants.ImagesSiteUrl + image;
            }
            else 
            {
                return "";
            }
           /*string.IsNullOrEmpty(image) || image.StartsWith("http") ? image : AppRuntimeConstants.ImagesSiteUrl + image;*/
        }


        public static string WrapPhysicalPath(this string image)
        {
            return string.IsNullOrEmpty(image) ? null : AppRuntimeConstants.ContentFolderPhysicalPath + image;
        }


        public static string RemoveContentUrl(this string image)
        {
            image = image.Replace(AppRuntimeConstants.ImagesSiteUrl, "");
            //if (!image.StartsWith("/"))
            //    image = "/" + image;
            return image;
        }
    }
}