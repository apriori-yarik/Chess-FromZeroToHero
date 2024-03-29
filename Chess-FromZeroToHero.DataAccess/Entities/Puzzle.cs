﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.DataAccess.Entities
{
    public class Puzzle : BaseEntity
    {
        public int Rating { get; set; }

        public int Likes { get; set; }

        public string Solution { get; set; }

        public Guid PositionId { get; set; }

        public Position Position { get; set; }

        public ICollection<UserPuzzle> UserPuzzles { get; set; }
    }
}
