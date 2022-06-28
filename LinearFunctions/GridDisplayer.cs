namespace LinearFunctions
{
    internal static class GridDisplayer
    {
        public static void Display(Camera camera, Graphics graphics)
        {
            int XLineX = (int)Math.Ceiling(camera.GridLocation.X);
            int YLineY = (int)Math.Floor(camera.GridLocation.Y);
            while (XLineX < CoordinateConverter.ConvertToGridX(camera, camera.Width))
            {
                int XLineXCamera = CoordinateConverter.ConvertToCameraX(camera, XLineX);
                graphics.DrawLine(XLineX == 0 ? new Pen(Color.Black, 3) : Pens.Black, new Point(camera.Location.X + XLineXCamera, camera.Location.Y), new Point(camera.Location.X + XLineXCamera, camera.Location.Y + camera.Height));
                XLineX++;
            }
            while (YLineY > CoordinateConverter.ConvertToGridY(camera, camera.Height))
            {
                int YLineYCamera = CoordinateConverter.ConvertToCameraY(camera, YLineY);
                graphics.DrawLine(YLineY == 0 ? new Pen(Color.Black, 3) : Pens.Black, new Point(camera.Location.X, camera.Location.Y + YLineYCamera), new Point(camera.Location.X + camera.Width, camera.Location.Y + YLineYCamera));
                YLineY--;
            }
        }
    }
}