namespace DesktopClient.UI.Panels
{
    partial class HistoryPanel
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
            LichSuTable = new DataGridView();
            check_Btn = new Button();
            button1 = new Button();
            search_Input = new TextBox();
            search_btn = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            xemToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)LichSuTable).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // LichSuTable
            // 
            LichSuTable.AllowUserToResizeColumns = false;
            LichSuTable.AllowUserToResizeRows = false;
            LichSuTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LichSuTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            LichSuTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            LichSuTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            LichSuTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            LichSuTable.DefaultCellStyle = dataGridViewCellStyle2;
            LichSuTable.Dock = DockStyle.Bottom;
            LichSuTable.Location = new Point(0, 148);
            LichSuTable.Margin = new Padding(0);
            LichSuTable.MultiSelect = false;
            LichSuTable.Name = "LichSuTable";
            LichSuTable.ReadOnly = true;
            LichSuTable.RowHeadersVisible = false;
            LichSuTable.RowHeadersWidth = 51;
            LichSuTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LichSuTable.Size = new Size(1114, 533);
            LichSuTable.TabIndex = 2;
            LichSuTable.CellMouseClick += LichSuTable_CellMouseClick;
            // 
            // check_Btn
            // 
            check_Btn.Location = new Point(28, 36);
            check_Btn.Name = "check_Btn";
            check_Btn.Size = new Size(75, 23);
            check_Btn.TabIndex = 3;
            check_Btn.Text = "Check";
            check_Btn.UseVisualStyleBackColor = true;
            check_Btn.Click += CheckEvent;
            // 
            // button1
            // 
            button1.Location = new Point(132, 36);
            button1.Name = "button1";
            button1.Size = new Size(99, 23);
            button1.TabIndex = 4;
            button1.Text = "Xem lịch sử";
            button1.UseVisualStyleBackColor = true;
            button1.Click += XemLichSuEvent;
            // 
            // search_Input
            // 
            search_Input.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            search_Input.Location = new Point(16, 88);
            search_Input.Margin = new Padding(3, 2, 3, 2);
            search_Input.Name = "search_Input";
            search_Input.PlaceholderText = "Nhập id thành viên";
            search_Input.Size = new Size(257, 32);
            search_Input.TabIndex = 5;
            // 
            // search_btn
            // 
            search_btn.Location = new Point(290, 95);
            search_btn.Name = "search_btn";
            search_btn.Size = new Size(99, 23);
            search_btn.TabIndex = 6;
            search_btn.Text = "Tìm kiếm";
            search_btn.UseVisualStyleBackColor = true;
            search_btn.Click += SearchEvent;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { xemToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(99, 26);
            // 
            // xemToolStripMenuItem
            // 
            xemToolStripMenuItem.Name = "xemToolStripMenuItem";
            xemToolStripMenuItem.Size = new Size(98, 22);
            xemToolStripMenuItem.Text = "Xem";
            xemToolStripMenuItem.Click += XemEvent;
            // 
            // HistoryPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(search_btn);
            Controls.Add(search_Input);
            Controls.Add(button1);
            Controls.Add(check_Btn);
            Controls.Add(LichSuTable);
            Name = "HistoryPanel";
            Size = new Size(1114, 681);
            ((System.ComponentModel.ISupportInitialize)LichSuTable).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView LichSuTable;
        private Button check_Btn;
        private Button button1;
        private TextBox search_Input;
        private Button search_btn;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem xemToolStripMenuItem;
    }
}
