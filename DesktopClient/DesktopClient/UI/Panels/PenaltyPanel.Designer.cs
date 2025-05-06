namespace DesktopClient.UI.Panels
{
    partial class PenaltyPanel
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            phieuPhatTable = new DataGridView();
            typeDropDown = new ComboBox();
            button1 = new Button();
            textBox1 = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            fineToolStripMenuItem = new ToolStripMenuItem();
            editPhiếuToolStripMenuItem = new ToolStripMenuItem();
            cancelToolStripMenuItem = new ToolStripMenuItem();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            addButton = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)phieuPhatTable).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // phieuPhatTable
            // 
            phieuPhatTable.AllowUserToResizeColumns = false;
            phieuPhatTable.AllowUserToResizeRows = false;
            phieuPhatTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            phieuPhatTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            phieuPhatTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            phieuPhatTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            phieuPhatTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            phieuPhatTable.DefaultCellStyle = dataGridViewCellStyle6;
            phieuPhatTable.Location = new Point(58, 140);
            phieuPhatTable.Margin = new Padding(3, 2, 3, 2);
            phieuPhatTable.MultiSelect = false;
            phieuPhatTable.Name = "phieuPhatTable";
            phieuPhatTable.ReadOnly = true;
            phieuPhatTable.RowHeadersVisible = false;
            phieuPhatTable.RowHeadersWidth = 51;
            phieuPhatTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            phieuPhatTable.Size = new Size(994, 538);
            phieuPhatTable.TabIndex = 2;
            phieuPhatTable.MouseClick += phieuPhatTable_MouseClick;
            // 
            // typeDropDown
            // 
            typeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeDropDown.FormattingEnabled = true;
            typeDropDown.Items.AddRange(new object[] { "Tất cả", "Chưa xử lý", "Đã xử lý", "Đã huỷ" });
            typeDropDown.Location = new Point(321, 84);
            typeDropDown.Margin = new Padding(3, 2, 3, 2);
            typeDropDown.Name = "typeDropDown";
            typeDropDown.Size = new Size(167, 29);
            typeDropDown.TabIndex = 8;
            typeDropDown.SelectedIndexChanged += typeDropDown_SelectedIndexChanged;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.search;
            button1.Location = new Point(494, 84);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(32, 32);
            button1.TabIndex = 7;
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(58, 86);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(257, 27);
            textBox1.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { fineToolStripMenuItem, editPhiếuToolStripMenuItem, cancelToolStripMenuItem, deleteToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(150, 92);
            // 
            // fineToolStripMenuItem
            // 
            fineToolStripMenuItem.Name = "fineToolStripMenuItem";
            fineToolStripMenuItem.Size = new Size(149, 22);
            fineToolStripMenuItem.Text = "Xử Lý Vi Phạm";
            fineToolStripMenuItem.Click += fineToolStripMenuItem_Click;
            // 
            // editPhiếuToolStripMenuItem
            // 
            editPhiếuToolStripMenuItem.Name = "editPhiếuToolStripMenuItem";
            editPhiếuToolStripMenuItem.Size = new Size(149, 22);
            editPhiếuToolStripMenuItem.Text = "Sửa phiếu";
            editPhiếuToolStripMenuItem.Click += editPhiếuToolStripMenuItem_Click;
            // 
            // cancelToolStripMenuItem
            // 
            cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            cancelToolStripMenuItem.Size = new Size(149, 22);
            cancelToolStripMenuItem.Text = "Huỷ phiếu";
            cancelToolStripMenuItem.Click += cancelToolStripMenuItem_Click;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(149, 22);
            deleteToolStripMenuItem.Text = "Xoá phiếu";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(16, 185, 129);
            addButton.Cursor = Cursors.Hand;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addButton.ForeColor = Color.White;
            addButton.Image = Properties.Resources.add;
            addButton.ImageAlign = ContentAlignment.TopCenter;
            addButton.Location = new Point(980, 51);
            addButton.Margin = new Padding(3, 2, 3, 2);
            addButton.Name = "addButton";
            addButton.Size = new Size(72, 65);
            addButton.TabIndex = 10;
            addButton.Text = "Tạo";
            addButton.TextAlign = ContentAlignment.BottomCenter;
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 63);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 11;
            label1.Text = "Tìm kiếm";
            // 
            // PenaltyPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label1);
            Controls.Add(addButton);
            Controls.Add(typeDropDown);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(phieuPhatTable);
            Name = "PenaltyPanel";
            Size = new Size(1114, 681);
            ((System.ComponentModel.ISupportInitialize)phieuPhatTable).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView phieuPhatTable;
        private ComboBox typeDropDown;
        private Button button1;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem fineToolStripMenuItem;
        private ToolStripMenuItem cancelToolStripMenuItem;
        private Button addButton;
        private ToolStripMenuItem deleteToolStripMenuItem;
        private ToolStripMenuItem editPhiếuToolStripMenuItem;
        private Label label1;
    }
}
