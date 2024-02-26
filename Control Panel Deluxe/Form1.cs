using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Control_Panel_Deluxe
{

    public partial class Form1 : Form
    {
        private Dictionary<string, List<Applications>> categories;
        private string dataFilePath = "data.json";


        public Form1()
        {
            InitializeComponent();
            categories = new Dictionary<string, List<Applications>>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataFromFile();
            UpdateCategoryListBox();
        }

        private void LoadDataFromFile()
        {
            try
            {
                if (File.Exists(dataFilePath))
                {
                    string jsonData = File.ReadAllText(dataFilePath);
                    categories = JsonConvert.DeserializeObject<Dictionary<string, List<Applications>>>(jsonData);

                    // Update the category list box
                    UpdateCategoryListBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data from file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDataToFile()
        {
            try
            {
                // Serialize the categories dictionary to JSON and save it to the file
                string jsonData = JsonConvert.SerializeObject(categories, Formatting.Indented);
                File.WriteAllText(dataFilePath, jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving data to file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCategoryListBox()
        {
            categoryListBox.Items.Clear();
            foreach (var category in categories.Keys)
            {
                categoryListBox.Items.Add(category);
            }
        }

        private void categoryListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            applicationListBox.Items.Clear();

            if (categoryListBox.SelectedItem != null)
            {
                string selectedCategory = categoryListBox.SelectedItem.ToString();
                if (categories.ContainsKey(selectedCategory))
                {
                    foreach (var app in categories[selectedCategory])
                    {
                        applicationListBox.Items.Add(app.Name); // Add the custom application name to the list box
                    }
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string newCategory = categoryTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(newCategory) && !categories.ContainsKey(newCategory))
            {
                categories.Add(newCategory, new List<Applications>());
                UpdateCategoryListBox();
                SaveDataToFile();
            }
            categoryTextBox.Clear();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (categoryListBox.SelectedItem != null)
            {
                string selectedCategory = categoryListBox.SelectedItem.ToString();
                categories.Remove(selectedCategory);
                UpdateCategoryListBox();
                SaveDataToFile();
            }
        }

        private void removeAppButton_Click(object sender, EventArgs e)
        {
            if (categoryListBox.SelectedItem != null && applicationListBox.SelectedItem != null)
            {
                string selectedCategory = categoryListBox.SelectedItem.ToString();
                string selectedAppName = applicationListBox.SelectedItem.ToString();
                var apps = categories[selectedCategory];

                for (var i = 0; i < apps.Count; i++) 
                { 
                    var app = apps[i];
                    if (app.Name == selectedAppName)
                    {
                        apps.Remove(app);
                    }    
                }
                SaveDataToFile();
            }
        }

        private void launchButton_Click(object sender, EventArgs e)
        {
            if (categoryListBox.SelectedItem != null && applicationListBox.SelectedItem != null)
            {
                string selectedCategory = categoryListBox.SelectedItem.ToString();
                string selectedAppName = applicationListBox.SelectedItem.ToString();

                var apps = categories[selectedCategory];

                for (var i = 0; i < apps.Count; i++)
                {
                    var app = apps[i];
                    if (app.Name == selectedAppName)
                    {
                        if (File.Exists(app.applicationFilePath))
                        {
                            Process.Start(app.applicationFilePath);
                        }
                        else
                        {
                            MessageBox.Show("The selected application doesn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            if (categoryListBox.SelectedItem != null) // Check if a category is selected
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Executable Files (*.exe)|*.exe";
                openFileDialog.Title = "Select Application Executable";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedAppFilePath = openFileDialog.FileName;
                    string appName = Path.GetFileNameWithoutExtension(selectedAppFilePath); // Extract the application name from the file path

                    // Prompt the user for the application name
                    string customAppName = PromptForApplicationName(appName);
                    if (!string.IsNullOrWhiteSpace(customAppName) && !categories[categoryListBox.SelectedItem.ToString()].Any(app => app.Name == customAppName)) // Ensure a valid custom name is provided
                    {
                        var app = new Applications(selectedAppFilePath, customAppName);
                        applicationListBox.Items.Add(customAppName); // Add the custom application name to the list box
                        categories[categoryListBox.SelectedItem.ToString()].Add(app); // Add the file path to the selected category

                        // Save both the file path and the custom name to the data file
                        
                        SaveDataToFile();
                    }
                    else
                    {
                        MessageBox.Show("Please enter a valid application name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                }
            }
            else
            {
                MessageBox.Show("Please select a category before adding an application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string PromptForApplicationName(string defaultName)
        {
            string customAppName = defaultName;
            // Display a MessageBox prompt to get the custom application name
            DialogResult result = MessageBox.Show($"Enter the name for the application:\n(Default: {defaultName})", "Enter Application Name", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                // Prompt the user to enter a custom application name
                customAppName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name for the application:", "Enter Application Name", defaultName);
            }
            return customAppName;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveDataToFile();
            MessageBox.Show("Data saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveDataToFile();
        }
    }

    public class Applications
    {
        public string applicationFilePath;
        public string Name;
        public Applications(string applicationFilePath, string Name)
        {
            this.applicationFilePath = applicationFilePath;
            this.Name = Name;
        }
    }
}
