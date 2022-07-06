namespace LinearFunctions
{
    internal class Camera
    {
        public double Scale { get; set; }
        public const double MinScale = 0.5;
        public const double MaxScale = 10;
        public int Height { get { return Size.Height; } }
        public int Width { get { return Size.Width; } }
        public Size Size { get; set; }
        public Point Location { get; set; } // Control container coordinates
        public PointF GridLocation
        {
            get
            {
                return _gridLocation;
            }
            set
            {
                float x;
                if (value.X > 1000000) x = 1000000;
                else if (value.X < -1000000) x = -1000000;
                else { x = value.X; }
                float y;
                if (value.Y > 1000000) y = 1000000;
                else if (value.Y < -1000000) y = -1000000;
                else { y = value.Y; }
                _gridLocation = new PointF(x, y);
            }
        }
        public PointF _gridLocation;
        public Camera(double scale, Size size, Point location)
        {
            Scale = scale;
            Size = size;
            Location = location;
            GridLocation = new PointF(0, 0);
            PointF edgeGridCoordinates = CoordinateConverter.CameraToGrid(this, new Point(Width, Height));
            GridLocation = new PointF(0 - edgeGridCoordinates.X / 2, 0 - edgeGridCoordinates.Y / 2);
        }
    }
}