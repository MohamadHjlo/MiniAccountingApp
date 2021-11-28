using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing;

namespace Accounting.Utility.Gradiant_Color
{
    public class GradiantClr
    {
        public void PaintGradient(Control ControlName, LinearGradientMode Direction, Color SatartColor, Color EndColor)
        {
            LinearGradientBrush GradBrush;
            GradBrush = new LinearGradientBrush(new Rectangle(0, 0, ControlName.Width, ControlName.Height), SatartColor, EndColor, Direction);
            Bitmap bmp = new Bitmap(ControlName.Width, ControlName.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(GradBrush, new Rectangle(0, 0, ControlName.Width, ControlName.Height));
            ControlName.BackgroundImage = bmp;
            ControlName.BackgroundImageLayout = ImageLayout.Stretch;
        }
    }
}
