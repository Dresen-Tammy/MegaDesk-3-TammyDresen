using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MegaDesk_3_TammyDresen
{
    public partial class AddQuote : Form
    {
        public AddQuote()
        {
            InitializeComponent();
        }

        private void cancelQuote_Click(object sender, EventArgs e)
        {
            var mainMenu = (MainMenu)Tag;
            mainMenu.Show();
            Close();
        }

        private void submitQuote_Click(object sender, EventArgs e)
        {
            // validate fields
            if (string.IsNullOrWhiteSpace(userName.Text))
            {
                MessageBox.Show("Please fill in Your Name.");
                userName.BackColor = Color.LightPink;
            }
            else if (string.IsNullOrWhiteSpace(userWidth.Text) || !int.TryParse(userWidth.Text, out int result) || int.Parse(userWidth.Text) < 24 
                || int.Parse(userWidth.Text) > 96)
            {
                MessageBox.Show("Please fill in Width with number between 24 and 96.");
                userWidth.BackColor = Color.LightPink;
                userName.BackColor = Color.White;
            }
            else if (string.IsNullOrWhiteSpace(userDepth.Text) || int.Parse(userDepth.Text) < 12
                || int.Parse(userDepth.Text) > 48)
            {
                MessageBox.Show("Please fill in Depth with number between 12 and 48.");
                userDepth.BackColor = Color.LightPink;
                userName.BackColor = Color.White;
            }
            else
            {
                userName.BackColor = userWidth.BackColor = userDepth.BackColor = Color.White;

                // parse text fields to ints
                int width = int.Parse(userWidth.Text);
                int depth = int.Parse(userDepth.Text);
                int drawers = int.Parse(userDrawers.Text);
                int rushDays = int.Parse(userSpeed.Text);

                // instantiate new deskQuote
                DeskQuote newDeskQuote = new DeskQuote(width, depth, drawers, userFinish.Text, rushDays, userName.Text);

            }
        }

        private void userWidth_Validating(object sender, CancelEventArgs e)
        {
          
            if (!int.TryParse(userWidth.Text, out int result) || int.Parse(userWidth.Text) < 24 || int.Parse(userWidth.Text) > 96)
            {
                e.Cancel = true;
                userWidth.Select(0, userWidth.Text.Length);
                MessageBox.Show("Width must be a number between 24 and 96");
                userWidth.BackColor = Color.LightPink;
            }
            else
            {
                userWidth.BackColor = Color.White;
            }
        }

        private void userDepth_Validating(object sender, CancelEventArgs e)
        {

            if (!int.TryParse(userDepth.Text, out int result) || int.Parse(userDepth.Text) < 12 || int.Parse(userDepth.Text) > 48)
            {
                e.Cancel = true;
                userDepth.Select(0, userDepth.Text.Length);
                MessageBox.Show("Depth must be a number between 12 and 48");
                userWidth.BackColor = Color.LightPink;
            }
            else
            {
                userDepth.BackColor = Color.White;
            }
        }
        private void userDepth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void userName_TextChanged(object sender, EventArgs e)
        {
            userName.BackColor = Color.White;

        }

        private void userDepth_TextChanged(object sender, EventArgs e)
        {
            userDepth.BackColor = Color.White;
        }
    }
}
