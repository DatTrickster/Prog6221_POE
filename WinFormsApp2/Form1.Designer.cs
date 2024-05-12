namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.captureDonationButton = new Button();
            this.viewDonationsButton = new Button();
            this.editDonorInfoButton = new Button();

            // captureDonationButton
            this.captureDonationButton.Location = new Point(50, 50);
            this.captureDonationButton.Size = new Size(150, 30);
            this.captureDonationButton.Text = "Capture Donation";
            this.captureDonationButton.Click += new EventHandler(CaptureDonationButton_Click);

            // viewDonationsButton
            this.viewDonationsButton.Location = new Point(50, 100);
            this.viewDonationsButton.Size = new Size(150, 30);
            this.viewDonationsButton.Text = "View Donations";
            this.viewDonationsButton.Click += new EventHandler(ViewDonationsButton_Click);

            // editDonorInfoButton
            this.editDonorInfoButton.Location = new Point(50, 150);
            this.editDonorInfoButton.Size = new Size(150, 30);
            this.editDonorInfoButton.Text = "Edit Donor Info";
            this.editDonorInfoButton.Click += new EventHandler(EditDonorInfoButton_Click);

            // Form1
            this.ClientSize = new Size(250, 200);
            this.Controls.Add(this.captureDonationButton);
            this.Controls.Add(this.viewDonationsButton);
            this.Controls.Add(this.editDonorInfoButton);
            this.Text = "Home Page";
        }



        #endregion
        private Button captureDonationButton;
        private Button viewDonationsButton;
        private Button editDonorInfoButton;
    }
}