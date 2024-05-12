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
    public partial class ViewDonationsForm : Form
    {
        public ViewDonationsForm()
        {
            InitializeComponent();
            DisplayDonations();
        }
        private void InitializeFormData()
        {
            if (DataStorage.Donations.Count == 0)
            {
                donationsListBox.Items.Add("No donations present");
            }
        }

        private void DisplayDonations()
        {
            foreach (var donation in DataStorage.Donations)
            {
                string donationInfo = $"Donor: {donation.DonorName}, Amount: ${donation.Amount}";
                donationsListBox.Items.Add(donationInfo);
            }
        }
    }
}
