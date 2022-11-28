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

        public int WhiteUserId { get; set; }

        public User WhiteUser { get; set; }

        public int BlackUserId { get; set; }

        public User BlackUser { get; set; }
    }
}
