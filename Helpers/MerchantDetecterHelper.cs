using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Security.Claims;

namespace Meta.IntroApp.Helpers
{
    public static class MerchantDetecterHelper
    {
        public const string Merchant_ID_Header_Key = "MerchantId";

        public static string Branch_ID_Header_Key = "BranchId";

        public static string User_ID_Header_Key = "UserId";

        public static string GetCurrentMerchantId(this HttpContext httpContext)
        {
                
                httpContext.Request.Headers.TryGetValue(Merchant_ID_Header_Key, out StringValues merchantId);
                return merchantId;          
           
        }

        public static int? GetCurrentBranchId(this HttpContext httpContext)
        {
            httpContext.Request.Headers.TryGetValue(Branch_ID_Header_Key, out StringValues branchId);
            return string.IsNullOrEmpty(branchId) ? null : (int?)int.Parse(branchId);
        }

        public static long? GetCurrentUserId(this HttpContext httpContext)
        {
            httpContext.Request.Headers.TryGetValue(User_ID_Header_Key, out StringValues UserId);
            return string.IsNullOrEmpty(UserId) ? null : (long?)long.Parse(UserId);
        }


    }
}