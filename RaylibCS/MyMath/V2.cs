namespace MyMath
{
    public class V2(double x, double y)
    {
        public double X { get; init; } = x;
        public double Y { get; init; } = y;

        public V2 Translate(V2 input)
        {
            return new V2(this.X + input.X, this.Y + input.Y);
        }
    }
}
