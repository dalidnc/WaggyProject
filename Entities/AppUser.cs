using Microsoft.AspNetCore.Identity;

namespace WaggyProject.Entities
{
    public class AppUser :IdentityUser<int> //key(primary) değerini int olarak tutuyoruz
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }

    }
}
