using System;
using System.IO;

namespace VddsMediaNet.Logger
{
    public class VddsMediaLogger : IVddsMediaLogger
    {
        public string Path { get; set; }


        public VddsMediaLogger(string path)
        {
            Path = path ?? throw new ArgumentNullException(nameof(path));
        }

        public void Log(VddsMediaDirection direction, string data)
        {
            try
            {
                using (var writer = File.AppendText(Path))
                {
                    var message = string.Empty;

                    if (direction == VddsMediaDirection.Incoming)
                    {
                        message = "incoming VDDS-media request";
                    }
                    else
                    {
                        message = "outgoing VDDS-media request";
                    }

                    writer.WriteLine($"[{DateTime.Now.ToString()}] Received {message}:");
                    writer.WriteLine(data);
                    writer.WriteLine("================================================================================");
                }
            }
            catch
            {

            }
        }
    }
}