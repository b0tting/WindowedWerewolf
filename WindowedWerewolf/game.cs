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
        private String HIDDEN_STRING = "???";

        private Dictionary<Label, Label> nameRoleMap = new Dictionary<Label, Label>();
        private Dictionary<Label, Label> roleNameMap = new Dictionary<Label, Label>();
        private Game game;

        public GameForm(Game newGame)
        {
            InitializeComponent();
            goMaximized();
            this.game = newGame;
            showPlayers();
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
            shortShowImage.MouseUp += new MouseEventHandler(roleHideAll);
            longShowImage.Location = new Point(this.Width - 256, 532);
            longShowImage.Click += new EventHandler(roleShowAll);
        }

        private void showPlayers()
        {
            int height = this.Height;
            int lineHeight = height / DEFAULT_LINES_BEFORE_RESIZING;

            Font nameFont = new Font(new FontFamily("Verdana"), (lineHeight / 2));
            
            int currentHeight = 0;
            int maxWidth = 0;
            foreach(String playerName in game.PlayerNames) {
                currentHeight += lineHeight;
                Label newName = new Label { Location = new Point(13, currentHeight), AutoSize = true, Text = playerName , ForeColor = Color.White, Font = nameFont };
                newName.MouseDown += new MouseEventHandler(roleShowFromName);
                newName.MouseUp += new MouseEventHandler(roleHideFromName);
                this.Controls.Add(newName);
                maxWidth = (newName.Width > maxWidth) ? newName.Width : maxWidth;
                nameRoleMap.Add(newName, null);
            }

            // Doen we in twee loops, omdat we tevoren niet weten hoe de langste naam is
            currentHeight = 0;
            int i = 0;
            foreach (String playerName in game.PlayerNames)
            {
                currentHeight += lineHeight;
                Label newRole = new Label { Location = new Point(maxWidth + 10, currentHeight), AutoSize = true, Text = HIDDEN_STRING, ForeColor = Color.White, Font = nameFont };
                newRole.Click += new EventHandler(roleClick);
                this.Controls.Add(newRole);
                nameRoleMap[nameRoleMap.Keys.ElementAt(i)] = newRole;
                roleNameMap.Add(newRole, nameRoleMap.Keys.ElementAt(i));
                i++;
            }
        }

        private void roleShowFromName(Object sender, EventArgs e)
        {
            Label nameLabel = (Label)sender;
            Label role = nameRoleMap[nameLabel];
            role.Text = game.getRole(nameLabel.Text);
        }

        private void roleHideFromName(Object sender, EventArgs e)
        {
            Label nameLabel = (Label)sender;
            Label role = nameRoleMap[nameLabel];
            role.Text = HIDDEN_STRING;
        }


        private void roleClick(Object sender, EventArgs e)
        {
            Label roleLabel = (Label)sender;

            // Haal speler naam op en bijbehorende rol. 
            String playerName = roleNameMap[roleLabel].Text;
            String role = game.getRole(playerName);

            roleLabel.Text = role;
        }

        private void killForm(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roleShowAll(object sender, EventArgs e)
        {
            foreach (Label name in nameRoleMap.Keys)
            {
                Label role = nameRoleMap[name];
                role.Text = game.getRole(name.Text);
            }
        }

        private void roleHideAll(object sender, EventArgs e)
        {
            foreach (Label role in roleNameMap.Keys)
            {
                role.Text = HIDDEN_STRING;
            }
        }
    }
}
