using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LePalaisBonbonGenerator
{
    public partial class Form1 : Form
    {

        Randomizer Random = new Randomizer();
        int nbCmd;
        public Form1()
        {
            InitializeComponent();
            numericUpDown2.Value = Random.nDayPercent;
            numericUpDown3.Value = Random.dayMax;
            numericUpDown4.Value = Random.nbCmdMax;
            numericUpDown5.Value = Random.startYear;
        }

        private void GenererButton_Click(object sender, EventArgs e)
        {
            nbCmd = (int)numericUpDown1.Value;
            Random.nDayPercent = (int)numericUpDown2.Value;
            Random.dayMax = (int)numericUpDown3.Value;
            Random.nbCmdMax = (int)numericUpDown4.Value;
            Random.startYear = (int)numericUpDown5.Value;
            progressBargeneration.Maximum = nbCmd;
            progressBargeneration.Step = 1;
            GenererButton.Enabled = false;
            Random.openFile();
            for (int i = 0; i < nbCmd; i++)
            {
                Random.randomize();
                progressBargeneration.PerformStep();
            }
            Random.closefile();
            GenererButton.Enabled = true;
            progressBargeneration.Value = 0;
            MessageBox.Show("Generation Terminé!","Generation de données", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void progressBargeneration_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

     

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
