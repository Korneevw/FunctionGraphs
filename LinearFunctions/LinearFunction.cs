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
            Range = "R";
            Domain = "R";
        }
        public override double? GetX(double y) // Координаты на сетке
        {
            if (K == 0 && y != 0) return null;
            if (K == 0 && y == 0) return double.PositiveInfinity;
            return Math.Round((y - B) / K, 3);
        }
        public override double? GetY(double x) // Координаты на сетке
        {
            if (K == 0) return B;
            return Math.Round((K * x) + B, 3);
        }
    }
}