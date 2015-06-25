using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowedWerewolf
{
    public partial class GameForm : Form
    {
        private int DEFAULT_LINES_BEFORE_RESIZING = 15;
        private WerewolfButtons buttons;
        private bool showAll = true;
        private bool contrastMode = false;
         
        public GameForm(Game newGame, Screen screen, bool contrastMode)
        {
            this.contrastMode = contrastMode;
            InitializeComponent();
            setupCanvas(screen, contrastMode);
            
            showPlayers(newGame, contrastMode);
            correctButtons();
         
        }

        // Put screen (and form) to maximum size
        private void setupCanvas(Screen screen, bool contrastMode)
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual; 
            this.Location = screen.WorkingArea.Location;
            // Customize the form.
            this.Size = screen.Bounds.Size;
            if (!contrastMode)
            {
                Assembly asm = Assembly.GetExecutingAssembly();
                Bitmap backgroundImage = new Bitmap(asm.GetManifestResourceStream("WindowedWerewolf.Resources.banner.jpg"));
                this.BackgroundImage = backgroundImage;
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

        private void correctButtons()
        {
            // 1/8 als spacer
            int spacer = exitBox.Image.Size.Width / 8;
            exitBox.Location = new Point(this.Width - exitBox.Image.Size.Width - spacer, spacer);
            exitBox.Click += new EventHandler(killForm);
            exitBox.BackColor = Color.Transparent;
            shortShowImage.Location = new Point(this.Width - exitBox.Image.Size.Width - spacer, exitBox.Image.Size.Height + spacer + spacer);
            shortShowImage.BackColor = Color.Transparent;
            shortShowImage.MouseDown += new MouseEventHandler(roleShowAll);
        }

        private Image resizeImage(Image imgToResize, int newHeight)
        {
            Size current = imgToResize.Size;
            Size newSize = new Size((current.Width * newHeight) / current.Height, newHeight);
            return (Image)(new Bitmap(imgToResize, newSize));
        }

        private void showPlayers(Game game, bool contrastMode)
        {
            int height = this.Height;

            
            int numberOfLines = game.PlayerNames.Count <= DEFAULT_LINES_BEFORE_RESIZING ?DEFAULT_LINES_BEFORE_RESIZING : game.PlayerNames.Count;

            // Added factor to keep some black space at the bottom of the screen
            int lineHeight = height / (numberOfLines + numberOfLines / 4);
           
            buttons = new WerewolfButtons(game);

            // We start a tad lower as well
            int currentHeight = lineHeight / 4;

            // Init custom font
            ResourceFontFetcher rff = new ResourceFontFetcher();
            FontFamily ff = contrastMode ? rff.GetFontFromResource(global::WindowedWerewolf.Properties.Resources.Kirvy) : rff.GetFontFromResource(global::WindowedWerewolf.Properties.Resources.Casper);
            Font nameFont = new Font(ff, (lineHeight / 2));
             
            Image resizedRoleImage = resizeImage(global::WindowedWerewolf.Properties.Resources.weerwolven_role, lineHeight);
            Image resizedPeekImage = resizeImage(global::WindowedWerewolf.Properties.Resources.weerwolven_peek, lineHeight);

            int maxNameWidth = 0;
            int maxRoleWidth = resizedRoleImage.Size.Width;

            foreach (String playerName in game.PlayerNames)
            {
                // Add a label for the player name
                Label newName = new Label { Location = new Point(13, currentHeight), AutoSize = true, BackColor = Color.Transparent, Text = playerName, ForeColor = Color.White, Font = nameFont, UseCompatibleTextRendering  = true};
                this.Controls.Add(newName);
                maxNameWidth = newName.Width > maxNameWidth ? newName.Width : maxNameWidth;
                
                // Add a label for the player role, but hide it as of yet
                Label newRole = new Label { Location = new Point(50, currentHeight), AutoSize = true, BackColor = Color.Transparent, Text = game.Playing[playerName], ForeColor = Color.White, Font = nameFont, UseCompatibleTextRendering = true };
                this.Controls.Add(newRole);
                maxRoleWidth = newRole.Width > maxRoleWidth ? newRole.Width : maxRoleWidth;
                newRole.Hide();


                // Add an image that people can click on to reveal the role permanently
                WerewolfPictureBox roleImage = new WerewolfPictureBox { Location = new Point(50, currentHeight), BackColor = Color.Transparent, AutoSize = true, Image = resizedRoleImage, Size = resizedRoleImage.Size };
                roleImage.playerName = playerName;
                this.Controls.Add(roleImage);
                roleImage.Click += new EventHandler(roleClick);

                // Add an image that people can click on to get a quick peek
                WerewolfPictureBox peekImage = new WerewolfPictureBox { Location = new Point(600, currentHeight), BackColor = Color.Transparent, AutoSize = true, Image = resizedPeekImage, Size = resizedRoleImage.Size };
                peekImage.playerName = playerName;
                peekImage.MouseDown += new MouseEventHandler(roleShowFromName);
                peekImage.MouseUp += new MouseEventHandler(roleHideFromName);
                this.Controls.Add(peekImage);

                buttons.Add(new WerewolfGUIButton(newName, newRole, roleImage, peekImage));

                currentHeight += lineHeight + (lineHeight / 4);
            }

            // Now that we know the width, set buttons to correct location and add to screen
            int spacer = maxNameWidth / 7;
            maxNameWidth = maxNameWidth + spacer;
            maxRoleWidth = maxNameWidth + spacer + maxRoleWidth;
            foreach(WerewolfGUIButton button in buttons.getButtons()) {
                button.getRoleLabel().Location = new Point(maxNameWidth, button.getRoleLabel().Location.Y);
                button.getRoleImage().Location = new Point(maxNameWidth, button.getRoleImage().Location.Y);
                button.getPeekImage().Location = new Point(maxRoleWidth, button.getRoleImage().Location.Y);
            }
            
        }

        private void roleShowFromName(Object sender, EventArgs e)
        {
            WerewolfPictureBox peekImage = (WerewolfPictureBox)sender;
            buttons.showPlayerRole(peekImage.playerName);
        }

        private void roleHideFromName(Object sender, EventArgs e)
        {
            WerewolfPictureBox peekImage = (WerewolfPictureBox)sender;
            buttons.hidePlayerRole(peekImage.playerName);
        }


        private void roleClick(Object sender, EventArgs e)
        {
            WerewolfPictureBox roleImage = (WerewolfPictureBox)sender;
            buttons.showPlayerRole(roleImage.playerName, true);
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
                   WerewolfGUIButton button = nameButtonMap[playerName];
                   if (button.getRoleImage().Visible)
                   {
                       button.getRoleImage().Hide();
                       button.getRoleLabel().Show();
                   }
                   if(reveal) {
                       button.Revealed = true;
                       button.getPeekImage().Hide();
                   }
            }

            public void hidePlayerRole(String playerName) {
                WerewolfGUIButton button = nameButtonMap[playerName];
                if (!button.getRoleImage().Visible && !button.Revealed)
                {
                    button.getRoleImage().Show();
                    button.getRoleLabel().Hide();
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
            private PictureBox roleImage;
            private PictureBox peekImage;

            private bool revealed;

            public bool Revealed
            {
              get { return revealed; }
              set { revealed = value; }
            }

            public WerewolfGUIButton(Label playerLabel, Label roleLabel, PictureBox roleImage, PictureBox peekImage)
            {
                this.playerLabel = playerLabel;
                this.roleLabel = roleLabel;
                this.roleImage = roleImage;
                this.peekImage = peekImage;
            }
                
            public Label getPlayerLabel() {
                return playerLabel;
            }

            public Label getRoleLabel()
            { 
                return roleLabel;
            }

            public PictureBox getRoleImage()
            {
                return roleImage;
            }

            public PictureBox getPeekImage()
            {
                return peekImage;
            }
        }

        private class WerewolfPictureBox : PictureBox
        {
            public String playerName;
        }
    }
}
