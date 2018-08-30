using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCategory
{
    public class BaseSportsCategory
    {
        /// <summary>Sport name of Base Type</summary>
        public string SportName
        {
            get; set;
        }

        /// <summary>Score Value of 'For' of Base Type</summary>
        public int ScoresOfFor
        {
            get; set;
        }

        /// <summary>Score Value of 'Against' of Base Type</summary>
        public int ScoresOfAgainst
        {
            get; set;
        }

        /// <summary>Score Difference between 'For' and 'Against'</summary>
        public int ScoresDifference
        {
            get
            {
                return Math.Abs(ScoresOfFor - ScoresOfAgainst);
            }
        }
        public BaseSportsCategory()
        {
        }
        public BaseSportsCategory(string name, int scoresF, int scoreA)
        {
            SportName = name;
            ScoresOfFor = scoresF;
            ScoresOfAgainst = scoreA;
        }

        /// <summary>Override Console output string format</summary>
        public override string ToString()
        {
            return "Team Name: " + SportName + ", For: " + ScoresOfFor + ", Against: " + ScoresOfAgainst + ", Difference: " + ScoresDifference;
        }
    }
}
