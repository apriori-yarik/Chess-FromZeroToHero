﻿using System;
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

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }
    }
}
