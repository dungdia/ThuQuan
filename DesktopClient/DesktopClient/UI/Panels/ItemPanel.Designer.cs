namespace DesktopClient.UI
{
    partial class ItemPanel
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            text_search = new TextBox();
            add_item = new Button();
            search_btn = new Button();
            excel_btn = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            sửaToolStripMenuItem = new ToolStripMenuItem();
            xóaToolStripMenuItem = new ToolStripMenuItem();
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
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(58, 140);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Control;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(994, 538);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellMouseClick += OptionEvent;
            // 
            // text_search
            // 
            text_search.Location = new Point(58, 90);
            text_search.Multiline = true;
            text_search.Name = "text_search";
            text_search.PlaceholderText = "Nhập vật dụng (tên, loại, tình trạng)...";
            text_search.Size = new Size(212, 31);
            text_search.TabIndex = 1;
            text_search.TextChanged += text_search_TextChanged;
            // 
            // add_item
            // 
            add_item.BackColor = Color.FromArgb(16, 185, 129);
            add_item.FlatAppearance.BorderSize = 0;
            add_item.FlatStyle = FlatStyle.Flat;
            add_item.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            add_item.ForeColor = Color.White;
            add_item.Image = Properties.Resources.add;
            add_item.ImageAlign = ContentAlignment.TopCenter;
            add_item.Location = new Point(980, 56);
            add_item.Name = "add_item";
            add_item.Size = new Size(72, 65);
            add_item.TabIndex = 3;
            add_item.Text = "Thêm";
            add_item.TextAlign = ContentAlignment.BottomCenter;
            add_item.UseVisualStyleBackColor = false;
            add_item.Click += add_item_Click;
            // 
            // search_btn
            // 
            search_btn.BackColor = Color.White;
            search_btn.Image = Properties.Resources.search;
            search_btn.Location = new Point(276, 89);
            search_btn.Name = "search_btn";
            search_btn.Size = new Size(32, 32);
            search_btn.TabIndex = 6;
            search_btn.UseVisualStyleBackColor = false;
            search_btn.Click += search_btn_Click;
            // 
            // excel_btn
            // 
            excel_btn.BackColor = Color.FromArgb(16, 185, 129);
            excel_btn.FlatAppearance.BorderSize = 0;
            excel_btn.FlatStyle = FlatStyle.Flat;
            excel_btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            excel_btn.ForeColor = Color.White;
            excel_btn.Image = Properties.Resources.export_excel;
            excel_btn.ImageAlign = ContentAlignment.TopCenter;
            excel_btn.Location = new Point(857, 56);
            excel_btn.Name = "excel_btn";
            excel_btn.Size = new Size(104, 65);
            excel_btn.TabIndex = 7;
            excel_btn.Text = "Nhập excel";
            excel_btn.TextAlign = ContentAlignment.BottomCenter;
            excel_btn.UseVisualStyleBackColor = false;
            excel_btn.Click += excel_btn_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { sửaToolStripMenuItem, xóaToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(95, 48);
            // 
            // sửaToolStripMenuItem
            // 
            sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            sửaToolStripMenuItem.Size = new Size(94, 22);
            sửaToolStripMenuItem.Text = "Sửa";
            sửaToolStripMenuItem.Click += edit_item_Click;
            // 
            // xóaToolStripMenuItem
            // 
            xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            xóaToolStripMenuItem.Size = new Size(94, 22);
            xóaToolStripMenuItem.Text = "Xóa";
            xóaToolStripMenuItem.Click += delete_item_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 66);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 8;
            label1.Text = "Tìm kiếm";
            // 
            // ItemPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label1);
            Controls.Add(excel_btn);
            Controls.Add(search_btn);
            Controls.Add(add_item);
            Controls.Add(text_search);
            Controls.Add(dataGridView1);
            Margin = new Padding(0);
            Name = "ItemPanel";
            Size = new Size(1114, 681);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridView1;

        #endregion

        private TextBox text_search;
        private Button add_item;
        private Button search_btn;
        private Button excel_btn;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem sửaToolStripMenuItem;
        private ToolStripMenuItem xóaToolStripMenuItem;
        private Label label1;
    }
}
