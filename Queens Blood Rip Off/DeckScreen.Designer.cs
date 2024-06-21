namespace Queens_Blood_Rip_Off
{
    partial class DeckScreen
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTick = new System.Windows.Forms.Timer(this.components);
            this.deckSizeLabel = new System.Windows.Forms.Label();
            this.NextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameTick
            // 
            this.gameTick.Enabled = true;
            this.gameTick.Interval = 20;
            this.gameTick.Tick += new System.EventHandler(this.gameTick_Tick);
            // 
            // deckSizeLabel
            // 
            this.deckSizeLabel.AutoSize = true;
            this.deckSizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deckSizeLabel.Location = new System.Drawing.Point(969, 211);
            this.deckSizeLabel.Name = "deckSizeLabel";
            this.deckSizeLabel.Size = new System.Drawing.Size(59, 29);
            this.deckSizeLabel.TabIndex = 0;
            this.deckSizeLabel.Text = "0/15";
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(955, 272);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(96, 33);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "Next";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // DeckScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.deckSizeLabel);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DeckScreen";
            this.Size = new System.Drawing.Size(1082, 688);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DeckScreen_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DeckScreen_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DeckScreen_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTick;
        private System.Windows.Forms.Label deckSizeLabel;
        private System.Windows.Forms.Button NextButton;
    }
}
