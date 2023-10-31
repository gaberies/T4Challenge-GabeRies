using Microsoft.AspNetCore.Identity;

namespace T4Challenge.Models
{
    public class ApplicationUser : IdentityUser
    {
        public bool IsAdmin { get; private set; }
        public bool IsClient { get; private set; }

        public void SetIsAdmin(bool value)
        {
            IsAdmin = value;
        }

        public bool GetIsAdmin()
        {
            return IsAdmin;
        }

        public void SetIsClient(bool value)
        {
            IsClient = value;
        }

        public bool GetIsClient()
        {
            return IsClient;
        }
    }
}
