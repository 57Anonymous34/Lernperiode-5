using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SpielParadies
{
    public partial class EingabeName : Form
    {
       private Form1 parent;
        public EingabeName(Form1 parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        public string Spielername { get; private set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                Spielername = txtName.Text.Trim();
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                MessageBox.Show("Bitte gib deinen Namen ein.");
            }
            new SpielAuswahl(parent).Show();
            this.Hide();


        }

    }

   
}
