using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class Team
    {
        static int _teamNumber;
        private string _name;
        private int _goalsScored;
        private int _goalsConceded;
        private int _matches;
        private int _totPoints;


        public int Matches
        {
            get
            {
                return _matches;
            }
            set
            {
                _matches = value;
            }
        }
        public int GoalsScored
        {
            get
            {
                return _goalsScored;
            }
            set
            {
                _goalsScored = value;
            }
        }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        public int GoalsConceded
        {
            get
            {
                return _goalsConceded;
            }
            set
            {
                _goalsConceded = value;
            }
        }
        public int TotPoints
        {
            get
            {
                return _totPoints;
            }
            set 
            { 
                if (value > 0)
                {
                    _totPoints = value;
                }
                else
                {
                    _totPoints = 0;
                }
                
            }
        }
        public Team()
        {
            _teamNumber++;
            
        }
        public Team(int m, int gS, int gC, int tP, string Op ,string n)
        {
            _teamNumber++;
            Name = n;
            Matches = m;
            GoalsScored = gS;
            GoalsConceded = gC;
            TotPoints = tP;

        }
        public int totPointsCalc(int gS, int gC)
        {
            if(gS > gC)
            {
                return 2;
            }
            else if(gS < gC)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
        public override string ToString()
        {
            return "\n"+_teamNumber + ": " + _name + " \nMatches: " + _matches + "\nGoalsScored: " + _goalsScored + "\nGoalsConceded: " + _goalsConceded + "\nTotalGoals: " + (_goalsScored + _goalsConceded) +"\nTotalPoints: " + _totPoints + "\n";
        }

    }
}
