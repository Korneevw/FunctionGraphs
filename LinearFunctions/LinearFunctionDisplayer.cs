namespace LinearFunctions
{
    internal static class LinearFunctionDisplayer
    {
        public static void Display(Camera camera, LinearFunction function, Graphics graphics)
        {
            double leftSideY = function.GetY(CoordinateConverter.ConvertToGridX(camera, 0));
            double rightSideY = function.GetY(CoordinateConverter.ConvertToGridX(camera, camera.Width));
            double upSideX = function.GetX(CoordinateConverter.ConvertToGridY(camera, 0));
            double downSideX = function.GetX(CoordinateConverter.ConvertToGridY(camera, camera.Height));
            List<Point> points = new List<Point>();
            if (upSideX >= CoordinateConverter.ConvertToGridX(camera, 0) && upSideX <= CoordinateConverter.ConvertToGridX(camera, camera.Width))
            {
                points.Add(new Point(camera.Location.X + CoordinateConverter.ConvertToCameraX(camera, upSideX), camera.Location.Y));
            }
            if (downSideX >= CoordinateConverter.ConvertToGridX(camera, 0) && downSideX <= CoordinateConverter.ConvertToGridX(camera, camera.Width))
            {
                points.Add(new Point(camera.Location.X + CoordinateConverter.ConvertToCameraX(camera, downSideX), camera.Location.Y + camera.Height));
            }
            if (leftSideY <= CoordinateConverter.ConvertToGridY(camera, 0) && leftSideY >= CoordinateConverter.ConvertToGridY(camera, camera.Height))
            {
                points.Add(new Point(camera.Location.X, camera.Location.Y + CoordinateConverter.ConvertToCameraY(camera, leftSideY)));
            }
            if (rightSideY <= CoordinateConverter.ConvertToGridY(camera, 0) && rightSideY >= CoordinateConverter.ConvertToGridY(camera, camera.Height))
            {
                points.Add(new Point(camera.Location.X + camera.Width, camera.Location.Y + CoordinateConverter.ConvertToCameraY(camera, rightSideY)));
            }
            if (points.Count == 2)
            {
                graphics.DrawLine(new Pen(Color.Red, 3), points[0], points[1]);
            }
        }
    }
}