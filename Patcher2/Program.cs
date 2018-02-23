using System;
using System.IO;
using System.Windows.Forms;
using Patcher2.Forms;
using SimpleLogger;
using SimpleLogger.Logging.Handlers;

namespace Patcher2
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var patcher2 = Path.Combine(appdata, "Patcher2");
            var log = Path.Combine(patcher2, "log.txt");

            if (!Directory.Exists(patcher2))
            {
                Directory.CreateDirectory(patcher2);
            }

            Logger.LoggerHandlerManager.AddHandler(new FileLoggerHandler(log));
            Logger.Log("Logger initialized");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
