namespace MyMath
{
    public class M2(double a11, double a12, double a21, double a22)
    {
        public double a11 { get; init; } = a11;
        public double a12 { get; init; } = a12;
        public double a21 { get; init; } = a21;
        public double a22 { get; init; } = a22;

        public V2 Multiply(V2 input)
        {
            return new V2(a11 * input.X + a12 * input.Y, a21 * input.X + a22 * input.Y);
        }

        public double Determinant()
        {
            return a11 * a22 - a12 * a21;
        }
    }
}
