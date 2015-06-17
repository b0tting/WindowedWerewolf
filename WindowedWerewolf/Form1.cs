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
    public partial class Menu : Form
    {
        private PlayerRoles[] defaultRoleList = new PlayerRoles[] { new PlayerRoles("Burger", PlayerRoles.ROLE_ANY_LEFT_LABEL), new PlayerRoles("Zieneres", "1"), new PlayerRoles("Weerwolf", "2")};
        private String[] defaultRoles = new String[] { "Barry", "Ziona", "Willem", "Harry", "Heroen", "Dirk"};
        public Menu()
        {
            InitializeComponent();
            roleAmount.Items.AddRange(new String[] { PlayerRoles.ROLE_ANY_LEFT_LABEL, "1", "2", "3", "4", "5", "6", "7"});

            Screen nuScreen = Screen.FromControl(this);
            foreach(Screen screen in Screen.AllScreens) {
                screenSelect.Items.Add(new ComboBoxScreenItem(screen.DeviceName, screen));
                if (screen.Equals(nuScreen))
                {
                    screenSelect.SelectedIndex = screenSelect.Items.Count - 1;
                }
            }
            roleList.Items.AddRange(defaultRoleList);
            roleName.Items.AddRange(defaultRoles);
            playerList.Items.AddRange(defaultRoles);
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
                    if (pr.name.Equals(role, StringComparison.CurrentCultureIgnoreCase))
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
                    throw new GameInitializationException("Niet genoeg spelers voor een nieuw spel");
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
                    throw new GameInitializationException("Geen rollen gedefiniëerd");
                }
                else if (roleCount > playerCount || (wildCardRole && roleCount - 1 > playerCount))
                {
                    throw new GameInitializationException("Er zijn meer rollen dan spelers!");
                }

                // EVERY DAY I'M SHUFFLING!
                Game newGame = new Game(playerList.Items.Cast<String>().ToList(), roleList.Items.Cast<PlayerRoles>().ToList());

                // Start the game already!
                GameForm g = new GameForm(newGame, ((ComboBoxScreenItem)(screenSelect.SelectedItem)).screenVal);
                g.Show(); 


            }
            catch (GameInitializationException exc)
            {
                alertBox(exc.StackTrace);
            }
        }

        private void roleAmount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Spelerlijst_Click(object sender, EventArgs e)
        {

        }

        private class ComboBoxScreenItem
        {
            public String textVal;
            public Screen screenVal;

            public ComboBoxScreenItem(String textVal, Screen screenVal)
            {
                this.textVal = textVal;
                this.screenVal = screenVal;
            }

            public override string ToString()
            {
                return textVal;
            }
        }
    }

  
}
