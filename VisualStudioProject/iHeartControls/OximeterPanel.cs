using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing.Drawing2D;

namespace OximeterControls
{
    public partial class OximeterPanel : UserControl
    {
        public enum ModeEnum { Pulse, Progress }
        private ModeEnum mode = ModeEnum.Pulse;
        public ModeEnum Mode
        {
            set
            {
                mode = value;

                switch (mode)
                {
                    case ModeEnum.Pulse:
                        values[0] = 1;
                        for (int i = 1; i < values.Length; i++)
                            values[i] = 0;
                        chartMin = values.Min();
                        chartMax = values.Max();
                        chartPanel.Invalidate();
                        chartFull = false;
                        chartIndex = 0;
                        break;
                    case ModeEnum.Progress:
                        chartIndex = values.Length - 1;
                        values[0] = 100;
                        for (int i = 1; i < values.Length; i++)
                            values[i] = 0;
                        chartPanel.Invalidate();
                        break;
                }
            }
            get
            {
                return mode;
            }

        }

        private const int valuesCount = 300;
        private UInt32[] values = new UInt32[valuesCount];
        private float[] chartY = new float[valuesCount];
        private UInt32 chartMax = UInt32.MaxValue;
        private UInt32 chartMin = UInt32.MinValue;
        private const float chartPadding = 5.0f;
        private int chartIndex = 0;
        private bool chartFull = false;

        private readonly Pen pulseFillPen;
        private readonly Pen pulseLinePen;
        private readonly Pen progressLinePen;
        private readonly Pen progressFillPen;
        private readonly Pen gridPen;

        private int spO2 = 0;
        public int SpO2
        {
            get
            {
                return spO2;
            }

            set
            {
                spO2 = value;
                if (value < 0)
                    spO2Label.Text = "‒";
                else
                    spO2Label.Text = spO2.ToString();
            }
        }

        private int pulseRate;
        public int PulseRate
        {
            get
            {
                return pulseRate;
            }
            set
            {
                pulseRate = value;
                if (value < 0)
                    pulseLabel.Text = "‒";
                else
                    pulseLabel.Text = pulseRate.ToString();
            }
        }

        public string MacAddress { get { return macLabel.Text; } set { macLabel.Text = value; } }

        private float progress;
        public float Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
                int len = (int)((chartPanel.Width - 2 * chartPadding) * progress / 100);

                values[0] = 0;
                for (int i = 1; i < values.Length - 3; i++)
                    values[i] = (uint)(i < len ? 100 : 0);
                values[values.Length - 3] = 0;
                values[values.Length - 2] = 0;
                values[values.Length - 1] = 0;

                CalculateChartValues();
                chartPanel.Invalidate();
            }
        }

        public OximeterPanel()
        {
            InitializeComponent();

            spO2Label.UseCompatibleTextRendering = true;
            pulseLabel.UseCompatibleTextRendering = true;

            pulseFillPen = new Pen(Color.FromArgb(32, 255, 165, 0));
            pulseLinePen = new Pen(Color.FromArgb(255, 255, 165, 0));
            pulseLinePen.Width = 1.5f;

            progressFillPen = new Pen(Color.FromArgb(32, 32, 200, 32));
            progressLinePen = new Pen(Color.FromArgb(255, 32, 200, 32));
            progressLinePen.Width = 1.5f;
            gridPen = new Pen(Color.FromArgb(16, 16, 16));

            this.Dock = DockStyle.Top;

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            chartPanel, new object[] { true });

            SpO2 = -1;
            PulseRate = -1;

            values[0] = 1;
            for (int i = 1; i < values.Length; i++)
            {
                values[i] = 0;
            }

            chartMin = values.Min();
            chartMax = values.Max();
        }

        private void chartPanel_Paint(object sender, PaintEventArgs e)
        {
            CalculateChartValues();
            Graphics g = e.Graphics;

            Pen fillPen = pulseFillPen;
            Pen linePen = pulseLinePen;

            switch (mode)
            {
                case ModeEnum.Pulse:
                    fillPen = pulseFillPen;
                    linePen = pulseLinePen;
                    break;
                case ModeEnum.Progress:
                    fillPen = progressFillPen;
                    linePen = progressLinePen;
                    break;
            }

            g.SmoothingMode = SmoothingMode.AntiAlias;

            for (int x = (int)chartPadding; x < chartPanel.Width; x += 50)
                g.DrawLine(gridPen, x, chartPadding, x, chartPanel.Height - chartPadding);

            for (int i = 0; i < valuesCount; i++)
            {
                if (i == chartIndex || i == chartIndex - 1 || i == chartIndex + 1)
                    continue;


                g.DrawLine(fillPen, i + chartPadding, chartPanel.Height - chartPadding, i + chartPadding, chartY[i]);
                if (i > 0)
                    g.DrawLine(linePen, i - 1 + chartPadding, chartY[i - 1], i + chartPadding, chartY[i]);
            }
        }

        public void AddPulseValue(UInt32 value)
        {
            if (!chartFull)
            {
                for (int i = chartIndex; i < valuesCount; i++)
                    values[i] = UInt32.MaxValue - value;

                if (chartIndex == valuesCount - 1)
                    chartFull = true;
            }
            else
            {
                values[chartIndex] = UInt32.MaxValue - value;
            }

            chartIndex++;
            if (chartIndex > valuesCount - 1)
                chartIndex = 0;

            chartPanel.Invalidate();
        }

        private void CalculateChartValues()
        {
            chartMin = values.Min();
            chartMax = values.Max();

            float d = chartMax - chartMin;

            if (d == 0)
                return;

            float h = chartPanel.Height - (2.0f * chartPadding) - 2.5f;

            for (int i = 0; i < valuesCount; i++)
            {
                chartY[i] = (1.0f - (values[i] - chartMin) / d) * h + chartPadding;
            }
        }
    }
}
