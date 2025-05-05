namespace DesktopClient.UI.Panels
{
    partial class ReturnPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            phieuTraTable = new DataGridView();
            textBox1 = new TextBox();
            button1 = new Button();
            typeDropDown = new ComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            viewToolStripMenuItem = new ToolStripMenuItem();
            addButton = new Button();
            ((System.ComponentModel.ISupportInitialize)phieuTraTable).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // phieuTraTable
            // 
            phieuTraTable.AllowUserToResizeColumns = false;
            phieuTraTable.AllowUserToResizeRows = false;
            phieuTraTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            phieuTraTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            phieuTraTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            phieuTraTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            phieuTraTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            phieuTraTable.DefaultCellStyle = dataGridViewCellStyle2;
            phieuTraTable.Dock = DockStyle.Bottom;
            phieuTraTable.Location = new Point(0, 129);
            phieuTraTable.MultiSelect = false;
            phieuTraTable.Name = "phieuTraTable";
            phieuTraTable.ReadOnly = true;
            phieuTraTable.RowHeadersVisible = false;
            phieuTraTable.RowHeadersWidth = 51;
            phieuTraTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            phieuTraTable.Size = new Size(1273, 779);
            phieuTraTable.TabIndex = 2;
            phieuTraTable.MouseClick += phieuTraTable_MouseClick;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(16, 45);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nhập tên người dùng...";
            textBox1.Size = new Size(293, 38);
            textBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Location = new Point(315, 45);
            button1.Name = "button1";
            button1.Size = new Size(102, 38);
            button1.TabIndex = 5;
            button1.Text = "Search";
            button1.UseVisualStyleBackColor = true;
            // 
            // typeDropDown
            // 
            typeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeDropDown.FormattingEnabled = true;
            typeDropDown.Items.AddRange(new object[] { "Tất cả", "Đã trả", "Trễ" });
            typeDropDown.Location = new Point(423, 45);
            typeDropDown.Name = "typeDropDown";
            typeDropDown.Size = new Size(190, 36);
            typeDropDown.TabIndex = 6;
            typeDropDown.SelectedIndexChanged += typeDropDown_SelectedIndexChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(149, 28);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(148, 24);
            viewToolStripMenuItem.Text = "Xem Phiếu";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(16, 185, 129);
            addButton.Cursor = Cursors.Hand;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addButton.Location = new Point(1048, 41);
            addButton.Name = "addButton";
            addButton.Size = new Size(169, 48);
            addButton.TabIndex = 12;
            addButton.Text = "Tạo Phiếu Trả";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addToolStripMenuItem_Click;
            // 
            // ReturnPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(addButton);
            Controls.Add(typeDropDown);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(phieuTraTable);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ReturnPanel";
            Size = new Size(1273, 908);
            ((System.ComponentModel.ISupportInitialize)phieuTraTable).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView phieuTraTable;
        private TextBox textBox1;
        private Button button1;
        private ComboBox typeDropDown;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private Button addButton;
    }
}
