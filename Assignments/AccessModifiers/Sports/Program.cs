using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _8_9_18.Sports;
namespace AccessModifiers.Sports
{
    class Program:Team
    {
        //void hi()
        //{
        //    SetTeamDetails();
        //}

        static void Main(string[] args)
        {
            Console.WriteLine("Hello......");
            Console.WriteLine("Welcome to \"TOURNMENT\"");
            Team[] CurrentPlayedTeam = new Team[CricketSettings.NoOfTeamsAtaTime];
            for (int i = 0; i < CricketSettings.NoOfTeamsAtaTime; i++)
            {
                i++;
                for (int Readteam = 0; Readteam < CricketSettings.NoOfTeamsAtaTime; Readteam++)
                {

                    CurrentPlayedTeam[Readteam] = new Team();
                    CurrentPlayedTeam[Readteam].SetTeamDetails();
                }
            }
           
                Match match = new Match();
                for (int Readteam = 0; Readteam < CricketSettings.NoOfTeamsAtaTime; Readteam++)
                {
                    match.TwoTeams[Readteam] = new TeamScore();
                    match.TwoTeams[Readteam].setTeamScore(CurrentPlayedTeam[Readteam]);
                }
                match.FindWhichTeamIsWin();
                match.FindHighstScorer();
                match.FindManOfTheMatch();
                Console.ReadLine();          
        }
    }
}