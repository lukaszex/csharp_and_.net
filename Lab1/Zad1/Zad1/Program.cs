using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zad1
{
    class Program
    {
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
            Console.WriteLine(p.ex8());
        }
        public void ex1()
        {
            Console.WriteLine("\n\n\nExercise 1\nHello world!");
            Console.ReadKey();
        }
        public void ex2()
        {
            Console.WriteLine("\n\n\nExercise 2");
            Console.WriteLine("5 + 3 = " + (5 + 3));
            Console.WriteLine("10 / 3 = " + (10 / 3));
            Console.WriteLine("-1 + 4 * 6 = " + (-1 + 4 * 6) + "\n" +
                              "(35 + 5) % 7 = " + ((35 + 7) % 7) + "\n" +
                              "14 + -4 * 6 / 11 = " + (14 + -4 * 6 / 11) + "\n" +
                              "2 + 15 / 6 * 1 - 7 % 2 = " + (2 + 15 / 6 * 1 - 7 % 2));
        }
        public void ex3()
        {

            Console.WriteLine("\n\n\nExercise 3");
            Console.WriteLine("Enter two numbers separated by space: ");
            string[] readings = Console.ReadLine().Split();
            int num1 = int.Parse(readings[0]);
            int num2 = int.Parse(readings[1]);
            Console.WriteLine("2nd number: " + num2 + " 1st number: " + num1);
        }
        public void ex4()
        {
            Console.WriteLine("\n\n\nExercise 4");
            Console.WriteLine("Enter 3 numbers, separated by spaces");
            string[] readings = Console.ReadLine().Split();
            int[] numbers = new int[3];
            for (int i = 0; i < 3; i++)
            {
                numbers[i] = Convert.ToInt32(readings[i]);
            }
            Console.WriteLine("{0} x {1} x {2} = {3}",
                numbers[2], numbers[1], numbers[0],
                numbers[0] * numbers[1] * numbers[2]);
        }
        public void ex5()
        {
            Console.WriteLine("\n\n\nExercise 5");
            Console.WriteLine("Enter a number: ");
            string reading = Console.ReadLine();
            int number = Convert.ToInt16(reading);
            Console.WriteLine(" {0}{0}{0}{0} \n{0}    {0}\n{0}    {0}\n" +
                "{0}    {0}\n{0}    {0}\n {0}{0}{0}{0} ",
                number);
        }
        public void ex6()
        {
            Console.WriteLine("\n\n\nExercise 6");
            int ii = 75400;
            double id = 7.54;
            string result = String.Format("Wartość int to {0}, a wartość" +
                " double to {1}", ii, id);
            Console.WriteLine(result);
            Console.WriteLine("Wartość int to " + ii.ToString() + ", a wartość" +
                " double to " + id.ToString());
            Console.WriteLine("---{0, 40}---   ---{0, 40}---", ii, id.ToString());
            Console.WriteLine("---{0, -40}---   ---{0, -40}---", ii, id.ToString());
            int i2 = 57300;
            double d2 = 5.73;
            Console.WriteLine("{0:c}    {1:c}", i2, d2);
            Console.WriteLine("{0:d}", i2);
            Console.WriteLine("{0:e}    {1:e}", i2, d2);
            Console.WriteLine("{0:f}    {1:f}", i2, d2);
            Console.WriteLine("{0:r}", d2);
            //Console.WriteLine("{0:o}", d2);
            Console.WriteLine("{0:x}", i2);
            float flo = 220.022f;
            Console.WriteLine("\n\n{0:0.00000}", flo);
            Console.WriteLine("{0:[#].(#)(##)}", flo);
            Console.WriteLine("{0:0.0}", flo);
            Console.WriteLine("{0:0,0}", flo);
            Console.WriteLine("{0:,.}", flo);
            Console.WriteLine("{0:0%}", flo);
            Console.WriteLine("{0:0e+0}", flo);
            double dd1 = 123.3;
            double dd2 = -1234;
            double dd3 = 0;
            Console.WriteLine("\n\n{0:#,##0.0;(#,##)Minus;Zero}", dd1);
            Console.WriteLine("{0:#,##0.0;(#,##)Minus;Zero}", dd2);
            Console.WriteLine("{0:#,##0.0;(#,##)Minus;Zero}", dd3);
            DateTime d = System.DateTime.Now;
            Console.WriteLine("\n\n");
            Console.WriteLine("{0:d}", d);
            Console.WriteLine("{0:D}", d);
            Console.WriteLine("{0:t}", d);
            Console.WriteLine("{0:T}", d);
            Console.WriteLine("{0:f}", d);
            Console.WriteLine("{0:F}", d);
            Console.WriteLine("{0:g}", d);
            Console.WriteLine("{0:G}", d);
            Console.WriteLine("{0:M}", d);
            Console.WriteLine("{0:r}", d);
            Console.WriteLine("{0:s}", d);
            Console.WriteLine("{0:u}", d);
            Console.WriteLine("{0:U}", d);
            Console.WriteLine("{0:Y}", d);
        }
        public void ex7()
        {
            Console.WriteLine("\n\n\nExercise 7");
            Console.WriteLine("Enter temperature in Celcius's degress");
            double c = Convert.ToDouble(Console.ReadLine());
            double k = c + 273;
            double f = c * 18 / 10 + 32;
            Console.WriteLine("In kelvins: {0}, in deg. Fahrenheit: {1}",
                k, f);
        }
        public bool ex8()
        {
            Console.WriteLine("\n\n\nExercise 8");
            Console.WriteLine("Enter two numbers, one after another");
            return int.Parse(Console.ReadLine()) * int.Parse(Console.ReadLine()) < 0;
        }
     
    }
}
