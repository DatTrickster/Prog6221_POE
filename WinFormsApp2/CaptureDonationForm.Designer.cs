namespace WinFormsApp2
{
    partial class CaptureDonationForm
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
        private void InitializeComponent()
        {
            // CaptureDonationForm
            this.ClientSize = new Size(300, 400);
            this.Text = "Capture Donation";

            // amountTextBox
            var amountLabel = new Label();
            amountLabel.Text = "Donation Amount:";
            amountLabel.Location = new Point(20, 20);
            this.Controls.Add(amountLabel);

            this.amountTextBox = new TextBox();
            this.amountTextBox.Location = new Point(20, 40);
            this.amountTextBox.Size = new Size(250, 20);
            this.Controls.Add(this.amountTextBox);

            // donorNameTextBox
            var donorNameLabel = new Label();
            donorNameLabel.Text = "Donor Name:";
            donorNameLabel.Location = new Point(20, 80);
            this.Controls.Add(donorNameLabel);

            this.donorNameTextBox = new TextBox();
            this.donorNameTextBox.Location = new Point(20, 100);
            this.donorNameTextBox.Size = new Size(250, 20);
            this.Controls.Add(this.donorNameTextBox);

            // captureButton
            this.captureButton = new Button();
            this.captureButton.Location = new Point(100, 140);
            this.captureButton.Size = new Size(100, 30);
            this.captureButton.Text = "Capture";
            this.captureButton.Click += new EventHandler(CaptureButton_Click);
            this.Controls.Add(this.captureButton);

            // donationsListBox
            this.donationsListBox = new ListBox();
            this.donationsListBox.Location = new Point(20, 200);
            this.donationsListBox.Size = new Size(250, 150);
            this.Controls.Add(this.donationsListBox);
        }

        private TextBox amountTextBox;
        private TextBox donorNameTextBox;
        private Button captureButton;
        private ListBox donationsListBox;
    }
}