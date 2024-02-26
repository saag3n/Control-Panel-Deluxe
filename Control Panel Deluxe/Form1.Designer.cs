namespace Control_Panel_Deluxe
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            categoryListBox = new ListBox();
            applicationListBox = new ListBox();
            addButton = new Button();
            removeButton = new Button();
            removeAppButton = new Button();
            categoryTextBox = new TextBox();
            browseButton = new Button();
            launchButton = new Button();
            saveButton = new Button();
            applicationNameTextBox = new TextBox();
            SuspendLayout();
            // 
            // categoryListBox
            // 
            categoryListBox.FormattingEnabled = true;
            categoryListBox.ItemHeight = 15;
            categoryListBox.Location = new Point(12, 12);
            categoryListBox.Name = "categoryListBox";
            categoryListBox.Size = new Size(192, 94);
            categoryListBox.TabIndex = 0;
            categoryListBox.SelectedIndexChanged += categoryListBox_SelectedIndexChanged;
            // 
            // applicationListBox
            // 
            applicationListBox.FormattingEnabled = true;
            applicationListBox.ItemHeight = 15;
            applicationListBox.Location = new Point(12, 186);
            applicationListBox.Name = "applicationListBox";
            applicationListBox.Size = new Size(192, 94);
            applicationListBox.TabIndex = 1;
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 141);
            addButton.Name = "addButton";
            addButton.Size = new Size(92, 39);
            addButton.TabIndex = 2;
            addButton.Text = "Add Category";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(110, 141);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(94, 39);
            removeButton.TabIndex = 3;
            removeButton.Text = "Remove Category";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // removeAppButton
            // 
            removeAppButton.Location = new Point(110, 312);
            removeAppButton.Name = "removeAppButton";
            removeAppButton.Size = new Size(94, 23);
            removeAppButton.TabIndex = 5;
            removeAppButton.Text = "Remove App";
            removeAppButton.UseVisualStyleBackColor = true;
            removeAppButton.Click += removeAppButton_Click;
            // 
            // categoryTextBox
            // 
            categoryTextBox.Location = new Point(12, 112);
            categoryTextBox.Name = "categoryTextBox";
            categoryTextBox.Size = new Size(192, 23);
            categoryTextBox.TabIndex = 6;
            // 
            // browseButton
            // 
            browseButton.Location = new Point(12, 312);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(92, 23);
            browseButton.TabIndex = 8;
            browseButton.Text = "Add App";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // launchButton
            // 
            launchButton.Location = new Point(12, 341);
            launchButton.Name = "launchButton";
            launchButton.Size = new Size(94, 23);
            launchButton.TabIndex = 9;
            launchButton.Text = "Launch";
            launchButton.UseVisualStyleBackColor = true;
            launchButton.Click += launchButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(210, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(45, 23);
            saveButton.TabIndex = 10;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // applicationNameTextBox
            // 
            applicationNameTextBox.Location = new Point(12, 283);
            applicationNameTextBox.Name = "applicationNameTextBox";
            applicationNameTextBox.Size = new Size(192, 23);
            applicationNameTextBox.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(267, 450);
            Controls.Add(applicationNameTextBox);
            Controls.Add(saveButton);
            Controls.Add(launchButton);
            Controls.Add(browseButton);
            Controls.Add(categoryTextBox);
            Controls.Add(removeAppButton);
            Controls.Add(removeButton);
            Controls.Add(addButton);
            Controls.Add(applicationListBox);
            Controls.Add(categoryListBox);
            MaximumSize = new Size(283, 489);
            MinimumSize = new Size(283, 489);
            Name = "Form1";
            Text = "Control Panel Deluxe";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox categoryListBox;
        private ListBox applicationListBox;
        private Button addButton;
        private Button removeButton;
        private Button removeAppButton;
        private TextBox categoryTextBox;
        private Button browseButton;
        private Button launchButton;
        private Button saveButton;
        private TextBox applicationNameTextBox;
    }
}
