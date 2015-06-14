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
    public partial class GameForm : Form
    {
        private int DEFAULT_LINES_BEFORE_RESIZING = 18;
        private WerewolfButtons buttons;
        private bool showAll = true;
         
        public GameForm(Game newGame)
        {
            InitializeComponent();
            goMaximized();
            showPlayers(newGame);
            correctButtons();
        }

        // Put screen (and form) to maximum size
        private void goMaximized() {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.Location = new Point(0, 0);
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
        }

        private void correctButtons()
        {
            exitBox.Location = new Point(this.Width - 256, 0);
            exitBox.Click += new EventHandler(killForm);
            shortShowImage.Location = new Point(this.Width - 256, 266);
            shortShowImage.MouseDown += new MouseEventHandler(roleShowAll);
        }

        private void showPlayers(Game game)
        {
            int height = this.Height;
            int lineHeight = height / DEFAULT_LINES_BEFORE_RESIZING;
            Font nameFont = new Font(new FontFamily("Verdana"), (lineHeight / 2));
            buttons = new WerewolfButtons(game);
            int currentHeight = 0;

            // Create all relevant buttons
            // Do gui stuff here, keep buttons and state in buttons object
            int maxWidth = 0;
            foreach (String playerName in game.PlayerNames)
            {
                Label newName = new Label { Location = new Point(13, currentHeight), AutoSize = true, Text = playerName, ForeColor = Color.White, Font = nameFont };
                this.Controls.Add(newName);                
                maxWidth = newName.Width > maxWidth ? newName.Width : maxWidth;
                newName.MouseDown += new MouseEventHandler(roleShowFromName);
                newName.MouseUp += new MouseEventHandler(roleHideFromName);

                Label newRole = new Label { Location = new Point(50, currentHeight), AutoSize = true, Text = WerewolfGUIButton.HIDDEN_STRING, ForeColor = Color.White, Font = nameFont };
                this.Controls.Add(newRole);
                newRole.Click += new EventHandler(roleClick);

                buttons.Add(new WerewolfGUIButton(newName, newRole));

                currentHeight += lineHeight;
            }

            // Now that we know the width, set buttons to correct location and add to screen
            foreach(WerewolfGUIButton button in buttons.getButtons()) { 
               button.getRoleLabel().Location = new Point(maxWidth + 50, button.getRoleLabel().Location.Y);
            }
            
        }

        private void roleShowFromName(Object sender, EventArgs e)
        {
            Label nameLabel = (Label)sender;
            buttons.showPlayerRole(nameLabel.Text);
        }

        private void roleHideFromName(Object sender, EventArgs e)
        {
            Label nameLabel = (Label)sender;
            buttons.hidePlayerRole(nameLabel.Text);
        }


        private void roleClick(Object sender, EventArgs e)
        {
            Label roleLabel = (Label)sender;
            String name = buttons.findNameForRoleLabel(roleLabel);
            buttons.showPlayerRole(name, true);
        }

        private void killForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roleShowAll(object sender, EventArgs e)
        {
            if (this.showAll)
            {
                buttons.showAll();
            }
            else
            {
                buttons.hideAll();
            }
            this.showAll = !this.showAll;
        }

        private class WerewolfButtons {
            private Dictionary<String, WerewolfGUIButton> nameButtonMap = new Dictionary<String, WerewolfGUIButton>();
            private Game game;

            public WerewolfButtons(Game game) {
                this.game = game;
            }

            public void Add(WerewolfGUIButton button) {
                nameButtonMap.Add(button.getPlayerLabel().Text, button);
            }

            public List<WerewolfGUIButton> getButtons() {
                return nameButtonMap.Values.ToList<WerewolfGUIButton>();
            }

            public string findNameForRoleLabel(Label roleLabel) {
                String found = null;
                foreach(WerewolfGUIButton button in nameButtonMap.Values) {
                    if(button.getRoleLabel() == roleLabel) {
                        found = button.getPlayerLabel().Text;
                    }
                }
                return found;
            }

            public void showPlayerRole(String playerName, bool reveal = false) {
                   Label roleLabel = nameButtonMap[playerName].getRoleLabel();
                   roleLabel.Text = game.getRole(playerName);
                   if(reveal) {
                       nameButtonMap[playerName].Revealed = true;
                   }
            }

            public void hidePlayerRole(String playerName) {
                WerewolfGUIButton button = nameButtonMap[playerName];
                if(!button.Revealed) {
                    button.getRoleLabel().Text = WerewolfGUIButton.HIDDEN_STRING;
                }
            }

            public void showAll() {
                foreach(WerewolfGUIButton button in nameButtonMap.Values) {
                    showPlayerRole(button.getPlayerLabel().Text);
                }
            }

            public void hideAll() {
                foreach(WerewolfGUIButton button in nameButtonMap.Values) {
                    if(!button.Revealed) {
                        hidePlayerRole(button.getPlayerLabel().Text);
                    }
                }
            }

        }

        private class WerewolfGUIButton {
            private Label playerLabel;
            private Label roleLabel;
            public static String HIDDEN_STRING = "???";

            private bool revealed;

            public bool Revealed
            {
              get { return revealed; }
              set { revealed = value; }
            }

            public WerewolfGUIButton(Label playerLabel, Label roleLabel)
            {
                this.playerLabel = playerLabel;
                this.roleLabel = roleLabel;
            }
                
            public Label getPlayerLabel() {
                return playerLabel;
            }

            public Label getRoleLabel()
            { 
                return roleLabel;
            }




        }
    }
}
