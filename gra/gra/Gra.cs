using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gra
{
    public partial class Gra : Form
    {
        
        Label pierwszytap = null;
        Label drugitap = null;

        Random random = new Random();

        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k", "d", "d", "p", "p",
            "b", "b", "v", "v", "w", "w", "z", "z", "x", "x", "a", "a",
        };

        
        private void przypiszobrazki()
        {
            
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        public Gra()
        {
            InitializeComponent();
            przypiszobrazki();
        }

        private void label_Click(object sender, EventArgs e)
        {
            
            if (timer1.Enabled == true)
                return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                
                if (clickedLabel.ForeColor == Color.Black)
                    
                    return;

                if (pierwszytap == null)
                {
                    pierwszytap = clickedLabel;
                    pierwszytap.ForeColor = Color.Black;

                    return;
                }

                drugitap = clickedLabel;
                drugitap.ForeColor = Color.Black;

                sprawdz();

                if (pierwszytap.Text == drugitap.Text)
                {
                    pierwszytap = null;
                    drugitap = null;
                    return;
                }

                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            timer1.Stop();

            
            pierwszytap.ForeColor = pierwszytap.BackColor;
            drugitap.ForeColor = drugitap.BackColor;

            
            pierwszytap = null;
            drugitap = null;
        }

        private void sprawdz()
        {
            
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                        return;
                }
            }

            MessageBox.Show("Brawo, wygrałeś :) ", "GJ");
            Close();
        }

    }
}