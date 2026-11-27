namespace PresentationLayer
{
    partial class MainForm
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.addSweetItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.catalogGroup = new System.Windows.Forms.GroupBox();
            this.catalogLayout = new System.Windows.Forms.TableLayoutPanel();
            this.categoryRow = new System.Windows.Forms.FlowLayoutPanel();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.categoryCombo = new System.Windows.Forms.ComboBox();
            this.catalogList = new System.Windows.Forms.ListView();
            this.catalogButtonsRow = new System.Windows.Forms.FlowLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.newSweetButton = new System.Windows.Forms.Button();
            this.giftGroup = new System.Windows.Forms.GroupBox();
            this.giftLayout = new System.Windows.Forms.TableLayoutPanel();
            this.nameRow = new System.Windows.Forms.FlowLayoutPanel();
            this.nameLabel = new System.Windows.Forms.Label();
            this.giftNameBox = new System.Windows.Forms.TextBox();
            this.renameButton = new System.Windows.Forms.Button();
            this.sortRow = new System.Windows.Forms.FlowLayoutPanel();
            this.sortLabel = new System.Windows.Forms.Label();
            this.sortCombo = new System.Windows.Forms.ComboBox();
            this.descendingCheck = new System.Windows.Forms.CheckBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.filterRow = new System.Windows.Forms.FlowLayoutPanel();
            this.sugarLabel = new System.Windows.Forms.Label();
            this.sugarMin = new System.Windows.Forms.NumericUpDown();
            this.toLabel = new System.Windows.Forms.Label();
            this.sugarMax = new System.Windows.Forms.NumericUpDown();
            this.findButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.filterInfo = new System.Windows.Forms.Label();
            this.giftList = new System.Windows.Forms.ListView();
            this.giftButtonsRow = new System.Windows.Forms.FlowLayoutPanel();
            this.removeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.statsLabel = new System.Windows.Forms.Label();
            this.catalogCategoryColumn = new System.Windows.Forms.ColumnHeader();
            this.catalogNameColumn = new System.Windows.Forms.ColumnHeader();
            this.catalogWeightColumn = new System.Windows.Forms.ColumnHeader();
            this.catalogSugarColumn = new System.Windows.Forms.ColumnHeader();
            this.catalogCaloriesColumn = new System.Windows.Forms.ColumnHeader();
            this.catalogKcalColumn = new System.Windows.Forms.ColumnHeader();
            this.catalogDetailsColumn = new System.Windows.Forms.ColumnHeader();
            this.giftCategoryColumn = new System.Windows.Forms.ColumnHeader();
            this.giftNameColumn = new System.Windows.Forms.ColumnHeader();
            this.giftWeightColumn = new System.Windows.Forms.ColumnHeader();
            this.giftSugarColumn = new System.Windows.Forms.ColumnHeader();
            this.giftCaloriesColumn = new System.Windows.Forms.ColumnHeader();
            this.giftKcalColumn = new System.Windows.Forms.ColumnHeader();
            this.giftDetailsColumn = new System.Windows.Forms.ColumnHeader();
            ((System.ComponentModel.ISupportInitialize)(this.sugarMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sugarMax)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.mainLayout.SuspendLayout();
            this.catalogGroup.SuspendLayout();
            this.catalogLayout.SuspendLayout();
            this.categoryRow.SuspendLayout();
            this.catalogButtonsRow.SuspendLayout();
            this.giftGroup.SuspendLayout();
            this.giftLayout.SuspendLayout();
            this.nameRow.SuspendLayout();
            this.sortRow.SuspendLayout();
            this.filterRow.SuspendLayout();
            this.giftButtonsRow.SuspendLayout();
            this.SuspendLayout();
            // menuStrip
            //
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.fileMenu, this.catalogMenu });
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1280, 24);
            this.menuStrip.TabIndex = 0;
            // fileMenu
            //
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.newItem, this.openItem, this.saveItem, this.exportItem, this.fileSeparator, this.exitItem });
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Text = "Файл";
            // newItem
            //
            this.newItem.Name = "newItem";
            this.newItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newItem.Text = "Новый подарок";
            this.newItem.Click += new System.EventHandler(this.newItem_Click);
            // openItem
            //
            this.openItem.Name = "openItem";
            this.openItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openItem.Text = "Открыть…";
            this.openItem.Click += new System.EventHandler(this.openItem_Click);
            // saveItem
            //
            this.saveItem.Name = "saveItem";
            this.saveItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveItem.Text = "Сохранить…";
            this.saveItem.Click += new System.EventHandler(this.saveItem_Click);
            // exportItem
            //
            this.exportItem.Name = "exportItem";
            this.exportItem.Text = "Экспорт отчёта (txt)…";
            this.exportItem.Click += new System.EventHandler(this.exportItem_Click);
            // fileSeparator
            //
            this.fileSeparator.Name = "fileSeparator";
            // exitItem
            //
            this.exitItem.Name = "exitItem";
            this.exitItem.Text = "Выход";
            this.exitItem.Click += new System.EventHandler(this.exitItem_Click);
            // catalogMenu
            //
            this.catalogMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.addSweetItem });
            this.catalogMenu.Name = "catalogMenu";
            this.catalogMenu.Text = "Каталог";
            // addSweetItem
            //
            this.addSweetItem.Name = "addSweetItem";
            this.addSweetItem.Text = "Добавить сладость в каталог…";
            this.addSweetItem.Click += new System.EventHandler(this.addSweetItem_Click);
            // statusStrip
            //
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.statusLabel });
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.TabIndex = 2;
            // statusLabel
            //
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Text = "Готово";
            // mainLayout
            //
            this.mainLayout.ColumnCount = 2;
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.mainLayout.Controls.Add(this.catalogGroup, 0, 0);
            this.mainLayout.Controls.Add(this.giftGroup, 1, 0);
            this.mainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainLayout.Name = "mainLayout";
            this.mainLayout.Padding = new System.Windows.Forms.Padding(6);
            this.mainLayout.RowCount = 1;
            this.mainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mainLayout.TabIndex = 1;
            // catalogGroup
            //
            this.catalogGroup.Controls.Add(this.catalogLayout);
            this.catalogGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogGroup.Name = "catalogGroup";
            this.catalogGroup.Padding = new System.Windows.Forms.Padding(8);
            this.catalogGroup.TabIndex = 0;
            this.catalogGroup.TabStop = false;
            this.catalogGroup.Text = "Каталог сладостей";
            // giftGroup
            //
            this.giftGroup.Controls.Add(this.giftLayout);
            this.giftGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.giftGroup.Name = "giftGroup";
            this.giftGroup.Padding = new System.Windows.Forms.Padding(8);
            this.giftGroup.TabIndex = 1;
            this.giftGroup.TabStop = false;
            this.giftGroup.Text = "Подарок";
            // catalogLayout
            //
            this.catalogLayout.ColumnCount = 1;
            this.catalogLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.catalogLayout.Controls.Add(this.categoryRow, 0, 0);
            this.catalogLayout.Controls.Add(this.catalogList, 0, 1);
            this.catalogLayout.Controls.Add(this.catalogButtonsRow, 0, 2);
            this.catalogLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogLayout.Name = "catalogLayout";
            this.catalogLayout.RowCount = 3;
            this.catalogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.catalogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.catalogLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.catalogLayout.TabIndex = 0;
            // giftLayout
            //
            this.giftLayout.ColumnCount = 1;
            this.giftLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.giftLayout.Controls.Add(this.nameRow, 0, 0);
            this.giftLayout.Controls.Add(this.sortRow, 0, 1);
            this.giftLayout.Controls.Add(this.filterRow, 0, 2);
            this.giftLayout.Controls.Add(this.filterInfo, 0, 3);
            this.giftLayout.Controls.Add(this.giftList, 0, 4);
            this.giftLayout.Controls.Add(this.giftButtonsRow, 0, 5);
            this.giftLayout.Controls.Add(this.statsLabel, 0, 6);
            this.giftLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.giftLayout.Name = "giftLayout";
            this.giftLayout.RowCount = 7;
            this.giftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.giftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.giftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.giftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.giftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.giftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.giftLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.giftLayout.TabIndex = 0;
            // categoryRow
            //
            this.categoryRow.AutoSize = true;
            this.categoryRow.Controls.Add(this.categoryLabel);
            this.categoryRow.Controls.Add(this.categoryCombo);
            this.categoryRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryRow.Name = "categoryRow";
            this.categoryRow.TabIndex = 0;
            this.categoryRow.WrapContents = false;
            // categoryLabel
            //
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Text = "Категория:";
            // categoryCombo
            //
            this.categoryCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryCombo.FormattingEnabled = true;
            this.categoryCombo.Name = "categoryCombo";
            this.categoryCombo.Size = new System.Drawing.Size(220, 23);
            this.categoryCombo.TabIndex = 1;
            this.categoryCombo.SelectedIndexChanged += new System.EventHandler(this.categoryCombo_SelectedIndexChanged);
            // catalogList
            //
            this.catalogList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.catalogCategoryColumn, this.catalogNameColumn, this.catalogWeightColumn, this.catalogSugarColumn, this.catalogCaloriesColumn, this.catalogKcalColumn, this.catalogDetailsColumn });
            this.catalogList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogList.FullRowSelect = true;
            this.catalogList.GridLines = true;
            this.catalogList.HideSelection = false;
            this.catalogList.MultiSelect = false;
            this.catalogList.Name = "catalogList";
            this.catalogList.TabIndex = 2;
            this.catalogList.UseCompatibleStateImageBehavior = false;
            this.catalogList.View = System.Windows.Forms.View.Details;
            this.catalogList.DoubleClick += new System.EventHandler(this.addButton_Click);
            // catalogCategoryColumn
            //
            this.catalogCategoryColumn.Text = "Категория";
            this.catalogCategoryColumn.Width = 130;
            // catalogNameColumn
            //
            this.catalogNameColumn.Text = "Название";
            this.catalogNameColumn.Width = 170;
            // catalogWeightColumn
            //
            this.catalogWeightColumn.Text = "Вес, г";
            this.catalogWeightColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.catalogWeightColumn.Width = 60;
            // catalogSugarColumn
            //
            this.catalogSugarColumn.Text = "Сахар, г";
            this.catalogSugarColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.catalogSugarColumn.Width = 70;
            // catalogCaloriesColumn
            //
            this.catalogCaloriesColumn.Text = "ккал/100 г";
            this.catalogCaloriesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.catalogCaloriesColumn.Width = 80;
            // catalogKcalColumn
            //
            this.catalogKcalColumn.Text = "ккал (шт.)";
            this.catalogKcalColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.catalogKcalColumn.Width = 75;
            // catalogDetailsColumn
            //
            this.catalogDetailsColumn.Text = "Особенности";
            this.catalogDetailsColumn.Width = 200;
            // catalogButtonsRow
            //
            this.catalogButtonsRow.AutoSize = true;
            this.catalogButtonsRow.Controls.Add(this.addButton);
            this.catalogButtonsRow.Controls.Add(this.newSweetButton);
            this.catalogButtonsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.catalogButtonsRow.Name = "catalogButtonsRow";
            this.catalogButtonsRow.TabIndex = 0;
            this.catalogButtonsRow.WrapContents = false;
            // addButton
            //
            this.addButton.AutoSize = true;
            this.addButton.Name = "addButton";
            this.addButton.TabIndex = 0;
            this.addButton.Text = "Добавить в подарок →";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // newSweetButton
            //
            this.newSweetButton.AutoSize = true;
            this.newSweetButton.Name = "newSweetButton";
            this.newSweetButton.TabIndex = 1;
            this.newSweetButton.Text = "Новая сладость…";
            this.newSweetButton.UseVisualStyleBackColor = true;
            this.newSweetButton.Click += new System.EventHandler(this.newSweetButton_Click);
            // nameRow
            //
            this.nameRow.AutoSize = true;
            this.nameRow.Controls.Add(this.nameLabel);
            this.nameRow.Controls.Add(this.giftNameBox);
            this.nameRow.Controls.Add(this.renameButton);
            this.nameRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nameRow.Name = "nameRow";
            this.nameRow.TabIndex = 0;
            this.nameRow.WrapContents = false;
            // nameLabel
            //
            this.nameLabel.AutoSize = true;
            this.nameLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Text = "Название:";
            // giftNameBox
            //
            this.giftNameBox.MaxLength = 80;
            this.giftNameBox.Name = "giftNameBox";
            this.giftNameBox.Size = new System.Drawing.Size(260, 23);
            this.giftNameBox.TabIndex = 1;
            // renameButton
            //
            this.renameButton.AutoSize = true;
            this.renameButton.Name = "renameButton";
            this.renameButton.TabIndex = 2;
            this.renameButton.Text = "Переименовать";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // sortRow
            //
            this.sortRow.AutoSize = true;
            this.sortRow.Controls.Add(this.sortLabel);
            this.sortRow.Controls.Add(this.sortCombo);
            this.sortRow.Controls.Add(this.descendingCheck);
            this.sortRow.Controls.Add(this.sortButton);
            this.sortRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sortRow.Name = "sortRow";
            this.sortRow.TabIndex = 1;
            this.sortRow.WrapContents = false;
            // sortLabel
            //
            this.sortLabel.AutoSize = true;
            this.sortLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Text = "Сортировка:";
            // sortCombo
            //
            this.sortCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortCombo.FormattingEnabled = true;
            this.sortCombo.Items.AddRange(new object[] { "По названию", "По весу", "По содержанию сахара", "По калорийности" });
            this.sortCombo.Name = "sortCombo";
            this.sortCombo.Size = new System.Drawing.Size(170, 23);
            this.sortCombo.TabIndex = 1;
            // descendingCheck
            //
            this.descendingCheck.AutoSize = true;
            this.descendingCheck.Margin = new System.Windows.Forms.Padding(6, 5, 6, 0);
            this.descendingCheck.Name = "descendingCheck";
            this.descendingCheck.TabIndex = 2;
            this.descendingCheck.Text = "по убыванию";
            this.descendingCheck.UseVisualStyleBackColor = true;
            // sortButton
            //
            this.sortButton.AutoSize = true;
            this.sortButton.Name = "sortButton";
            this.sortButton.TabIndex = 3;
            this.sortButton.Text = "Сортировать";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // filterRow
            //
            this.filterRow.AutoSize = true;
            this.filterRow.Controls.Add(this.sugarLabel);
            this.filterRow.Controls.Add(this.sugarMin);
            this.filterRow.Controls.Add(this.toLabel);
            this.filterRow.Controls.Add(this.sugarMax);
            this.filterRow.Controls.Add(this.findButton);
            this.filterRow.Controls.Add(this.resetButton);
            this.filterRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filterRow.Name = "filterRow";
            this.filterRow.TabIndex = 2;
            this.filterRow.WrapContents = false;
            // sugarLabel
            //
            this.sugarLabel.AutoSize = true;
            this.sugarLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.sugarLabel.Name = "sugarLabel";
            this.sugarLabel.Text = "Сахар, г: от";
            // sugarMin
            //
            this.sugarMin.DecimalPlaces = 1;
            this.sugarMin.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.sugarMin.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            this.sugarMin.Name = "sugarMin";
            this.sugarMin.Size = new System.Drawing.Size(70, 23);
            this.sugarMin.TabIndex = 1;
            this.sugarMin.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // toLabel
            //
            this.toLabel.AutoSize = true;
            this.toLabel.Margin = new System.Windows.Forms.Padding(3, 7, 3, 0);
            this.toLabel.Name = "toLabel";
            this.toLabel.Text = "до";
            // sugarMax
            //
            this.sugarMax.DecimalPlaces = 1;
            this.sugarMax.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            this.sugarMax.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            this.sugarMax.Name = "sugarMax";
            this.sugarMax.Size = new System.Drawing.Size(70, 23);
            this.sugarMax.TabIndex = 3;
            this.sugarMax.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // findButton
            //
            this.findButton.AutoSize = true;
            this.findButton.Name = "findButton";
            this.findButton.TabIndex = 4;
            this.findButton.Text = "Найти";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click);
            // resetButton
            //
            this.resetButton.AutoSize = true;
            this.resetButton.Name = "resetButton";
            this.resetButton.TabIndex = 5;
            this.resetButton.Text = "Показать все";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // filterInfo
            //
            this.filterInfo.AutoSize = true;
            this.filterInfo.ForeColor = System.Drawing.Color.DarkBlue;
            this.filterInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.filterInfo.Name = "filterInfo";
            this.filterInfo.TabIndex = 3;
            // giftList
            //
            this.giftList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { this.giftCategoryColumn, this.giftNameColumn, this.giftWeightColumn, this.giftSugarColumn, this.giftCaloriesColumn, this.giftKcalColumn, this.giftDetailsColumn });
            this.giftList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.giftList.FullRowSelect = true;
            this.giftList.GridLines = true;
            this.giftList.HideSelection = false;
            this.giftList.MultiSelect = false;
            this.giftList.Name = "giftList";
            this.giftList.TabIndex = 4;
            this.giftList.UseCompatibleStateImageBehavior = false;
            this.giftList.View = System.Windows.Forms.View.Details;
            // giftCategoryColumn
            //
            this.giftCategoryColumn.Text = "Категория";
            this.giftCategoryColumn.Width = 130;
            // giftNameColumn
            //
            this.giftNameColumn.Text = "Название";
            this.giftNameColumn.Width = 170;
            // giftWeightColumn
            //
            this.giftWeightColumn.Text = "Вес, г";
            this.giftWeightColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giftWeightColumn.Width = 60;
            // giftSugarColumn
            //
            this.giftSugarColumn.Text = "Сахар, г";
            this.giftSugarColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giftSugarColumn.Width = 70;
            // giftCaloriesColumn
            //
            this.giftCaloriesColumn.Text = "ккал/100 г";
            this.giftCaloriesColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giftCaloriesColumn.Width = 80;
            // giftKcalColumn
            //
            this.giftKcalColumn.Text = "ккал (шт.)";
            this.giftKcalColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.giftKcalColumn.Width = 75;
            // giftDetailsColumn
            //
            this.giftDetailsColumn.Text = "Особенности";
            this.giftDetailsColumn.Width = 200;
            // giftButtonsRow
            //
            this.giftButtonsRow.AutoSize = true;
            this.giftButtonsRow.Controls.Add(this.removeButton);
            this.giftButtonsRow.Controls.Add(this.clearButton);
            this.giftButtonsRow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.giftButtonsRow.Name = "giftButtonsRow";
            this.giftButtonsRow.TabIndex = 5;
            this.giftButtonsRow.WrapContents = false;
            // removeButton
            //
            this.removeButton.AutoSize = true;
            this.removeButton.Name = "removeButton";
            this.removeButton.TabIndex = 0;
            this.removeButton.Text = "← Убрать из подарка";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // clearButton
            //
            this.clearButton.AutoSize = true;
            this.clearButton.Name = "clearButton";
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Очистить подарок";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // statsLabel
            //
            this.statsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.statsLabel.Name = "statsLabel";
            this.statsLabel.TabIndex = 6;
            // MainForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 700);
            this.Controls.Add(this.mainLayout);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MinimumSize = new System.Drawing.Size(1000, 560);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Конструктор подарка со сладостями";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sugarMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sugarMax)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.mainLayout.ResumeLayout(false);
            this.catalogGroup.ResumeLayout(false);
            this.catalogLayout.ResumeLayout(false);
            this.categoryRow.ResumeLayout(false);
            this.catalogButtonsRow.ResumeLayout(false);
            this.giftGroup.ResumeLayout(false);
            this.giftLayout.ResumeLayout(false);
            this.nameRow.ResumeLayout(false);
            this.sortRow.ResumeLayout(false);
            this.filterRow.ResumeLayout(false);
            this.giftButtonsRow.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.PerformLayout();
            this.categoryRow.PerformLayout();
            this.catalogButtonsRow.PerformLayout();
            this.nameRow.PerformLayout();
            this.sortRow.PerformLayout();
            this.filterRow.PerformLayout();
            this.giftButtonsRow.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem newItem;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.ToolStripMenuItem saveItem;
        private System.Windows.Forms.ToolStripMenuItem exportItem;
        private System.Windows.Forms.ToolStripSeparator fileSeparator;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.ToolStripMenuItem catalogMenu;
        private System.Windows.Forms.ToolStripMenuItem addSweetItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.TableLayoutPanel mainLayout;
        private System.Windows.Forms.GroupBox catalogGroup;
        private System.Windows.Forms.TableLayoutPanel catalogLayout;
        private System.Windows.Forms.FlowLayoutPanel categoryRow;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.ComboBox categoryCombo;
        private System.Windows.Forms.ListView catalogList;
        private System.Windows.Forms.FlowLayoutPanel catalogButtonsRow;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button newSweetButton;
        private System.Windows.Forms.GroupBox giftGroup;
        private System.Windows.Forms.TableLayoutPanel giftLayout;
        private System.Windows.Forms.FlowLayoutPanel nameRow;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.TextBox giftNameBox;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.FlowLayoutPanel sortRow;
        private System.Windows.Forms.Label sortLabel;
        private System.Windows.Forms.ComboBox sortCombo;
        private System.Windows.Forms.CheckBox descendingCheck;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.FlowLayoutPanel filterRow;
        private System.Windows.Forms.Label sugarLabel;
        private System.Windows.Forms.NumericUpDown sugarMin;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.NumericUpDown sugarMax;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label filterInfo;
        private System.Windows.Forms.ListView giftList;
        private System.Windows.Forms.FlowLayoutPanel giftButtonsRow;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label statsLabel;
        private System.Windows.Forms.ColumnHeader catalogCategoryColumn;
        private System.Windows.Forms.ColumnHeader catalogNameColumn;
        private System.Windows.Forms.ColumnHeader catalogWeightColumn;
        private System.Windows.Forms.ColumnHeader catalogSugarColumn;
        private System.Windows.Forms.ColumnHeader catalogCaloriesColumn;
        private System.Windows.Forms.ColumnHeader catalogKcalColumn;
        private System.Windows.Forms.ColumnHeader catalogDetailsColumn;
        private System.Windows.Forms.ColumnHeader giftCategoryColumn;
        private System.Windows.Forms.ColumnHeader giftNameColumn;
        private System.Windows.Forms.ColumnHeader giftWeightColumn;
        private System.Windows.Forms.ColumnHeader giftSugarColumn;
        private System.Windows.Forms.ColumnHeader giftCaloriesColumn;
        private System.Windows.Forms.ColumnHeader giftKcalColumn;
        private System.Windows.Forms.ColumnHeader giftDetailsColumn;
    }
}