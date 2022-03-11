namespace WebApplication1.Helpers
{
    public class IdentityHelper
    {
        public static int UserId => int.Parse(HttpHelper.HttpContext.User.Identity.Name);
    }
}
