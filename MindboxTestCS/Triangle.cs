namespace MindboxClassLibrary
{
    public class Triangle
    {
        private double eps = Constants.CalculationAccuracy;

        public double EdgeA { get; }
        public double EdgeB { get; }
        public double EdgeC { get; }

        public Triangle(double edgeA, double edgeB, double edgeC)
        {
            if (edgeA < eps)
                throw new ArgumentException("The side is specified incorrectly.", nameof(edgeA));

            if (edgeB < eps)
                throw new ArgumentException("The side is specified incorrectly.", nameof(edgeB));

            if (edgeC < eps)
                throw new ArgumentException("The side is specified incorrectly.", nameof(edgeC));

            var maxEdge = Math.Max(edgeA, Math.Max(edgeB, edgeC));
            var perimeter = edgeA + edgeB + edgeC;
            if ((perimeter - maxEdge) - maxEdge < Constants.CalculationAccuracy)
                throw new ArgumentException("The largest side of the triangle must be less than the sum of the other sides");

            EdgeA = edgeA;
            EdgeB = edgeB;
            EdgeC = edgeC;
        }

        public bool IsRightTriangle()
        {
            double maxEdge = EdgeA, b = EdgeB, c = EdgeC;
            if (b - maxEdge > Constants.CalculationAccuracy)
                (b, maxEdge) = (maxEdge, b);

            if (c - maxEdge > Constants.CalculationAccuracy)
                (c, maxEdge) = (maxEdge, c);

            return Math.Abs(Math.Pow(maxEdge, 2) - Math.Pow(b, 2) - Math.Pow(c, 2)) < Constants.CalculationAccuracy;
        }

        public double GetSquare()
        {
            var halfP = (EdgeA + EdgeB + EdgeC) / 2d;
            var square = Math.Sqrt(
                halfP
                * (halfP - EdgeA)
                * (halfP - EdgeB)
                * (halfP - EdgeC)
            );

            return square;
        }
    }
}
