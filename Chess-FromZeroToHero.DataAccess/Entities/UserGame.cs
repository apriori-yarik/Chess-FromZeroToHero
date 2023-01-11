﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.DataAccess.Entities
{
    public class UserGame
    {
        public Guid GameId { get; set; }

        public Game Game { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Enums.Color Color { get; set; }
    }
}
