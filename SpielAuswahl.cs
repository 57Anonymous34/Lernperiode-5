using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpielParadies
{
    public partial class SpielAuswahl : Form
    {
        private EingabeName eingabeForm;
        private Form1 parent;
        private string spielername;
        public SpielAuswahl(EingabeName eingabeForm, Form1 parent, string spielername)
        {
            InitializeComponent();
            label1.Text = "Chose your Game";
            this.eingabeForm = eingabeForm;
            this.parent = parent;
            this.spielername = spielername;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new TicTacToe(this).Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form2(this, spielername).Show();
            this.Hide();
        }

        private void SpielAuswahl_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }
    }
}
