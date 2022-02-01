using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Food_Center.Model
{
    public class LoginModel
    {
        public string EmailId { get; set; }
        public string Password { get; set; }

        public string RefreshToken { get; set; }

    }
}
