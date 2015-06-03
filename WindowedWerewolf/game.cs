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
        public GameForm(Game newGame)
        {

            InitializeComponent();
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            setNames(newGame.Playing);
        }

        private void setNames(SortedDictionary<String, String> playing)
        {
            int height = 13;
            int currentHeight = 0;
            foreach(String playerName in playing.Keys) {
                currentHeight += height;
                this.Controls.Add(new Label { Location = new Point(13, currentHeight), AutoSize = true, Text = playerName + " - " + playing[playerName], ForeColor = Color.White });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
