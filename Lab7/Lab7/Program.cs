using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Program
    {
        interface ICepikData
        {
            string cepikData();
        }
        interface IStatData
        {
            string statData();
        }
        interface IPoliceData
        {
            string policeData();
        }
        public class Auto : ICepikData, IStatData, IPoliceData
        {
            public string type { get; set; }
            public string brand { get; set; }
            public int capacity { get; set; }
            public int numberOfSeats { get; set; }
            //There is no need for so many fields. Those contained above and below are enough to demonstrate the example
            /*public int vin { get; set; }
            public string registrationNumber { get; set; }
            public int yearOfProduction { get; set; }
            public string color { get; set; }
            public int policyNumber { get; set; }*/
            public string nameAndSurname { get; set; }
            public string address { get; set; }
            /*public long pesel { get; set; }
            public string drivingLicenceNumber { get; set; }
            public int drivingLicenseYear { get; set; }
            public int yearOfPurchase { get; set; }*/
            public int penaltyPoints { get; set; }
            
            public string cepikData()
            {
                return String.Join(" ", "Car: ", type, brand, capacity, numberOfSeats, "\nOwner: ", nameAndSurname, address);
            }
            public string statData()
            {
                return String.Join(" ", "Car: ", type, brand, capacity, numberOfSeats);
            }
            public string policeData()
            {
                return String.Join(" ", "Car: ", type, brand, capacity, numberOfSeats, "\nOwner: ", nameAndSurname, address, penaltyPoints);
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
            public override string ToString()
            {
                return "(" + x + ", " + y + ")";
            }
            static public Point operator +(Point p1, Point p2) => new Point(p1.x + p2.x, p1.y + p2.y);
            /*{
                Point p3 = new Point(p1.x + p2.x, p1.y + p2.y);
                return p3;
            }*/
            static public bool operator true(Point p) => p.x != 0 || p.y != 0;
            static public bool operator false(Point p) => p.x == 0 && p.y == 0;
            static public bool operator ==(Point p1, Point p2) => p1.x == p2.x && p1.y == p2.y;
            static public bool operator !=(Point p1, Point p2) => p1.x != p2.x || p1.y != p2.y;
            static public bool operator <(Point p1, Point p2) => p1.x < p2.x && p1.y < p2.y;
            static public bool operator >(Point p1, Point p2) => p1.x > p2.x && p1.y > p2.y;
            static public bool operator <=(Point p1, Point p2) => p1.x <= p2.x && p1.y <= p2.y;
            static public bool operator >=(Point p1, Point p2) => p1.x >= p2.x && p1.y >= p2.y;
            static public Point operator ++(Point p) => new Point(p.x++, p.y++);
            /*{
                Point p2 = new Point(p.x++, p.y++);
                return p2;
            }*/
            static public Point operator --(Point p) => new Point(p.x--, p.y--);
            /*{
                Point p2 = new Point(p.x--, p.y--);
                return p2;
            }*/
            static public implicit operator Point(int i) => new Point(i, 0);
            /*{
                Point p = new Point(i, 0);
                return p;
            }*/
            static public explicit operator int(Point p) => p.x + p.y;
            /*{
                int sum = p.x + p.y;
                return sum;
            }*/
        }
        public delegate float f(int i, int j);
        public class Ex3Class
        {
            public float add(int i, int j) => i + j;
            public float sub(int i, int j) => i - j;
            public float mul(int i, int j) => i * j;
            public float div(int i, int j) => (float)i / (float)j;
        }
        public void ex1()
        {
            Console.WriteLine("Exercise 1");
            List<ICepikData> cepikList = new List<ICepikData>();
            List<IStatData> statList = new List<IStatData>();
            List<IPoliceData> policeList = new List<IPoliceData>();
            Auto car1 = new Auto();
            car1.type = "car";
            car1.brand = "skoda";
            car1.capacity = 50;
            car1.numberOfSeats = 5;
            car1.nameAndSurname = "Adam Małysz";
            car1.penaltyPoints = 5;
            Auto car2 = new Auto();
            car2.type = "truck";
            car2.brand = "man";
            car2.capacity = 2000;
            car2.numberOfSeats = 2;
            car2.nameAndSurname = "Andrzej Gołota";
            car2.penaltyPoints = 10;
            cepikList.Add(car1);
            cepikList.Add(car2);
            statList.Add(car1);
            statList.Add(car2);
            policeList.Add(car1);
            policeList.Add(car2);
            Console.WriteLine("ICepikData:");
            foreach (ICepikData car in cepikList)
            {
                Console.WriteLine(car.cepikData() + "\n\n");
            }
            Console.WriteLine("IStatData:");
            foreach (IStatData car in statList)
            {
                Console.WriteLine(car.statData() + "\n\n");
            }
            Console.WriteLine("IPoliceData:");
            foreach (IPoliceData car in policeList)
            {
                Console.WriteLine(car.policeData() + "\n\n");
            }
        }
        public void ex2()
        {
            Console.WriteLine("\n\n\nExercise 2");
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            Console.WriteLine("Point 1: {0}", p1.ToString());
            Console.WriteLine("Point 2: {0}", p2.ToString());
            Console.WriteLine("Operator +: {0}", (p1 + p2).ToString());
            Console.WriteLine("Oprator true, point1: " + (p1 ? "True" : "False"));
            Console.WriteLine("Operator ==: {0}", p1 == p2);
            Console.WriteLine("Operator <: {0}", p1 < p2);
            Console.WriteLine("Operator ++, point 1: {0}", p1++.ToString());
            Console.WriteLine("Operator --, point 2: {0}", p2--.ToString());
            Point p3 = 3;
            Console.WriteLine("Point p = 3: {0}", p3.ToString());
            int sum = (int)p2;
            Console.WriteLine("int sum = (int)p2: {0}", sum);
        }
        public void ex3()
        {
            Console.WriteLine("\n\n\nExercise 3");
            Ex3Class cl = new Ex3Class();
            f handler = cl.add;
            Console.WriteLine("Numbers: 1, 2\nSum: {0}", handler(1, 2));
            handler = cl.sub;
            Console.WriteLine("Substract: {0}", handler(1, 2));
            handler = cl.mul;
            Console.WriteLine("Multiply: {0}", handler(1, 2));
            handler = cl.div;
            Console.WriteLine("Division: {0}", handler(1, 2));
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.ex1();
            p.ex2();
            p.ex3();
        }
    }
}
