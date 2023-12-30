namespace MyMath
{
    public class T2 (M2 rotation, V2 translation)
    {
        public M2 Rotation = rotation;
        public V2 Translation = translation;

        public V2 Apply(V2 input)
        {
            return this.Rotation.Multiply(input).Translate(this.Translation);
        }
    }
}
