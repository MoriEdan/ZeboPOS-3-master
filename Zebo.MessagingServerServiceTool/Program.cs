using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Zebo.MessagingServerServiceTool;

namespace Zebo.MessagingServerServiceTool
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CurrentCulture;
            Application.Run(new FrmMain());
        }
    }
}
