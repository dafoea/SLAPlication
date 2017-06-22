using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PrinterTestForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Warn the user if there is no projector connectected to the computer. it should be noted that this will not
            //know if the user is running a 2-monitor setup
            while (Screen.AllScreens.Length == 1)
            {
                DialogResult result = MessageBox.Show("No external display detected, please connect the projector before proceding", "Warning", MessageBoxButtons.AbortRetryIgnore);
                if (result == DialogResult.Abort) Environment.Exit(0);
                if (result == DialogResult.Ignore) break;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());


        }
    }
}
