
using System;
using System.Collections;
using System.Collections.Generic;

namespace PMC
{

    class Program
    {
        static void Main(string[] args)
        {
            decimal x;
            decimal y;
            decimal z;

            string strX;
            string strY;
            string strZ;

            Console.WriteLine("Введіть координати точок для формування позиції.\nДля завершення натисніть 'q'");

            Possition<Point> possition = new Possition<Point>();

            while (true)
            {
                try
                {
                    Console.Write("X = ");
                    strX = Console.ReadLine();
                    if (strX == "q")
                        break;
                    x = Convert.ToDecimal(strX);

                    Console.Write("Y = ");
                    strY = Console.ReadLine();
                    if (strX == "q")
                        break;
                    y = Convert.ToDecimal(strY);

                    Console.Write("Z = ");
                    strZ = Console.ReadLine();
                    if (strX == "q")
                        break;
                    z = Convert.ToDecimal(strZ);


                    Point point = new Point(x, y, z);
                    possition.Add(point);

                    Console.WriteLine(possition.ToString());
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadKey();
        } 
        class Point : IComparable<Point>
        {
            /// <summary>
            /// поле, що представляє координату x
            /// </summary>
            public decimal X { get; private set; }
            /// <summary>
            /// поле, що представляє координату y
            /// </summary>
            public decimal Y { get; private set; }
            /// <summary>
            /// поле, що представляє координату z
            /// </summary>
            public decimal Z { get; private set; }

            public Point() : this(0) { }
            public Point(decimal x) : this(x, 0) { }
            public Point(decimal x, decimal y) : this(x, y, 0) { }
            public Point(decimal x, decimal y, decimal z)
            {
                X = x;
                Y = y;
                Z = z;
            }

            public override string ToString()
            {
                string s = string.Format("X = {0}, Y = {1}, Z = {2}.", X, Y, Z);
                return s;
            }

            /// <summary>
            /// Порівнює 2 точки, викликає метод Mathematics(Point pointThis, Point point)
            /// </summary>
            /// <param name="point"></param>
            /// <returns></returns>
            public int CompareTo(Point point)
            {
                return Mathematics(this, point);
            }

            /// <summary>
            /// Порівнює 2 точки по їх відношенню до початку координат
            /// за формулою: корінь квадратний з суми квадратів координат та
            /// вертає значення методу CompareTo(Point point)
            /// </summary>
            /// <param name="pointThis"></param>
            /// <param name="point"></param>
            /// <returns></returns>
            int Mathematics(Point pointThis, Point point)
            {
                double powPointThis = Math.Pow((double)pointThis.X, 2) + Math.Pow((double)pointThis.Y, 2) + Math.Pow((double)pointThis.Z, 2);
                double sqrtPointThis = Math.Sqrt(powPointThis);

                double powPoint = Math.Pow((double)point.X, 2) + Math.Pow((double)point.Y, 2) + Math.Pow((double)point.Z, 2);
                double sqrtPoint = Math.Sqrt(powPoint);

                if (sqrtPointThis > sqrtPoint)
                    return 1;
                if (sqrtPointThis < sqrtPoint)
                    return -1;
                return 0;
            }

        }
        class Possition<Point> : IEnumerable<Point>
        {
            List<Point> points = new List<Point>();

            /// <summary>
            /// Дозволяє додати точки при ініціалізації позиції
            /// </summary>
            /// <param name="point"></param>
            public void Add(Point point)
            {
                if (point is Point)
                    points.Add(point);
            }

            public Point this[int index]
            {
                get { return points[index]; }
                set
                {
                    if (index >= 0 && value is Point)
                    {
                        points.Add(value);
                    }
                }
            }

            public IEnumerator<Point> GetEnumerator()
            {
                for (int i = 0; i < points.Count; i++)
                {
                    yield return points[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return points.GetEnumerator();
            }

            public override string ToString()
            {
                string s = string.Empty;
                for (int i = 0; i < points.Count; i++)
                {
                    s += string.Format("{0} точка має координати: {1}\n", i+1, points[i].ToString());
                }
                return s;
            }
        }
        class Matrix<Possition> : IEnumerable<Possition<Point>>
        {
            IList<Possition<Point>> possitions = new List<Possition<Point>>();

            /// <summary>
            /// Дозволяє додати позиції в матрицю при ініціалізації матриці
            /// </summary>
            /// <param name="possition"></param>
            public void Add(Possition<Point> possition)
            {
                if (possition is Possition<Point>)
                    possitions.Add(possition);
            }

            public Possition<Point> this[int index]
            {
                get { return possitions[index]; }
                set
                {
                    if (index >= 0 && value is Possition<Point>)
                    {
                        possitions.Add(value);
                    }
                }
            }

            public IEnumerator<Possition<Point>> GetEnumerator()
            {
                for (int i = 0; i < possitions.Count; i++)
                {
                    yield return possitions[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return possitions.GetEnumerator();
            }

        }
        class Container<Matrix> : IEnumerable<Matrix<Possition<Point>>>
        {
            IList<Matrix<Possition<Point>>> matrices = new List<Matrix<Possition<Point>>>();

            /// <summary>
            /// Дозволяє дадати матриці до контейнеру при ініціалізації контейнеру
            /// </summary>
            /// <param name="matrix"></param>
            public void Add(Matrix<Possition<Point>> matrix)
            {
                if (matrix is Matrix<Possition<Point>>)
                    matrices.Add(matrix);
            }

            public Matrix<Possition<Point>> this[int index]
            {
                get { return matrices[index]; }
                set
                {
                    if (index >= 0 && value is Matrix<Possition<Point>>)
                    {
                        matrices.Add(value);
                    }
                }
            }

            public IEnumerator<Matrix<Possition<Point>>> GetEnumerator()
            {
                for (int i = 0; i < matrices.Count; i++)
                {
                    yield return matrices[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return matrices.GetEnumerator();
            }
        }
        class Containars<Container> : IEnumerable<Container<Matrix<Possition<Point>>>>
        {
            IList<Container<Matrix<Possition<Point>>>> containers = new List<Container<Matrix<Possition<Point>>>>();

            /// <summary>
            /// Дозволяє додати контейнери в контейнер контейнерів при ініціалізації контейнера контейнерів
            /// </summary>
            /// <param name="contaner"></param>
            public void Add(Container<Matrix<Possition<Point>>> contaner)
            {
                if (contaner is Container<Matrix<Possition<Point>>>)
                    containers.Add(contaner);
            }

            public Container<Matrix<Possition<Point>>> this[int index]
            {
                get { return containers[index]; }
                set
                {
                    if (index >= 0 && value is Container<Matrix<Possition<Point>>>)
                    {
                        containers.Add(value);
                    }
                }
            }

            public IEnumerator<Container<Matrix<Possition<Point>>>> GetEnumerator()
            {
                for (int i = 0; i < containers.Count; i++)
                {
                    yield return containers[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return containers.GetEnumerator();
            }
        }
    }
}
