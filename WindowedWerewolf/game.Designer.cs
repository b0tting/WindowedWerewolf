namespace WindowedWerewolf
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.exitBox = new System.Windows.Forms.PictureBox();
            this.shortShowImage = new System.Windows.Forms.PictureBox();
            this.longShowImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortShowImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.longShowImage)).BeginInit();
            this.SuspendLayout();
            // 
            // exitBox
            // 
            this.exitBox.Image = ((System.Drawing.Image)(resources.GetObject("exitBox.Image")));
            this.exitBox.Location = new System.Drawing.Point(63, 110);
            this.exitBox.Name = "exitBox";
            this.exitBox.Size = new System.Drawing.Size(256, 256);
            this.exitBox.TabIndex = 1;
            this.exitBox.TabStop = false;
            // 
            // shortShowImage
            // 
            this.shortShowImage.Image = global::WindowedWerewolf.Properties.Resources.Holidays_Werewolf_icon1;
            this.shortShowImage.Location = new System.Drawing.Point(814, 408);
            this.shortShowImage.Name = "shortShowImage";
            this.shortShowImage.Size = new System.Drawing.Size(256, 256);
            this.shortShowImage.TabIndex = 2;
            this.shortShowImage.TabStop = false;
            // 
            // longShowImage
            // 
            this.longShowImage.Image = global::WindowedWerewolf.Properties.Resources.Werewolf_icon;
            this.longShowImage.Location = new System.Drawing.Point(867, 129);
            this.longShowImage.Name = "longShowImage";
            this.longShowImage.Size = new System.Drawing.Size(256, 256);
            this.longShowImage.TabIndex = 3;
            this.longShowImage.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1556, 747);
            this.Controls.Add(this.longShowImage);
            this.Controls.Add(this.shortShowImage);
            this.Controls.Add(this.exitBox);
            this.Name = "GameForm";
            this.Text = "game";
            ((System.ComponentModel.ISupportInitialize)(this.exitBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shortShowImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.longShowImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox exitBox;
        private System.Windows.Forms.PictureBox shortShowImage;
        private System.Windows.Forms.PictureBox longShowImage;
    }
}