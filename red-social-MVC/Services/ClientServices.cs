using red_social_MVC.Models;

namespace red_social_MVC.Services
{
    public class ClientServices
    {
        private readonly RedSocialDbContext _context;

        public ClientServices(RedSocialDbContext context)
        {
            _context = context;
        }


    }
}
