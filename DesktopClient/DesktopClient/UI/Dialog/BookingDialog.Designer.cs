namespace DesktopClient.UI.Dialog
{
    partial class BookingDialog
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
            idTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            id_thanhvienTextBox = new TextBox();
            label3 = new Label();
            nameTextBox = new TextBox();
            label4 = new Label();
            dateTextBox = new TextBox();
            label5 = new Label();
            tinhTrangTextBox = new TextBox();
            ChiTietPhieuDatDataTable = new DataGridView();
            processBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)ChiTietPhieuDatDataTable).BeginInit();
            SuspendLayout();
            // 
            // idTextBox
            // 
            idTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTextBox.Location = new Point(35, 50);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.ShortcutsEnabled = false;
            idTextBox.Size = new Size(69, 34);
            idTextBox.TabIndex = 0;
            idTextBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(35, 19);
            label1.Name = "label1";
            label1.Size = new Size(31, 28);
            label1.TabIndex = 1;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(126, 19);
            label2.Name = "label2";
            label2.Size = new Size(132, 28);
            label2.TabIndex = 3;
            label2.Text = "ID Thành Viên";
            // 
            // id_thanhvienTextBox
            // 
            id_thanhvienTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            id_thanhvienTextBox.Location = new Point(126, 50);
            id_thanhvienTextBox.Name = "id_thanhvienTextBox";
            id_thanhvienTextBox.ReadOnly = true;
            id_thanhvienTextBox.ShortcutsEnabled = false;
            id_thanhvienTextBox.Size = new Size(130, 34);
            id_thanhvienTextBox.TabIndex = 2;
            id_thanhvienTextBox.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(275, 19);
            label3.Name = "label3";
            label3.Size = new Size(72, 28);
            label3.TabIndex = 5;
            label3.Text = "Họ Tên";
            // 
            // nameTextBox
            // 
            nameTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameTextBox.Location = new Point(275, 50);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.ReadOnly = true;
            nameTextBox.ShortcutsEnabled = false;
            nameTextBox.Size = new Size(296, 34);
            nameTextBox.TabIndex = 4;
            nameTextBox.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(587, 19);
            label4.Name = "label4";
            label4.Size = new Size(95, 28);
            label4.TabIndex = 7;
            label4.Text = "Ngày Đặt";
            // 
            // dateTextBox
            // 
            dateTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTextBox.Location = new Point(587, 50);
            dateTextBox.Name = "dateTextBox";
            dateTextBox.ReadOnly = true;
            dateTextBox.ShortcutsEnabled = false;
            dateTextBox.Size = new Size(130, 34);
            dateTextBox.TabIndex = 6;
            dateTextBox.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(733, 19);
            label5.Name = "label5";
            label5.Size = new Size(101, 28);
            label5.TabIndex = 9;
            label5.Text = "Tình trạng";
            // 
            // tinhTrangTextBox
            // 
            tinhTrangTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tinhTrangTextBox.Location = new Point(733, 50);
            tinhTrangTextBox.Name = "tinhTrangTextBox";
            tinhTrangTextBox.ReadOnly = true;
            tinhTrangTextBox.ShortcutsEnabled = false;
            tinhTrangTextBox.Size = new Size(146, 34);
            tinhTrangTextBox.TabIndex = 8;
            tinhTrangTextBox.TabStop = false;
            // 
            // ChiTietPhieuDatDataTable
            // 
            ChiTietPhieuDatDataTable.AllowUserToResizeColumns = false;
            ChiTietPhieuDatDataTable.AllowUserToResizeRows = false;
            ChiTietPhieuDatDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ChiTietPhieuDatDataTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ChiTietPhieuDatDataTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            ChiTietPhieuDatDataTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            ChiTietPhieuDatDataTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ChiTietPhieuDatDataTable.DefaultCellStyle = dataGridViewCellStyle2;
            ChiTietPhieuDatDataTable.Dock = DockStyle.Bottom;
            ChiTietPhieuDatDataTable.Location = new Point(0, 192);
            ChiTietPhieuDatDataTable.MultiSelect = false;
            ChiTietPhieuDatDataTable.Name = "ChiTietPhieuDatDataTable";
            ChiTietPhieuDatDataTable.RowHeadersVisible = false;
            ChiTietPhieuDatDataTable.RowHeadersWidth = 51;
            ChiTietPhieuDatDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ChiTietPhieuDatDataTable.Size = new Size(945, 460);
            ChiTietPhieuDatDataTable.TabIndex = 10;
            // 
            // processBtn
            // 
            processBtn.BackColor = SystemColors.ActiveCaption;
            processBtn.FlatAppearance.BorderSize = 0;
            processBtn.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            processBtn.Location = new Point(763, 130);
            processBtn.Name = "processBtn";
            processBtn.Size = new Size(170, 56);
            processBtn.TabIndex = 12;
            processBtn.Text = "Xử lý phiếu";
            processBtn.UseVisualStyleBackColor = false;
            processBtn.Click += processBtn_Click;
            // 
            // BookingDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 652);
            Controls.Add(processBtn);
            Controls.Add(ChiTietPhieuDatDataTable);
            Controls.Add(label5);
            Controls.Add(tinhTrangTextBox);
            Controls.Add(label4);
            Controls.Add(dateTextBox);
            Controls.Add(label3);
            Controls.Add(nameTextBox);
            Controls.Add(label2);
            Controls.Add(id_thanhvienTextBox);
            Controls.Add(label1);
            Controls.Add(idTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookingDialog";
            StartPosition = FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)ChiTietPhieuDatDataTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextBox;
        private Label label1;
        private Label label2;
        private TextBox id_thanhvienTextBox;
        private Label label3;
        private TextBox nameTextBox;
        private Label label4;
        private TextBox dateTextBox;
        private Label label5;
        private TextBox tinhTrangTextBox;
        private DataGridView ChiTietPhieuDatDataTable;
        private Button processBtn;
    }
}