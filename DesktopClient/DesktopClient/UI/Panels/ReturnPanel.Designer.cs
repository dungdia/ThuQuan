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
            label1 = new Label();
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
            phieuTraTable.Location = new Point(56, 141);
            phieuTraTable.Margin = new Padding(3, 2, 3, 2);
            phieuTraTable.MultiSelect = false;
            phieuTraTable.Name = "phieuTraTable";
            phieuTraTable.ReadOnly = true;
            phieuTraTable.RowHeadersVisible = false;
            phieuTraTable.RowHeadersWidth = 51;
            phieuTraTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            phieuTraTable.Size = new Size(994, 538);
            phieuTraTable.TabIndex = 2;
            phieuTraTable.MouseClick += phieuTraTable_MouseClick;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(56, 91);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(243, 27);
            textBox1.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.search;
            button1.Location = new Point(478, 91);
            button1.Margin = new Padding(3, 2, 3, 2);
            button1.Name = "button1";
            button1.Size = new Size(32, 32);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // typeDropDown
            // 
            typeDropDown.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDropDown.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeDropDown.FormattingEnabled = true;
            typeDropDown.Items.AddRange(new object[] { "Tất cả", "Đã trả", "Trễ" });
            typeDropDown.Location = new Point(305, 91);
            typeDropDown.Margin = new Padding(3, 2, 3, 2);
            typeDropDown.Name = "typeDropDown";
            typeDropDown.Size = new Size(167, 29);
            typeDropDown.TabIndex = 6;
            typeDropDown.SelectedIndexChanged += typeDropDown_SelectedIndexChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { viewToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(132, 26);
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(131, 22);
            viewToolStripMenuItem.Text = "Xem Phiếu";
            viewToolStripMenuItem.Click += viewToolStripMenuItem_Click;
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
            addButton.Location = new Point(980, 56);
            addButton.Margin = new Padding(3, 2, 3, 2);
            addButton.Name = "addButton";
            addButton.Size = new Size(72, 65);
            addButton.TabIndex = 12;
            addButton.Text = "Tạo";
            addButton.TextAlign = ContentAlignment.BottomCenter;
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(56, 68);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 13;
            label1.Text = "Tìm kiếm";
            // 
            // ReturnPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label1);
            Controls.Add(addButton);
            Controls.Add(typeDropDown);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(phieuTraTable);
            Name = "ReturnPanel";
            Size = new Size(1114, 681);
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
        private Label label1;
    }
}
