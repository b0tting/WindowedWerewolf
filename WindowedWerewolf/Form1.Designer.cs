namespace WindowedWerewolf
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playerList = new System.Windows.Forms.CheckedListBox();
            this.addPlayer = new System.Windows.Forms.Button();
            this.playerName = new System.Windows.Forms.TextBox();
            this.deleteSelectedPlayer = new System.Windows.Forms.Button();
            this.deleteSelectedRoles = new System.Windows.Forms.Button();
            this.roleList = new System.Windows.Forms.CheckedListBox();
            this.roleAmount = new System.Windows.Forms.ListBox();
            this.addRole = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.roleName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // playerList
            // 
            this.playerList.FormattingEnabled = true;
            this.playerList.Location = new System.Drawing.Point(13, 13);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(188, 169);
            this.playerList.TabIndex = 0;
            
            // 
            // addPlayer
            // 
            this.addPlayer.Location = new System.Drawing.Point(13, 302);
            this.addPlayer.Name = "addPlayer";
            this.addPlayer.Size = new System.Drawing.Size(118, 23);
            this.addPlayer.TabIndex = 1;
            this.addPlayer.Text = "Voeg speler toe";
            this.addPlayer.UseVisualStyleBackColor = true;
            this.addPlayer.Click += new System.EventHandler(this.addPlayer_Click);
            // 
            // playerName
            // 
            this.playerName.Location = new System.Drawing.Point(13, 276);
            this.playerName.Name = "playerName";
            this.playerName.Size = new System.Drawing.Size(188, 20);
            this.playerName.TabIndex = 2;
            // 
            // deleteSelectedPlayer
            // 
            this.deleteSelectedPlayer.BackColor = System.Drawing.SystemColors.Control;
            this.deleteSelectedPlayer.Location = new System.Drawing.Point(13, 189);
            this.deleteSelectedPlayer.Name = "deleteSelectedPlayer";
            this.deleteSelectedPlayer.Size = new System.Drawing.Size(188, 23);
            this.deleteSelectedPlayer.TabIndex = 3;
            this.deleteSelectedPlayer.Text = "Verwijder";
            this.deleteSelectedPlayer.UseVisualStyleBackColor = false;
            this.deleteSelectedPlayer.Click += new System.EventHandler(this.deleteSelectedPlayer_Click);
            // 
            // deleteSelectedRoles
            // 
            this.deleteSelectedRoles.Location = new System.Drawing.Point(207, 189);
            this.deleteSelectedRoles.Name = "deleteSelectedRoles";
            this.deleteSelectedRoles.Size = new System.Drawing.Size(185, 23);
            this.deleteSelectedRoles.TabIndex = 6;
            this.deleteSelectedRoles.Text = "Verwijder";
            this.deleteSelectedRoles.UseVisualStyleBackColor = true;
            this.deleteSelectedRoles.Click += new System.EventHandler(this.deleteSelectedRoles_Click);
            // 
            // roleList
            // 
            this.roleList.FormattingEnabled = true;
            this.roleList.Location = new System.Drawing.Point(207, 13);
            this.roleList.Name = "roleList";
            this.roleList.Size = new System.Drawing.Size(185, 169);
            this.roleList.TabIndex = 4;
            // 
            // roleAmount
            // 
            this.roleAmount.FormattingEnabled = true;
            this.roleAmount.Location = new System.Drawing.Point(340, 276);
            this.roleAmount.Name = "roleAmount";
            this.roleAmount.Size = new System.Drawing.Size(52, 43);
            this.roleAmount.TabIndex = 7;
            // 
            // addRole
            // 
            this.addRole.Location = new System.Drawing.Point(207, 303);
            this.addRole.Name = "addRole";
            this.addRole.Size = new System.Drawing.Size(118, 23);
            this.addRole.TabIndex = 8;
            this.addRole.Text = "Voeg rol toe";
            this.addRole.UseVisualStyleBackColor = true;
            this.addRole.Click += new System.EventHandler(this.addRole_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Speler ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 257);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Rol";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(337, 257);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Aantal";
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(133, 386);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(117, 54);
            this.start.TabIndex = 12;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.button1_Click);
            // 
            // roleName
            // 
            this.roleName.FormattingEnabled = true;
            this.roleName.Location = new System.Drawing.Point(207, 276);
            this.roleName.Name = "roleName";
            this.roleName.Size = new System.Drawing.Size(118, 21);
            this.roleName.TabIndex = 13;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 514);
            this.Controls.Add(this.roleName);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addRole);
            this.Controls.Add(this.roleAmount);
            this.Controls.Add(this.deleteSelectedRoles);
            this.Controls.Add(this.roleList);
            this.Controls.Add(this.deleteSelectedPlayer);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.addPlayer);
            this.Controls.Add(this.playerList);
            this.Name = "Menu";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox playerList;
        private System.Windows.Forms.Button addPlayer;
        private System.Windows.Forms.TextBox playerName;
        private System.Windows.Forms.Button deleteSelectedPlayer;
        private System.Windows.Forms.Button deleteSelectedRoles;
        private System.Windows.Forms.CheckedListBox roleList;
        private System.Windows.Forms.ListBox roleAmount;
        private System.Windows.Forms.Button addRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ComboBox roleName;
    }
}

