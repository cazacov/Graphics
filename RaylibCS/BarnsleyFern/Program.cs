using MyMath;
using Raylib_cs;

namespace BarnsleyFern
{
    internal class Program
    {
        const int screenW = 2048;
        const int screenH = 2048;
        const int x0 = screenW / 2;
        const int y0 = screenH;
        const int scale = 200;

        public static T2[] transformations = new T2[]
        {
            /*
            new T2(new M2(0, 0, 0, 0.25), new V2(0, -0.4)),
            new T2(new M2(0.95, 0.005, -0.005, 0.93), new V2(-0.002, 0.5)),
            new T2(new M2(0.035, -0.2, 0.16, 0.04), new V2(-0.09, 0.02)),
            new T2(new M2(-0.04, 0.2, 0.16, 0.04), new V2(0.083, 0.12)),
            */
            new T2(new M2(0, 0, 0, 0.16), new V2(0, -0)),
            new T2(new M2(0.85, 0.04, -0.04, 0.85), new V2(0.0, 1.6)),
            new T2(new M2(0.20, -0.26, 0.23, 0.22), new V2(0.0, 1.6)),
            new T2(new M2(-0.15, 0.28, 0.26, 0.24), new V2(0.0, 0.44)),
        };

        public static Color[] colors = new Color[]
        {
            Color.BLUE,
            Color.GREEN,
            Color.YELLOW,
            Color.MAGENTA,
        };


        static void Main(string[] args)
        {
            var random = new Random();

            Raylib.InitWindow(screenW, screenH, "Hello World");
            Raylib.ClearBackground(Color.BLACK);
            Line(new V2(0,-1), new V2(0,1), Color.GRAY);
            Line(new V2(-1, 0), new V2(1, 0), Color.GRAY);

            int n = 0;
            Raylib.BeginDrawing();
            var point = new V2(random.Next(1024) / 1024.0, random.Next(1024) / 1024.0);

            double[] prob = new double[4];
            var dsum = 0.0;
            for (int i = 0; i < 4; i++)
            {
                dsum += Math.Abs(transformations[i].Rotation.Determinant());
            }

            var d = 0.0;
            for (int i = 0; i < 4; i++)
            {
                d += Math.Abs(transformations[i].Rotation.Determinant()) / dsum;
                prob[i] = d;
            }


            while (!Raylib.WindowShouldClose())
            {
                var trProb = random.Next(1024) / 1024.0;

                var trIndex = 0;
                while (prob[trIndex] < trProb && trIndex < 4)
                {
                    trIndex++;
                }


                point = transformations[trIndex].Apply(point);
                Pixel(point, Color.GREEN);
                //Console.WriteLine($"{point.X}\t\t{point.Y}");

                n++;
                if (n % 1000 == 0)
                {
                    Raylib.EndDrawing();
                    Raylib.BeginDrawing();
                }
            }
            Raylib.CloseWindow();
        }

        private static void Pixel(V2 position, Color color)
        {
            Raylib.DrawPixel(
                (int)(x0 + position.X * scale),
                (int)(y0  - position.Y * scale),
                color);
        }

        static void Line(V2 from, V2 to, Color color)
        {
            Raylib.DrawLine( 
                (int)(x0 + from.X * scale),
                (int)(y0 - from.Y * scale),
                (int)(x0 + to.X * scale),
                (int)(y0 - to.Y * scale),
                color);
        }
    }
}
