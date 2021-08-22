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
using System.Threading;

namespace MeasurmentComputingAcc
{
    public partial class Form1 : Form
    {
        string fileName = "Log.csv";
        StreamWriter write;

        private const int AVERAGE = 40;
        private const int DIFFERENTIAL = 20;
        private MccDaq.MccBoard DaqBoard;
        private short xValueAnalog, yValueAnalog, zValueAnalog, vValueAnalog, pValueAnalog; // v is combine vector, p is pressure value
        private short[] zValueAnalogArr;            // Use to hold previous results in order to calculate differencial
        private short zValueAnalogArrIndex;
        private short zMax, zMaxTemp, zMin, zMinTemp, zRange, zRangePrev;
        private bool zSlope;
        private short newMax, newMin;
        private short[] zValueAnalogAverageArr;
        
        // Variables, array and list for dynamic plot of data
        private short[] zGarr;
        private short zGindex;
        private Int32 zGarrSum;
        private short zG;
        private List<short> zGlist = new List<short>();
        //plotStruct plotVar;

        private short zValueAnalogAverage;
        private int zValueAnalogSum;
        private short averageIndex;
        private short zIO_Log;                  // State of output IO
        private const short LOW  = 7000;
        private const short MIDDLE = 7500;
        private const short HIGH = 8000;

        private float breathTime, previousBreadTime;                   // Count number of 100ms ticks between picks
        private short nextBreath;                   // Number of time ticks until next Exhaust
        private short counter;                      // Prevent quick transactions
        private short transactionDelay = 0;   // Number of minimum cycles between transactions

        private const short NUM_OF_POINTS = 500;   // Total number of points in chart
        private bool pauseGraphFlag = false;
        private bool enableValve = false;
        private bool startMeasure = false;

        private const short GAVE = 300;

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
            chart1.Series["Respiration"].BorderWidth = 3;
            chart1.Series["Vaccum"].BorderWidth = 3;
        }

