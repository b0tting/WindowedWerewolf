using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowedWerewolf
{
    public class PlayerRoles
    {
        public static String ROLE_ANY_LEFT_LABEL = "(overige spelers)";
        public static int ROLE_ANY_LEFT_AMOUNT = -1;

        public String name;
        public int amount;
        public PlayerRoles(String role, String amount)
        {
            this.name = role;
            if (ROLE_ANY_LEFT_LABEL.Equals(amount))
            {
                this.amount = ROLE_ANY_LEFT_AMOUNT;
            }
            else
            {
                this.amount = int.Parse(amount);
            }
        }

        public bool isWildCardRole()
        {
            return this.amount == ROLE_ANY_LEFT_AMOUNT;
        }

        public override string ToString()
        {
            if (isWildCardRole())
            {
                return this.name + " " + ROLE_ANY_LEFT_LABEL;
            }
            else
            {
                return this.name + " (" + this.amount + ")";
            }

        }
    }
}
