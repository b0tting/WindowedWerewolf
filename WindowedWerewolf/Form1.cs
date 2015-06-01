using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowedWerewolf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            roleAmount.Items.AddRange(new String[] { PlayerRoles.ROLE_ANY_LEFT_LABEL, "1", "2", "3", "4", "5"});
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addPlayer_Click(object sender, EventArgs e)
        {
            String name = playerName.Text.Trim();
            if (name.Length > 0 && !playerList.Items.Contains(name))
            {
                playerName.Text = "";
                playerList.Items.Add(name);
            }
        }

        private void addRole_Click(object sender, EventArgs e)
        {
            String role = roleName.Text.Trim();
            if (role.Length > 0 && roleAmount.SelectedIndex >= 0)
            {
                PlayerRoles newPr = new PlayerRoles(role, roleAmount.SelectedItem.ToString());

                // Vervang rol als hij al bestaat door de nieuwe suggestie
                PlayerRoles removePr = null;
                foreach (PlayerRoles pr in roleList.Items)
                {
                    if (pr.name.Equals(role))
                    {
                        removePr = pr;
                    }
                }
                if (removePr != null)
                {
                    roleList.Items.Remove(removePr);
                }

                // En als we toch itereren, check dat er niet een tweede wildcard wordt toegevoegd. 
                bool alreadyGotWildcard = false;
                foreach (PlayerRoles pr in roleList.Items)
                {
                    if (pr.isWildCardRole())
                    {
                        alreadyGotWildcard = true;
                    }
                }
                if (alreadyGotWildcard && newPr.isWildCardRole())
                {
                    alertBox("Er mag maar één rol zijn met 'overige' aantal");
                }
                else
                {
                    roleList.Items.Add(newPr);
                }
            }
        }

        private void deleteSelectedItems(CheckedListBox clb)
        {
            while (clb.CheckedItems.Count > 0)
            {
                clb.Items.RemoveAt(clb.CheckedIndices[0]);
            }               
        
        }

        private void deleteSelectedPlayer_Click(object sender, EventArgs e)
        {
            deleteSelectedItems(playerList);
        }

        private void deleteSelectedRoles_Click(object sender, EventArgs e)
        {
            deleteSelectedItems(roleList);
        }

        private void alertBox(String message)
        {
            MessageBox.Show(message, "Start spel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Eerst controleren of er spelers zijn
                int playerCount = playerList.Items.Count;
                if (playerCount < 1)
                {
                    throw new Exception("Niet genoeg spelers voor een nieuw spel");
                }

                // Dan controleren of er wel rollen zijn, iets moeilijker..
                bool wildCardRole = false;
                int roleCount = 0;
                for (int i = 0; i < roleList.Items.Count; i++)
                {
                    PlayerRoles pr = (PlayerRoles)roleList.Items[i];
                    if (pr.isWildCardRole())
                    {
                        wildCardRole = true;
                    }
                    else
                    {
                        roleCount += pr.amount;
                    }
                }
                if (roleCount < 1 && !wildCardRole)
                {
                    throw new Exception("Geen rollen gedefiniëerd");
                }

                // EVERY DAY I'M SHUFFLING!

            }
            catch (Exception exc)
            {
                alertBox(exc.Message);
            }
        }
    }

    class PlayerRoles
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

        public bool isWildCardRole() {
            return this.amount == ROLE_ANY_LEFT_AMOUNT;
        }

        public override string ToString() {
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
