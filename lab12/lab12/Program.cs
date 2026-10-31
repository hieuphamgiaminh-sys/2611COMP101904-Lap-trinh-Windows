using System;
using System.Windows.Forms;
using lab12.Forms;

namespace lab12
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmNhapDiemTheoLop());
        }
    }
}