        public Form1()
        {
            InitializeComponent();

            zRange = 25;
            zRangePrev = 25;

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

            DaqBoard = new MccDaq.MccBoard(1);

            zValueAnalogArr = new short[DIFFERENTIAL];
            zValueAnalogArrIndex = 0;

            zIO_Log = 0; 
            
            zValueAnalogAverageArr = new short[AVERAGE];
            averageIndex = 0;

            transactionDelay = (short)(00 / timer1.Interval);  // Delay of 200 ms

            //plotVar = new plotStruct();
            zGarr = new short[GAVE];

            try
            {
                if (File.Exists(fileName))
                {
                    write = new StreamWriter(fileName, false);
                    write.Write("Zvalue" + "\t" + "Max" + "\t" + "Min" + "\t" + "zRange" + "\t" + "zRangePrev" + "\t" + "IO" + "\n");
                }
            }
            catch (Exception ex)
            { }

            DaqBoard.DConfigPort(MccDaq.DigitalPortType.AuxPort, MccDaq.DigitalPortDirection.DigitalOut);
            
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
                // write.Close();
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
            DaqBoard.AIn(4, MccDaq.Range.Bip10Volts, out zValueAnalog);

            DaqBoard.AIn(3, MccDaq.Range.Bip10Volts, out pValueAnalog);

            xValueAnalog -= 32767;
            yValueAnalog -= 32767;
            zValueAnalog = (short)(zValueAnalog & 0x7FFF);
            pValueAnalog = (short)(pValueAnalog & 0x7FFF);      // Pressure / Vacuum values

            vValueAnalog = (short)Math.Sqrt(xValueAnalog * xValueAnalog + yValueAnalog * yValueAnalog + zValueAnalog * zValueAnalog);   // Combined vector
            vValue.Text = vValueAnalog.ToString();
            
            // Decrease DC values in order to focuse on the signal
            //zValueAnalog -= 1000;
            //zValueAnalog *= 8;
            //zValueAnalog -= 10000;

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

            zValueAnalogAverage -= 1000;
            zValueAnalogAverage *= 8;
            zValueAnalogAverage -= 10000;

            // Calculating DC and manage MIN MAX list for graph automatic axis update
            CalculateDC();
            
            // Search minimum and maximum from actual signal
            SearchMinMax();
            
            // Toggle output, verify not to fast
            if ((counter > transactionDelay) /*&& (zRange > 50)*/)      // Option to block to fast transactions, e.g set as 20 for 200ms delay
            {
                counter = 0;

                // Use one of the 3 algorithem options
                if (((chbConst.Checked == true) && (zValueAnalogAverage < (zValueAnalogArr[DIFFERENTIAL - 1] - delta)) &&  // Compare present value to 3 different early values, improve stability
                    (zValueAnalogAverage < (zValueAnalogArr[(DIFFERENTIAL / 2) - 1] - delta)) &&
                    (zValueAnalogAverage < (zValueAnalogArr[(DIFFERENTIAL - 5) - 1] - delta))) ||
                ((chbManual.Checked == true) && (zValueAnalogAverage < (Convert.ToInt32(txtMiddle.Text) + Convert.ToInt32(txtRange.Text)))) ||
                ((chbMeasure.Checked == true) && (zSlope == false) /* (zValueAnalogAverage < (zMax - (zRange / 4))) */ ))
                {
                    zIO_Log = LOW;
                    InHale();
                }
                else if (((chbConst.Checked == true) && (zValueAnalogAverage > (zValueAnalogArr[DIFFERENTIAL - 1] + delta)) &&   // Compare present value to 3 different early values, improve stability
                    (zValueAnalogAverage > (zValueAnalogArr[(DIFFERENTIAL / 2) - 1] + delta)) &&
                    (zValueAnalogAverage > (zValueAnalogArr[(DIFFERENTIAL - 5) - 1] + delta))) ||
                (chbManual.Checked == true) ||
                ((chbMeasure.Checked == true) && (zSlope == true) /* (zValueAnalogAverage > (zMin + (zRange / 4))) */ ))
                {
                    if (zRange > 20)
                    {
                        zIO_Log = HIGH;
                        ExHale();
                    }
                }
            }
            
            LogValues();

            // Manage array of values in order to calculate derivative and slop
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
            DaqBoard.DOut(MccDaq.DigitalPortType.AuxPort, 0x0000);
            status.BackColor = Color.Green;
            txtBreath.Text = "Inhale";
            timer2.Stop();
            //dataStruct[arrayIndex].digital = 0x1;
        }

