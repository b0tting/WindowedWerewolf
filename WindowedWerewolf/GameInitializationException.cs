using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowedWerewolf
{
    public class GameInitializationException : Exception
    {
        public GameInitializationException(String message):base(message)
        {
        }
    }
}
