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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CaptureDonationButton_Click(object sender, EventArgs e)
        {
            var captureDonationForm = new CaptureDonationForm();
            captureDonationForm.ShowDialog();
        }

        private void ViewDonationsButton_Click(object sender, EventArgs e)
        {
            var viewDonationsForm = new ViewDonationsForm();
            viewDonationsForm.ShowDialog();
        }

        private void EditDonorInfoButton_Click(object sender, EventArgs e)
        {
            var editDonorInfoForm = new EditDonorInfoForm();
            editDonorInfoForm.ShowDialog();
        }
    }
}
