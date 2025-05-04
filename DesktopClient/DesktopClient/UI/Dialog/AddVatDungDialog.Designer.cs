namespace DesktopClient.UI.Dialog
{
    partial class AddVatDungDialog
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
            type_combobox = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            close_btn = new Button();
            add_btn = new Button();
            SuspendLayout();
            // 
            // name_item
            // 
            name_item.Location = new Point(12, 92);
            name_item.Name = "name_item";
            name_item.Size = new Size(121, 23);
            name_item.TabIndex = 0;
            // 
            // img_item
            // 
            img_item.Location = new Point(149, 92);
            img_item.Name = "img_item";
            img_item.Size = new Size(236, 23);
            img_item.TabIndex = 1;
            // 
            // desc_item
            // 
            desc_item.Location = new Point(405, 92);
            desc_item.Name = "desc_item";
            desc_item.Size = new Size(236, 23);
            desc_item.TabIndex = 2;
            // 
            // type_combobox
            // 
            type_combobox.FormattingEnabled = true;
            type_combobox.Items.AddRange(new object[] { "Sách", "Thiết bị" });
            type_combobox.Location = new Point(667, 92);
            type_combobox.Name = "type_combobox";
            type_combobox.Size = new Size(121, 23);
            type_combobox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 59);
            label1.Name = "label1";
            label1.Size = new Size(76, 15);
            label1.TabIndex = 4;
            label1.Text = "Tên vật dụng";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(244, 59);
            label2.Name = "label2";
            label2.Size = new Size(56, 15);
            label2.TabIndex = 5;
            label2.Text = "Hình ảnh";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(507, 59);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 6;
            label3.Text = "Mô tả";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(690, 59);
            label4.Name = "label4";
            label4.Size = new Size(79, 15);
            label4.TabIndex = 7;
            label4.Text = "Loại vật dụng";
            // 
            // close_btn
            // 
            close_btn.BackColor = Color.MistyRose;
            close_btn.Location = new Point(507, 168);
            close_btn.Name = "close_btn";
            close_btn.Size = new Size(112, 52);
            close_btn.TabIndex = 8;
            close_btn.Text = "Đóng";
            close_btn.UseVisualStyleBackColor = false;
            close_btn.Click += close_btn_Click;
            // 
            // add_btn
            // 
            add_btn.BackColor = Color.Chartreuse;
            add_btn.Location = new Point(657, 168);
            add_btn.Name = "add_btn";
            add_btn.Size = new Size(112, 52);
            add_btn.TabIndex = 10;
            add_btn.Text = "Thêm";
            add_btn.UseVisualStyleBackColor = false;
            add_btn.Click += add_btn_Click;
            // 
            // AddVatDungDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 269);
            Controls.Add(add_btn);
            Controls.Add(close_btn);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(type_combobox);
            Controls.Add(desc_item);
            Controls.Add(img_item);
            Controls.Add(name_item);
            Name = "AddVatDungDialog";
            Text = "Thêm vật dụng";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox name_item;
        private TextBox img_item;
        private TextBox desc_item;
        private ComboBox type_combobox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button close_btn;
        private Button add_btn;
    }
}