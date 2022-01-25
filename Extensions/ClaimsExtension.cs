using System.Security.Claims;

namespace Meta.IntroApp.Extensions
{
    public static class ClaimsExtension
    {

        public static long? GetCurrentAccountId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated)
            {
                return null;
            }

            long.TryParse(user.FindFirst(ClaimTypes.NameIdentifier).Value, out long id);
            return id;
        }
    }
}
