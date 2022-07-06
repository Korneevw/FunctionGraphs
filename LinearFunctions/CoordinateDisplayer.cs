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
            if (CoordinateConverter.CameraXToGridX(camera, 0) < 0 && CoordinateConverter.CameraXToGridX(camera, camera.Width) > 0)
            {
                int YLineY = (int)Math.Floor(camera.GridLocation.Y);
                while (YLineY > CoordinateConverter.CameraYToGridY(camera, camera.Height))
                {
                    int YLineYCamera = CoordinateConverter.GridYToCameraY(camera, YLineY);
                    graphics.DrawString($"{YLineY}", new Font(Form.DefaultFont.FontFamily, (int)((YLineY.ToString().Length > 5 ? 8 : 12) * camera.Scale)), Brushes.Black, new Point(camera.Location.X + CoordinateConverter.GridXToCameraX(camera, 0), camera.Location.Y + YLineYCamera));
                    YLineY--;
                }
                graphics.DrawString($"Y", new Font(Form.DefaultFont.FontFamily, (int)(12 * camera.Scale)), Brushes.Black, new Point(camera.Location.X + CoordinateConverter.GridXToCameraX(camera, 0) - 25, camera.Location.Y));
            }
            if (CoordinateConverter.CameraYToGridY(camera, 0) > 0 && CoordinateConverter.CameraYToGridY(camera, camera.Height) < 0)
            {
                int XLineX = (int)Math.Ceiling(camera.GridLocation.X);
                while (XLineX < CoordinateConverter.CameraXToGridX(camera, camera.Width))
                {
                    int XLineXCamera = CoordinateConverter.GridXToCameraX(camera, XLineX);
                    graphics.DrawString($"{XLineX}", new Font(Form.DefaultFont.FontFamily, (int)((XLineX.ToString().Length > 5 ? 8 : 12) * camera.Scale)), Brushes.Black, new Point(camera.Location.X + XLineXCamera, camera.Location.Y + CoordinateConverter.GridYToCameraY(camera, 0)));
                    XLineX++;
                }
                graphics.DrawString($"X", new Font(Form.DefaultFont.FontFamily, (int)(12 * camera.Scale)), Brushes.Black, new Point(camera.Location.X + camera.Width - 20, camera.Location.Y + CoordinateConverter.GridYToCameraY(camera, 0) - 25));
            }
        }
    }
}
