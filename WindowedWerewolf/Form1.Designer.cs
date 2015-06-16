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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.playerList = new System.Windows.Forms.CheckedListBox();
            this.addPlayer = new System.Windows.Forms.Button();
            this.playerName = new System.Windows.Forms.TextBox();
            this.deleteSelectedPlayer = new System.Windows.Forms.Button();
            this.deleteSelectedRoles = new System.Windows.Forms.Button();
            this.roleList = new System.Windows.Forms.CheckedListBox();
            this.addRole = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.start = new System.Windows.Forms.Button();
            this.roleName = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.roleAmount = new System.Windows.Forms.ComboBox();
            this.Spelerlijst = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.screenSelect = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // playerList
            // 
            resources.ApplyResources(this.playerList, "playerList");
            this.playerList.FormattingEnabled = true;
            this.playerList.Name = "playerList";
            // 
            // addPlayer
            // 
            resources.ApplyResources(this.addPlayer, "addPlayer");
            this.addPlayer.Name = "addPlayer";
            this.addPlayer.UseVisualStyleBackColor = true;
            this.addPlayer.Click += new System.EventHandler(this.addPlayer_Click);
            // 
            // playerName
            // 
            resources.ApplyResources(this.playerName, "playerName");
            this.playerName.Name = "playerName";
            // 
            // deleteSelectedPlayer
            // 
            resources.ApplyResources(this.deleteSelectedPlayer, "deleteSelectedPlayer");
            this.deleteSelectedPlayer.BackColor = System.Drawing.SystemColors.Control;
            this.deleteSelectedPlayer.Name = "deleteSelectedPlayer";
            this.deleteSelectedPlayer.UseVisualStyleBackColor = false;
            this.deleteSelectedPlayer.Click += new System.EventHandler(this.deleteSelectedPlayer_Click);
            // 
            // deleteSelectedRoles
            // 
            resources.ApplyResources(this.deleteSelectedRoles, "deleteSelectedRoles");
            this.deleteSelectedRoles.Name = "deleteSelectedRoles";
            this.deleteSelectedRoles.UseVisualStyleBackColor = true;
            this.deleteSelectedRoles.Click += new System.EventHandler(this.deleteSelectedRoles_Click);
            // 
            // roleList
            // 
            resources.ApplyResources(this.roleList, "roleList");
            this.roleList.FormattingEnabled = true;
            this.roleList.Name = "roleList";
            // 
            // addRole
            // 
            resources.ApplyResources(this.addRole, "addRole");
            this.addRole.Name = "addRole";
            this.addRole.UseVisualStyleBackColor = true;
            this.addRole.Click += new System.EventHandler(this.addRole_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // start
            // 
            resources.ApplyResources(this.start, "start");
            this.start.Name = "start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.button1_Click);
            // 
            // roleName
            // 
            resources.ApplyResources(this.roleName, "roleName");
            this.roleName.FormattingEnabled = true;
            this.roleName.Name = "roleName";
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::WindowedWerewolf.Properties.Resources.banner;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // roleAmount
            // 
            resources.ApplyResources(this.roleAmount, "roleAmount");
            this.roleAmount.FormattingEnabled = true;
            this.roleAmount.Name = "roleAmount";
            // 
            // Spelerlijst
            // 
            resources.ApplyResources(this.Spelerlijst, "Spelerlijst");
            this.Spelerlijst.Name = "Spelerlijst";
            this.Spelerlijst.Click += new System.EventHandler(this.Spelerlijst_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // screenSelect
            // 
            resources.ApplyResources(this.screenSelect, "screenSelect");
            this.screenSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.screenSelect.FormattingEnabled = true;
            this.screenSelect.Name = "screenSelect";
            // 
            // Menu
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.screenSelect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Spelerlijst);
            this.Controls.Add(this.roleAmount);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.roleName);
            this.Controls.Add(this.start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addRole);
            this.Controls.Add(this.deleteSelectedRoles);
            this.Controls.Add(this.roleList);
            this.Controls.Add(this.deleteSelectedPlayer);
            this.Controls.Add(this.playerName);
            this.Controls.Add(this.addPlayer);
            this.Controls.Add(this.playerList);
            this.Name = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button addRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.ComboBox roleName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox roleAmount;
        private System.Windows.Forms.Label Spelerlijst;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox screenSelect;
    }
}

