namespace DesktopClient.UI.Dialog
{
    partial class BorrowDialog
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
            idLabel = new Label();
            idTextBox = new TextBox();
            label1 = new Label();
            id_thanhvienTextBox = new TextBox();
            label2 = new Label();
            ten_thanhvienTextBox = new TextBox();
            idnhanvienLabel = new Label();
            id_nhanvienTextBox = new TextBox();
            tennhanvienLabel = new Label();
            ten_nhanvienTextBox = new TextBox();
            tinhtrangLabel = new Label();
            tinhtrangTextBox = new TextBox();
            thoigianMuonTimePicker = new DateTimePicker();
            thoigiantraTimePicker = new DateTimePicker();
            thoigianmuonLabel = new Label();
            label7 = new Label();
            chiTietPhieuMuonTable = new DataGridView();
            removeItemBtn = new Button();
            addItemBtn = new Button();
            selectUserBtn = new Button();
            createBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)chiTietPhieuMuonTable).BeginInit();
            SuspendLayout();
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idLabel.Location = new Point(26, 15);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(31, 28);
            idLabel.TabIndex = 3;
            idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            idTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTextBox.Location = new Point(26, 46);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.ShortcutsEnabled = false;
            idTextBox.Size = new Size(69, 34);
            idTextBox.TabIndex = 2;
            idTextBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(101, 15);
            label1.Name = "label1";
            label1.Size = new Size(132, 28);
            label1.TabIndex = 5;
            label1.Text = "ID Thành Viên";
            // 
            // id_thanhvienTextBox
            // 
            id_thanhvienTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            id_thanhvienTextBox.Location = new Point(101, 46);
            id_thanhvienTextBox.Name = "id_thanhvienTextBox";
            id_thanhvienTextBox.ReadOnly = true;
            id_thanhvienTextBox.ShortcutsEnabled = false;
            id_thanhvienTextBox.Size = new Size(132, 34);
            id_thanhvienTextBox.TabIndex = 4;
            id_thanhvienTextBox.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(239, 15);
            label2.Name = "label2";
            label2.Size = new Size(142, 28);
            label2.TabIndex = 7;
            label2.Text = "Tên Thành Viên";
            // 
            // ten_thanhvienTextBox
            // 
            ten_thanhvienTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ten_thanhvienTextBox.Location = new Point(239, 46);
            ten_thanhvienTextBox.Name = "ten_thanhvienTextBox";
            ten_thanhvienTextBox.ReadOnly = true;
            ten_thanhvienTextBox.ShortcutsEnabled = false;
            ten_thanhvienTextBox.Size = new Size(192, 34);
            ten_thanhvienTextBox.TabIndex = 6;
            ten_thanhvienTextBox.TabStop = false;
            // 
            // idnhanvienLabel
            // 
            idnhanvienLabel.AutoSize = true;
            idnhanvienLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idnhanvienLabel.Location = new Point(437, 15);
            idnhanvienLabel.Name = "idnhanvienLabel";
            idnhanvienLabel.Size = new Size(126, 28);
            idnhanvienLabel.TabIndex = 9;
            idnhanvienLabel.Text = "ID Nhân Viên";
            // 
            // id_nhanvienTextBox
            // 
            id_nhanvienTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            id_nhanvienTextBox.Location = new Point(437, 46);
            id_nhanvienTextBox.Name = "id_nhanvienTextBox";
            id_nhanvienTextBox.ReadOnly = true;
            id_nhanvienTextBox.ShortcutsEnabled = false;
            id_nhanvienTextBox.Size = new Size(132, 34);
            id_nhanvienTextBox.TabIndex = 8;
            id_nhanvienTextBox.TabStop = false;
            // 
            // tennhanvienLabel
            // 
            tennhanvienLabel.AutoSize = true;
            tennhanvienLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tennhanvienLabel.Location = new Point(575, 15);
            tennhanvienLabel.Name = "tennhanvienLabel";
            tennhanvienLabel.Size = new Size(136, 28);
            tennhanvienLabel.TabIndex = 11;
            tennhanvienLabel.Text = "Tên Nhân Viên";
            // 
            // ten_nhanvienTextBox
            // 
            ten_nhanvienTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ten_nhanvienTextBox.Location = new Point(575, 46);
            ten_nhanvienTextBox.Name = "ten_nhanvienTextBox";
            ten_nhanvienTextBox.ReadOnly = true;
            ten_nhanvienTextBox.ShortcutsEnabled = false;
            ten_nhanvienTextBox.Size = new Size(192, 34);
            ten_nhanvienTextBox.TabIndex = 10;
            ten_nhanvienTextBox.TabStop = false;
            // 
            // tinhtrangLabel
            // 
            tinhtrangLabel.AutoSize = true;
            tinhtrangLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tinhtrangLabel.Location = new Point(773, 15);
            tinhtrangLabel.Name = "tinhtrangLabel";
            tinhtrangLabel.Size = new Size(101, 28);
            tinhtrangLabel.TabIndex = 13;
            tinhtrangLabel.Text = "Tình trạng";
            // 
            // tinhtrangTextBox
            // 
            tinhtrangTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tinhtrangTextBox.Location = new Point(773, 46);
            tinhtrangTextBox.Name = "tinhtrangTextBox";
            tinhtrangTextBox.ReadOnly = true;
            tinhtrangTextBox.ShortcutsEnabled = false;
            tinhtrangTextBox.Size = new Size(177, 34);
            tinhtrangTextBox.TabIndex = 12;
            tinhtrangTextBox.TabStop = false;
            // 
            // thoigianMuonTimePicker
            // 
            thoigianMuonTimePicker.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            thoigianMuonTimePicker.CalendarTitleBackColor = SystemColors.Window;
            thoigianMuonTimePicker.Enabled = false;
            thoigianMuonTimePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            thoigianMuonTimePicker.Location = new Point(26, 120);
            thoigianMuonTimePicker.Name = "thoigianMuonTimePicker";
            thoigianMuonTimePicker.Size = new Size(351, 34);
            thoigianMuonTimePicker.TabIndex = 14;
            // 
            // thoigiantraTimePicker
            // 
            thoigiantraTimePicker.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            thoigiantraTimePicker.CalendarTitleBackColor = SystemColors.Window;
            thoigiantraTimePicker.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            thoigiantraTimePicker.Location = new Point(551, 120);
            thoigiantraTimePicker.Name = "thoigiantraTimePicker";
            thoigiantraTimePicker.Size = new Size(351, 34);
            thoigiantraTimePicker.TabIndex = 15;
            // 
            // thoigianmuonLabel
            // 
            thoigianmuonLabel.AutoSize = true;
            thoigianmuonLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            thoigianmuonLabel.Location = new Point(26, 89);
            thoigianmuonLabel.Name = "thoigianmuonLabel";
            thoigianmuonLabel.Size = new Size(150, 28);
            thoigianmuonLabel.TabIndex = 16;
            thoigianmuonLabel.Text = "Thời gian mượn";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(551, 89);
            label7.Name = "label7";
            label7.Size = new Size(122, 28);
            label7.TabIndex = 17;
            label7.Text = "Thời gian trả";
            // 
            // chiTietPhieuMuonTable
            // 
            chiTietPhieuMuonTable.AllowUserToResizeColumns = false;
            chiTietPhieuMuonTable.AllowUserToResizeRows = false;
            chiTietPhieuMuonTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            chiTietPhieuMuonTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            chiTietPhieuMuonTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            chiTietPhieuMuonTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            chiTietPhieuMuonTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            chiTietPhieuMuonTable.DefaultCellStyle = dataGridViewCellStyle2;
            chiTietPhieuMuonTable.Dock = DockStyle.Bottom;
            chiTietPhieuMuonTable.Location = new Point(0, 220);
            chiTietPhieuMuonTable.MultiSelect = false;
            chiTietPhieuMuonTable.Name = "chiTietPhieuMuonTable";
            chiTietPhieuMuonTable.ReadOnly = true;
            chiTietPhieuMuonTable.RowHeadersVisible = false;
            chiTietPhieuMuonTable.RowHeadersWidth = 51;
            chiTietPhieuMuonTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            chiTietPhieuMuonTable.Size = new Size(962, 367);
            chiTietPhieuMuonTable.TabIndex = 18;
            // 
            // removeItemBtn
            // 
            removeItemBtn.BackColor = Color.Red;
            removeItemBtn.Location = new Point(621, 160);
            removeItemBtn.Name = "removeItemBtn";
            removeItemBtn.Size = new Size(161, 54);
            removeItemBtn.TabIndex = 19;
            removeItemBtn.Text = "Xoá vật dụng";
            removeItemBtn.UseVisualStyleBackColor = false;
            removeItemBtn.Click += removeItemBtn_Click;
            // 
            // addItemBtn
            // 
            addItemBtn.BackColor = SystemColors.ActiveCaption;
            addItemBtn.Location = new Point(454, 160);
            addItemBtn.Name = "addItemBtn";
            addItemBtn.Size = new Size(161, 54);
            addItemBtn.TabIndex = 20;
            addItemBtn.Text = "Thêm vật dụng";
            addItemBtn.UseVisualStyleBackColor = false;
            addItemBtn.Click += addItemBtn_Click;
            // 
            // selectUserBtn
            // 
            selectUserBtn.BackColor = SystemColors.MenuHighlight;
            selectUserBtn.Location = new Point(287, 160);
            selectUserBtn.Name = "selectUserBtn";
            selectUserBtn.Size = new Size(161, 54);
            selectUserBtn.TabIndex = 21;
            selectUserBtn.Text = "Chọn Thành Viên";
            selectUserBtn.UseVisualStyleBackColor = false;
            selectUserBtn.Click += selectUserBtn_Click;
            // 
            // createBtn
            // 
            createBtn.BackColor = Color.PaleGreen;
            createBtn.Location = new Point(789, 160);
            createBtn.Name = "createBtn";
            createBtn.Size = new Size(161, 54);
            createBtn.TabIndex = 22;
            createBtn.Text = "Tạo phiếu";
            createBtn.UseVisualStyleBackColor = false;
            createBtn.Click += createBtn_Click;
            // 
            // BorrowDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 587);
            Controls.Add(createBtn);
            Controls.Add(selectUserBtn);
            Controls.Add(addItemBtn);
            Controls.Add(removeItemBtn);
            Controls.Add(chiTietPhieuMuonTable);
            Controls.Add(label7);
            Controls.Add(thoigianmuonLabel);
            Controls.Add(thoigiantraTimePicker);
            Controls.Add(thoigianMuonTimePicker);
            Controls.Add(tinhtrangLabel);
            Controls.Add(tinhtrangTextBox);
            Controls.Add(tennhanvienLabel);
            Controls.Add(ten_nhanvienTextBox);
            Controls.Add(idnhanvienLabel);
            Controls.Add(id_nhanvienTextBox);
            Controls.Add(label2);
            Controls.Add(ten_thanhvienTextBox);
            Controls.Add(label1);
            Controls.Add(id_thanhvienTextBox);
            Controls.Add(idLabel);
            Controls.Add(idTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BorrowDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "BorrowDialog";
            ((System.ComponentModel.ISupportInitialize)chiTietPhieuMuonTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label idLabel;
        private TextBox idTextBox;
        private Label label1;
        private TextBox id_thanhvienTextBox;
        private Label label2;
        private TextBox ten_thanhvienTextBox;
        private Label idnhanvienLabel;
        private TextBox id_nhanvienTextBox;
        private Label tennhanvienLabel;
        private TextBox ten_nhanvienTextBox;
        private Label tinhtrangLabel;
        private TextBox tinhtrangTextBox;
        private DateTimePicker thoigianMuonTimePicker;
        private DateTimePicker thoigiantraTimePicker;
        private Label thoigianmuonLabel;
        private Label label7;
        private DataGridView chiTietPhieuMuonTable;
        private Button removeItemBtn;
        private Button addItemBtn;
        private Button selectUserBtn;
        private Button createBtn;
    }
}