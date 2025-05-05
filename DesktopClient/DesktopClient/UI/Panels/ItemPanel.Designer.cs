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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            text_search = new TextBox();
            add_item = new Button();
            delete_item = new Button();
            edit_item = new Button();
            search_btn = new Button();
            excel_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // 
            // text_search
            // 
            text_search.Location = new Point(58, 38);
            text_search.Name = "text_search";
            text_search.PlaceholderText = "Nhập vật dụng (tên, loại, tình trạng)...";
            text_search.Size = new Size(244, 23);
            text_search.TabIndex = 1;
            text_search.TextChanged += text_search_TextChanged;
            // 
            // add_item
            // 
            add_item.Location = new Point(815, 37);
            add_item.Name = "add_item";
            add_item.Size = new Size(75, 23);
            add_item.TabIndex = 3;
            add_item.Text = "Thêm";
            add_item.UseVisualStyleBackColor = true;
            add_item.Click += add_item_Click;
            // 
            // delete_item
            // 
            delete_item.Location = new Point(977, 37);
            delete_item.Name = "delete_item";
            delete_item.Size = new Size(75, 23);
            delete_item.TabIndex = 4;
            delete_item.Text = "Xóa";
            delete_item.UseVisualStyleBackColor = true;
            delete_item.Click += delete_item_Click;
            // 
            // edit_item
            // 
            edit_item.Location = new Point(896, 37);
            edit_item.Name = "edit_item";
            edit_item.Size = new Size(75, 23);
            edit_item.TabIndex = 5;
            edit_item.Text = "Sửa";
            edit_item.UseVisualStyleBackColor = true;
            edit_item.Click += edit_item_Click;
            // 
            // search_btn
            // 
            search_btn.BackColor = Color.PeachPuff;
            search_btn.Location = new Point(308, 37);
            search_btn.Name = "search_btn";
            search_btn.Size = new Size(75, 23);
            search_btn.TabIndex = 6;
            search_btn.Text = "Tìm kiếm";
            search_btn.UseVisualStyleBackColor = false;
            search_btn.Click += search_btn_Click;
            // 
            // excel_btn
            // 
            excel_btn.Location = new Point(734, 37);
            excel_btn.Name = "excel_btn";
            excel_btn.Size = new Size(75, 23);
            excel_btn.TabIndex = 7;
            excel_btn.Text = "Nhập excel";
            excel_btn.UseVisualStyleBackColor = true;
            excel_btn.Click += excel_btn_Click;
            // 
            // ItemPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(excel_btn);
            Controls.Add(search_btn);
            Controls.Add(edit_item);
            Controls.Add(delete_item);
            Controls.Add(add_item);
            Controls.Add(text_search);
            Controls.Add(dataGridView1);
            Margin = new Padding(0);
            Name = "ItemPanel";
            Size = new Size(1114, 681);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.DataGridView dataGridView1;

        #endregion

        private TextBox text_search;
        private Button add_item;
        private Button delete_item;
        private Button edit_item;
        private Button search_btn;
        private Button excel_btn;
    }
}