        private void ExHale()
        {
            if (enableValve == true)
            {
                DaqBoard.DOut(MccDaq.DigitalPortType.AuxPort, 0xFFFF);
            }
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

            if ((zValueAnalogAverage < (zMaxTemp - (zRange / 4) )) /* && (newMax == 1)*/)
            {
                zSlope = false;
                newMin = 1;
                newMax = 0;
                zMax = zMaxTemp;
                txtMax.Text = zMaxTemp.ToString();
                zMaxTemp = 0;
                if ((zMax - zMin) > 0)
                {
                    zRange = (short)(zMax - zMin);

                    // Prevent dramatic changes in Range, disregard single big changes (becasue it prevents detecting next MIN or MAX)
                    if ((zRange > (zRangePrev << 2)) || (zRange < 25))
                        zRange = zRangePrev;
                    else
                        zRangePrev = zRange;
                }
                else
                    zRange = 0;
            }

            if ((zValueAnalogAverage < zMinTemp) && (newMin == 1))
            {
                zMinTemp = zValueAnalogAverage;
            }

            if ((zValueAnalogAverage > (zMinTemp + (zRange / 4) ))/* && (newMin == 1)*/)
            {
                // Time of previous breath
                previousBreadTime = breathTime;         // In timer ticks
                breathTime = (breathTime * timer1.Interval) / 1000;
                txtTime.Text = breathTime.ToString();

                // Count breath per second
                if (breathTime != 0)
                    txtBinS.Text = ((short)(60 / breathTime)).ToString();

                breathTime = 0;
                zSlope = true;
                newMax = 1;
                newMin = 0;
                zMin = zMinTemp;
                txtMin.Text = zMinTemp.ToString();
                zMinTemp = 0x7fff;
                if ((zMax - zMin) > 0)
                {
                    zRange = (short)(zMax - zMin);
                    // Prevent dramatic changes in Range, disregard single big changes (becasue it prevents detecting next MIN or MAX)
                    if ((zRange > (zRangePrev << 2)) || (zRange < 25))
                        zRange = zRangePrev;
                    else
                        zRangePrev = zRange;
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

        // Calculating DC and MIN MAX manage list for graph automatic axis update
        public void CalculateDC()
        {
            if (zGindex == 300)
                zGindex = 0;
            short listIndex = 0;
            
            zGarr[zGindex++] = zValueAnalogAverage;

            // Only if graph is active
            if (pauseGraphFlag == false)
            {
                // Search the items list for location of next element 
                while ((zGlist.Count > 0) && (listIndex < zGlist.Count) && (zValueAnalogAverage > zGlist[listIndex])) // Verify the list not empty + search for list item bigger then last measurement
                {
                    if (listIndex >= zGlist.Count)
                    {
                        break;
                    }
                    listIndex++;
                }
                zGlist.Insert(listIndex, zValueAnalogAverage);
            }
            zGarrSum = 0;
            for (int i = 0; i < GAVE; i++)
            {
                zGarrSum += zGarr[i];
            }
            zG = (short)(zGarrSum / GAVE);
        }

        private void LogValues()
        {
            //dataStruct[arrayIndex++].value = zValueAnalogAverage;
            if (write != null)
            {
                //write.Write(zValueAnalogAverage + "\t" + zMax + "\t" + zMaxTemp + "\t" + zMin + "\t" + zMinTemp + "\t" + zIO + "\n");
                write.Write(zValueAnalogAverage + "\t" + zMax + "\t" + zMin + "\t" + zRange + "\t" + zRangePrev + "\t" + zIO_Log + "\n");
            }

            //// Logging into array
            //if (arrayIndex_Log < 10000)
            //{
            //    zMAxArr_Log[arrayIndex_Log] = zMax;
            //    zMaxTempArr_Log[arrayIndex_Log] = zMaxTemp;
            //    zMinArr_Log[arrayIndex_Log] = zMin;
            //    zMinTempArr_Log[arrayIndex_Log] = zMinTemp;
            //    zIOarr_Log[arrayIndex_Log] = zIO_Log;
            //    zValueAnalogArr_Log[arrayIndex_Log++] = zValueAnalogAverage;
            //}
        }
        
        private void Plot()
        {
            short listIndex = 0;
            if (pauseGraphFlag == false)        // Continue to add point to graph
            {
                chart1.Series["Respiration"].Points.Add(zValueAnalogAverage);
                chart1.Series["Vaccum"].Points.Add(pValueAnalog);
                if (zIO_Log == HIGH)
                   chart1.Series["Respiration"].Points[chart1.Series["Respiration"].Points.Count()-1].Color = Color.Red;
                else if (zIO_Log == LOW)
                    chart1.Series["Respiration"].Points[chart1.Series["Respiration"].Points.Count()-1].Color = Color.Green;

                System.Windows.Forms.DataVisualization.Charting.Axis y = new System.Windows.Forms.DataVisualization.Charting.Axis();
                //y.Minimum = zG - 300;
                //y.Maximum = zG + 300;
                y.Minimum = zGlist.First();
                y.Maximum = zGlist.Last() + 1;
                
                chart1.ChartAreas[0].AxisY = y;

                if (chart1.Series["Respiration"].Points.Count() >= NUM_OF_POINTS)  // keep specified amount of point in graph, FIFO
                {
                    zGlist.Remove((short)chart1.Series["Respiration"].Points.First().YValues[0]);
                    chart1.Series["Respiration"].Points.RemoveAt(0);                // Remove the oldest measured item
                    chart1.Series["Vaccum"].Points.RemoveAt(0);                     // Remove the oldest measured item
                    
                    chart1.ResetAutoValues();
                    chart1.ChartAreas[0].RecalculateAxesScale();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zRange = 25;
            zRangePrev = 25;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            zIO_Log = LOW;
            InHale();
        }
    }
}
