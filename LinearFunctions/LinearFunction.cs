namespace LinearFunctions
{
    internal class LinearFunction
    {
        public double K = 0;
        public double B = 0;
        public LinearFunction(double k, double b)
        {
            K = k;
            B = b;
        }
        public double GetY(double x) // Grid coordinates 
        {
            return Math.Round((K * x) + B, 3);
        }
        public double GetX(double y) // Grid coordinates
        {
            return Math.Round((y - B) / K, 3);
        }
    }
}