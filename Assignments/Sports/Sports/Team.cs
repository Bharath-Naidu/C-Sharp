using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_9_18.Sports
{

     public class Team
    {
        public Player[] Players = new Player[CricketSettings.NoOfPlayers];

        public string Name { get; set; }

        public void SetTeamDetails()
        {
            Console.WriteLine("Plaese Enter Team name");

            Name = Console.ReadLine().ToUpper();
            Console.WriteLine("Please enter the player details");
            for (int playerseq = 0; playerseq < Players.Length; playerseq++)
            {
                Players[playerseq] = new Player();
                Players[playerseq].Plrname = Console.ReadLine().ToUpper();
            }

        }


    }
}
