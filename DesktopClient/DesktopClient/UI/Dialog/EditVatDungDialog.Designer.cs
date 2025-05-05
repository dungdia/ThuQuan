namespace DesktopClient.UI.Dialog
{
    partial class EditVatDungDialog
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
            name_item = new TextBox();
            img_item = new TextBox();
            desc_item = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            close_btn = new Button();
            save_btn = new Button();
            type_combobox = new ComboBox();
            img_pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)img_pictureBox).BeginInit();
            SuspendLayout();
            // 
            // name_item
            // 
            name_item.Location = new Point(12, 93);
            name_item.Name = "name_item";
            name_item.Size = new Size(100, 23);
            name_item.TabIndex = 0;
            // 
            // img_item
            // 
            img_item.Location = new Point(152, 93);
            img_item.Name = "img_item";
            img_item.Size = new Size(230, 23);
            img_item.TabIndex = 1;
            // 
            // desc_item
            // 
            desc_item.Location = new Point(419, 93);
            desc_item.Name = "desc_item";
            desc_item.Size = new Size(214, 23);
            desc_item.TabIndex = 2;
            desc_item.TextChanged += desc_item_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 64);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 5;
            label1.Text = "Tên vật dụng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(230, 64);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 6;
            label2.Text = "Hình ảnh";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(500, 64);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 7;
            label3.Text = "Mô tả";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(692, 64);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 8;
            label4.Text = "Loại vật dụng";
            label4.Click += label4_Click;
            // 
            // close_btn
            // 
            close_btn.BackColor = Color.MistyRose;
            close_btn.ForeColor = SystemColors.ActiveCaptionText;
            close_btn.Location = new Point(532, 148);
            close_btn.Name = "close_btn";
            close_btn.Size = new Size(101, 51);
            close_btn.TabIndex = 10;
            close_btn.Text = "Đóng";
            close_btn.UseVisualStyleBackColor = false;
            close_btn.Click += close_btn_Click;
            // 
            // save_btn
            // 
            save_btn.BackColor = Color.PaleGreen;
            save_btn.Location = new Point(671, 148);
            save_btn.Name = "save_btn";
            save_btn.Size = new Size(100, 51);
            save_btn.TabIndex = 11;
            save_btn.Text = "Cập nhật";
            save_btn.UseVisualStyleBackColor = false;
            save_btn.Click += save_btn_Click;
            // 
            // type_combobox
            // 
            type_combobox.FormattingEnabled = true;
            type_combobox.Location = new Point(667, 93);
            type_combobox.Name = "type_combobox";
            type_combobox.Size = new Size(121, 23);
            type_combobox.TabIndex = 13;
            // 
            // img_pictureBox
            // 
            img_pictureBox.Location = new Point(209, 132);
            img_pictureBox.Name = "img_pictureBox";
            img_pictureBox.Size = new Size(91, 93);
            img_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            img_pictureBox.TabIndex = 14;
            img_pictureBox.TabStop = false;
            img_pictureBox.Click += img_pictureBox_Click;
            // 
            // EditVatDungDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 237);
            Controls.Add(img_pictureBox);
            Controls.Add(type_combobox);
            Controls.Add(save_btn);
            Controls.Add(close_btn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(desc_item);
            Controls.Add(img_item);
            Controls.Add(name_item);
            Name = "EditVatDungDialog";
            Text = "Cập nhật vật dụng";
            ((System.ComponentModel.ISupportInitialize)img_pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox name_item;
        private TextBox img_item;
        private TextBox desc_item;
        private TextBox type_item;
        private TextBox status_item;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button close_btn;
        private Button save_btn;
        private ComboBox type_combobox;
        private PictureBox img_pictureBox;
    }
}