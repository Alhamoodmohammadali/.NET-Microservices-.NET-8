using Microsoft.AspNetCore.Identity;

namespace EduSpot.Services.AuthAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
