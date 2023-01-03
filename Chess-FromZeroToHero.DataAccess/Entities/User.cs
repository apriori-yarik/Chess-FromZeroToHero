using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.DataAccess.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public int Rating { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public byte[] ProfilePicture { get; set; }

        //public ICollection<Game> WhiteGames { get; set; }

        //public ICollection<Game> BlackGames { get; set; }

        public ICollection<UserPuzzle> UserPuzzles { get; set; }

        public ICollection<UserGame> UserGames { get; set; }
    }
}
