using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        struct Point2D
        {
            private double X;
            private double Y;
            public Point2D(double x, double y)
            {
                X = x;
                Y = y;
            }
            public void Reset()
            {
                X = 0;
                Y = 0;
            }
            public void IncrX(double dx)
            {
                X += dx;
            }
            public void IncrY(double dy)
            {
                Y += dy;
            }
            public void print2DPoint()
            {
                Console.WriteLine("({0}, {1})", X, Y);
            }
            public double Dist(Point2D Point)
            {
                return Math.Sqrt(Math.Pow(X - Point.X, 2) + Math.Pow(Y - Point.Y, 2));
            }
        }
        
        struct Point2D_1
        {
            private double X;
            private double Y;

            public void Reset()
            {
                X = 0;
                Y = 0;
            }
            public void IncrX(double dx)
            {
                X += dx;
            }
            public void IncrY(double dy)
            {
                Y += dy;
            }
            public void print2DPoint()
            {
                Console.WriteLine("({}, {})", X, Y);
            }
            public double Dist(Point2D_1 Point)
            {
                return Math.Sqrt(Math.Pow(X - Point.X, 2) + Math.Pow(Y - Point.Y, 2));
            }
        }
        /*struct Point2D_2
        {
            private double X = 3;
            private double Y = 3;

            public Point2D_2()
            { }
            public void Reset()
            {
                X = 0;
                Y = 0;
            }
            public void IncrX(double dx)
            {
                X += dx;
            }
            public void IncrY(double dy)
            {
                Y += dy;
            }
            public void print2DPoint()
            {
                Console.WriteLine("({}, {})", X, Y);
            }
            public double Dist(Point2D_1 Point)
            {
                return Math.Sqrt(Math.Pow(X - Point.X, 2) + Math.Pow(Y - Point.Y, 2));
            }
        }*/
        public enum Days {Monday = 1, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday};
        public enum Range {Small = 1, Medium = 99, Large = 100};
        public struct Coords
        {
            public int x, y;

            public Coords(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
        public class Point
        {
            public int x, y;

            public Point(int p1, int p2)
            {
                x = p1;
                y = p2;
            }
        }
        public void ex1()
        {
            double rad = 3;
            Console.WriteLine("Exercise 1");
            double[] coordsD = new double[10];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter coordinates of point no. {0}, separated by space", i + 1);
                string[] coords = Console.ReadLine().Split();
                coordsD[2 * i] = Double.Parse(coords[0]);
                coordsD[2 * i + 1] = Double.Parse(coords[1]);
            }
            Point2D[] points = new Point2D[5];
            for (int i = 0; i < 5; i++)
            {
                points[i] = new Point2D(coordsD[2 * i], coordsD[2 * i + 1]);
            }
            bool insideOrNegative = false;
            do
            {
                double[] distances = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    double distance = points[4].Dist(points[i]);
                    distances[i] = distance;
                    if (distance <= rad)
                    {
                        insideOrNegative = true;
                        Console.WriteLine("Point 5 is inside one of the circles. Coordinates of all points:");
                        foreach (Point2D point in points)
                        {
                            point.print2DPoint();
                        }
                        break;
                    }
                }
                if (insideOrNegative == false)
                {
                    double minDist = distances[0];
                    foreach (double distance in distances)
                    {
                        if (distance < minDist)
                        {
                            minDist = distance;
                        }
                    }
                    Console.WriteLine("Your point is not inside any of the circles. Distance to the nearest point: {0}. Enter new coordinates:", minDist);
                    string[] newCoords = Console.ReadLine().Split();
                    double[] newCoordsD = new double[2];
                    for (int i = 0; i < 2; i++)
                    {
                        newCoordsD[i] = Double.Parse(newCoords[i]);
                        if (newCoordsD[i] < 0)
                        {
                            Console.WriteLine("One of coordinates is lower than 0. Program will end now. Coordinates of all points:");
                            foreach (Point2D point in points)
                            {
                                point.print2DPoint();
                            }
                            insideOrNegative = true;
                        }
                    }
                    points[4] = new Point2D(newCoordsD[0], newCoordsD[1]);
                }
            } while (insideOrNegative == false);
        }
        public void ex2()
        {
            Console.WriteLine("\n\n\nExerceise 2");
            Point2D_1 Point = new Point2D_1();
            Console.WriteLine(Point.ToString());
        }
        public void ex3()
        {
            Console.WriteLine("\n\n\nExercise 3");
            int stringCnt = 0;
            int intCnt = 0;
            int floatCnt = 0;
            string stringResult = "";
            int intResult = 0;
            float floatResult = 0;
            while(intResult != -1)
            {
                Console.WriteLine("Enter your string or number:");
                string reading = Console.ReadLine();
                if(int.TryParse(reading, out intResult))
                {
                    intCnt += 1;
                }
                if(float.TryParse(reading, out floatResult))
                {
                    floatCnt += 1;
                }
                stringResult = reading;
                stringCnt += 1;
            }
            Console.WriteLine("Successful convertions: {0} to string, {1} to int, {2} to float", stringCnt, intCnt, floatCnt);
        }
        public void ex4()
        {
            Console.WriteLine("\n\n\nExercise 4");
            Console.WriteLine("Enter number from 1 to 7:");
            int reading = int.Parse(Console.ReadLine());
            Console.WriteLine("Your number refers to {0}", Enum.GetName(typeof(Days), reading));
            Console.WriteLine("Enter another number, larger than 0:");
            reading = int.Parse(Console.ReadLine());
            if(reading < (int)Range.Small)
            {
                Console.WriteLine("Your number is {0}", Enum.GetName(typeof(Range), 10));
            }
            else if(reading >= (int)Range.Small && reading <= (int)Range.Medium)
            {
                Console.WriteLine("Your number is {0}", Enum.GetName(typeof(Range), 99));
            }
            else
            {
                Console.WriteLine("your number is {0}", Enum.GetName(typeof(Range), 100));
            }
        }
        public void ex5()
        {
            Console.WriteLine("\n\n\nExercise 5");
            string vowels = "aąeęiouyAĄEĘIOUY";
            Console.WriteLine("Enter a single character:");
            char reading = char.Parse(Console.ReadLine());
            if(vowels.IndexOf(reading) != -1)
            {
                Console.WriteLine("Your character is a vowel");
            }
            else if(Char.IsDigit(reading))
            {
                Console.WriteLine("Your character is a digit");
            }
            else
            {
                Console.WriteLine("Your character is neither a wovel, nor a digit");
            }
        }
        public void ex6()
        {
            Console.WriteLine("\n\n\nExercise 6");
            Console.WriteLine("Enter your string:");
            string reading = Console.ReadLine();
            foreach(char c in reading)
            {
                Console.Write("{0} ", c);
            }
            Console.WriteLine();
        }
        public void ex7()
        {
            Console.WriteLine("\n\n\nExercise 7");
            //int over = 329459235093421;
            try
            {
                int maxInt = 2147483647;
                int over = checked(maxInt++);
            }
            catch (System.OverflowException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public void fun2(Coords c)
        {
            c.x += 1;
            c.y += 1;
        }
        public void fun1(Point p)
        {
            p.x += 1;
            p.y += 1;
        }
        public void ex8()
        {
            Console.WriteLine("\n\n\nExercise 8");
            Coords c = new Coords(1, 1);
            Point p = new Point(1, 1);
            Console.WriteLine("Coordinates before functions' calls:\nCoords: {0}, {1}\nPoint: {2}, {3}", c.x, c.y, p.x, p.y);
            fun2(c);
            fun1(p);
            Console.WriteLine("Coordinates after functions' calls:\nCoords: {0}, {1}\nPoint: {2}, {3}", c.x, c.y, p.x, p.y);
            Coords c1 = new Coords(1, 1);
            Point p1 = new Point(1, 1);
            Coords c2 = new Coords(1, 1);
            Point p2 = new Point(1, 1);
            Console.WriteLine("Results of first pair comparisons:");
            Console.WriteLine("Object.Equals: {0}", Object.Equals(p1, c1));
            Console.WriteLine("Point.Equals: {0}", p1.Equals(c1));
            Console.WriteLine("Coords.Equals: {0}", c1.Equals(p1));
            Console.WriteLine("Object.ReferenceEquals: {0}", Object.ReferenceEquals(p1, c1));
            Console.WriteLine("Results of second pair comparisons:");
            Console.WriteLine("Object.Equals: {0}", Object.Equals(p2, c2));
            Console.WriteLine("Point.Equals: {0}", p2.Equals(c2));
            Console.WriteLine("Coords.Equals: {0}", c2.Equals(p2));
            Console.WriteLine("Object.ReferenceEquals: {0}", Object.ReferenceEquals(p2, c2));
        }
        public void ex9()
        {
            Console.WriteLine("\n\n\nExercise 9");
            Console.WriteLine("Enter your expression. It may contain integers not larger than 100, + and - only");
            string reading = Console.ReadLine();
            char[] operators = { '+', '-' };
            string[] inputs = reading.Split(operators);
            int[] intInputs = new int[inputs.Length];
            try
            {
                for (int i = 0; i < inputs.Length; i++)
                {
                    intInputs[i] = int.Parse(inputs[i]);
                }
            }
            catch (System.FormatException e)
            {
                Console.WriteLine("Character not recognized. Program will end");
                return;
            }
            int result = intInputs[0];
            int lastChecked = 0;
            for(int i = 1; i < intInputs.Length; i++)
            {
                for(int k = lastChecked; k < reading.Length; k++)
                {
                    if(char.IsDigit(reading[k]))
                    {
                        continue;
                    }
                    else if(reading[k] == '+')
                    {
                        result += intInputs[i];
                        lastChecked = k + 1;
                        break;
                    }
                    else if(reading[k] == '-')
                    {
                        result -= intInputs[i];
                        lastChecked = k + 1;
                        break;
                    }
                }
            }
            Console.WriteLine("Result: {0}", result);
        }
        public void ex10()
        {
            Console.WriteLine("\n\n\nExercise 10");
            Console.WriteLine("Implicit conversions: short -> int, int -> long, int -> float, uint -> double");
            short sh = 5;
            int integer = 50;
            uint ui = 3;
            int shConv = sh;
            long integerConv = integer;
            float integerConv2 = integer;
            double uiConv = ui;
            //Explicit conversions:
            shConv = (int)sh;
            integerConv = (long)integer;
            integerConv2 = (float)integer;
            uiConv = (double)ui;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ex1();
            p.ex2();
            p.ex3();
            p.ex4();
            p.ex5();
            p.ex6();
            p.ex7();
            p.ex8();
            p.ex9();
            p.ex10();
        }
    }
}