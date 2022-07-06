using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearFunctions
{
    internal static class MousePointDisplayer
    {
        public static void Display(Camera camera, Function function, Point mouseFormLocation, Graphics graphics)
        {
            Point? graphPointCamera = CoordinateConverter.FormToCamera(camera, mouseFormLocation);
            if (graphPointCamera is null) return;
            PointF graphPointGrid = CoordinateConverter.CameraToGrid(camera, (Point)graphPointCamera);
            int yAxisXCamera = CoordinateConverter.GridXToCameraX(camera, 0);
            if (yAxisXCamera < camera.Location.X) yAxisXCamera = 0;
            else if (yAxisXCamera > camera.Location.X + camera.Width) yAxisXCamera = camera.Width;
            graphics.DrawLine(Pens.Blue, new Point(camera.Location.X + ((Point)graphPointCamera).X, camera.Location.Y + ((Point)graphPointCamera).Y), new Point(camera.Location.X + yAxisXCamera, camera.Location.Y + ((Point)graphPointCamera).Y));
            int xAxisYCamera = CoordinateConverter.GridYToCameraY(camera, 0);
            if (xAxisYCamera < camera.Location.Y) xAxisYCamera = 0;
            else if (xAxisYCamera > camera.Height) xAxisYCamera = camera.Height;
            graphics.DrawLine(Pens.Blue, new Point(camera.Location.X + ((Point)graphPointCamera).X, camera.Location.Y + ((Point)graphPointCamera).Y), new Point(camera.Location.X + ((Point)graphPointCamera).X, camera.Location.Y + xAxisYCamera));
            SizeF stringSize = graphics.MeasureString($"({Math.Round(graphPointGrid.X, 3)}, {Math.Round(graphPointGrid.Y, 3)})", new Font(Form.DefaultFont.FontFamily, 12));
            Size stringSizeInt = new Size((int)Math.Round(stringSize.Width), (int)Math.Round(stringSize.Height));
            graphics.DrawString($"({Math.Round(graphPointGrid.X, 3)}, {Math.Round(graphPointGrid.Y, 3)})", new Font(Form.DefaultFont.FontFamily, 12), Brushes.Blue,
                new Point(camera.Location.X + ((Point)graphPointCamera).X - stringSizeInt.Width, camera.Location.Y + ((Point)graphPointCamera).Y - stringSizeInt.Height));
        }
        public static void DisplayByY(Camera camera, Function function, int mouseYForm, Graphics graphics)
        {
            int? mouseYCamera = CoordinateConverter.FormYToCameraY(camera, mouseYForm);
            if (mouseYCamera is null) return;
            double mouseYGrid = CoordinateConverter.CameraYToGridY(camera, (int)mouseYCamera);
            double? graphXGrid = function.GetX(mouseYGrid);
            if (graphXGrid is null) return;
            if (graphXGrid < CoordinateConverter.CameraXToGridX(camera, 0) || graphXGrid > CoordinateConverter.CameraXToGridX(camera, camera.Width)) return;
            PointF graphPointGrid = new PointF((float)graphXGrid, (float)mouseYGrid);
            Point graphPointCamera = CoordinateConverter.GridToCamera(camera, graphPointGrid);
            int yAxisXCamera = CoordinateConverter.GridXToCameraX(camera, 0);
            if (yAxisXCamera < camera.Location.X) yAxisXCamera = 0;
            else if (yAxisXCamera > camera.Location.X + camera.Width) yAxisXCamera = camera.Width;
            graphics.DrawLine(Pens.Blue, new Point(camera.Location.X + graphPointCamera.X, camera.Location.Y + graphPointCamera.Y), new Point(camera.Location.X + yAxisXCamera, camera.Location.Y + graphPointCamera.Y));
            int xAxisYCamera = CoordinateConverter.GridYToCameraY(camera, 0);
            if (xAxisYCamera < camera.Location.Y) xAxisYCamera = 0;
            else if (xAxisYCamera > camera.Height) xAxisYCamera = camera.Height;
            graphics.DrawLine(Pens.Blue, new Point(camera.Location.X + graphPointCamera.X, camera.Location.Y + graphPointCamera.Y), new Point(camera.Location.X + graphPointCamera.X, camera.Location.Y + xAxisYCamera));
            SizeF stringSize = graphics.MeasureString($"({Math.Round(graphPointGrid.X, 3)}, {Math.Round(graphPointGrid.Y, 3)})", new Font(Form.DefaultFont.FontFamily, 12));
            Size stringSizeInt = new Size((int)Math.Round(stringSize.Width), (int)Math.Round(stringSize.Height));
            graphics.DrawString($"({Math.Round(graphPointGrid.X, 3)}, {Math.Round(graphPointGrid.Y, 3)})", new Font(Form.DefaultFont.FontFamily, 12), Brushes.Blue,
                new Point(camera.Location.X + graphPointCamera.X - stringSizeInt.Width, camera.Location.Y + graphPointCamera.Y - stringSizeInt.Height));
        }
        public static void DisplayByX(Camera camera, Function function, int mouseXForm, Graphics graphics)
        {
            int? mouseXCamera = CoordinateConverter.FormXToCameraX(camera, mouseXForm);
            if (mouseXCamera is null) return;
            double mouseXGrid = CoordinateConverter.CameraXToGridX(camera, (int)mouseXCamera);
            double? graphYGrid = function.GetY(mouseXGrid);
            if (graphYGrid is null) return;
            if (graphYGrid > CoordinateConverter.CameraYToGridY(camera, 0) || graphYGrid < CoordinateConverter.CameraYToGridY(camera, camera.Height)) return;
            PointF graphPointGrid = new PointF((float)mouseXGrid, (float)graphYGrid);
            Point graphPointCamera = CoordinateConverter.GridToCamera(camera, graphPointGrid);
            int xAxisYCamera = CoordinateConverter.GridYToCameraY(camera, 0);
            if (xAxisYCamera < camera.Location.Y) xAxisYCamera = 0;
            else if (xAxisYCamera > camera.Height) xAxisYCamera = camera.Height;
            graphics.DrawLine(Pens.Blue, new Point(camera.Location.X + graphPointCamera.X, camera.Location.Y + graphPointCamera.Y), new Point(camera.Location.X + graphPointCamera.X, camera.Location.Y + xAxisYCamera));
            int yAxisXCamera = CoordinateConverter.GridXToCameraX(camera, 0);
            if (yAxisXCamera < camera.Location.X) yAxisXCamera = 0;
            else if (yAxisXCamera > camera.Location.X + camera.Width) yAxisXCamera = camera.Width;
            graphics.DrawLine(Pens.Blue, new Point(camera.Location.X + graphPointCamera.X, camera.Location.Y + graphPointCamera.Y), new Point(camera.Location.X + yAxisXCamera, camera.Location.Y + graphPointCamera.Y));
            SizeF stringSize = graphics.MeasureString($"({Math.Round(graphPointGrid.X, 3)}, {Math.Round(graphPointGrid.Y, 3)})", new Font(Form.DefaultFont.FontFamily, 12));
            Size stringSizeInt = new Size((int)Math.Round(stringSize.Width), (int)Math.Round(stringSize.Height));
            graphics.DrawString($"({Math.Round(graphPointGrid.X, 3)}, {Math.Round(graphPointGrid.Y, 3)})", new Font(Form.DefaultFont.FontFamily, 12), Brushes.Blue, 
                new Point(camera.Location.X + graphPointCamera.X - stringSizeInt.Width, camera.Location.Y + graphPointCamera.Y - stringSizeInt.Height));
        }
    }
}
