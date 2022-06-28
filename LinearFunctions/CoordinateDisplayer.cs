using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFunctions
{
    internal static class CoordinateDisplayer
    {
        public static void Display(Camera camera, Graphics graphics)
        {
            if (CoordinateConverter.ConvertToGridX(camera, 0) < 0 && CoordinateConverter.ConvertToGridX(camera, camera.Width) > 0)
            {
                int YLineY = (int)Math.Floor(camera.GridLocation.Y);
                while (YLineY > CoordinateConverter.ConvertToGridY(camera, camera.Height))
                {
                    int YLineYCamera = CoordinateConverter.ConvertToCameraY(camera, YLineY);
                    graphics.DrawString($"{YLineY}", new Font(Form.DefaultFont.FontFamily, (int)(12 * camera.Scale)), Brushes.Black, new Point(camera.Location.X + CoordinateConverter.ConvertToCameraX(camera, 0), camera.Location.Y + YLineYCamera));
                    YLineY--;
                }
            }
            if (CoordinateConverter.ConvertToGridY(camera, 0) > 0 && CoordinateConverter.ConvertToGridY(camera, camera.Height) < 0)
            {
                int XLineX = (int)Math.Ceiling(camera.GridLocation.X);
                while (XLineX < CoordinateConverter.ConvertToGridX(camera, camera.Width))
                {
                    int XLineXCamera = CoordinateConverter.ConvertToCameraX(camera, XLineX);
                    graphics.DrawString($"{XLineX}", new Font(Form.DefaultFont.FontFamily, (int)(12 * camera.Scale)), Brushes.Black, new Point(camera.Location.X + XLineXCamera, camera.Location.Y + CoordinateConverter.ConvertToCameraY(camera, 0)));
                    XLineX++;
                }
            }
        }
    }
}
