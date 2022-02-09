using Microsoft.EntityFrameworkCore;

namespace PaymentAPI.Models
{
    [Keyless]
    public class UserLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
