using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class CaptureDonationForm : Form
    {
        public CaptureDonationForm()
        {
            InitializeComponent();
        }
        private void CaptureButton_Click(object sender, EventArgs e)
        {
            decimal amount;
            string donorName = donorNameTextBox.Text;

            if (string.IsNullOrWhiteSpace(donorName))
            {
                MessageBox.Show("Please enter the donor's name.");
                return;
            }

            if (!decimal.TryParse(amountTextBox.Text, out amount) || amount <= 0)
            {
                MessageBox.Show("Please enter a valid donation amount.");
                return;
            }

            // Capture donation with amount and donor name
            var donation = new Donation { Amount = amount, DonorName = donorName };
            DataStorage.Donations.Add(donation);
            donationsListBox.Items.Add($"Donor: {donorName}, Amount: ${amount}");
            MessageBox.Show($"Donation of ${amount} by {donorName} Captured Successfully!");
        }
    }
}
