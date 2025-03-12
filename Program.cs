using System.Drawing;

namespace homework3
{
    internal class Program
    {
        abstract class PlaneFigure()
        {
            public abstract double GetArea();
            public abstract bool Valid();
            public abstract int[] Edge { get; set; }
        }


        class Triangles : PlaneFigure
        {
            private int[] edges = new int[3];
            public override double GetArea()
            {
                if (!Valid()) { throw new InvalidOperationException("Invalid Edges"); }
                //using float calculation ensures precision
                double p= (edges[0] + edges[1] + edges[2])/2.0;  
                return System.Math.Sqrt(p * (p-edges[0]) * (p-edges[1]) * (p-edges[2]));
            }

            public override bool Valid() {
                return (edges[0] > 0 && edges[1] > 0 && edges[2] > 0
                    && (edges[0] < edges[1] + edges[2])
                    && (edges[1] < edges[0] + edges[2])
                    && (edges[2] < edges[1] + edges[0]));
            }

            public override int[] Edge
            {
                get=> edges;
                set
                {
                    if(value.Length != 3) { throw new ArgumentException("Triangle must have 3 edges."); }
                    edges=value;
                    if(!Valid()) { throw new ArgumentException("Invalid Edges");  }
                }
            }
        }
        class Rectangular : PlaneFigure
        {
            private int[] edges = new int[4];
            public override double GetArea()
            {
                if (!Valid()) { throw new ArgumentException("Invalid Edges"); }
                return edges[0] * edges[1];
            }

            public override bool Valid()
            {
                return (edges[0]>0 && edges[1]>0 
                    && (edges[0] == edges[2])
                    && (edges[1] == edges[3]));
            }

            public override int[] Edge
            {
                get => edges;
                set
                {
                    if (value.Length != 4) { throw new ArgumentException("Rectangular must have 4 edges."); }
                    edges = value;
                    if (!Valid()) { throw new ArgumentException("Invalid Edges"); }
                }
            }
        }

        class Square : Rectangular
        {
            public override double GetArea()
            {
                if (!Valid())
                {
                    throw new ArgumentException("Invalid Edges");
                }
                    return Edge[0] * Edge[0];
            }

            public override bool Valid()
            {
                return base.Valid() && Edge[0] == Edge[1];
            }

        }

        class ShapeFactory
        {
            private static Random _random = new Random();

            public static PlaneFigure GeneratePlaneFigure()
            {
                int shape = _random.Next(0,3);//0-Tri;1-Rec;2-Squ
                switch (shape)
                {
                    case 0:return GenerateTriangles();
                    case 1:return GenerateRectangular();
                    case 2:return GenerateSquare();
                    default: throw new NotImplementedException();
                }

            }

            private static Triangles GenerateTriangles()
            {
                while (true)
                {
                    int a = _random.Next(1, 10);
                    int b = _random.Next(1, 10);
                    int c = _random.Next(1, 10);
                    if(a<b+c && b<a+c && c < b + a)
                    {
                        return new Triangles { Edge = new int [] { a, b, c } };
                    }
                }
            }
            private static Rectangular GenerateRectangular()
            {
                int length = _random.Next(1, 10);
                int width = _random.Next(1, 10);
                return new Rectangular { Edge = new[] { length, width, length, width } };
            }

            private static Square GenerateSquare()
            {
                int side = _random.Next(1, 10);
                return new Square { Edge = new[] { side, side, side, side } };
            }

        }

        static void Main(string[] args)
        {
            double totalArea = 0;

            for (int i = 0; i < 10; i++)
            {
                PlaneFigure shape = ShapeFactory.GeneratePlaneFigure();
                totalArea += shape.GetArea();

                Console.WriteLine($"创建 {shape.GetType().Name}" +
                    $"\n边长：{string.Join(",", shape.Edge)}" +
                    $"\n面积：{shape.GetArea()}\n");
            }

            Console.WriteLine($"总面积：{totalArea:N2}");
        }
    }
}
