namespace LinearFunctions
{
    internal class LinearFunction : Function
    {
        public double K = 0;
        public double B = 0;
        public LinearFunction(double k, double b)
        {
            K = k;
            B = b;
            Formula = "y(x) = kx + b";
        }
        public override double GetX(double y) // Grid coordinates
        {
            return Math.Round((y - B) / K, 3);
        }
        public override double GetY(double x) // Grid coordinates 
        {
            return Math.Round((K * x) + B, 3);
        }
    }
}