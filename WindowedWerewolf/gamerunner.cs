using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowedWerewolf
{
    public class Game
    {
        private List<String> playerNames;
        private SortedDictionary<String, String> playing;

        public SortedDictionary<String, String> Playing
        {
            get { return playing; }
            set { playing = value; }
        }

        public List<String> PlayerNames
        {
            get { return playerNames; }
            set { playerNames = value; }
        }
        private List<PlayerRoles> playerRoles;

        public Game(List<String> playerNames, List<PlayerRoles> playerRoles)
        {
            this.playerNames = playerNames; this.playerRoles = playerRoles;
            this.playing = new SortedDictionary<String, String>();
            shufflePlayers();
        }

        

        private void shufflePlayers()
        {
            
            

            // Shuffle met een mooie lamba functie
            Random rnd = new Random();
            List<String> playersWorkArr = playerNames.OrderBy(item => rnd.Next()).ToList();

            PlayerRoles wildCard = null;
            foreach(PlayerRoles pr in playerRoles) {
                if(!pr.isWildCardRole()) {
                    List<String> playersWorkArr2 = (List<String>)playersWorkArr.Take(pr.amount).ToList();
                    foreach(String player in playersWorkArr2) {
                        playing.Add(player, pr.name);
                    }
                   playersWorkArr = (List<String>)playersWorkArr.Skip(pr.amount).ToList();
                } else {
                    wildCard = pr;
                }
            }

            if(wildCard != null) {
                foreach(String player in playersWorkArr){
                    playing.Add(player, wildCard.name);
                }
            }

        }
    }
}
