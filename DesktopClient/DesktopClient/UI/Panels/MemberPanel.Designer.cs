﻿namespace DesktopClient.UI
{
    partial class MemberPanel
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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            ThanhVienTable = new DataGridView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            xemToolStripMenuItem = new ToolStripMenuItem();
            sửaToolStripMenuItem = new ToolStripMenuItem();
            xóaToolStripMenuItem = new ToolStripMenuItem();
            xóaToolStripMenuItem1 = new ToolStripMenuItem();
            addBtn = new Button();
            timkiem_Input = new TextBox();
            timkiem_Btn = new Button();
            label1 = new Label();
            excel_btn = new Button();
            ((System.ComponentModel.ISupportInitialize)ThanhVienTable).BeginInit();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // ThanhVienTable
            // 
            ThanhVienTable.AllowUserToResizeColumns = false;
            ThanhVienTable.AllowUserToResizeRows = false;
            ThanhVienTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ThanhVienTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            ThanhVienTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            ThanhVienTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ThanhVienTable.Location = new Point(58, 140);
            ThanhVienTable.Name = "ThanhVienTable";
            ThanhVienTable.RowHeadersVisible = false;
            ThanhVienTable.RowHeadersWidth = 55;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 11F);
            ThanhVienTable.RowsDefaultCellStyle = dataGridViewCellStyle6;
            ThanhVienTable.RowTemplate.Height = 30;
            ThanhVienTable.RowTemplate.Resizable = DataGridViewTriState.False;
            ThanhVienTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ThanhVienTable.Size = new Size(994, 538);
            ThanhVienTable.TabIndex = 0;
            ThanhVienTable.CellMouseClick += OptionEvent;
            ThanhVienTable.CurrentCellDirtyStateChanged += ThanhVienTable_CurrentCellDirtyStateChanged;
            ThanhVienTable.DataBindingComplete += ThanhVienTable_DataBindingComplete;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { xemToolStripMenuItem, sửaToolStripMenuItem, xóaToolStripMenuItem, xóaToolStripMenuItem1 });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(123, 92);
            // 
            // xemToolStripMenuItem
            // 
            xemToolStripMenuItem.Name = "xemToolStripMenuItem";
            xemToolStripMenuItem.Size = new Size(122, 22);
            xemToolStripMenuItem.Text = "Xem";
            xemToolStripMenuItem.Click += XemEvent;
            // 
            // sửaToolStripMenuItem
            // 
            sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            sửaToolStripMenuItem.Size = new Size(122, 22);
            sửaToolStripMenuItem.Text = "Cập nhật";
            sửaToolStripMenuItem.Click += EditEvent;
            // 
            // xóaToolStripMenuItem
            // 
            xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            xóaToolStripMenuItem.Size = new Size(122, 22);
            xóaToolStripMenuItem.Text = "Khóa";
            xóaToolStripMenuItem.Click += LockEvent;
            // 
            // xóaToolStripMenuItem1
            // 
            xóaToolStripMenuItem1.Name = "xóaToolStripMenuItem1";
            xóaToolStripMenuItem1.Size = new Size(122, 22);
            xóaToolStripMenuItem1.Text = "Xóa";
            xóaToolStripMenuItem1.Click += Xoa_Event;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.FromArgb(16, 185, 129);
            addBtn.FlatAppearance.BorderSize = 0;
            addBtn.FlatStyle = FlatStyle.Flat;
            addBtn.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.White;
            addBtn.Image = Properties.Resources.add;
            addBtn.ImageAlign = ContentAlignment.TopCenter;
            addBtn.Location = new Point(980, 56);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(72, 65);
            addBtn.TabIndex = 2;
            addBtn.Text = "Thêm";
            addBtn.TextAlign = ContentAlignment.BottomCenter;
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += RegisterEvent;
            // 
            // timkiem_Input
            // 
            timkiem_Input.BorderStyle = BorderStyle.None;
            timkiem_Input.Font = new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            timkiem_Input.Location = new Point(58, 90);
            timkiem_Input.Margin = new Padding(0);
            timkiem_Input.Multiline = true;
            timkiem_Input.Name = "timkiem_Input";
            timkiem_Input.Size = new Size(212, 31);
            timkiem_Input.TabIndex = 3;
            // 
            // timkiem_Btn
            // 
            timkiem_Btn.BackColor = Color.White;
            timkiem_Btn.Cursor = Cursors.Hand;
            timkiem_Btn.FlatAppearance.BorderSize = 0;
            timkiem_Btn.FlatStyle = FlatStyle.Flat;
            timkiem_Btn.Image = Properties.Resources.search;
            timkiem_Btn.Location = new Point(276, 91);
            timkiem_Btn.Margin = new Padding(3, 2, 3, 2);
            timkiem_Btn.Name = "timkiem_Btn";
            timkiem_Btn.Size = new Size(32, 32);
            timkiem_Btn.TabIndex = 4;
            timkiem_Btn.UseVisualStyleBackColor = false;
            timkiem_Btn.Click += SearchEvent;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 69);
            label1.Name = "label1";
            label1.Size = new Size(81, 21);
            label1.TabIndex = 7;
            label1.Text = "Tìm kiếm";
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
            excel_btn.TabIndex = 8;
            excel_btn.Text = "Nhập excel";
            excel_btn.TextAlign = ContentAlignment.BottomCenter;
            excel_btn.UseVisualStyleBackColor = false;
            excel_btn.Click += excel_btn_Click;
            // 
            // MemberPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(excel_btn);
            Controls.Add(label1);
            Controls.Add(timkiem_Btn);
            Controls.Add(timkiem_Input);
            Controls.Add(addBtn);
            Controls.Add(ThanhVienTable);
            Name = "MemberPanel";
            Size = new Size(1114, 681);
            ((System.ComponentModel.ISupportInitialize)ThanhVienTable).EndInit();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ThanhVienTable;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem xemToolStripMenuItem;
        private ToolStripMenuItem sửaToolStripMenuItem;
        private ToolStripMenuItem xóaToolStripMenuItem;
        private Button addBtn;
        private TextBox timkiem_Input;
        private Button timkiem_Btn;
        private Label label1;
        private ToolStripMenuItem xóaToolStripMenuItem1;
        private Button excel_btn;
    }
}
