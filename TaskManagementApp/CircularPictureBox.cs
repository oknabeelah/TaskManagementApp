
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Devart.Data;
using Devart.Data.PostgreSql;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace Whole_Saler.forms
{
    public class CircularPictureBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(ClientRectangle);

                // Clip the control to the circular shape
                Region = new Region(path);

                // Draw the border (optional)
                using (Pen pen = new Pen(Color.Black, 2f))
                {
                    e.Graphics.DrawEllipse(pen, ClientRectangle);
                }
            }
        }
    }
}

   