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
            label1 = new Label();
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
            LichSuTable.Location = new Point(58, 140);
            LichSuTable.Margin = new Padding(0);
            LichSuTable.MultiSelect = false;
            LichSuTable.Name = "LichSuTable";
            LichSuTable.ReadOnly = true;
            LichSuTable.RowHeadersVisible = false;
            LichSuTable.RowHeadersWidth = 51;
            LichSuTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LichSuTable.Size = new Size(994, 538);
            LichSuTable.TabIndex = 2;
            LichSuTable.CellMouseClick += LichSuTable_CellMouseClick;
            // 
            // check_Btn
            // 
            check_Btn.BackColor = Color.FromArgb(16, 185, 129);
            check_Btn.FlatAppearance.BorderSize = 0;
            check_Btn.FlatStyle = FlatStyle.Flat;
            check_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            check_Btn.ForeColor = Color.White;
            check_Btn.Image = Properties.Resources.check_circle_svgrepo_com__3_1;
            check_Btn.ImageAlign = ContentAlignment.TopCenter;
            check_Btn.Location = new Point(977, 56);
            check_Btn.Name = "check_Btn";
            check_Btn.Size = new Size(75, 65);
            check_Btn.TabIndex = 3;
            check_Btn.Text = "Checkin";
            check_Btn.TextAlign = ContentAlignment.BottomCenter;
            check_Btn.UseVisualStyleBackColor = false;
            check_Btn.Click += CheckEvent;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(255, 215, 64);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.history_svgrepo_com__2___1_;
            button1.ImageAlign = ContentAlignment.TopCenter;
            button1.Location = new Point(872, 56);
            button1.Name = "button1";
            button1.Size = new Size(99, 65);
            button1.TabIndex = 4;
            button1.Text = "Xem lịch sử";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = false;
            button1.Click += XemLichSuEvent;
            // 
            // search_Input
            // 
            search_Input.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            search_Input.Location = new Point(58, 86);
            search_Input.Margin = new Padding(3, 2, 3, 2);
            search_Input.Name = "search_Input";
            search_Input.PlaceholderText = "Nhập id thành viên";
            search_Input.Size = new Size(257, 27);
            search_Input.TabIndex = 5;
            // 
            // search_btn
            // 
            search_btn.BackColor = Color.White;
            search_btn.FlatAppearance.BorderSize = 0;
            search_btn.FlatStyle = FlatStyle.Flat;
            search_btn.Image = Properties.Resources.search;
            search_btn.Location = new Point(321, 81);
            search_btn.Name = "search_btn";
            search_btn.Size = new Size(32, 32);
            search_btn.TabIndex = 6;
            search_btn.UseVisualStyleBackColor = false;
            search_btn.Click += SearchEvent;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { xemToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(181, 48);
            // 
            // xemToolStripMenuItem
            // 
            xemToolStripMenuItem.Name = "xemToolStripMenuItem";
            xemToolStripMenuItem.Size = new Size(180, 22);
            xemToolStripMenuItem.Text = "Xem";
            xemToolStripMenuItem.Click += Xem_Event;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 63);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 12;
            label1.Text = "Tìm kiếm";
            // 
            // HistoryPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(label1);
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
        private Label label1;
    }
}
