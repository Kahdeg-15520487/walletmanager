namespace API
{
    using System.Security.Claims;

    public static class HttpContextExtensionMethods
    {
        public static string GetUserIdpId(this HttpContext HttpContext)
        {
            return HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
