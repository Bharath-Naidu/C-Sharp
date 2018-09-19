using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_9_18.Sports
{
    
    public class Player
    {
        public String Plrname;
        private float StrikeRate=20.0F;
      protected internal float StrikeRateOfPlayer { get { return StrikeRate; } set { StrikeRate = value + StrikeRate; } }

    }
}
