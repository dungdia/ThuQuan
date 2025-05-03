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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            vatDungDataTable = new DataGridView();
            cancelBtn = new Button();
            selectBtn = new Button();
            searchInput = new TextBox();
            searchBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)vatDungDataTable).BeginInit();
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
            // vatDungDataTable
            // 
            vatDungDataTable.AllowUserToResizeColumns = false;
            vatDungDataTable.AllowUserToResizeRows = false;
            vatDungDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            vatDungDataTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            vatDungDataTable.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            vatDungDataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            vatDungDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            vatDungDataTable.DefaultCellStyle = dataGridViewCellStyle4;
            vatDungDataTable.Dock = DockStyle.Bottom;
            vatDungDataTable.Location = new Point(0, 151);
            vatDungDataTable.MultiSelect = false;
            vatDungDataTable.Name = "vatDungDataTable";
            vatDungDataTable.ReadOnly = true;
            vatDungDataTable.RowHeadersVisible = false;
            vatDungDataTable.RowHeadersWidth = 51;
            vatDungDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            vatDungDataTable.Size = new Size(766, 489);
            vatDungDataTable.TabIndex = 20;
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
            Controls.Add(vatDungDataTable);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SelectItemDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SelectItemDialog";
            ((System.ComponentModel.ISupportInitialize)vatDungDataTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView vatDungDataTable;
        private Button cancelBtn;
        private Button selectBtn;
        private TextBox searchInput;
        private Button searchBtn;
    }
}