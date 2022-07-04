namespace LinearFunctions
{
    internal static class LinearFunctionDisplayer
    {
        public static void Display(Camera camera, LinearFunction function, Graphics graphics)
        {
            double leftSideY = function.GetY(CoordinateConverter.CameraXToGridX(camera, 0));
            double rightSideY = function.GetY(CoordinateConverter.CameraXToGridX(camera, camera.Width));
            double upSideX = function.GetX(CoordinateConverter.CameraYToGridY(camera, 0));
            double downSideX = function.GetX(CoordinateConverter.CameraYToGridY(camera, camera.Height));
            List<Point> points = new List<Point>();
            if (upSideX >= CoordinateConverter.CameraXToGridX(camera, 0) && upSideX <= CoordinateConverter.CameraXToGridX(camera, camera.Width))
            {
                points.Add(new Point(camera.Location.X + CoordinateConverter.GridXToCameraX(camera, upSideX), camera.Location.Y));
            }
            if (downSideX >= CoordinateConverter.CameraXToGridX(camera, 0) && downSideX <= CoordinateConverter.CameraXToGridX(camera, camera.Width))
            {
                points.Add(new Point(camera.Location.X + CoordinateConverter.GridXToCameraX(camera, downSideX), camera.Location.Y + camera.Height));
            }
            if (leftSideY <= CoordinateConverter.CameraYToGridY(camera, 0) && leftSideY >= CoordinateConverter.CameraYToGridY(camera, camera.Height))
            {
                points.Add(new Point(camera.Location.X, camera.Location.Y + CoordinateConverter.GridYToCameraY(camera, leftSideY)));
            }
            if (rightSideY <= CoordinateConverter.CameraYToGridY(camera, 0) && rightSideY >= CoordinateConverter.CameraYToGridY(camera, camera.Height))
            {
                points.Add(new Point(camera.Location.X + camera.Width, camera.Location.Y + CoordinateConverter.GridYToCameraY(camera, rightSideY)));
            }
            if (points.Count == 2)
            {
                graphics.DrawLine(new Pen(Color.Red, 1), points[0], points[1]);
            }
        }
    }
}