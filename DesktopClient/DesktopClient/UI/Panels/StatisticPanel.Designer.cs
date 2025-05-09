using System.ComponentModel;

namespace DesktopClient.UI;

partial class StatisticPanel
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
        System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
        System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
        System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
        System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
        System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
        System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
        chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        button1 = new Button();
        label2 = new Label();
        label1 = new Label();
        ngayKT1 = new DateTimePicker();
        ngayBD1 = new DateTimePicker();
        tabPage2 = new TabPage();
        button2 = new Button();
        label3 = new Label();
        label4 = new Label();
        ngayKT2 = new DateTimePicker();
        ngayBD2 = new DateTimePicker();
        chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
        ((ISupportInitialize)chart1).BeginInit();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage2.SuspendLayout();
        ((ISupportInitialize)chart2).BeginInit();
        SuspendLayout();
        // 
        // chart1
        // 
        chartArea3.AxisX.MajorGrid.Enabled = false;
        chartArea3.Name = "ChartArea1";
        chart1.ChartAreas.Add(chartArea3);
        legend3.Name = "Legend1";
        chart1.Legends.Add(legend3);
        chart1.Location = new Point(0, 119);
        chart1.Name = "chart1";
        series3.ChartArea = "ChartArea1";
        series3.CustomProperties = "EmptyPointValue=Zero";
        series3.EmptyPointStyle.IsValueShownAsLabel = true;
        series3.Legend = "Legend1";
        series3.Name = "SoLuong";
        chart1.Series.Add(series3);
        chart1.Size = new Size(1106, 534);
        chart1.TabIndex = 1;
        chart1.Text = "chart1";
        title3.Name = "Title1";
        title3.Text = "Thống kê thành viên vào thư quán";
        chart1.Titles.Add(title3);
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Dock = DockStyle.Fill;
        tabControl1.Location = new Point(0, 0);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(1114, 681);
        tabControl1.TabIndex = 2;
        // 
        // tabPage1
        // 
        tabPage1.BackColor = SystemColors.ActiveCaption;
        tabPage1.Controls.Add(button1);
        tabPage1.Controls.Add(label2);
        tabPage1.Controls.Add(label1);
        tabPage1.Controls.Add(ngayKT1);
        tabPage1.Controls.Add(ngayBD1);
        tabPage1.Controls.Add(chart1);
        tabPage1.Location = new Point(4, 24);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(1106, 653);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Thống kê thành viên vào thư quán";
        // 
        // button1
        // 
        button1.BackColor = Color.White;
        button1.FlatAppearance.BorderSize = 0;
        button1.FlatStyle = FlatStyle.Flat;
        button1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button1.Location = new Point(510, 47);
        button1.Name = "button1";
        button1.Size = new Size(97, 34);
        button1.TabIndex = 6;
        button1.Text = "Thống kê";
        button1.UseVisualStyleBackColor = false;
        button1.Click += button1_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label2.Location = new Point(269, 35);
        label2.Name = "label2";
        label2.Size = new Size(107, 20);
        label2.TabIndex = 5;
        label2.Text = "Ngày kết thúc";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label1.Location = new Point(63, 35);
        label1.Name = "label1";
        label1.Size = new Size(103, 20);
        label1.TabIndex = 4;
        label1.Text = "Ngày bắt đầu";
        // 
        // ngayKT1
        // 
        ngayKT1.Location = new Point(269, 58);
        ngayKT1.Name = "ngayKT1";
        ngayKT1.Size = new Size(200, 23);
        ngayKT1.TabIndex = 3;
        // 
        // ngayBD1
        // 
        ngayBD1.Location = new Point(63, 58);
        ngayBD1.Name = "ngayBD1";
        ngayBD1.Size = new Size(200, 23);
        ngayBD1.TabIndex = 2;
        // 
        // tabPage2
        // 
        tabPage2.BackColor = SystemColors.ActiveCaption;
        tabPage2.Controls.Add(button2);
        tabPage2.Controls.Add(label3);
        tabPage2.Controls.Add(label4);
        tabPage2.Controls.Add(ngayKT2);
        tabPage2.Controls.Add(ngayBD2);
        tabPage2.Controls.Add(chart2);
        tabPage2.Location = new Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(1106, 653);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Thống kê vật dụng mượn";
        // 
        // button2
        // 
        button2.BackColor = Color.White;
        button2.FlatAppearance.BorderSize = 0;
        button2.FlatStyle = FlatStyle.Flat;
        button2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
        button2.Location = new Point(510, 47);
        button2.Name = "button2";
        button2.Size = new Size(97, 34);
        button2.TabIndex = 12;
        button2.Text = "Thống kê";
        button2.UseVisualStyleBackColor = false;
        button2.Click += button2_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label3.Location = new Point(269, 35);
        label3.Name = "label3";
        label3.Size = new Size(107, 20);
        label3.TabIndex = 11;
        label3.Text = "Ngày kết thúc";
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label4.Location = new Point(63, 35);
        label4.Name = "label4";
        label4.Size = new Size(103, 20);
        label4.TabIndex = 10;
        label4.Text = "Ngày bắt đầu";
        // 
        // ngayKT2
        // 
        ngayKT2.Location = new Point(269, 58);
        ngayKT2.Name = "ngayKT2";
        ngayKT2.Size = new Size(200, 23);
        ngayKT2.TabIndex = 9;
        // 
        // ngayBD2
        // 
        ngayBD2.Location = new Point(63, 58);
        ngayBD2.Name = "ngayBD2";
        ngayBD2.Size = new Size(200, 23);
        ngayBD2.TabIndex = 8;
        // 
        // chart2
        // 
        chartArea4.AxisX.MajorGrid.Enabled = false;
        chartArea4.Name = "ChartArea1";
        chart2.ChartAreas.Add(chartArea4);
        legend4.Name = "Legend1";
        chart2.Legends.Add(legend4);
        chart2.Location = new Point(0, 119);
        chart2.Name = "chart2";
        series4.ChartArea = "ChartArea1";
        series4.CustomProperties = "EmptyPointValue=Zero";
        series4.EmptyPointStyle.IsValueShownAsLabel = true;
        series4.Legend = "Legend1";
        series4.Name = "SoLuong";
        chart2.Series.Add(series4);
        chart2.Size = new Size(1106, 534);
        chart2.TabIndex = 7;
        chart2.Text = "chart2";
        title4.Name = "SLVao";
        title4.Text = "Thống kê vật dụng mượn";
        chart2.Titles.Add(title4);
        // 
        // StatisticPanel
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.ActiveCaption;
        Controls.Add(tabControl1);
        Margin = new Padding(3, 2, 3, 2);
        Name = "StatisticPanel";
        Size = new Size(1114, 681);
        ((ISupportInitialize)chart1).EndInit();
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        ((ISupportInitialize)chart2).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private Label label1;
    private DateTimePicker ngayKT1;
    private DateTimePicker ngayBD1;
    private TabPage tabPage2;
    private Button button1;
    private Label label2;
    private Button button2;
    private Label label3;
    private Label label4;
    private DateTimePicker ngayKT2;
    private DateTimePicker ngayBD2;
    private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
}