namespace MindboxClassLibrary
{
    public class Circle : IFigure
    {
        public const double minRadius = 1e-6;

        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius - minRadius < Constants.CalculationAccuracy)
                throw new ArgumentException("The radius of the circle is specified incorrectly.", nameof(radius));
            Radius = radius;
        }

        public double GetSquare()
        {
            return Math.PI * Math.Pow(Radius, 2d);
        }
    }
}
