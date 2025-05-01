namespace DesktopClient.UI.CustomControls
{
    partial class NavButton
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
            text = new Label();
            icon = new PictureBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)icon).BeginInit();
            SuspendLayout();
            // 
            // text
            // 
            text.AutoSize = true;
            text.Cursor = Cursors.Hand;
            text.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            text.Location = new Point(42, 3);
            text.Margin = new Padding(0);
            text.Name = "text";
            text.Size = new Size(85, 21);
            text.TabIndex = 3;
            text.Text = "Trang chủ";
            text.TextAlign = ContentAlignment.BottomCenter;
            text.MouseEnter += NavButton_MouseEnter;
            text.MouseLeave += NavButton_MouseLeave;
            // 
            // icon
            // 
            icon.Cursor = Cursors.Hand;
            icon.Image = Properties.Resources.home_svgrepo_com;
            icon.Location = new Point(3, 3);
            icon.Name = "icon";
            icon.Size = new Size(36, 36);
            icon.SizeMode = PictureBoxSizeMode.Zoom;
            icon.TabIndex = 2;
            icon.TabStop = false;
            icon.MouseEnter += NavButton_MouseEnter;
            icon.MouseLeave += NavButton_MouseLeave;
            // 
            // panel1
            // 
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(150, 44);
            panel1.TabIndex = 4;
            panel1.MouseEnter += NavButton_MouseEnter;
            panel1.MouseLeave += NavButton_MouseLeave;
            // 
            // NavButton
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLight;
            Controls.Add(text);
            Controls.Add(icon);
            Controls.Add(panel1);
            Cursor = Cursors.Hand;
            Name = "NavButton";
            Size = new Size(150, 44);
            MouseEnter += NavButton_MouseEnter;
            MouseLeave += NavButton_MouseLeave;
            ((System.ComponentModel.ISupportInitialize)icon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label text;
        public PictureBox icon;
        public Panel panel1;
    }
}
