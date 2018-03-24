using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using EasySort.Tests;
using EasySort.Classes;
using EasySort.WinForms;

namespace EasySort
{
    static class Program
    {
        static bool debugMode = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Run();
        }

        static void Run()
        {
            if (debugMode)
                RunDebug();
            else
                RunMain();
        }

        static void RunMain()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        static void RunDebug()
        {
            UnitTests.TestHSV();
        }
    }
}
