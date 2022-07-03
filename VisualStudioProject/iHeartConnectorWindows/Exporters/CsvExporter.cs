using OximeterServer.Data;
using System.Text;

namespace OximeterServer.Exporters
{
    internal class CsvExporter : Exporter
    {
        private readonly char _separator;
        private readonly string _fileName;
        private readonly List<OximeterStreamData> _data;
        public CsvExporter(string fileName, List<OximeterStreamData> data, char separator) : base()
        {
            _fileName = fileName;
            _data = data;
            _separator = separator;
        }

        protected override void DoWork()
        {
            float progress = 0.0f;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Time{_separator}Millis{_separator}SpO2{_separator}Pulse Rate{_separator}IR{_separator}IR Index{_separator}SpO2 Status{_separator}Battery{_separator}Device ID");
                for (int i = 0; i < _data.Count && !this.terminationRequested; i++)
                {
                    progress = i * 99.0f / _data.Count;
                    OnProgressChangedEvent(progress, $"CSV export: {progress:F0}%");

                    sb.AppendLine($"{_data[i].Timestamp.ToString("yyyy.MM.dd HH:mm:ss.fff")}{_separator}{_data[i].Millis}{_separator}{_data[i].SpO2}{_separator}{_data[i].PulseRate}{_separator}{_data[i].IR}{_separator}{_data[i].IRIndex}{_separator}{_data[i].SpO2Status:X2}{_separator}{(float)_data[i].BatteryLevel / 1000.0f}{_separator}{_data[i].DeviceId}");
                }

                if (!this.terminationRequested)
                {
                    File.WriteAllText(_fileName, sb.ToString());
                    OnProgressChangedEvent(100.0f, $"CSV export completed: {_data.Count} points");
                }
                else
                {
                    OnProgressChangedEvent(progress, "CSV export cancelled");
                }
            }
            catch
            {
                OnProgressChangedEvent(progress, "CSV export failed");
            }

            OnCompletedEvent();
        }
    }
}
