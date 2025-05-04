namespace DesktopClient.UI.Dialog.ChildDialog
{
    partial class SelectItemDialog
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
            label1 = new Label();
            VatDungTable = new DataGridView();
            cancelBtn = new Button();
            selectBtn = new Button();
            searchInput = new TextBox();
            searchBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)VatDungTable).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BackColor = SystemColors.ActiveCaption;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(766, 52);
            label1.TabIndex = 1;
            label1.Text = "Chọn Vật Dụng";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // VatDungTable
            // 
            VatDungTable.AllowUserToResizeColumns = false;
            VatDungTable.AllowUserToResizeRows = false;
            VatDungTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            VatDungTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            VatDungTable.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            VatDungTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            VatDungTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            VatDungTable.DefaultCellStyle = dataGridViewCellStyle2;
            VatDungTable.Dock = DockStyle.Bottom;
            VatDungTable.Location = new Point(0, 151);
            VatDungTable.MultiSelect = false;
            VatDungTable.Name = "VatDungTable";
            VatDungTable.ReadOnly = true;
            VatDungTable.RowHeadersVisible = false;
            VatDungTable.RowHeadersWidth = 51;
            VatDungTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            VatDungTable.Size = new Size(766, 489);
            VatDungTable.TabIndex = 20;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.Red;
            cancelBtn.Location = new Point(579, 75);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(175, 52);
            cancelBtn.TabIndex = 21;
            cancelBtn.Text = "Huỷ";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // selectBtn
            // 
            selectBtn.BackColor = SystemColors.MenuHighlight;
            selectBtn.Location = new Point(398, 75);
            selectBtn.Name = "selectBtn";
            selectBtn.Size = new Size(175, 52);
            selectBtn.TabIndex = 22;
            selectBtn.Text = "Chọn";
            selectBtn.UseVisualStyleBackColor = false;
            selectBtn.Click += selectBtn_Click;
            // 
            // searchInput
            // 
            searchInput.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchInput.Location = new Point(12, 81);
            searchInput.Name = "searchInput";
            searchInput.PlaceholderText = "Tên người dùng...";
            searchInput.Size = new Size(252, 43);
            searchInput.TabIndex = 23;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = SystemColors.ActiveBorder;
            searchBtn.Location = new Point(270, 75);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(122, 52);
            searchBtn.TabIndex = 24;
            searchBtn.Text = "search";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // SelectItemDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 640);
            Controls.Add(searchBtn);
            Controls.Add(searchInput);
            Controls.Add(selectBtn);
            Controls.Add(cancelBtn);
            Controls.Add(VatDungTable);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SelectItemDialog";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)VatDungTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView VatDungTable;
        private Button cancelBtn;
        private Button selectBtn;
        private TextBox searchInput;
        private Button searchBtn;
    }
}