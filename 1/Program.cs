using System.Diagnostics.Metrics;

namespace _1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Team footBall = new Team();
            //footBall.GoalsScored = 3;
            //footBall.GoalsConceded = 2;
            //footBall.Matches = 2;
            //footBall.TotPoints = footBall.totPointsCalc(footBall.GoalsScored, footBall.GoalsConceded);
            //Console.WriteLine(footBall.ToString());
            //Team footBall2 = new Team();
            //footBall2.GoalsScored = 2;
            //footBall2.GoalsConceded = 2;
            //footBall2.TotPoints = footBall2.CalculateGoalPerformance(footBall2.GoalsScored, footBall2.GoalsConceded);
            //Console.WriteLine(footBall2.ToString());
            List<string> league = new List<string>();
            List<string> homeNames = new List<string>();
            List<string> awayNames = new List<string>();
            List<string> homeGoals = new List<string>();
            List<string> awayGoals = new List<string>();
            List<string> allNames = new List<string>();
            List<int> allTeamPoints = new List<int>();
            List<int> allGoals = new List<int>();
            List<int> allConceded = new List<int>();
            string path = @"../../../results.csv";

            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string readIn = sr.ReadLine();
            while (readIn != null)
            {
                league = readIn.Split(',').ToList();
                if (league.Count == 4)
                {
                        
                    homeNames.Add(league[0].Trim(' '));
                    homeGoals.Add(league[2].Trim(' '));
                        
                    awayNames.Add(league[1].Trim(' '));
                    awayGoals.Add(league[3].Trim(' '));
                        
                }
                readIn = sr.ReadLine();
            }

            
            foreach (string name in homeNames)
            {
                int matchCounter = 0;
                int goalCounter = 0;
                int concededCounter = 0;
                int totPointsCounter = 0;
                Team footBall = new Team();
                footBall.Name = name;
                if (!allNames.Contains(name))
                { 
                    for (int i = 0; i < homeNames.Count; i++)
                    {
                        if (homeNames[i].Contains(name))
                        {
                            goalCounter += int.Parse(homeGoals[homeNames.IndexOf(name)]);
                        
                            concededCounter += int.Parse(awayGoals[homeNames.IndexOf(name)]);
                            matchCounter += 1;
                            footBall.GoalsScored = int.Parse(homeGoals[homeNames.IndexOf(name)]);
                            footBall.GoalsConceded = int.Parse(awayGoals[homeNames.IndexOf(name)]);
                            

                            totPointsCounter += footBall.totPointsCalc(footBall.GoalsScored, footBall.GoalsConceded);
                            footBall.TotPoints = totPointsCounter;

                        }
                        if (awayNames[i].Contains(name))
                        {
                            goalCounter += int.Parse(awayGoals[awayNames.IndexOf(name)]);
                            concededCounter += int.Parse(homeGoals[awayNames.IndexOf(name)]);
                            matchCounter += 1;

                            footBall.GoalsScored = int.Parse(awayGoals[awayNames.IndexOf(name)]);
                            footBall.GoalsConceded = int.Parse(homeGoals[awayNames.IndexOf(name)]);

                            totPointsCounter += footBall.totPointsCalc(footBall.GoalsScored, footBall.GoalsConceded);
                            footBall.TotPoints = totPointsCounter;
                        }

                        footBall.GoalsScored = goalCounter;
                        footBall.GoalsConceded = concededCounter;
                        footBall.Matches = matchCounter;
                    }
                    allNames.Add(name);
                    allGoals.Add(footBall.GoalsScored);
                    allConceded.Add(footBall.GoalsConceded);
                    allTeamPoints.Add(totPointsCounter);
                }
                

                Console.WriteLine("**********************");
                Console.WriteLine(footBall.ToString());
            }
            int mostGoals = allGoals.IndexOf(allGoals.Max());
            Console.WriteLine($"Most Goals: {allNames[mostGoals]}");
            int bestDefence = allConceded.IndexOf(allConceded.Min());
            Console.WriteLine($"Best defence: {allNames[bestDefence]}");
            int winningTeam = allTeamPoints.IndexOf(allTeamPoints.Max());
            Console.WriteLine($"Winning Team: {allNames[winningTeam]}");
        }
    }
}