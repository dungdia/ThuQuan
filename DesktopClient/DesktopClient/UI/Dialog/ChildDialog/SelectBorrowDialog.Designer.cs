namespace DesktopClient.UI.Dialog.ChildDialog
{
    partial class SelectBorrowDialog
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
            label1 = new Label();
            searchBtn = new Button();
            searchInput = new TextBox();
            selectBtn = new Button();
            cancelBtn = new Button();
            phieuMuonTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)phieuMuonTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1213, 52);
            label1.TabIndex = 2;
            label1.Text = "Chọn Phiếu Mượn";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = SystemColors.ActiveBorder;
            searchBtn.Location = new Point(270, 85);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(122, 52);
            searchBtn.TabIndex = 28;
            searchBtn.Text = "search";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // searchInput
            // 
            searchInput.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchInput.Location = new Point(12, 91);
            searchInput.Name = "searchInput";
            searchInput.Size = new Size(252, 43);
            searchInput.TabIndex = 27;
            // 
            // selectBtn
            // 
            selectBtn.BackColor = SystemColors.MenuHighlight;
            selectBtn.Location = new Point(398, 85);
            selectBtn.Name = "selectBtn";
            selectBtn.Size = new Size(175, 52);
            selectBtn.TabIndex = 26;
            selectBtn.Text = "Chọn";
            selectBtn.UseVisualStyleBackColor = false;
            selectBtn.Click += selectBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.Red;
            cancelBtn.Location = new Point(579, 85);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(175, 52);
            cancelBtn.TabIndex = 25;
            cancelBtn.Text = "Huỷ";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // phieuMuonTable
            // 
            phieuMuonTable.AllowUserToResizeColumns = false;
            phieuMuonTable.AllowUserToResizeRows = false;
            phieuMuonTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            phieuMuonTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            phieuMuonTable.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            phieuMuonTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            phieuMuonTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            phieuMuonTable.DefaultCellStyle = dataGridViewCellStyle4;
            phieuMuonTable.Dock = DockStyle.Bottom;
            phieuMuonTable.Location = new Point(0, 180);
            phieuMuonTable.MultiSelect = false;
            phieuMuonTable.Name = "phieuMuonTable";
            phieuMuonTable.ReadOnly = true;
            phieuMuonTable.RowHeadersVisible = false;
            phieuMuonTable.RowHeadersWidth = 51;
            phieuMuonTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            phieuMuonTable.Size = new Size(1213, 425);
            phieuMuonTable.TabIndex = 29;
            // 
            // SelectBorrowDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1213, 605);
            Controls.Add(phieuMuonTable);
            Controls.Add(searchBtn);
            Controls.Add(searchInput);
            Controls.Add(selectBtn);
            Controls.Add(cancelBtn);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectBorrowDialog";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)phieuMuonTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button searchBtn;
        private TextBox searchInput;
        private Button selectBtn;
        private Button cancelBtn;
        private DataGridView phieuMuonTable;
    }
}