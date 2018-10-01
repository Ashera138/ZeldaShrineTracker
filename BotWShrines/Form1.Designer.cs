namespace ZeldaShrineTracker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.viewDetailBox = new System.Windows.Forms.TextBox();
            this.typeCompletionSelection = new System.Windows.Forms.ComboBox();
            this.queryLabel = new System.Windows.Forms.Label();
            this.queryInputTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.viewByDropDown = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.changesSaved = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.completionTypeDropDown = new System.Windows.Forms.ComboBox();
            this.typeCompletionLabel = new System.Windows.Forms.Label();
            this.editInstructionsLabel = new System.Windows.Forms.Label();
            this.editDetailsBox = new System.Windows.Forms.TextBox();
            this.dataToEditDropDown = new System.Windows.Forms.ComboBox();
            this.selectToEditLabel = new System.Windows.Forms.Label();
            this.shrineNameLabel = new System.Windows.Forms.Label();
            this.editDetailBox = new System.Windows.Forms.TextBox();
            this.enterAShrineToEditBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(399, 516);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.viewDetailBox);
            this.tabPage1.Controls.Add(this.typeCompletionSelection);
            this.tabPage1.Controls.Add(this.queryLabel);
            this.tabPage1.Controls.Add(this.queryInputTextBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.viewByDropDown);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(391, 490);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "View / Search";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // viewDetailBox
            // 
            this.viewDetailBox.Location = new System.Drawing.Point(39, 136);
            this.viewDetailBox.Multiline = true;
            this.viewDetailBox.Name = "viewDetailBox";
            this.viewDetailBox.ReadOnly = true;
            this.viewDetailBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.viewDetailBox.Size = new System.Drawing.Size(318, 322);
            this.viewDetailBox.TabIndex = 8;
            // 
            // typeCompletionSelection
            // 
            this.typeCompletionSelection.AllowDrop = true;
            this.typeCompletionSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeCompletionSelection.Enabled = false;
            this.typeCompletionSelection.FormattingEnabled = true;
            this.typeCompletionSelection.Items.AddRange(new object[] {
            "Blessing",
            "Combat",
            "Puzzle"});
            this.typeCompletionSelection.Location = new System.Drawing.Point(9, 89);
            this.typeCompletionSelection.Name = "typeCompletionSelection";
            this.typeCompletionSelection.Size = new System.Drawing.Size(130, 21);
            this.typeCompletionSelection.TabIndex = 7;
            this.typeCompletionSelection.Visible = false;
            this.typeCompletionSelection.SelectedIndexChanged += new System.EventHandler(this.TypeCompletionSelection_SelectedIndexChanged);
            // 
            // queryLabel
            // 
            this.queryLabel.Location = new System.Drawing.Point(6, 64);
            this.queryLabel.Name = "queryLabel";
            this.queryLabel.Size = new System.Drawing.Size(379, 23);
            this.queryLabel.TabIndex = 6;
            // 
            // queryInputTextBox
            // 
            this.queryInputTextBox.Enabled = false;
            this.queryInputTextBox.Location = new System.Drawing.Point(9, 90);
            this.queryInputTextBox.Name = "queryInputTextBox";
            this.queryInputTextBox.Size = new System.Drawing.Size(376, 20);
            this.queryInputTextBox.TabIndex = 4;
            this.queryInputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QueryInputTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "View shrines by:";
            // 
            // viewByDropDown
            // 
            this.viewByDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.viewByDropDown.FormattingEnabled = true;
            this.viewByDropDown.Items.AddRange(new object[] {
            "Shrine Name",
            "Region",
            "Type",
            "Completion",
            "Notes"});
            this.viewByDropDown.Location = new System.Drawing.Point(9, 36);
            this.viewByDropDown.Name = "viewByDropDown";
            this.viewByDropDown.Size = new System.Drawing.Size(161, 21);
            this.viewByDropDown.TabIndex = 0;
            this.viewByDropDown.SelectedIndexChanged += new System.EventHandler(this.ViewByDropDown_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.changesSaved);
            this.tabPage2.Controls.Add(this.submit);
            this.tabPage2.Controls.Add(this.completionTypeDropDown);
            this.tabPage2.Controls.Add(this.typeCompletionLabel);
            this.tabPage2.Controls.Add(this.editInstructionsLabel);
            this.tabPage2.Controls.Add(this.editDetailsBox);
            this.tabPage2.Controls.Add(this.dataToEditDropDown);
            this.tabPage2.Controls.Add(this.selectToEditLabel);
            this.tabPage2.Controls.Add(this.shrineNameLabel);
            this.tabPage2.Controls.Add(this.editDetailBox);
            this.tabPage2.Controls.Add(this.enterAShrineToEditBox);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(391, 490);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Edit";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // changesSaved
            // 
            this.changesSaved.AutoSize = true;
            this.changesSaved.Enabled = false;
            this.changesSaved.Location = new System.Drawing.Point(265, 383);
            this.changesSaved.Name = "changesSaved";
            this.changesSaved.Size = new System.Drawing.Size(84, 13);
            this.changesSaved.TabIndex = 19;
            this.changesSaved.Text = "Changes saved!";
            this.changesSaved.Visible = false;
            // 
            // submit
            // 
            this.submit.Enabled = false;
            this.submit.Location = new System.Drawing.Point(268, 399);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(83, 56);
            this.submit.TabIndex = 18;
            this.submit.Text = "Submit changes";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Visible = false;
            this.submit.Click += new System.EventHandler(this.Submit_Click);
            // 
            // completionTypeDropDown
            // 
            this.completionTypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.completionTypeDropDown.Enabled = false;
            this.completionTypeDropDown.FormattingEnabled = true;
            this.completionTypeDropDown.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.completionTypeDropDown.Location = new System.Drawing.Point(205, 314);
            this.completionTypeDropDown.Name = "completionTypeDropDown";
            this.completionTypeDropDown.Size = new System.Drawing.Size(146, 21);
            this.completionTypeDropDown.TabIndex = 17;
            this.completionTypeDropDown.Visible = false;
            this.completionTypeDropDown.SelectedIndexChanged += new System.EventHandler(this.CompletionTypeDropDown_SelectedIndexChanged);
            // 
            // typeCompletionLabel
            // 
            this.typeCompletionLabel.AutoSize = true;
            this.typeCompletionLabel.Enabled = false;
            this.typeCompletionLabel.Location = new System.Drawing.Point(221, 298);
            this.typeCompletionLabel.Name = "typeCompletionLabel";
            this.typeCompletionLabel.Size = new System.Drawing.Size(116, 13);
            this.typeCompletionLabel.TabIndex = 16;
            this.typeCompletionLabel.Text = "Select type/completion";
            this.typeCompletionLabel.Visible = false;
            // 
            // editInstructionsLabel
            // 
            this.editInstructionsLabel.AutoSize = true;
            this.editInstructionsLabel.Location = new System.Drawing.Point(27, 335);
            this.editInstructionsLabel.Name = "editInstructionsLabel";
            this.editInstructionsLabel.Size = new System.Drawing.Size(35, 13);
            this.editInstructionsLabel.TabIndex = 14;
            this.editInstructionsLabel.Text = "label3";
            // 
            // editDetailsBox
            // 
            this.editDetailsBox.Location = new System.Drawing.Point(30, 351);
            this.editDetailsBox.Multiline = true;
            this.editDetailsBox.Name = "editDetailsBox";
            this.editDetailsBox.Size = new System.Drawing.Size(207, 104);
            this.editDetailsBox.TabIndex = 13;
            // 
            // dataToEditDropDown
            // 
            this.dataToEditDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dataToEditDropDown.FormattingEnabled = true;
            this.dataToEditDropDown.Items.AddRange(new object[] {
            "Description",
            "Type",
            "Completion",
            "Notes"});
            this.dataToEditDropDown.Location = new System.Drawing.Point(30, 314);
            this.dataToEditDropDown.Name = "dataToEditDropDown";
            this.dataToEditDropDown.Size = new System.Drawing.Size(138, 21);
            this.dataToEditDropDown.TabIndex = 12;
            this.dataToEditDropDown.SelectedIndexChanged += new System.EventHandler(this.DataToEdit_SelectedIndexChanged);
            // 
            // selectToEditLabel
            // 
            this.selectToEditLabel.AutoSize = true;
            this.selectToEditLabel.Location = new System.Drawing.Point(27, 298);
            this.selectToEditLabel.Name = "selectToEditLabel";
            this.selectToEditLabel.Size = new System.Drawing.Size(141, 13);
            this.selectToEditLabel.TabIndex = 11;
            this.selectToEditLabel.Text = "Select what you wanna edit:";
            // 
            // shrineNameLabel
            // 
            this.shrineNameLabel.AutoSize = true;
            this.shrineNameLabel.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shrineNameLabel.Location = new System.Drawing.Point(131, 28);
            this.shrineNameLabel.Name = "shrineNameLabel";
            this.shrineNameLabel.Size = new System.Drawing.Size(127, 28);
            this.shrineNameLabel.TabIndex = 10;
            this.shrineNameLabel.Text = "Enter a shrine";
            // 
            // editDetailBox
            // 
            this.editDetailBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.editDetailBox.Location = new System.Drawing.Point(30, 99);
            this.editDetailBox.Multiline = true;
            this.editDetailBox.Name = "editDetailBox";
            this.editDetailBox.ReadOnly = true;
            this.editDetailBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.editDetailBox.Size = new System.Drawing.Size(337, 176);
            this.editDetailBox.TabIndex = 9;
            this.editDetailBox.TabStop = false;
            // 
            // enterAShrineToEditBox
            // 
            this.enterAShrineToEditBox.Location = new System.Drawing.Point(73, 59);
            this.enterAShrineToEditBox.Name = "enterAShrineToEditBox";
            this.enterAShrineToEditBox.Size = new System.Drawing.Size(233, 20);
            this.enterAShrineToEditBox.TabIndex = 8;
            this.enterAShrineToEditBox.TextChanged += new System.EventHandler(this.EnterAShrineToEditBox_TextChanged);
            this.enterAShrineToEditBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EnterAShrineToEditBox_KeyDown);
            // 
            // label2
            // 
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(6, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(379, 23);
            this.label2.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 543);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Breath of the Wild Shrines";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label queryLabel;
        private System.Windows.Forms.TextBox queryInputTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox viewByDropDown;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox enterAShrineToEditBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox typeCompletionSelection;
        private System.Windows.Forms.TextBox viewDetailBox;
        private System.Windows.Forms.TextBox editDetailBox;
        private System.Windows.Forms.Label shrineNameLabel;
        private System.Windows.Forms.Label selectToEditLabel;
        private System.Windows.Forms.Label editInstructionsLabel;
        private System.Windows.Forms.TextBox editDetailsBox;
        private System.Windows.Forms.ComboBox dataToEditDropDown;
        private System.Windows.Forms.Label typeCompletionLabel;
        private System.Windows.Forms.ComboBox completionTypeDropDown;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label changesSaved;
    }
}

