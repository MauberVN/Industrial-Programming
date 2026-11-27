namespace PresentationLayer
{
    partial class AddSweetForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.kindLabel = new System.Windows.Forms.Label();
            this.kindCombo = new System.Windows.Forms.ComboBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.weightLabel = new System.Windows.Forms.Label();
            this.weightBox = new System.Windows.Forms.NumericUpDown();
            this.sugarLabel = new System.Windows.Forms.Label();
            this.sugarBox = new System.Windows.Forms.NumericUpDown();
            this.caloriesLabel = new System.Windows.Forms.Label();
            this.caloriesBox = new System.Windows.Forms.NumericUpDown();
            this.cocoaLabel = new System.Windows.Forms.Label();
            this.cocoaBox = new System.Windows.Forms.NumericUpDown();
            this.fillingLabel = new System.Windows.Forms.Label();
            this.fillingBox = new System.Windows.Forms.TextBox();
            this.flavorLabel = new System.Windows.Forms.Label();
            this.flavorBox = new System.Windows.Forms.TextBox();
            this.hasFillingLabel = new System.Windows.Forms.Label();
            this.hasFillingCheck = new System.Windows.Forms.CheckBox();
            this.fruitBaseLabel = new System.Windows.Forms.Label();
            this.fruitBaseBox = new System.Windows.Forms.TextBox();
            this.hasNutsLabel = new System.Windows.Forms.Label();
            this.hasNutsCheck = new System.Windows.Forms.CheckBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.TextBox();
            this.buttonsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.weightBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sugarBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.caloriesBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocoaBox)).BeginInit();
            this.tableLayout.SuspendLayout();
            this.buttonsPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // tableLayout
            //
            this.tableLayout.ColumnCount = 2;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayout.Controls.Add(this.kindLabel, 0, 0);
            this.tableLayout.Controls.Add(this.kindCombo, 1, 0);
            this.tableLayout.Controls.Add(this.nameLabel, 0, 1);
            this.tableLayout.Controls.Add(this.nameBox, 1, 1);
            this.tableLayout.Controls.Add(this.weightLabel, 0, 2);
            this.tableLayout.Controls.Add(this.weightBox, 1, 2);
            this.tableLayout.Controls.Add(this.sugarLabel, 0, 3);
            this.tableLayout.Controls.Add(this.sugarBox, 1, 3);
            this.tableLayout.Controls.Add(this.caloriesLabel, 0, 4);
            this.tableLayout.Controls.Add(this.caloriesBox, 1, 4);
            this.tableLayout.Controls.Add(this.cocoaLabel, 0, 5);
            this.tableLayout.Controls.Add(this.cocoaBox, 1, 5);
            this.tableLayout.Controls.Add(this.fillingLabel, 0, 6);
            this.tableLayout.Controls.Add(this.fillingBox, 1, 6);
            this.tableLayout.Controls.Add(this.flavorLabel, 0, 7);
            this.tableLayout.Controls.Add(this.flavorBox, 1, 7);
            this.tableLayout.Controls.Add(this.hasFillingLabel, 0, 8);
            this.tableLayout.Controls.Add(this.hasFillingCheck, 1, 8);
            this.tableLayout.Controls.Add(this.fruitBaseLabel, 0, 9);
            this.tableLayout.Controls.Add(this.fruitBaseBox, 1, 9);
            this.tableLayout.Controls.Add(this.hasNutsLabel, 0, 10);
            this.tableLayout.Controls.Add(this.hasNutsCheck, 1, 10);
            this.tableLayout.Controls.Add(this.colorLabel, 0, 11);
            this.tableLayout.Controls.Add(this.colorBox, 1, 11);
            this.tableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.Padding = new System.Windows.Forms.Padding(12);
            this.tableLayout.RowCount = 12;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayout.TabIndex = 0;
            //
            // kindLabel
            //
            this.kindLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.kindLabel.AutoSize = true;
            this.kindLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.kindLabel.Name = "kindLabel";
            this.kindLabel.Text = "Вид:";
            //
            // kindCombo
            //
            this.kindCombo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kindCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.kindCombo.FormattingEnabled = true;
            this.kindCombo.Name = "kindCombo";
            this.kindCombo.TabIndex = 0;
            this.kindCombo.SelectedIndexChanged += new System.EventHandler(this.kindCombo_SelectedIndexChanged);
            //
            // nameLabel
            //
            this.nameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nameLabel.AutoSize = true;
            this.nameLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Text = "Название:";
            //
            // nameBox
            //
            this.nameBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameBox.MaxLength = 80;
            this.nameBox.Name = "nameBox";
            this.nameBox.TabIndex = 1;
            //
            // weightLabel
            //
            this.weightLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.weightLabel.AutoSize = true;
            this.weightLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Text = "Вес, г:";
            //
            // weightBox
            //
            this.weightBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weightBox.DecimalPlaces = 1;
            this.weightBox.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            this.weightBox.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            this.weightBox.Value = new decimal(new int[] { 10, 0, 0, 0 });
            this.weightBox.Name = "weightBox";
            this.weightBox.TabIndex = 2;
            //
            // sugarLabel
            //
            this.sugarLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.sugarLabel.AutoSize = true;
            this.sugarLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.sugarLabel.Name = "sugarLabel";
            this.sugarLabel.Text = "Сахар, г:";
            //
            // sugarBox
            //
            this.sugarBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sugarBox.DecimalPlaces = 2;
            this.sugarBox.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.sugarBox.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            this.sugarBox.Value = new decimal(new int[] { 2, 0, 0, 0 });
            this.sugarBox.Name = "sugarBox";
            this.sugarBox.TabIndex = 3;
            //
            // caloriesLabel
            //
            this.caloriesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.caloriesLabel.AutoSize = true;
            this.caloriesLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.caloriesLabel.Name = "caloriesLabel";
            this.caloriesLabel.Text = "Калорийность, ккал/100 г:";
            //
            // caloriesBox
            //
            this.caloriesBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.caloriesBox.DecimalPlaces = 0;
            this.caloriesBox.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.caloriesBox.Maximum = new decimal(new int[] { 2000, 0, 0, 0 });
            this.caloriesBox.Value = new decimal(new int[] { 400, 0, 0, 0 });
            this.caloriesBox.Name = "caloriesBox";
            this.caloriesBox.TabIndex = 4;
            //
            // cocoaLabel
            //
            this.cocoaLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cocoaLabel.AutoSize = true;
            this.cocoaLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.cocoaLabel.Name = "cocoaLabel";
            this.cocoaLabel.Text = "Какао, %:";
            //
            // cocoaBox
            //
            this.cocoaBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cocoaBox.DecimalPlaces = 0;
            this.cocoaBox.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            this.cocoaBox.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            this.cocoaBox.Value = new decimal(new int[] { 30, 0, 0, 0 });
            this.cocoaBox.Name = "cocoaBox";
            this.cocoaBox.TabIndex = 5;
            //
            // fillingLabel
            //
            this.fillingLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fillingLabel.AutoSize = true;
            this.fillingLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.fillingLabel.Name = "fillingLabel";
            this.fillingLabel.Text = "Начинка:";
            //
            // fillingBox
            //
            this.fillingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fillingBox.MaxLength = 60;
            this.fillingBox.Name = "fillingBox";
            this.fillingBox.TabIndex = 6;
            //
            // flavorLabel
            //
            this.flavorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flavorLabel.AutoSize = true;
            this.flavorLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.flavorLabel.Name = "flavorLabel";
            this.flavorLabel.Text = "Вкус:";
            //
            // flavorBox
            //
            this.flavorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flavorBox.MaxLength = 60;
            this.flavorBox.Name = "flavorBox";
            this.flavorBox.TabIndex = 7;
            //
            // hasFillingLabel
            //
            this.hasFillingLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hasFillingLabel.AutoSize = true;
            this.hasFillingLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.hasFillingLabel.Name = "hasFillingLabel";
            this.hasFillingLabel.Text = "С начинкой:";
            //
            // hasFillingCheck
            //
            this.hasFillingCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hasFillingCheck.Text = "да";
            this.hasFillingCheck.UseVisualStyleBackColor = true;
            this.hasFillingCheck.Name = "hasFillingCheck";
            this.hasFillingCheck.TabIndex = 8;
            //
            // fruitBaseLabel
            //
            this.fruitBaseLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fruitBaseLabel.AutoSize = true;
            this.fruitBaseLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.fruitBaseLabel.Name = "fruitBaseLabel";
            this.fruitBaseLabel.Text = "Фруктовая основа:";
            //
            // fruitBaseBox
            //
            this.fruitBaseBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fruitBaseBox.MaxLength = 60;
            this.fruitBaseBox.Name = "fruitBaseBox";
            this.fruitBaseBox.TabIndex = 9;
            //
            // hasNutsLabel
            //
            this.hasNutsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hasNutsLabel.AutoSize = true;
            this.hasNutsLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.hasNutsLabel.Name = "hasNutsLabel";
            this.hasNutsLabel.Text = "С орехами:";
            //
            // hasNutsCheck
            //
            this.hasNutsCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hasNutsCheck.Text = "да";
            this.hasNutsCheck.UseVisualStyleBackColor = true;
            this.hasNutsCheck.Name = "hasNutsCheck";
            this.hasNutsCheck.TabIndex = 10;
            //
            // colorLabel
            //
            this.colorLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.colorLabel.AutoSize = true;
            this.colorLabel.Margin = new System.Windows.Forms.Padding(3, 8, 8, 8);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Text = "Цвет:";
            //
            // colorBox
            //
            this.colorBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.colorBox.MaxLength = 60;
            this.colorBox.Name = "colorBox";
            this.colorBox.TabIndex = 11;
            //
            // buttonsPanel
            //
            this.buttonsPanel.AutoSize = true;
            this.buttonsPanel.Controls.Add(this.cancelButton);
            this.buttonsPanel.Controls.Add(this.okButton);
            this.buttonsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonsPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonsPanel.Name = "buttonsPanel";
            this.buttonsPanel.Padding = new System.Windows.Forms.Padding(8);
            this.buttonsPanel.TabIndex = 1;
            //
            // okButton
            //
            this.okButton.AutoSize = true;
            this.okButton.Name = "okButton";
            this.okButton.TabIndex = 0;
            this.okButton.Text = "Добавить в каталог";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            //
            // cancelButton
            //
            this.cancelButton.AutoSize = true;
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Отмена";
            this.cancelButton.UseVisualStyleBackColor = true;
            //
            // AddSweetForm
            //
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(440, 380);
            this.Controls.Add(this.tableLayout);
            this.Controls.Add(this.buttonsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSweetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новая сладость";
            ((System.ComponentModel.ISupportInitialize)(this.weightBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sugarBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.caloriesBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocoaBox)).EndInit();
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            this.buttonsPanel.ResumeLayout(false);
            this.buttonsPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.Label kindLabel;
        private System.Windows.Forms.ComboBox kindCombo;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.NumericUpDown weightBox;
        private System.Windows.Forms.Label sugarLabel;
        private System.Windows.Forms.NumericUpDown sugarBox;
        private System.Windows.Forms.Label caloriesLabel;
        private System.Windows.Forms.NumericUpDown caloriesBox;
        private System.Windows.Forms.Label cocoaLabel;
        private System.Windows.Forms.NumericUpDown cocoaBox;
        private System.Windows.Forms.Label fillingLabel;
        private System.Windows.Forms.TextBox fillingBox;
        private System.Windows.Forms.Label flavorLabel;
        private System.Windows.Forms.TextBox flavorBox;
        private System.Windows.Forms.Label hasFillingLabel;
        private System.Windows.Forms.CheckBox hasFillingCheck;
        private System.Windows.Forms.Label fruitBaseLabel;
        private System.Windows.Forms.TextBox fruitBaseBox;
        private System.Windows.Forms.Label hasNutsLabel;
        private System.Windows.Forms.CheckBox hasNutsCheck;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.TextBox colorBox;
        private System.Windows.Forms.FlowLayoutPanel buttonsPanel;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}