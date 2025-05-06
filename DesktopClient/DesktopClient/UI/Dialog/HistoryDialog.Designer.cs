namespace DesktopClient.UI.Dialog
{
    partial class HistoryDialog
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            XemLichSu_Table = new DataGridView();
            search_Btn = new Button();
            month_cBox = new ComboBox();
            year_cBox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            reset_Btn = new Button();
            ((System.ComponentModel.ISupportInitialize)XemLichSu_Table).BeginInit();
            SuspendLayout();
            // 
            // XemLichSu_Table
            // 
            XemLichSu_Table.AllowUserToResizeColumns = false;
            XemLichSu_Table.AllowUserToResizeRows = false;
            XemLichSu_Table.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            XemLichSu_Table.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            XemLichSu_Table.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            XemLichSu_Table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            XemLichSu_Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            XemLichSu_Table.DefaultCellStyle = dataGridViewCellStyle4;
            XemLichSu_Table.Dock = DockStyle.Bottom;
            XemLichSu_Table.Location = new Point(0, 192);
            XemLichSu_Table.Margin = new Padding(0);
            XemLichSu_Table.MultiSelect = false;
            XemLichSu_Table.Name = "XemLichSu_Table";
            XemLichSu_Table.ReadOnly = true;
            XemLichSu_Table.RowHeadersVisible = false;
            XemLichSu_Table.RowHeadersWidth = 51;
            XemLichSu_Table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            XemLichSu_Table.Size = new Size(914, 408);
            XemLichSu_Table.TabIndex = 3;
            // 
            // search_Btn
            // 
            search_Btn.Location = new Point(333, 95);
            search_Btn.Margin = new Padding(3, 4, 3, 4);
            search_Btn.Name = "search_Btn";
            search_Btn.Size = new Size(86, 31);
            search_Btn.TabIndex = 6;
            search_Btn.Text = "Tìm kiếm";
            search_Btn.UseVisualStyleBackColor = true;
            search_Btn.Click += SearchEvent;
            // 
            // month_cBox
            // 
            month_cBox.DropDownStyle = ComboBoxStyle.DropDownList;
            month_cBox.FormattingEnabled = true;
            month_cBox.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            month_cBox.Location = new Point(14, 96);
            month_cBox.Margin = new Padding(3, 4, 3, 4);
            month_cBox.Name = "month_cBox";
            month_cBox.Size = new Size(138, 28);
            month_cBox.TabIndex = 7;
            // 
            // year_cBox
            // 
            year_cBox.DropDownStyle = ComboBoxStyle.DropDownList;
            year_cBox.FormattingEnabled = true;
            year_cBox.Items.AddRange(new object[] { "2024", "2025" });
            year_cBox.Location = new Point(177, 96);
            year_cBox.Margin = new Padding(3, 4, 3, 4);
            year_cBox.Name = "year_cBox";
            year_cBox.Size = new Size(138, 28);
            year_cBox.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 72);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 9;
            label1.Text = "Tháng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(177, 72);
            label2.Name = "label2";
            label2.Size = new Size(41, 20);
            label2.TabIndex = 10;
            label2.Text = "Năm";
            // 
            // reset_Btn
            // 
            reset_Btn.Location = new Point(435, 95);
            reset_Btn.Margin = new Padding(3, 4, 3, 4);
            reset_Btn.Name = "reset_Btn";
            reset_Btn.Size = new Size(86, 31);
            reset_Btn.TabIndex = 11;
            reset_Btn.Text = "Làm mới";
            reset_Btn.UseVisualStyleBackColor = true;
            reset_Btn.Click += ResetEvent;
            // 
            // HistoryDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(reset_Btn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(year_cBox);
            Controls.Add(month_cBox);
            Controls.Add(search_Btn);
            Controls.Add(XemLichSu_Table);
            Margin = new Padding(3, 4, 3, 4);
            Name = "HistoryDialog";
            Text = "HistoryDialog";
            ((System.ComponentModel.ISupportInitialize)XemLichSu_Table).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView XemLichSu_Table;
        private Button search_Btn;
        private ComboBox month_cBox;
        private ComboBox year_cBox;
        private Label label1;
        private Label label2;
        private Button reset_Btn;
    }
}