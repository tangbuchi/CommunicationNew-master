using System;
using System.Windows.Forms;
using ipScan.Classes.Main;

namespace ipScan
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
            // Application.Run(new IPScanForm());

            IPScanForm iPScanForm = new IPScanForm();
            iPScanForm.StartScan("192.168.61.1", "192.168.61.254");
            while (IPScanForm.IPScanDone == false)
            {
                if (IPScanForm.IPScanDone)
                {
                    Console.WriteLine("------------------------");
                }
                System.Threading.Thread.Sleep(300);
            }
        }
    }
}
