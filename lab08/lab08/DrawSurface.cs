using System.Drawing;
using System.Windows.Forms;

namespace lab08
{
    public class DrawSurface : Panel
    {
        public DrawSurface()
        {
            DoubleBuffered = true;
            BackColor = Color.White;
            Dock = DockStyle.Fill;
        }
    }
}