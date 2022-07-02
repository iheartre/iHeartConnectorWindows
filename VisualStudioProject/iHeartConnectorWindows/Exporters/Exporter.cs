using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OximeterServer.Exporters
{
    internal abstract class Exporter
    {
        public class ExporterEventArgs : EventArgs
        {
            public float Progress { get; set; }
            public string? Status { get; set; }
        }

        public event EventHandler? OnCompleted;
        public event EventHandler<ExporterEventArgs>? OnProgressChanged;

        protected Thread thread;
        protected bool terminationRequested = false;

        protected Exporter()
        {
            thread = new Thread(DoWork);
        }

        public void Start()
        {
            thread.Start();
        }

        public async void Stop()
        {
            terminationRequested = true;
            await Task.Run(() => thread.Join());
        }

        protected abstract void DoWork();

        protected void OnCompletedEvent()
        {
            this.OnCompleted?.Invoke(this, EventArgs.Empty);
        }

        protected void OnProgressChangedEvent(float progress, string status)
        {
            this.OnProgressChanged?.Invoke(this, new ExporterEventArgs() { Progress = progress, Status = status });
        }
    }
}
