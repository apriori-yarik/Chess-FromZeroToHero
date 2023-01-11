using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.DataAccess.Entities
{
    public class Position : BaseEntity
    {
        public string FEN { get; set; }

        public bool Turn { get; set; }

        public int? WhiteTimeLeft { get; set; }

        public int? BlackTimeLeft { get; set; }

        public Guid? GameId { get; set; }

        public Game Game { get; set; }

        public Guid? PuzzleId { get; set; }

        public Puzzle Puzzle { get; set; }
    }
}
