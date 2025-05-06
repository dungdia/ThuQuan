namespace DesktopClient.UI.Panels
{
    partial class StaffPanel
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
            dataGridView1 = new DataGridView();
            searchTextbox = new TextBox();
            searchBtn = new Button();
            comboBox1 = new ComboBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            viewDetailToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            accountLockToolStripMenuItem = new ToolStripMenuItem();
            addButton = new Button();
            refreshBtn = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(66, 187);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1136, 717);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellMouseClick += dataGridView1_CellMouseClick;
            // 
            // searchTextbox
            // 
            searchTextbox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            searchTextbox.BorderStyle = BorderStyle.None;
            searchTextbox.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchTextbox.Location = new Point(66, 120);
            searchTextbox.Margin = new Padding(0);
            searchTextbox.Multiline = true;
            searchTextbox.Name = "searchTextbox";
            searchTextbox.Size = new Size(242, 41);
            searchTextbox.TabIndex = 1;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = Color.White;
            searchBtn.FlatAppearance.BorderSize = 0;
            searchBtn.FlatStyle = FlatStyle.Flat;
            searchBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBtn.Image = Properties.Resources.search;
            searchBtn.Location = new Point(479, 119);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(37, 43);
            searchBtn.TabIndex = 2;
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Tất cả", "Đang làm việc", "Đã nghỉ" });
            comboBox1.Location = new Point(315, 120);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(156, 38);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { viewDetailToolStripMenuItem, editToolStripMenuItem, accountLockToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(206, 76);
            // 
            // viewDetailToolStripMenuItem
            // 
            viewDetailToolStripMenuItem.Name = "viewDetailToolStripMenuItem";
            viewDetailToolStripMenuItem.Size = new Size(205, 24);
            viewDetailToolStripMenuItem.Text = "Xem chi tiết";
            viewDetailToolStripMenuItem.Click += viewDetailToolStripMenuItem_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(205, 24);
            editToolStripMenuItem.Text = "Sửa";
            editToolStripMenuItem.Click += editToolStripMenuItem_Click;
            // 
            // accountLockToolStripMenuItem
            // 
            accountLockToolStripMenuItem.Name = "accountLockToolStripMenuItem";
            accountLockToolStripMenuItem.Size = new Size(205, 24);
            accountLockToolStripMenuItem.Text = "Mở/Khóa tài khoản";
            accountLockToolStripMenuItem.Click += accountLockToolStripMenuItem_Click;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(16, 185, 129);
            addButton.Cursor = Cursors.Hand;
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addButton.ForeColor = Color.White;
            addButton.Image = Properties.Resources.add;
            addButton.ImageAlign = ContentAlignment.TopCenter;
            addButton.Location = new Point(1120, 75);
            addButton.Name = "addButton";
            addButton.Size = new Size(82, 87);
            addButton.TabIndex = 4;
            addButton.Text = "Thêm";
            addButton.TextAlign = ContentAlignment.BottomCenter;
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.BackColor = Color.White;
            refreshBtn.FlatAppearance.BorderSize = 0;
            refreshBtn.FlatStyle = FlatStyle.Flat;
            refreshBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshBtn.Image = Properties.Resources.refresh;
            refreshBtn.Location = new Point(522, 120);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(37, 43);
            refreshBtn.TabIndex = 5;
            refreshBtn.UseVisualStyleBackColor = false;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(66, 92);
            label1.Name = "label1";
            label1.Size = new Size(100, 28);
            label1.TabIndex = 6;
            label1.Text = "Tìm kiếm";
            // 
            // StaffPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label1);
            Controls.Add(refreshBtn);
            Controls.Add(addButton);
            Controls.Add(comboBox1);
            Controls.Add(searchBtn);
            Controls.Add(searchTextbox);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "StaffPanel";
            Size = new Size(1273, 908);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox searchTextbox;
        private Button searchBtn;
        private ComboBox comboBox1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem viewDetailToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private Button addButton;
        private Button refreshBtn;
        private ToolStripMenuItem accountLockToolStripMenuItem;
        private Label label1;
    }
}
