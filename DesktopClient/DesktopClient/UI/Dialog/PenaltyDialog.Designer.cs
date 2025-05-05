namespace DesktopClient.UI.Dialog
{
    partial class PenaltyDialog
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
            label2 = new Label();
            ten_thanhvienTextBox = new TextBox();
            label1 = new Label();
            id_thanhvienTextBox = new TextBox();
            idLabel = new Label();
            idTextBox = new TextBox();
            lyDoLabel = new Label();
            lyDoTextBox = new TextBox();
            mucPhatTextBox = new TextBox();
            mucPhatLabel = new Label();
            selectUserBtn = new Button();
            selectPenaltyType = new Button();
            chiTietPhieuPhatTable = new DataGridView();
            confirmBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)chiTietPhieuPhatTable).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(225, 9);
            label2.Name = "label2";
            label2.Size = new Size(142, 28);
            label2.TabIndex = 23;
            label2.Text = "Tên Thành Viên";
            // 
            // ten_thanhvienTextBox
            // 
            ten_thanhvienTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ten_thanhvienTextBox.Location = new Point(225, 40);
            ten_thanhvienTextBox.Name = "ten_thanhvienTextBox";
            ten_thanhvienTextBox.ReadOnly = true;
            ten_thanhvienTextBox.ShortcutsEnabled = false;
            ten_thanhvienTextBox.Size = new Size(192, 34);
            ten_thanhvienTextBox.TabIndex = 22;
            ten_thanhvienTextBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(87, 9);
            label1.Name = "label1";
            label1.Size = new Size(132, 28);
            label1.TabIndex = 21;
            label1.Text = "ID Thành Viên";
            // 
            // id_thanhvienTextBox
            // 
            id_thanhvienTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            id_thanhvienTextBox.Location = new Point(87, 40);
            id_thanhvienTextBox.Name = "id_thanhvienTextBox";
            id_thanhvienTextBox.ReadOnly = true;
            id_thanhvienTextBox.ShortcutsEnabled = false;
            id_thanhvienTextBox.Size = new Size(132, 34);
            id_thanhvienTextBox.TabIndex = 20;
            id_thanhvienTextBox.TabStop = false;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idLabel.Location = new Point(12, 9);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(31, 28);
            idLabel.TabIndex = 19;
            idLabel.Text = "ID";
            // 
            // idTextBox
            // 
            idTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTextBox.Location = new Point(12, 40);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.ShortcutsEnabled = false;
            idTextBox.Size = new Size(69, 34);
            idTextBox.TabIndex = 18;
            idTextBox.TabStop = false;
            // 
            // lyDoLabel
            // 
            lyDoLabel.AutoSize = true;
            lyDoLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lyDoLabel.Location = new Point(423, 9);
            lyDoLabel.Name = "lyDoLabel";
            lyDoLabel.Size = new Size(61, 28);
            lyDoLabel.TabIndex = 25;
            lyDoLabel.Text = "Lý Do";
            // 
            // lyDoTextBox
            // 
            lyDoTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lyDoTextBox.Location = new Point(423, 40);
            lyDoTextBox.Name = "lyDoTextBox";
            lyDoTextBox.ShortcutsEnabled = false;
            lyDoTextBox.Size = new Size(307, 34);
            lyDoTextBox.TabIndex = 24;
            lyDoTextBox.TabStop = false;
            // 
            // mucPhatTextBox
            // 
            mucPhatTextBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mucPhatTextBox.Location = new Point(736, 40);
            mucPhatTextBox.Name = "mucPhatTextBox";
            mucPhatTextBox.ReadOnly = true;
            mucPhatTextBox.ShortcutsEnabled = false;
            mucPhatTextBox.Size = new Size(192, 34);
            mucPhatTextBox.TabIndex = 26;
            mucPhatTextBox.TabStop = false;
            // 
            // mucPhatLabel
            // 
            mucPhatLabel.AutoSize = true;
            mucPhatLabel.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mucPhatLabel.Location = new Point(736, 9);
            mucPhatLabel.Name = "mucPhatLabel";
            mucPhatLabel.Size = new Size(96, 28);
            mucPhatLabel.TabIndex = 27;
            mucPhatLabel.Text = "Mức phạt";
            // 
            // selectUserBtn
            // 
            selectUserBtn.BackColor = SystemColors.MenuHighlight;
            selectUserBtn.Location = new Point(217, 94);
            selectUserBtn.Name = "selectUserBtn";
            selectUserBtn.Size = new Size(161, 54);
            selectUserBtn.TabIndex = 32;
            selectUserBtn.Text = "Chọn Thành Viên";
            selectUserBtn.UseVisualStyleBackColor = false;
            selectUserBtn.Click += selectUserBtn_Click;
            // 
            // selectPenaltyType
            // 
            selectPenaltyType.BackColor = Color.IndianRed;
            selectPenaltyType.Location = new Point(12, 94);
            selectPenaltyType.Name = "selectPenaltyType";
            selectPenaltyType.Size = new Size(199, 54);
            selectPenaltyType.TabIndex = 33;
            selectPenaltyType.Text = "Chọn Hình Thức Phạt";
            selectPenaltyType.UseVisualStyleBackColor = false;
            selectPenaltyType.Click += selectPenaltyType_Click;
            // 
            // chiTietPhieuPhatTable
            // 
            chiTietPhieuPhatTable.AllowUserToResizeColumns = false;
            chiTietPhieuPhatTable.AllowUserToResizeRows = false;
            chiTietPhieuPhatTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            chiTietPhieuPhatTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            chiTietPhieuPhatTable.BackgroundColor = SystemColors.ButtonFace;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            chiTietPhieuPhatTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            chiTietPhieuPhatTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            chiTietPhieuPhatTable.DefaultCellStyle = dataGridViewCellStyle2;
            chiTietPhieuPhatTable.Dock = DockStyle.Bottom;
            chiTietPhieuPhatTable.Location = new Point(0, 162);
            chiTietPhieuPhatTable.MultiSelect = false;
            chiTietPhieuPhatTable.Name = "chiTietPhieuPhatTable";
            chiTietPhieuPhatTable.ReadOnly = true;
            chiTietPhieuPhatTable.RowHeadersVisible = false;
            chiTietPhieuPhatTable.RowHeadersWidth = 51;
            chiTietPhieuPhatTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            chiTietPhieuPhatTable.Size = new Size(941, 367);
            chiTietPhieuPhatTable.TabIndex = 34;
            // 
            // confirmBtn
            // 
            confirmBtn.BackColor = Color.PaleGreen;
            confirmBtn.Location = new Point(768, 94);
            confirmBtn.Name = "confirmBtn";
            confirmBtn.Size = new Size(161, 54);
            confirmBtn.TabIndex = 35;
            confirmBtn.Text = "Xác nhận";
            confirmBtn.UseVisualStyleBackColor = false;
            confirmBtn.Click += confirmBtn_Click;
            // 
            // PenaltyDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 529);
            Controls.Add(confirmBtn);
            Controls.Add(chiTietPhieuPhatTable);
            Controls.Add(selectPenaltyType);
            Controls.Add(selectUserBtn);
            Controls.Add(mucPhatLabel);
            Controls.Add(mucPhatTextBox);
            Controls.Add(lyDoLabel);
            Controls.Add(lyDoTextBox);
            Controls.Add(label2);
            Controls.Add(ten_thanhvienTextBox);
            Controls.Add(label1);
            Controls.Add(id_thanhvienTextBox);
            Controls.Add(idLabel);
            Controls.Add(idTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PenaltyDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "PenaltyDialog";
            ((System.ComponentModel.ISupportInitialize)chiTietPhieuPhatTable).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label tinhtrangLabel;
        private TextBox tinhtrangTextBox;
        private Label label2;
        private TextBox ten_thanhvienTextBox;
        private Label label1;
        private TextBox id_thanhvienTextBox;
        private Label idLabel;
        private TextBox idTextBox;
        private Label lyDoLabel;
        private TextBox lyDoTextBox;
        private TextBox mucPhatTextBox;
        private Label mucPhatLabel;
        private Button confirmBtn;
        private Button selectUserBtn;
        private Button selectPenaltyType;
        private DataGridView chiTietPhieuPhatTable;
    }
}