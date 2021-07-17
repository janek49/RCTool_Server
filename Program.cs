using System;
using System.Windows.Forms;
using RCTool_Server.Util;
using RCTool_Server.Views;

namespace RCTool_Server
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

            Logger.Log("Uruchomiono aplikację.");

            Application.Run(new FormMain());
        }
    }
}
