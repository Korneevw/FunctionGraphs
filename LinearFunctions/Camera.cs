namespace LinearFunctions
{
    internal class Camera
    {
        public double Scale;
        public int Height { get { return Size.Height; } }
        public int Width { get { return Size.Width; } }
        public Size Size;
        public Point Location;
        public PointF GridLocation; // Grid coordinates
        public Camera(double scale, Size size, Point location)
        {
            Scale = scale;
            Size = size;
            Location = location;
            GridLocation = new PointF(0, 0);
            PointF edgeGridCoordinates = CoordinateConverter.ConvertToGrid(this, new PointF(Width, Height));
            GridLocation = new PointF(0 - edgeGridCoordinates.X / 2, 0 - edgeGridCoordinates.Y / 2);
        }
    }
}