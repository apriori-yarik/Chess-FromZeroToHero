using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.Contracts.Dtos.User
{
    public class UserDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int Rating { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public byte[] ProfilePicture { get; set; }
    }
}
