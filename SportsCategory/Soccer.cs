using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsCategory
{
    public class Soccer: BaseSportsCategory
    {
        /// <summary>Score of 'For' in Soccer game</summary>
        public int SoccerScoresF
        {
            get
            {
                return ScoresOfFor;
            }
            set { ScoresOfFor = value; }
        }
        /// <summary>Score of 'Against' in Soccer game</summary>
        public int SoccerScoresA
        {
            get
            {
                return ScoresOfAgainst;
            }
            set
            {
                ScoresOfAgainst = value;
            }
        }

        public Soccer(){}

        public Soccer(string name, string scoresF, string scoresA)
            : base(name, Int32.Parse(scoresF), Int32.Parse(scoresA))
        {
        }
    }
}
