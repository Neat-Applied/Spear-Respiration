using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace MeasurmentComputingAcc
{
    public struct data {
        public short value { get; set; }
        public short digital { get; set; }
    }

    public partial class Form1 : Form
    {
        string fileName = "Log.csv";
        StreamWriter write;

        private const int AVERAGE = 20;
        private const int DIFFERENTIAL = 10;
        private MccDaq.MccBoard DaqBoard;
        private short xValueAnalog, yValueAnalog, zValueAnalog, vValueAnalog;
        private short[] zValueAnalogArr;            // Use to hold previous results in order to calculate differencial
        private short zValueAnalogArrIndex;
        private short zMax, zMaxTemp, zMin, zMinTemp, zRange;
        private bool zSlope;
        private short newMax, newMin;
        private short[] zValueAnalogAverageArr;
        private short zValueAnalogAverage;
        private int zValueAnalogSum;
        private short averageIndex;
        private short[] zValueAnalogArr_Log;
        private short[] zMAxArr_Log;
        private short[] zMaxTempArr_Log;
        private short[] zMinArr_Log;
        private short[] zMinTempArr_Log;
        private short zIO_Log;                  // State of output IO
        private short[] zIOarr_Log;
        private short arrayIndex_Log;
        private const short LOW  = 7000;
        private const short MIDDLE = 7500;
        private const short HIGH = 8000;

        private float breathTime, previousBreadTime;                   // Count number of 100ms ticks between picks
        private short nextBreath;                   // Number of time ticks until next Exhaust
        private short counter;                      // Prevent quick transactions
        private const short transactionDelay = 0;   // Number of minimum cycles between transactions

        private short plotPoints = 0;                   // Number of points in chart
        private const short NUM_OF_POINTS = 1000;   // Total number of points in chart
        private bool pauseGraphFlag = false;
        private bool enableValve = false;
        private bool startMeasure = false;

        data[] dataStruct;

        private void pauseGraph_Click(object sender, EventArgs e)
        {
            if (pauseGraphFlag == false)
            {
                pauseGraphFlag = true;
                pauseGraph.Text = "Resume Graph";
            }
            else
            {
                pauseGraphFlag = false;
                pauseGraph.Text = "Pause Graph";
            }
        }

        private void chbConst_CheckedChanged(object sender, EventArgs e)
        {
            if (chbConst.Checked == true)
            {
                chbManual.Checked = false;
                chbMeasure.Checked = false;
            }
        }

        private void chbManual_CheckedChanged(object sender, EventArgs e)
        {
            if (chbManual.Checked == true)
            {
                chbConst.Checked = false;
                chbMeasure.Checked = false;
            }
        }

        private void chbMeasure_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMeasure.Checked == true)
            {
                chbManual.Checked = false;
                chbConst.Checked = false;
            }
        }

        private void txtEarlyPump_TextChanged(object sender, EventArgs e)
        {
            if (txtEarlyPump.Text != "")
                nextBreath = (short)(Convert.ToInt32(txtEarlyPump.Text) / timer1.Interval);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataStruct = new data[10000];
            //dataBindingSource.DataSource = new List<data>();
            //cartesianChart1.AxisX.Add(new LiveCharts.Wpf.Axis
            //{
            //    Title = "Seconds",
            //    Labels = new[] { " " }
            //});
            //cartesianChart1.AxisY.Add(new LiveCharts.Wpf.Axis
            //{
            //    Title = "miliVolts",
            //    Labels = new[] {"one", "two"},
            //    LabelFormatter = value => value.ToString("C")
            //});
            //cartesianChart1.LegendLocation = LiveCharts.LegendLocation.Right;
        }

        public Form1()
        {
            InitializeComponent();

            zRange = 25;
            
            zMax = 0;
            zMaxTemp = 0;
            newMax = 1;
            zSlope = false;

            zMin = 0x7fff;
            zMinTemp = 0x7fff;
            newMin = 0;

            breathTime = 0;
            previousBreadTime = 0;
            counter = 0;
            nextBreath = 0;

            DaqBoard = new MccDaq.MccBoard(0);

            zValueAnalogArr = new short[DIFFERENTIAL];
            zValueAnalogArrIndex = 0;

            zValueAnalogArr_Log = new short[10000];
            zMAxArr_Log = new short[10000];
            zMaxTempArr_Log = new short[10000];
            zMinArr_Log = new short[10000];
            zMinTempArr_Log = new short[10000];
            zIOarr_Log = new short[10000];
            zIO_Log = 0; 
            arrayIndex_Log = 0;
            
            zValueAnalogAverageArr = new short[AVERAGE];
            averageIndex = 0;

            try
            {
                //if (File.Exists(fileName))
                //{
                    write = new StreamWriter(fileName, false);
                    write.Write("Zvalue" + "\t" + "Max" + "\t" + "Min" + "\t" + zRange + "\t" + "IO" + "\n");
                //}
            }
            catch (Exception ex)
            { }

            DaqBoard.DConfigPort(MccDaq.DigitalPortType.AuxPort, MccDaq.DigitalPortDirection.DigitalOut);
            //variable = new LineSeries() { Values = V };

            timer2.Start();
        }

        private void enValve_Click(object sender, EventArgs e)
        {
            if (enableValve == false)
            {
                enableValve = true;
                enValve.Text = "Disable Valve";
            }
            else
            {
                enableValve = false;
                enValve.Text = "Enable Valve";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (startMeasure == false)
            {
                button1.Text = "Stop measuring";
                startMeasure = true;
                timer1.Start();
            }
            else
            {
                button1.Text = "Start measuring";
                startMeasure = false;
                timer1.Stop();
                //write.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int i;
            int delta = 3;

            try
            {
                delta = Convert.ToInt32(txtDelta.Text);
            }
            catch (Exception ex) { };

            breathTime++;
            counter++;

            DaqBoard.AIn(0, MccDaq.Range.Bip10Volts, out xValueAnalog);
            DaqBoard.AIn(1, MccDaq.Range.Bip10Volts, out yValueAnalog);
            DaqBoard.AIn(2, MccDaq.Range.Bip10Volts, out zValueAnalog);
            
            xValueAnalog -= 32767;
            yValueAnalog -= 32767;
            zValueAnalog -= 32767;

            vValueAnalog = (short)Math.Sqrt(xValueAnalog * xValueAnalog + yValueAnalog * yValueAnalog + zValueAnalog * zValueAnalog);
            vValue.Text = vValueAnalog.ToString();

            zValueAnalog *= 2;

            // Manage average index
            if (averageIndex == AVERAGE)
                averageIndex = 0;

            zValueAnalogAverageArr[averageIndex++] = zValueAnalog;

            zValueAnalogSum = 0;
            for (i = 0; i < AVERAGE; i++)
            {
                zValueAnalogSum += zValueAnalogAverageArr[i];
            }
            zValueAnalogAverage = (short)(zValueAnalogSum / AVERAGE);

            // Calculate Min Max and Range of previoous breath
            SearchMinMax();
            if ((nextBreath != 0) && ((breathTime + nextBreath) > previousBreadTime))
            {
                zIO_Log = HIGH;
                if (enableValve == true)
                {
                    ExHale();
                }
            }
            // Toggle output, verify not to fast
            else if ((counter > transactionDelay) && (zRange > 50))
            {
                counter = 0;
                if ((chbConst.Checked == true) && (zValueAnalogAverage < (zValueAnalogArr[DIFFERENTIAL - 1] - delta)) ||
                ((chbManual.Checked == true) && (zValueAnalogAverage < (Convert.ToInt32(txtMiddle.Text) + Convert.ToInt32(txtRange.Text)))) ||
                ((chbMeasure.Checked == true) && (zSlope == false) /* (zValueAnalogAverage < (zMax - (zRange / 4))) */ ))
                {
                    zIO_Log = LOW;
                    InHale();
                }
                else if ((chbConst.Checked == true) && (zValueAnalogAverage > (zValueAnalogArr[DIFFERENTIAL - 1] + delta)) ||
                        (chbManual.Checked == true) ||
                        ((chbMeasure.Checked == true) && (zSlope == true) /* (zValueAnalogAverage > (zMin + (zRange / 4))) */ ))
                {
                    if (zRange > 20)
                    {
                        zIO_Log = HIGH;
                        if (enableValve == true)
                        {
                            ExHale();
                        }
                    }
                }
            }
            
            LogValues();

            if (zValueAnalogArrIndex == DIFFERENTIAL)
                zValueAnalogArrIndex = 0;
            zValueAnalogArr[zValueAnalogArrIndex++] = zValueAnalogAverage;
            
            xValue.Text = Convert.ToString(xValueAnalog);
            yValue.Text = Convert.ToString(yValueAnalog);
            zValue.Text = Convert.ToString(zValueAnalogAverage);

            Plot();
        }

        private void InHale()
        {
            DaqBoard.DOut(MccDaq.DigitalPortType.AuxPort, 0xffff);
            status.BackColor = Color.Green;
            txtBreath.Text = "Inhale";
            timer2.Stop();
            //dataStruct[arrayIndex].digital = 0x1;
        }

        private void ExHale()
        {
            DaqBoard.DOut(MccDaq.DigitalPortType.AuxPort, 0x0000);
            status.BackColor = Color.Red;
            txtBreath.Text = "Exhale";
            timer2.Start();
            //dataStruct[arrayIndex].digital = 0x0;
        }

        public void SearchMinMax()
        {
            if ((zValueAnalogAverage > zMaxTemp) && (newMax == 1))
            {
                zMaxTemp = zValueAnalogAverage;
            }

            if (zValueAnalogAverage < (zMaxTemp - (zRange / 4) ))
            {
                zSlope = false;
                breathTime = 0;
                newMin = 1;
                newMax = 0;
                zMax = zMaxTemp;
                txtMax.Text = zMaxTemp.ToString();
                zMaxTemp = 0;
                if ((zMax - zMin) > 0)
                {
                    zRange = (short)(zMax - zMin);
                }
                else
                    zRange = 0;
            }

            if ((zValueAnalogAverage < zMinTemp) && (newMin == 1))
            {
                zMinTemp = zValueAnalogAverage;
            }

            if (zValueAnalogAverage > (zMinTemp + (zRange / 4) ))
            {
                // Time of previous breath
                previousBreadTime = breathTime;         // In timer ticks
                breathTime = (breathTime * timer1.Interval) / 1000;
                txtTime.Text = breathTime.ToString();

                // Count breath per second
                if (breathTime != 0)
                    txtBinS.Text = ((short)(60 / breathTime)).ToString();

                zSlope = true;
                newMax = 1;
                newMin = 0;
                zMin = zMinTemp;
                txtMin.Text = zMinTemp.ToString();
                zMinTemp = 0x7fff;
                if ((zMax - zMin) > 0)
                {
                    zRange = (short)(zMax - zMin);
                }
                else
                    zRange = 0;
            }
            
            //if (zRange < 20)
            //{
            //    zRange = 20;
            //}

            txtActualRange.Text = zRange.ToString();
        }

        private void LogValues()
        {
            //dataStruct[arrayIndex++].value = zValueAnalogAverage;
            if (write != null)
            {
                //write.Write(zValueAnalogAverage + "\t" + zMax + "\t" + zMaxTemp + "\t" + zMin + "\t" + zMinTemp + "\t" + zIO + "\n");
                write.Write(zValueAnalogAverage + "\t" + zMax + "\t" + zMin + "\t" + zRange + "\t" + zIO_Log + "\n");
            }

            if (arrayIndex_Log < 10000)
            {
                zMAxArr_Log[arrayIndex_Log] = zMax;
                zMaxTempArr_Log[arrayIndex_Log] = zMaxTemp;
                zMinArr_Log[arrayIndex_Log] = zMin;
                zMinTempArr_Log[arrayIndex_Log] = zMinTemp;
                zIOarr_Log[arrayIndex_Log] = zIO_Log;
                zValueAnalogArr_Log[arrayIndex_Log++] = zValueAnalogAverage;
            }
        }
        
        private void Plot()
        {
            if (pauseGraphFlag == false)        // Continue to add point to graph
            {
                chart1.Series["Respiration"].Points.Add(zValueAnalogAverage);

                if (plotPoints < NUM_OF_POINTS)     // keep specified amount of point in graph
                {
                    plotPoints++;
                }
                else
                {
                    chart1.Series["Respiration"].Points.RemoveAt(0);
                }
            }
            
            // cartesianChart1.Series.Clear();
            //values.Add(zValueAnalogAverage);

            //series.Add(new LiveCharts.Wpf.LineSeries() { Title = "Acc", Values = new ChartValues<short>(values) });
            //series.Insert(index++, Values = new ChartValues<short>(values));
            //cartesianChart1.Series = series;

            // V.Add(400);

            //List<short> l = new List<short> { 400 };
            //variable.Values.Add(l);

            //cartesianChart1.Series.Insert(0, variable);
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            InHale();
        }

    }
}
