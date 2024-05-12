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
    public partial class EditDonorInfoForm : Form
    {
        public EditDonorInfoForm()
        {
            InitializeComponent();
        }
        private void InitializeFormData()
        {
            // Populate donationsComboBox with donations
            if (DataStorage.Donations.Count == 0)
            {
                donationsComboBox.Items.Add("No donations present");
                donationsComboBox.Enabled = false;
                nameTextBox.Enabled = false;
                saveButton.Enabled = false;
            }
            else
            {
                foreach (var donation in DataStorage.Donations)
                {
                    donationsComboBox.Items.Add($"Donation: {donation.Amount}, Donor: {donation.DonorName}");
                }
                donationsComboBox.SelectedIndex = 0; // Select the first donation by default
            }
        }

        private void DonationsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update nameTextBox with selected donor name
            if (donationsComboBox.SelectedIndex != -1)
            {
                int selectedIndex = donationsComboBox.SelectedIndex;
                var selectedDonation = DataStorage.Donations[selectedIndex];
                nameTextBox.Text = selectedDonation.DonorName;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = donationsComboBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("No donation selected.");
                return;
            }

            string name = nameTextBox.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please enter the donor's name.");
                return;
            }

            // Save updated donor name to DataStorage
            var selectedDonation = DataStorage.Donations[selectedIndex];
            selectedDonation.DonorName = name;

            MessageBox.Show("Donor Information Updated Successfully!");
        }
    }
}
