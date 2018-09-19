using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_9_18.Sports
{
    public class TeamScore : Team
    {

        public float TeamTotalScore = 0;
        //public TempTotal;
        public double BallsTaken = 0;
        public bool isWin = false;
        // public string temp_HigestScorer;

       public PlayerScore[] ScoreOfPlayer = new PlayerScore[CricketSettings.NoOfPlayers];
        public void setTeamScore(Team CurrentTeam)
        {
            Name = CurrentTeam.Name;
            Console.WriteLine("Now please enter the team \"{0}\" scores\n", Name);
            for (int count = 0; count < CricketSettings.NoOfPlayers; count++)
            {
                ScoreOfPlayer[count] = new PlayerScore();
                ScoreOfPlayer[count].PlayerDetails = CurrentTeam.Players[count];

                Console.Write("{0} how many Runs scored=", CurrentTeam.Players[count].Plrname);
                ScoreOfPlayer[count].Score = Convert.ToInt32(Console.ReadLine());

                Console.Write("{0} how many balls taken=", CurrentTeam.Players[count].Plrname);
                ScoreOfPlayer[count].BallsTaken = Convert.ToInt32(Console.ReadLine());
                BallsTaken = BallsTaken + ScoreOfPlayer[count].BallsTaken;
                TeamTotalScore = TeamTotalScore + ScoreOfPlayer[count].Score;
                CurrentTeam.Players[count].StrikeRateOfPlayer = (ScoreOfPlayer[count].Score / ScoreOfPlayer[count].BallsTaken) * 100;

                Console.WriteLine("\n");
            }
        }
       
    }
}


