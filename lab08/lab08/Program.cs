using System;
using System.Windows.Forms;

namespace lab08
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPaint());
        }
    }
}