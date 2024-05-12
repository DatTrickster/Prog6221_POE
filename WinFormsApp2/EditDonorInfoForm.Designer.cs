namespace WinFormsApp2
{
    partial class EditDonorInfoForm
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
            // EditDonorInfoForm
            this.ClientSize = new Size(300, 200);
            this.Text = "Edit Donor Information";

            // donationsComboBox
            this.donationsComboBox = new ComboBox();
            this.donationsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.donationsComboBox.Location = new Point(20, 20);
            this.donationsComboBox.Size = new Size(250, 20);
            this.donationsComboBox.SelectedIndexChanged += new EventHandler(DonationsComboBox_SelectedIndexChanged);
            this.Controls.Add(this.donationsComboBox);

            // nameTextBox
            var nameLabel = new Label();
            nameLabel.Text = "Name:";
            nameLabel.Location = new Point(20, 60);
            this.Controls.Add(nameLabel);

            this.nameTextBox = new TextBox();
            this.nameTextBox.Location = new Point(20, 80);
            this.nameTextBox.Size = new Size(250, 20);
            this.Controls.Add(this.nameTextBox);

            // saveButton
            this.saveButton = new Button();
            this.saveButton.Location = new Point(100, 140);
            this.saveButton.Size = new Size(100, 30);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new EventHandler(SaveButton_Click);
            this.Controls.Add(this.saveButton);

            // Initialize form data
            InitializeFormData();
        }
        private ComboBox donationsComboBox;
        private TextBox nameTextBox;
        private Button saveButton;

    }
}