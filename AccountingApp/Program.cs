using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.DataLayer.Context;

namespace AccountingApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            int i = 0;
            Process Currentproc = Process.GetCurrentProcess();
            Process[] proc = Process.GetProcesses();
            foreach (Process item in proc)
            {
                if (Currentproc.ProcessName == item.ProcessName) i++;
            }
            if (i > 1)
            {
                MessageBox.Show("Press any Key To Exit... ");
                return;
            }


            UnitOfWork db = new UnitOfWork();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
