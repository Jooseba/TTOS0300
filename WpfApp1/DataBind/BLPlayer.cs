using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBind
{
    public static class Team
    {
        public static List<Player> GetPlayers()
        {
            List<Player> players = new List<Player>();

            //Lisätään muutama pelaaja olio
            players.Add(new Player() { Firstname = "Kuja", Lastname = "Keijjo", Number = 5, Position = "Hyökkääjä" });
            players.Add(new Player() { Firstname = "Hermanni", Lastname = "Metsä", Number = 6, Position = "Puolustaja" });
            players.Add(new Player() { Firstname = "Riku", Lastname = "Rinne", Number = 1, Position = "Maalivahti" });

            return players;
        }
    }

    public class Player
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }
    }
}
