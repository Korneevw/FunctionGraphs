namespace LinearFunctions
{
    internal static class CoordinateConverter
    {
        public static Point ConvertToCamera(Camera camera, PointF gridCoordinates)
        {
            return new Point(
                (int)(Math.Abs((camera.GridLocation.X - gridCoordinates.X) * (50 * camera.Scale))),
                (int)(Math.Abs((camera.GridLocation.Y - gridCoordinates.Y) * (50 * camera.Scale))));
        }
        public static int ConvertToCameraX(Camera camera, double gridX)
        {
            return (int)Math.Abs((camera.GridLocation.X - gridX) * (50 * camera.Scale));
        }
        public static int ConvertToCameraY(Camera camera, double gridY)
        {
            return (int)Math.Abs((camera.GridLocation.Y - gridY) * (50 * camera.Scale));
        }
        public static PointF ConvertToGrid(Camera camera, PointF cameraCoordinates)
        {
            return new PointF(
                (float)Math.Round((camera.GridLocation.X + cameraCoordinates.X / (50 * camera.Scale)), 3),
                (float)Math.Round((camera.GridLocation.Y - cameraCoordinates.Y / (50 * camera.Scale)), 3));
        }
        public static double ConvertToGridX(Camera camera, double cameraX)
        {
            return Math.Round((camera.GridLocation.X + cameraX / (50 * camera.Scale)), 3);
        }
        public static double ConvertToGridY(Camera camera, double cameraY)
        {
            return Math.Round((camera.GridLocation.Y - cameraY / (50 * camera.Scale)), 3);
        }
    }
}