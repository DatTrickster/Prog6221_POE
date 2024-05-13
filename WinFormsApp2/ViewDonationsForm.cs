// ViewDonationsForm.cs
using System;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class ViewDonationsForm : Form
    {
        public ViewDonationsForm()
        {
            InitializeComponent();
            InitializeFormData(); // Initialize form data
            DisplayDonations();   // Display donations in the DataGridView
        }

        // Method to initialize form data
        private void InitializeFormData()
        {
            if (DataStorage.Donations.Count == 0)
            {
                MessageBox.Show("No donations present");
            }
        }

        // Method to display donations in the DataGridView
        private void DisplayDonations()
        {
            // Bind donations list to DataGridView
            dataGridView1.DataSource = DataStorage.Donations;
        }

        // Event handler for when data binding is completed for DataGridView
        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Optionally, you can perform additional tasks after data binding is completed
        }
    }
}
