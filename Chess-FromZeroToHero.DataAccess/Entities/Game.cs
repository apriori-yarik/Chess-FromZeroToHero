using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.DataAccess.Entities
{
    public class Game : BaseEntity
    {
        public int TimeControl { get; set; }

        public int TimeIncrement { get; set; }

        public int Result { get; set; }

        public bool IsRated { get; set; }

        public DateTime CreatedDate { get; set; }

        public ICollection<Position> Positions { get; set; }

        public ICollection<UserGame> UserGames { get; set; }
    }
}
