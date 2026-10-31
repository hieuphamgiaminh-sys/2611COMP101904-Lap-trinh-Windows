using System;
using System.Windows.Forms;

namespace lab09
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new lab09());
        }
    }
}