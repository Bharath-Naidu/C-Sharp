using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_9_18.Sports
{
    public class Match
    {
        public Player ManOfTheMatch;
        public Player HigestScoreer;
        public TeamScore[] TwoTeams = new TeamScore[CricketSettings.NoOfTeamsAtaTime];
        public void FindWhichTeamIsWin()
        {
            
            if (TwoTeams[0].TeamTotalScore > TwoTeams[1].TeamTotalScore)
            {
                TwoTeams[0].isWin = true;
               
                DisplayTeamDetails(TwoTeams[0]);
                Console.WriteLine("{0} win by {1} runs",TwoTeams[0].Name, (TwoTeams[0].TeamTotalScore- TwoTeams[1].TeamTotalScore));
                
            }
            else
            {
                
                TwoTeams[1].isWin = true;
                DisplayTeamDetails(TwoTeams[1]);
                Console.WriteLine("{0} win by {1} runs", TwoTeams[1].Name, (TwoTeams[1].TeamTotalScore - TwoTeams[0].TeamTotalScore));
                
            }
           
        }
        public void FindHighstScorer()
        {
            float total = 0;
            HigestScoreer = new Player();

            for (int teams = 0; teams < CricketSettings.NoOfTeamsAtaTime; teams++)
            {
                for (int seq = 0; seq < CricketSettings.NoOfPlayers - 1; seq++)
                {
                    if (TwoTeams[teams].ScoreOfPlayer[seq].Score > TwoTeams[teams].ScoreOfPlayer[seq + 1].Score && total < TwoTeams[teams].ScoreOfPlayer[seq].Score)
                    {
                        total = TwoTeams[teams].ScoreOfPlayer[seq].Score;
                        HigestScoreer = TwoTeams[teams].ScoreOfPlayer[seq].PlayerDetails;
                    }
                    else if (total < TwoTeams[teams].ScoreOfPlayer[seq + 1].Score)
                    {
                        total = TwoTeams[teams].ScoreOfPlayer[seq + 1].Score;
                        HigestScoreer = TwoTeams[teams].ScoreOfPlayer[seq + 1].PlayerDetails;
                    }
                }
            }
            Console.WriteLine("The Higestscorer of match is {0}", HigestScoreer.Plrname);
        }
        
        public void FindManOfTheMatch()
        {
            float total = 0;
            ManOfTheMatch = new Player();
            for (int teams = 0; teams < CricketSettings.NoOfTeamsAtaTime; teams++)
                if (TwoTeams[teams].isWin)
                    for (int seq = 0; seq < CricketSettings.NoOfPlayers - 1; seq++)
                        if (TwoTeams[teams].ScoreOfPlayer[seq].Score > TwoTeams[teams].ScoreOfPlayer[seq + 1].Score && total < TwoTeams[teams].ScoreOfPlayer[seq].Score)
                        {
                            total = TwoTeams[teams].ScoreOfPlayer[seq].Score;
                            ManOfTheMatch= TwoTeams[teams].ScoreOfPlayer[seq].PlayerDetails;
                        }
                        else if (total < TwoTeams[teams].ScoreOfPlayer[seq + 1].Score)
                        {
                            total = TwoTeams[teams].ScoreOfPlayer[seq].Score;
                            ManOfTheMatch = TwoTeams[teams].ScoreOfPlayer[seq + 1].PlayerDetails;
                        }

            Console.WriteLine("Man of the match goes to {0}", ManOfTheMatch.Plrname);

        }
        public void DisplayTeamDetails(TeamScore T)
        {
            Console.WriteLine("| Player Name     | Score     | Balls     | Strike Rate of this match|");
            Console.WriteLine("|_________________|___________|___________|__________________________|");
            for (int count = 0; count < CricketSettings.NoOfPlayers; count++)
            {
                float st = (T.ScoreOfPlayer[count].Score / T.ScoreOfPlayer[count].BallsTaken) * 100;
                Console.WriteLine("|{0}|{1}|{2}|{3}|", T.ScoreOfPlayer[count].PlayerDetails.Plrname.ToString().PadRight(17), T.ScoreOfPlayer[count].Score.ToString().PadRight(11), T.ScoreOfPlayer[count].BallsTaken.ToString().PadRight(11), st.ToString().PadRight(26));
            }
            
        }

    }
}

