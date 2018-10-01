using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ZeldaShrineTracker
{
    public partial class Form1 : Form
    {
        private List<Shrine> _allShrines = new List<Shrine>();
        private readonly List<string> _shrineNames = new List<string>();
        // HashSet is used instead of a List<T> so that there will be no duplicate elements
        private readonly HashSet<string> _regions = new HashSet<string>();
        private string _queryInput;
        
        public Form1()
        {
            InitializeComponent();
            GetShrineData();
            AutoCompleteTextBox(enterAShrineToEditBox, _shrineNames);
            DisplayDefaultEditControls();
            dataToEditDropDown.HideControl();
            selectToEditLabel.HideControl();
        }

        private void GetShrineData()
        {
            _allShrines = Xml.GetShrines().ToList();

            foreach (Shrine shrine in _allShrines)
            {
                _shrineNames.Add(shrine.Name);
                _regions.Add(shrine.Region);
            }
        }

        private void AutoCompleteTextBox(TextBox textBox, IEnumerable<string> list)
        {
            textBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            var dataCollection = new AutoCompleteStringCollection();
            dataCollection.AddItems(list);
            textBox.AutoCompleteCustomSource = dataCollection;
        }

        private void ResetViewForm()
        {
            queryInputTextBox.ShowControl();
            typeCompletionSelection.HideControl();
            viewDetailBox.Clear();
            queryInputTextBox.Clear();
            typeCompletionSelection.Items.Clear();
        }

        private void SetViewTypeCompletionControls()
        {
            queryInputTextBox.HideControl();
            typeCompletionSelection.ShowControl();
        }

        private void ViewByDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetViewForm();
            switch (viewByDropDown.SelectedIndex)
            {
                case 0:
                    queryLabel.Text = "Enter a shrine name below:";
                    AutoCompleteTextBox(queryInputTextBox, _shrineNames);
                    break;
                case 1:
                    queryLabel.Text = "Enter a region below:";
                    AutoCompleteTextBox(queryInputTextBox, _regions);
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
                    DisplayData.ShowNotes(_allShrines, viewDetailBox);
                    break;
                default:
                    throw new Exception("How did this happen? There are only 5 View-By selections...");
            }
        }

        private void QueryInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            _queryInput = queryInputTextBox.Text;

            if (_shrineNames.Contains(_queryInput))
            {
                DisplayData.ShowShrineInfo(_queryInput, _allShrines, viewDetailBox);
            }
            else if (_regions.Contains(_queryInput))
            {
                DisplayData.ShowShrinesInARegion(_queryInput, _allShrines, viewDetailBox);
            }
            else
                DisplayData.ShowNotes(_queryInput, _allShrines, viewDetailBox);
        }

        private void TypeCompletionSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (viewByDropDown.SelectedIndex)
            {
                case 2:
                    switch (typeCompletionSelection.SelectedIndex)
                    {
                        case 0:
                            DisplayData.ShowAllShrinesOfType("Blessing", _allShrines, viewDetailBox);
                            break;
                        case 1:
                            DisplayData.ShowAllShrinesOfType("Combat", _allShrines, viewDetailBox);
                            break;
                        case 2:
                            DisplayData.ShowAllShrinesOfType("Puzzle", _allShrines, viewDetailBox);
                            break;
                        default:
                            throw new Exception("How did this happen? There are only 3 type cases...");
                    }

                    break;
                case 3:
                {
                    viewDetailBox.Text = typeCompletionSelection.SelectedIndex == 0 ? "Completed " : "Incomplete ";
                    viewDetailBox.Text += "shrines: " + Environment.NewLine;

                    foreach (Shrine shrine in _allShrines)
                    {
                        switch (typeCompletionSelection.SelectedIndex)
                        {
                            case 0 when shrine.Completion == "Yes":
                            case 1 when shrine.Completion == "No":
                                viewDetailBox.Text += $"{shrine.Name} - {shrine.Region}{Environment.NewLine}";
                                break;
                        }
                    }

                    break;
                }
            }
        }


        // ================
        // === EDIT TAB ===
        // ================

        private string _shrineToEdit;
        private string _updatedDetails;
        private int _shrineIndex;

        private void DisplayDefaultEditControls()
        {
            editInstructionsLabel.HideControl();
            dataToEditDropDown.ShowControl();
            selectToEditLabel.ShowControl();
            editDetailBox.HideControl();
            typeCompletionLabel.HideControl();
            completionTypeDropDown.HideControl();
            completionTypeDropDown.Items.Clear();
            changesSaved.HideControl();
        }

        private void SetEditTypeCompletionControls()
        {
            typeCompletionLabel.ShowControl();
            submit.HideControl();
            completionTypeDropDown.ShowControl();
        }

        private void EnterAShrineToEditBox_TextChanged(object sender, EventArgs e)
        {
            _shrineToEdit = enterAShrineToEditBox.Text;
        }

        private void EnterAShrineToEditBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            _shrineToEdit = enterAShrineToEditBox.Text;

            if (_shrineNames.Contains(_shrineToEdit))
            {
                for (int i = 0; i < _shrineNames.Count; i++)
                {
                    if (_shrineToEdit == _shrineNames[i])
                        _shrineIndex = i;
                }
                DisplayData.ShowShrineInfo(_shrineToEdit, _allShrines, editDetailBox);
                DisplayDefaultEditControls();
                dataToEditDropDown.SelectedIndex = -1;
            }
            else
                MessageBox.Show("That's not a valid shrine name. Try again.");
        }

        private void DataToEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayDefaultEditControls();
            submit.ShowControl();

            if (dataToEditDropDown.SelectedIndex == -1)
            {
                submit.Enabled = false;
                submit.Visible = false;
                return;
            }

            switch (dataToEditDropDown.SelectedIndex)
            {
                case 0: // Description
                    editDetailsBox.ShowControl();
                    editInstructionsLabel.ShowControl();
                    submit.ShowControl();
                    _updatedDetails = editDetailsBox.Text;
                    editInstructionsLabel.Text = $"Enter a description for {_shrineToEdit}:";
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
                    editDetailsBox.ShowControl();
                    editInstructionsLabel.ShowControl();
                    submit.ShowControl();
                    _updatedDetails = editDetailsBox.Text;
                    editInstructionsLabel.Text = $"Enter notes for {_shrineToEdit}:";
                    break;
                default:
                    throw new Exception("How did this happen? There are only 4 View-By selections...");
            }
            editDetailsBox.Clear();
            completionTypeDropDown.SelectedIndex = -1;
        }

        private string _newType;
        private string _newCompletion;

        private void CompletionTypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (completionTypeDropDown.SelectedIndex == -1)
                return;
            submit.ShowControl();
            changesSaved.HideControl();
        }

        private void Submit_Click(object sender, EventArgs e)
        {
            switch (completionTypeDropDown.Items.Count)
            {
                case 3:
                    switch (completionTypeDropDown.SelectedIndex)
                    {
                        case 0:
                            _newType = "Blessing";
                            break;
                        case 1:
                            _newType = "Combat";
                            break;
                        default:
                            _newType = "Puzzle";
                            break;
                    }

                    EditData.ChangeType(_newType, ref _allShrines, _shrineIndex);
                    break;
                case 2:
                    _newCompletion = completionTypeDropDown.SelectedIndex == 0 ? "Yes" : "No";
                    EditData.ChangeCompletion(_newCompletion, ref _allShrines, _shrineIndex);
                    break;
            }

            switch (dataToEditDropDown.SelectedIndex)
            {
                case 0:
                    _updatedDetails = editDetailsBox.Text;
                    EditData.ChangeDescription(_updatedDetails, ref _allShrines, _shrineIndex);
                    break;
                case 3:
                    _updatedDetails = editDetailsBox.Text;
                    EditData.ChangeNotes(_updatedDetails, ref _allShrines, _shrineIndex);
                    break;
            }

            submit.HideControl();
            changesSaved.ShowControl();
            editDetailsBox.Clear();
            completionTypeDropDown.SelectedIndex = -1;

            DisplayData.ShowShrineInfo(_shrineToEdit, _allShrines, editDetailBox);
            Xml.SaveChanges(_allShrines);
        }
    }
}
