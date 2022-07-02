using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OximeterServer.Data
{
    internal class OximeterStreamData
    {
        public DateTime Timestamp { get; init; }
        public UInt32 Millis { get; init; }
        public byte SpO2 { get; init; }
        public byte PulseRate { get; init; }
        public UInt32 IR { get; init; }
        public byte IRIndex { get; init; }
        public byte SpO2Status { get; init; }
        public UInt16 BatteryLevel { get; init; }

        public byte[] GetBytes(char separator)
        {
            StringBuilder sb = new();

            sb.Append($"0001{separator}");                            // 1
            sb.Append($"{(Timestamp.Year - 2000):D2}{separator}");    // 2
            sb.Append($"{Timestamp.Month:D2}{separator}");            // 3
            sb.Append($"{Timestamp.Day:D2}{separator}");              // 4
            sb.Append($"{Timestamp.Hour:D2}{separator}");             // 5
            sb.Append($"{Timestamp.Minute:D2}{separator}");           // 6
            sb.Append($"{Timestamp.Second:D2}{separator}");           // 7
            sb.Append($"{Timestamp.Millisecond:D4}{separator}");      // 8
            sb.Append($"{Millis:D10}{separator}");                    // 9
            sb.Append($"{SpO2:D3}{separator}");                       // 10
            sb.Append($"{PulseRate:D3}{separator}");                  // 11
            sb.Append($"{IR:D10}{separator}");                        // 12
            sb.Append($"{IRIndex:D3}{separator}");                    // 13
            sb.Append($"{SpO2Status:D3}{separator}");                 // 14
            sb.Append($"{BatteryLevel:D5}{separator}");               // 15
            sb.Append("\r\n");

            return Encoding.ASCII.GetBytes(sb.ToString());
        }
    }
}
