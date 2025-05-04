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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            XemLichSu_Table.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            XemLichSu_Table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            XemLichSu_Table.DefaultCellStyle = dataGridViewCellStyle2;
            XemLichSu_Table.Dock = DockStyle.Bottom;
            XemLichSu_Table.Location = new Point(0, 144);
            XemLichSu_Table.Margin = new Padding(0);
            XemLichSu_Table.MultiSelect = false;
            XemLichSu_Table.Name = "XemLichSu_Table";
            XemLichSu_Table.ReadOnly = true;
            XemLichSu_Table.RowHeadersVisible = false;
            XemLichSu_Table.RowHeadersWidth = 51;
            XemLichSu_Table.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            XemLichSu_Table.Size = new Size(800, 306);
            XemLichSu_Table.TabIndex = 3;
            // 
            // search_Btn
            // 
            search_Btn.Location = new Point(291, 71);
            search_Btn.Name = "search_Btn";
            search_Btn.Size = new Size(75, 23);
            search_Btn.TabIndex = 6;
            search_Btn.Text = "tìm kiếm";
            search_Btn.UseVisualStyleBackColor = true;
            search_Btn.Click += SearchEvent;
            // 
            // month_cBox
            // 
            month_cBox.DropDownStyle = ComboBoxStyle.DropDownList;
            month_cBox.FormattingEnabled = true;
            month_cBox.Items.AddRange(new object[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" });
            month_cBox.Location = new Point(12, 72);
            month_cBox.Name = "month_cBox";
            month_cBox.Size = new Size(121, 23);
            month_cBox.TabIndex = 7;
            // 
            // year_cBox
            // 
            year_cBox.DropDownStyle = ComboBoxStyle.DropDownList;
            year_cBox.FormattingEnabled = true;
            year_cBox.Items.AddRange(new object[] { "2024", "2025" });
            year_cBox.Location = new Point(155, 72);
            year_cBox.Name = "year_cBox";
            year_cBox.Size = new Size(121, 23);
            year_cBox.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 54);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 9;
            label1.Text = "Tháng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(155, 54);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 10;
            label2.Text = "năm";
            // 
            // reset_Btn
            // 
            reset_Btn.Location = new Point(381, 71);
            reset_Btn.Name = "reset_Btn";
            reset_Btn.Size = new Size(75, 23);
            reset_Btn.TabIndex = 11;
            reset_Btn.Text = "reset";
            reset_Btn.UseVisualStyleBackColor = true;
            reset_Btn.Click += ResetEvent;
            // 
            // HistoryDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(reset_Btn);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(year_cBox);
            Controls.Add(month_cBox);
            Controls.Add(search_Btn);
            Controls.Add(XemLichSu_Table);
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