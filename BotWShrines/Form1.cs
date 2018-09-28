using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotWShrines
{
    public partial class Form1 : Form
    {
        List<Shrine> shrineList = Xml.CreateShrineList();
        List<string> shrineNames = new List<string>();
        HashSet<string> regions = new HashSet<string>();
        string queryInput;
        
        public Form1()
        {
            InitializeComponent();
            foreach (Shrine shrine in shrineList)
            {
                shrineNames.Add(shrine.Name);
                regions.Add(shrine.Region);
            }
            autoCompleteTextBox(enterAShrineToEditBox, shrineNames);
            DisplayDefaultEditControls();
            dataToEditDropDown.Enabled = false;
            dataToEditDropDown.Visible = false;
            selectToEditLabel.Enabled = false;
            selectToEditLabel.Visible = false;
        }
        private void autoCompleteTextBox(TextBox textBox, IEnumerable<string> list)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            addItems(DataCollection, list);
            textBox.AutoCompleteCustomSource = DataCollection;
        }

        public void addItems(AutoCompleteStringCollection col, IEnumerable<string> list)
        {
            foreach (string item in list)
            {
                col.Add(item);
            }
        }

        private void ResetViewForm()
        {
            queryInputTextBox.Enabled = true;
            queryInputTextBox.Visible = true;
            typeCompletionSelection.Enabled = false;
            typeCompletionSelection.Visible = false;
            viewDetailBox.Clear();
            queryInputTextBox.Clear();
            typeCompletionSelection.Items.Clear();
        }

        private void SetViewTypeCompletionControls()
        {
            queryInputTextBox.Visible = false;
            queryInputTextBox.Enabled = false;
            typeCompletionSelection.Visible = true;
            typeCompletionSelection.Enabled = true;
        }

        private void viewByDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetViewForm();
            switch (viewByDropDown.SelectedIndex)
            {
                case 0:
                    queryLabel.Text = "Enter a shrine name below:";
                    autoCompleteTextBox(queryInputTextBox, shrineNames);
                    break;
                case 1:
                    queryLabel.Text = "Enter a region below:";
                    autoCompleteTextBox(queryInputTextBox, regions);
                    break;
                case 2:
                    SetViewTypeCompletionControls();
                    queryLabel.Text = "Enter a shrine type below:";
                    typeCompletionSelection.Items.Add("Blessing");
                    typeCompletionSelection.Items.Add("Combat");
                    typeCompletionSelection.Items.Add("Puzzle");
                    break;
                case 3:
                    SetViewTypeCompletionControls();
                    queryLabel.Text = "Select search-by option from dropdown list below: ";
                    typeCompletionSelection.Items.Add("Yes");
                    typeCompletionSelection.Items.Add("No");
                    break;
                case 4:
                    queryLabel.Text = "Search for ____ in Shrine notes: ";
                    DisplayData.ShowNotes(shrineList, viewDetailBox);
                    break;
                default:
                    throw new Exception("How did this happen? There are only 5 View-By selections...");
            }
        }

        private void queryInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                queryInput = queryInputTextBox.Text;

                if (shrineNames.Contains(queryInput))
                {
                    DisplayData.ShowShrineInfo(queryInput, shrineList, viewDetailBox);
                }
                else if (regions.Contains(queryInput))
                {
                    DisplayData.ShowShrinesInARegion(queryInput, shrineList, viewDetailBox);
                }
                else
                    DisplayData.ShowNotes(queryInput, shrineList, viewDetailBox);
            }
        }

        private void typeCompletionSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewByDropDown.SelectedIndex == 2)
            {
                switch (typeCompletionSelection.SelectedIndex)
                {
                    case 0:
                        DisplayData.ShowAllShrinesOfType("Blessing", shrineList, viewDetailBox);
                        break;
                    case 1:
                        DisplayData.ShowAllShrinesOfType("Combat", shrineList, viewDetailBox);
                        break;
                    case 2:
                        DisplayData.ShowAllShrinesOfType("Puzzle", shrineList, viewDetailBox);
                        break;
                    default:
                        throw new Exception("How did this happen? There are only 3 type cases...");
                }
            }
            else if (viewByDropDown.SelectedIndex == 3)
            {
                if (typeCompletionSelection.SelectedIndex == 0)
                    viewDetailBox.Text = "Completed shrines: " + Environment.NewLine;
                else
                    viewDetailBox.Text = "Incomplete shrines: " + Environment.NewLine;

                foreach (Shrine shrine in shrineList)
                {
                    if (typeCompletionSelection.SelectedIndex == 0 && shrine.Completion == "Yes")
                    {
                        viewDetailBox.Text += shrine.Name + " - " + shrine.Region + Environment.NewLine;
                    }
                    else if (typeCompletionSelection.SelectedIndex == 1 && shrine.Completion != "Yes")
                    {
                        viewDetailBox.Text += shrine.Name + " - " + shrine.Region + Environment.NewLine;
                    }
                }
            }
        }


        // ================
        // === EDIT TAB ===
        // ================

        string shrineToEdit;
        string updatedDetails;
        int shrineIndex;

        private void DisplayDefaultEditControls()
        {
            editInstructionsLabel.Enabled = false;
            editInstructionsLabel.Visible = false;
            dataToEditDropDown.Enabled = true;
            dataToEditDropDown.Visible = true;
            selectToEditLabel.Enabled = true;
            selectToEditLabel.Visible = true;
            editDetailsBox.Enabled = false;
            editDetailsBox.Visible = false;
            typeCompletionLabel.Enabled = false;
            typeCompletionLabel.Visible = false;
            completionTypeDropDown.Enabled = false;
            completionTypeDropDown.Visible = false;
            completionTypeDropDown.Items.Clear();
            changesSaved.Enabled = false;
            changesSaved.Visible = false;
        }

        private void SetEditTypeCompletionControls()
        {
            typeCompletionLabel.Enabled = true;
            typeCompletionLabel.Visible = true;
            submit.Enabled = false;
            submit.Visible = false;
            completionTypeDropDown.Enabled = true;
            completionTypeDropDown.Visible = true;
        }

        private void enterAShrineToEditBox_TextChanged(object sender, EventArgs e)
        {
            shrineToEdit = enterAShrineToEditBox.Text;
        }

        private void enterAShrineToEditBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                shrineToEdit = enterAShrineToEditBox.Text;

                if (shrineNames.Contains(shrineToEdit))
                {
                    for (int i = 0; i < shrineNames.Count; i++)
                    {
                        if (shrineToEdit == shrineNames[i])
                            shrineIndex = i;
                    }
                    DisplayData.ShowShrineInfo(shrineToEdit, shrineList, editDetailBox);
                    DisplayDefaultEditControls();
                    dataToEditDropDown.SelectedIndex = -1;
                }
                else
                    MessageBox.Show("That's not a valid shrine name. Try again.");
            }
        }

        private void dataToEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDefaultEditControls();
            submit.Enabled = true;
            submit.Visible = true;

            if (dataToEditDropDown.SelectedIndex == -1)
            {
                submit.Enabled = false;
                submit.Visible = false;
                return;
            }

            switch (dataToEditDropDown.SelectedIndex)
            {
                case 0: // Description
                    editDetailsBox.Enabled = true;
                    editDetailsBox.Visible = true;
                    editInstructionsLabel.Enabled = true;
                    editInstructionsLabel.Visible = true;
                    submit.Enabled = true;
                    submit.Visible = true;
                    updatedDetails = editDetailsBox.Text;
                    editInstructionsLabel.Text = $"Enter a description for {shrineToEdit}:";
                    break;
                case 1: // Type
                    SetEditTypeCompletionControls();
                    typeCompletionLabel.Text = "Select a shrine type.";
                    completionTypeDropDown.Items.Add("Blessing");
                    completionTypeDropDown.Items.Add("Combat");
                    completionTypeDropDown.Items.Add("Puzzle");
                    break;
                case 2: // Completion
                    SetEditTypeCompletionControls();
                    typeCompletionLabel.Text = "Select a completion status.";
                    completionTypeDropDown.Items.Add("Yes");
                    completionTypeDropDown.Items.Add("No");
                    break;
                case 3: // Notes
                    editDetailsBox.Enabled = true;
                    editDetailsBox.Visible = true;
                    editInstructionsLabel.Enabled = true;
                    editInstructionsLabel.Visible = true;
                    submit.Enabled = true;
                    submit.Visible = true;
                    updatedDetails = editDetailsBox.Text;
                    editInstructionsLabel.Text = $"Enter notes for {shrineToEdit}:";
                    break;
                default:
                    throw new Exception("How did this happen? There are only 4 View-By selections...");
            }
            editDetailsBox.Clear();
            completionTypeDropDown.SelectedIndex = -1;
        }

        string newType;
        string newCompletion;

        private void completionTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completionTypeDropDown.SelectedIndex == -1)
                return;
            submit.Enabled = true;
            submit.Visible = true;
            changesSaved.Enabled = false;
            changesSaved.Visible = false;
        }

        private void submit_Click(object sender, EventArgs e)
        {
            if (completionTypeDropDown.Items.Count == 3)
            {
                if (completionTypeDropDown.SelectedIndex == 0)
                    newType = "Blessing";
                else if (completionTypeDropDown.SelectedIndex == 1)
                    newType = "Combat";
                else
                    newType = "Puzzle";
                EditData.ChangeType(newType, ref shrineList, shrineIndex);
            }
            else if (completionTypeDropDown.Items.Count == 2)
            {
                if (completionTypeDropDown.SelectedIndex == 0)
                    newCompletion = "Yes";
                else
                    newCompletion = "No";
                EditData.ChangeCompletion(newCompletion, ref shrineList, shrineIndex);
            }
            if (dataToEditDropDown.SelectedIndex == 0)
            {
                updatedDetails = editDetailsBox.Text;
                EditData.ChangeDescription(updatedDetails, ref shrineList, shrineIndex);
            }
            else if (dataToEditDropDown.SelectedIndex == 3)
            {
                updatedDetails = editDetailsBox.Text;
                EditData.ChangeNotes(updatedDetails, ref shrineList, shrineIndex);
            }
            submit.Enabled = false;
            submit.Visible = false;
            changesSaved.Enabled = true;
            changesSaved.Visible = true;
            editDetailsBox.Clear();
            completionTypeDropDown.SelectedIndex = -1;

            DisplayData.ShowShrineInfo(shrineToEdit, shrineList, editDetailBox);
            Xml.SaveChanges(shrineList);
        }
    }
}
