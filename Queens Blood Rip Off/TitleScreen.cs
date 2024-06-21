﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Queens_Blood_Rip_Off
{
    public partial class TitleScreen : UserControl
    {
        public TitleScreen()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            Form1.ChangeScreen(this, new GameScreen());
        }

        private void endButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
