using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFunctions
{
    internal static class MousePointDisplayer
    {
        public static void Display(Camera camera, Function function, Point mouseFormLocation, Graphics g)
        {
            Point? mouseCameraLocation = CoordinateConverter.FormToCamera(camera, mouseFormLocation);
            if (mouseCameraLocation is null) return;
            PointF mouseGridLocation = CoordinateConverter.CameraToGrid(camera, (Point)mouseCameraLocation);
            if (Math.Round(function.GetX(mouseGridLocation.Y), 2) == Math.Round(mouseGridLocation.X, 2) && Math.Round(function.GetY(mouseGridLocation.X), 2) == Math.Round(mouseGridLocation.Y, 2))
            {
                // Do something
            }
        }
        public static void DisplayByX(Camera camera, Function function, int mouseFormY, Graphics g)
        {
            int? mouseCameraY = CoordinateConverter.FormYToCameraY(camera, mouseFormY);
            if (mouseCameraY is null) return;
            double mouseGridY = CoordinateConverter.CameraYToGridY(camera, (int)mouseCameraY);
            PointF graphPoint = new PointF((float)function.GetX(mouseGridY), (float)mouseGridY);
        }
        public static void DisplayByY(Camera camera, Function function, Point mouseFormLocation, Graphics g)
        {
            Point? mouseCameraLocation = CoordinateConverter.FormToCamera(camera, mouseFormLocation);
            if (mouseCameraLocation is null) return;
            PointF mouseGridLocation = CoordinateConverter.CameraToGrid(camera, (Point)mouseCameraLocation);
            if (Math.Round(function.GetX(mouseGridLocation.Y), 2) == Math.Round(mouseGridLocation.X, 2) && Math.Round(function.GetY(mouseGridLocation.X), 2) == Math.Round(mouseGridLocation.Y, 2))
            {
                int p = CoordinateConverter.GridXToCameraX(camera, 0);
            }
        }
    }
}
