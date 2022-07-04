namespace LinearFunctions
{
    internal static class CoordinateConverter
    {
        public static Point? FormToCamera(Camera camera, Point formCoordinates)
        {
            if (formCoordinates.X < camera.Location.X || formCoordinates.X > camera.Location.X + camera.Width 
                || formCoordinates.Y < camera.Location.Y || formCoordinates.Y > camera.Location.Y + camera.Height)
            {
                return null;
            }
            return new Point(formCoordinates.X - camera.Location.X, formCoordinates.Y - camera.Location.Y);
        }
        public static int? FormXToCameraX(Camera camera, int formX)
        {
            if (formX < camera.Location.X || formX > camera.Location.X + camera.Width) return null;
            return formX - camera.Location.X;
        }
        public static int? FormYToCameraY(Camera camera, int formY)
        {
            if (formY < camera.Location.Y || formY > camera.Location.Y + camera.Height) return null;
            return formY - camera.Location.Y;
        }
        public static Point GridToCamera(Camera camera, PointF gridCoordinates)
        {
            // To do
            return new Point(
                (int)(Math.Abs((camera.GridLocation.X - gridCoordinates.X) * (50 * camera.Scale))),
                (int)(Math.Abs((camera.GridLocation.Y - gridCoordinates.Y) * (50 * camera.Scale))));
        }
        public static int GridXToCameraX(Camera camera, double gridX)
        {
            if (gridX < camera.GridLocation.X) return 0;
            else if (gridX > (camera.GridLocation.X + camera.Width)) return camera.Width;
            return (int)Math.Abs((camera.GridLocation.X - gridX) * (50 * camera.Scale));
        }
        public static int GridYToCameraY(Camera camera, double gridY)
        {
            if (gridY > camera.GridLocation.Y) return 0;
            else if (gridY < CameraYToGridY(camera, camera.Height)) return camera.Height;
            return (int)Math.Abs((camera.GridLocation.Y - gridY) * (50 * camera.Scale));
        }
        public static PointF CameraToGrid(Camera camera, Point cameraCoordinates)
        {
            return new PointF(
                (float)Math.Round((camera.GridLocation.X + cameraCoordinates.X / (50 * camera.Scale)), 3),
                (float)Math.Round((camera.GridLocation.Y - cameraCoordinates.Y / (50 * camera.Scale)), 3));
        }
        public static double CameraXToGridX(Camera camera, int cameraX)
        {
            return Math.Round((camera.GridLocation.X + cameraX / (50 * camera.Scale)), 3);
        }
        public static double CameraYToGridY(Camera camera, int cameraY)
        {
            return Math.Round((camera.GridLocation.Y - cameraY / (50 * camera.Scale)), 3);
        }
    }
}