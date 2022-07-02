using System.Runtime;
using OximeterServer.Data;
using SpreadsheetLight;

namespace OximeterServer.Exporters
{
    internal class ExcelExporter : Exporter
    {
        private readonly string _fileName;
        private readonly List<OximeterStreamData> _data;
        public ExcelExporter(string fileName, List<OximeterStreamData> data) : base()
        {
            _fileName = fileName;
            _data = data;
        }

        protected override void DoWork()
        {
            GCLatencyMode gcMode = GCSettings.LatencyMode;

            float progress = 0.0f;

            try
            {
                GCSettings.LatencyMode = GCLatencyMode.LowLatency;
                this.thread.Priority = ThreadPriority.Lowest;

                using (SLDocument sl = new SLDocument())
                {
                    sl.RenameWorksheet("Sheet1", "Oximeter");
                    sl.SelectWorksheet("Oximeter");
                    sl.SetCellValue(1, 1, "Time");
                    sl.SetCellValue(1, 2, "Millis");
                    sl.SetCellValue(1, 3, "SpO2");
                    sl.SetCellValue(1, 4, "Pulse Rate");
                    sl.SetCellValue(1, 5, "IR");
                    sl.SetCellValue(1, 6, "IR Index");
                    sl.SetCellValue(1, 7, "SpO2 Status");
                    sl.SetCellValue(1, 8, "Battery");

                    for (int i = 0; i < _data.Count && !this.terminationRequested; i++)
                    {
                        progress = i * 99.0f / _data.Count;
                        OnProgressChangedEvent(progress, $"Excel export: {progress:F0}%");

                        sl.SetCellValue(i + 2, 1, _data[i].Timestamp.ToString("yyyy.MM.dd HH:mm:ss.fff"));
                        sl.SetCellValue(i + 2, 2, _data[i].Millis);
                        sl.SetCellValue(i + 2, 3, _data[i].SpO2);
                        sl.SetCellValue(i + 2, 4, _data[i].PulseRate);
                        sl.SetCellValue(i + 2, 5, _data[i].IR);
                        sl.SetCellValue(i + 2, 6, _data[i].IRIndex);
                        sl.SetCellValue(i + 2, 7, $"{_data[i].SpO2Status:X2}");
                        sl.SetCellValue(i + 2, 8, _data[i].BatteryLevel/1000);
                        Thread.SpinWait(100);
                    }

                    if (!this.terminationRequested)
                    {
                        for (int i = 1; i <= 8; i++)
                            sl.AutoFitColumn(i);

                        sl.SaveAs(_fileName);
                        OnProgressChangedEvent(100.0f, $"Excel export completed: {_data.Count} points");
                    }
                    else
                    {
                        OnProgressChangedEvent(progress, "Excel export cancelled");
                    }
                }
            }
            catch
            {
                OnProgressChangedEvent(progress, "Excel export failed");
            }
            finally
            {
                GCSettings.LatencyMode = gcMode;
            }

            OnCompletedEvent();
        }
    }
}
