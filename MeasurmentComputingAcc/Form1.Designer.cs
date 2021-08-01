
namespace MeasurmentComputingAcc
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.xValue = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.yValue = new System.Windows.Forms.Label();
            this.zValue = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMiddle = new System.Windows.Forms.TextBox();
            this.txtRange = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMin = new System.Windows.Forms.TextBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtActualRange = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDelta = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBinS = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.vValue = new System.Windows.Forms.Label();
            this.chbMeasure = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chbConst = new System.Windows.Forms.CheckBox();
            this.chbManual = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtBreath = new System.Windows.Forms.TextBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label13 = new System.Windows.Forms.Label();
            this.txtEarlyPump = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pauseGraph = new System.Windows.Forms.Button();
            this.enValve = new System.Windows.Forms.Button();
            this.dataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "StartMeasuring";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // xValue
            // 
            this.xValue.AutoSize = true;
            this.xValue.Location = new System.Drawing.Point(26, 52);
            this.xValue.Name = "xValue";
            this.xValue.Size = new System.Drawing.Size(13, 13);
            this.xValue.TabIndex = 1;
            this.xValue.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(26, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "X acceleration";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(120, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y acceleration";
            // 
            // yValue
            // 
            this.yValue.AutoSize = true;
            this.yValue.Location = new System.Drawing.Point(120, 52);
            this.yValue.Name = "yValue";
            this.yValue.Size = new System.Drawing.Size(13, 13);
            this.yValue.TabIndex = 5;
            this.yValue.Text = "0";
            // 
            // zValue
            // 
            this.zValue.AutoSize = true;
            this.zValue.Location = new System.Drawing.Point(206, 52);
            this.zValue.Name = "zValue";
            this.zValue.Size = new System.Drawing.Size(13, 13);
            this.zValue.TabIndex = 6;
            this.zValue.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(206, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Z acceleration";
            // 
            // txtMiddle
            // 
            this.txtMiddle.Location = new System.Drawing.Point(11, 53);
            this.txtMiddle.Name = "txtMiddle";
            this.txtMiddle.Size = new System.Drawing.Size(100, 20);
            this.txtMiddle.TabIndex = 8;
            this.txtMiddle.Text = "0";
            // 
            // txtRange
            // 
            this.txtRange.Location = new System.Drawing.Point(185, 53);
            this.txtRange.Name = "txtRange";
            this.txtRange.Size = new System.Drawing.Size(100, 20);
            this.txtRange.TabIndex = 9;
            this.txtRange.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Middle_Value";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(185, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Range";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(191, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Min";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Max";
            // 
            // txtMin
            // 
            this.txtMin.Location = new System.Drawing.Point(191, 44);
            this.txtMin.Name = "txtMin";
            this.txtMin.Size = new System.Drawing.Size(100, 20);
            this.txtMin.TabIndex = 13;
            this.txtMin.Text = "0";
            // 
            // txtMax
            // 
            this.txtMax.Location = new System.Drawing.Point(17, 44);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(100, 20);
            this.txtMax.TabIndex = 12;
            this.txtMax.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Range";
            // 
            // txtActualRange
            // 
            this.txtActualRange.Location = new System.Drawing.Point(14, 106);
            this.txtActualRange.Name = "txtActualRange";
            this.txtActualRange.Size = new System.Drawing.Size(100, 20);
            this.txtActualRange.TabIndex = 16;
            this.txtActualRange.Text = "0";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(12, 60);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(95, 240);
            this.status.TabIndex = 18;
            this.status.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Delta";
            // 
            // txtDelta
            // 
            this.txtDelta.Location = new System.Drawing.Point(175, 36);
            this.txtDelta.Name = "txtDelta";
            this.txtDelta.Size = new System.Drawing.Size(100, 20);
            this.txtDelta.TabIndex = 19;
            this.txtDelta.Text = "5";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtMiddle);
            this.groupBox1.Controls.Add(this.txtRange);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(432, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 96);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual adjustment";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBinS);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtTime);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtMax);
            this.groupBox2.Controls.Add(this.txtMin);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtActualRange);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(432, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(356, 191);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Calculation";
            // 
            // txtBinS
            // 
            this.txtBinS.Location = new System.Drawing.Point(188, 161);
            this.txtBinS.Name = "txtBinS";
            this.txtBinS.Size = new System.Drawing.Size(100, 20);
            this.txtBinS.TabIndex = 20;
            this.txtBinS.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(188, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 21;
            this.label12.Text = "Breath in Second";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(191, 106);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 20);
            this.txtTime.TabIndex = 18;
            this.txtTime.Text = "0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(191, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Last Breath time";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label11.Location = new System.Drawing.Point(120, 86);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 24;
            this.label11.Text = "Joined Vector";
            // 
            // vValue
            // 
            this.vValue.AutoSize = true;
            this.vValue.Location = new System.Drawing.Point(120, 110);
            this.vValue.Name = "vValue";
            this.vValue.Size = new System.Drawing.Size(13, 13);
            this.vValue.TabIndex = 23;
            this.vValue.Text = "0";
            // 
            // chbMeasure
            // 
            this.chbMeasure.AutoSize = true;
            this.chbMeasure.Checked = true;
            this.chbMeasure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbMeasure.Location = new System.Drawing.Point(17, 35);
            this.chbMeasure.Name = "chbMeasure";
            this.chbMeasure.Size = new System.Drawing.Size(128, 17);
            this.chbMeasure.TabIndex = 22;
            this.chbMeasure.Text = "Use measured values";
            this.chbMeasure.UseVisualStyleBackColor = true;
            this.chbMeasure.CheckedChanged += new System.EventHandler(this.chbMeasure_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.chbManual);
            this.groupBox3.Controls.Add(this.chbMeasure);
            this.groupBox3.Location = new System.Drawing.Point(123, 201);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 157);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Choose Algorithem";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chbConst);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtDelta);
            this.groupBox4.Location = new System.Drawing.Point(6, 82);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(291, 63);
            this.groupBox4.TabIndex = 26;
            this.groupBox4.TabStop = false;
            // 
            // chbConst
            // 
            this.chbConst.AutoSize = true;
            this.chbConst.Location = new System.Drawing.Point(11, 36);
            this.chbConst.Name = "chbConst";
            this.chbConst.Size = new System.Drawing.Size(123, 17);
            this.chbConst.TabIndex = 24;
            this.chbConst.Text = "Use constant values";
            this.chbConst.UseVisualStyleBackColor = true;
            this.chbConst.CheckedChanged += new System.EventHandler(this.chbConst_CheckedChanged);
            // 
            // chbManual
            // 
            this.chbManual.AutoSize = true;
            this.chbManual.Location = new System.Drawing.Point(17, 62);
            this.chbManual.Name = "chbManual";
            this.chbManual.Size = new System.Drawing.Size(116, 17);
            this.chbManual.TabIndex = 23;
            this.chbManual.Text = "Use manual values";
            this.chbManual.UseVisualStyleBackColor = true;
            this.chbManual.CheckedChanged += new System.EventHandler(this.chbManual_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.xValue);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.vValue);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.yValue);
            this.groupBox5.Controls.Add(this.zValue);
            this.groupBox5.Location = new System.Drawing.Point(123, 60);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(297, 135);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Measured values";
            // 
            // txtBreath
            // 
            this.txtBreath.Location = new System.Drawing.Point(12, 26);
            this.txtBreath.Name = "txtBreath";
            this.txtBreath.Size = new System.Drawing.Size(95, 20);
            this.txtBreath.TabIndex = 27;
            // 
            // timer2
            // 
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(132, 370);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 26;
            this.label13.Text = "Early Pumping [10ms]";
            // 
            // txtEarlyPump
            // 
            this.txtEarlyPump.Location = new System.Drawing.Point(135, 386);
            this.txtEarlyPump.Name = "txtEarlyPump";
            this.txtEarlyPump.Size = new System.Drawing.Size(100, 20);
            this.txtEarlyPump.TabIndex = 25;
            this.txtEarlyPump.Text = "0";
            this.txtEarlyPump.TextChanged += new System.EventHandler(this.txtEarlyPump_TextChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(15, 412);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Respiration";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1044, 180);
            this.chart1.TabIndex = 29;
            this.chart1.Text = "chart1";
            // 
            // pauseGraph
            // 
            this.pauseGraph.Location = new System.Drawing.Point(76, 609);
            this.pauseGraph.Name = "pauseGraph";
            this.pauseGraph.Size = new System.Drawing.Size(117, 23);
            this.pauseGraph.TabIndex = 30;
            this.pauseGraph.Text = "Pause Graph";
            this.pauseGraph.UseVisualStyleBackColor = true;
            this.pauseGraph.Click += new System.EventHandler(this.pauseGraph_Click);
            // 
            // enValve
            // 
            this.enValve.Location = new System.Drawing.Point(233, 23);
            this.enValve.Name = "enValve";
            this.enValve.Size = new System.Drawing.Size(137, 23);
            this.enValve.TabIndex = 31;
            this.enValve.Text = "Enable Valve";
            this.enValve.UseVisualStyleBackColor = true;
            this.enValve.Click += new System.EventHandler(this.enValve_Click);
            // 
            // dataBindingSource
            // 
            this.dataBindingSource.DataSource = typeof(MeasurmentComputingAcc.data);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1071, 658);
            this.Controls.Add(this.enValve);
            this.Controls.Add(this.pauseGraph);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtBreath);
            this.Controls.Add(this.txtEarlyPump);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Spear-Respiration_v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label xValue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label yValue;
        private System.Windows.Forms.Label zValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMiddle;
        private System.Windows.Forms.TextBox txtRange;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.BindingSource dataBindingSource;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMin;
        private System.Windows.Forms.TextBox txtMax;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtActualRange;
        private System.Windows.Forms.Button status;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDelta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label vValue;
        private System.Windows.Forms.TextBox txtBinS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chbMeasure;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chbConst;
        private System.Windows.Forms.CheckBox chbManual;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txtBreath;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEarlyPump;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button pauseGraph;
        private System.Windows.Forms.Button enValve;
    }
}

