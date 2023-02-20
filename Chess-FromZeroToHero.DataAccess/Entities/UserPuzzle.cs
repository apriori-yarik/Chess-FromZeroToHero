using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.DataAccess.Entities
{
    public class UserPuzzle
    {
        public bool IsSuccessful { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid PuzzleId { get; set; }

        public Puzzle Puzzle { get; set; }
    }
}
