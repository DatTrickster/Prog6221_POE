namespace WinFormsApp2
{
    partial class ViewDonationsForm
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
            // ViewDonationsForm
            this.ClientSize = new Size(500, 400);
            this.Text = "View Donations";

            // donationsListBox
            this.donationsListBox = new ListBox();
            this.donationsListBox.Location = new Point(20, 20);
            this.donationsListBox.Size = new Size(460, 340);
            this.Controls.Add(this.donationsListBox);

            // Initialize form data
            InitializeFormData();
        }
        private ListBox donationsListBox;
        #endregion
    }
}