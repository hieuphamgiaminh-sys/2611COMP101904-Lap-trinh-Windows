using lab07.Forms;
using System;
using System.Windows.Forms;

namespace lab07
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            FrmLogin frmLogin = new FrmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new FrmMain(frmLogin.LoggedInUser));
            }
        }
    }
}