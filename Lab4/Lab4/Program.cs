using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Program
    {
        /*public void fun1(in int i)
        {
            i += 1;
        }*/
        public void fun2(out int i)
        {
            i = 10;
        }
        public void fun3(ref int i)
        {
            i += 1;
        }
        public void fun4(int i)
        {
            i += 1;
        }
        /*public void theSameName(in int p)
        {
            Console.WriteLine("1");
        }
        public void theSameName(out int p)
        {
            p = 5;
        }*/
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
        }
        public void fun5(Point p)
        {
            Point p2 = new Point(5, 5);
            p = p2;
        }
        public void fun6(ref Point p)
        {
            Point p2 = new Point(5, 5);
            p = p2;
        }
        class TestPointer
        {
            public unsafe static void Main2()
            {
                int[] list = { 10, 100, 200 };
                fixed (int* ptr = list)
                    for (int i = 0; i < 3; i++)
                    {
                        Console.WriteLine("Adres [{0}]={1}", i, (int)(ptr + 1));
                        Console.WriteLine("Wartość[{0}]={1}", i, *(ptr + i));
                    }
            }
        }
        public unsafe void swap(int* p, int *q)
        {
            int temp = *p;
            *p = *q;
            *q = temp;
        }
        public void ex1()
        {
            Console.WriteLine("Exercise 1");
            int k = 0;
            Console.WriteLine("Integer, before and after:\nFun1: Impossible\nFun2 before: {0}", k);
            fun2(out k);
            Console.WriteLine("Fun2 after: {0}", k);
            k = 0;
            Console.WriteLine("Fun3 before: {0}", k);
            fun3(ref k);
            Console.WriteLine("Fun3 after: {0}", k);
            k = 0;
            Console.WriteLine("Fun4 before: {0}", k);
            fun4(k);
            Console.WriteLine("Fun4 after: {0}", k);
            short j = 0;
            Console.WriteLine("Short, before and after:\nFun1: Impossible\nFun2: Impossible\nFun3: Impossible\nFun4 before: {0}", j);
            fun4(j);
            Console.WriteLine("Fun4 after: {0}", j);
            Point test = new Point(1, 1);
            Console.WriteLine("Point, before and after:\nFun5 before: {0}", test.ToString());
            fun5(test);
            Console.WriteLine("Fun5 after: {0}", test.ToString());
            test = new Point(1, 1);
            Console.WriteLine("Fun6 before: {0}", test.ToString());
            fun6(ref test);
            Console.WriteLine("Fun6 after: {0}", test.ToString());
            test = null;
            Console.WriteLine("Point = null, calling ToString() method causes an exception");
            fun5(test);
            //Console.WriteLine("Fun5 after: {0}", test.ToString());
            test = null;
            //Console.WriteLine("Fun6 before: {0}", test.ToString());
            fun6(ref test);
            //Console.WriteLine("Fun6 after: {0}", test.ToString());
        }
        public unsafe void ex2()
        {
            Console.WriteLine("\n\n\nExercise 2\nTestPointer.Main():");
            TestPointer.Main2();
            int i1 = 5;
            int i2 = 10;
            int* ptr1 = &i1;
            int* ptr2 = &i2;
            Console.WriteLine("Swap, before and after:\nBefore: i1 = {0}, i2 = {1}", *ptr1, *ptr2);
            swap(ptr1, ptr2);
            Console.WriteLine("After: i1 = {0}, i1 = {1}", *ptr1, *ptr2);
            int[] bufor = new int[1024];
            fixed(int* p = bufor)
            {
                *p = 1;
                *(p + 1) = 2;
                *(p + 2) = 3;
                Console.WriteLine("Fixed:\n*p = {0}\n*(p + 1) = {1}\n*(p + 2) = {2}", *p, *(p + 1), *(p + 2));
            }
        }
        public void ex3()
        {
            Console.WriteLine("\n\n\nExercise 3");
            int[] arr = new int[0];
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter an element:");
                int reading = int.Parse(Console.ReadLine());
                int[] newArray = new int[arr.Length + 1];
                newArray[0] = reading;
                Array.Copy(arr, 0, newArray, 1, arr.Length);
                arr = newArray;
            }
            Console.WriteLine("Result:");
            foreach(int a in arr)
            {
                Console.Write(a + ", ");
            }
        }
        public void ex4()
        {
            Console.WriteLine("\n\n\nExercise 4");
            int[] numbers = new int[5];
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter a number no. {0}", i + 1);
                int number = int.Parse(Console.ReadLine());
                numbers[i] = number;
            }
            Console.WriteLine("Results:");
            for(int i = 4; i >= 0; i--)
            {
                Console.WriteLine("{0}", numbers[i]);
            }
        }
        public void ex5()
        {
            Console.WriteLine("\n\n\nExercise 5");
            int[] numbers = new int[5];
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter a number no. {0}", i + 1);
                int number = int.Parse(Console.ReadLine());
                numbers[i] = number;
            }
            var numbersGrouped = numbers.GroupBy(x => x);
            foreach(var checkedNumber in numbersGrouped)
            {
                int count = checkedNumber.Count();
                if(count > 1)
                {
                    Console.WriteLine("Number {0} repeats {1} times", checkedNumber.Key, count);
                }
            }
        }
        public void displayMatrix5x5(int[,] matrix)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write("{0}, ", matrix[i, j]);
                }
                Console.Write("\n");
            }
        }
        public void ex6()
        {
            int[,] matrix1 = new int[5, 5]
                {
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1},
                { 1, 1, 1, 1, 1}
            };
            int[,] matrix2 = new int[5, 5]
                {
                {5, 5, 5, 5, 5},
                {5, 5, 5, 5, 5},
                {5, 5, 5, 5, 5},
                {5, 5, 5, 5, 5},
                {5, 5, 5, 5, 5}
                };
            int[,] sum = new int[5, 5];
            Console.WriteLine("\n\n\nExercise 6\nMatrix 1:");
            displayMatrix5x5(matrix1);
            Console.WriteLine("Matrix 2:");
            displayMatrix5x5(matrix2);
            for (int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
                {
                    sum[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            Console.WriteLine("Result:");
            displayMatrix5x5(sum);
            Console.WriteLine("Length: {0}, LongLength: {1}, Rank: {2}", sum.Length, sum.LongLength, sum.Rank);
        }
        public void ex7()
        {
            int[,] matrix = new int[3, 3]
            {
                { 1, 0, -1 },
                { 0, 0, 1 },
                { -1, -1, 0 }
            };
            int det = 0;
            for (int i = 0; i < 3; i++)
            {
                det += matrix[0, i] * (matrix[1, (i + 1) % 3] * matrix[2, (i + 2) % 3] - matrix[1, (i + 2) % 3] * matrix[2, (i + 1) % 3]);
            }
            Console.WriteLine("Determinant is: {0}", det);
        }
        public void displayMatrix(int [][] matrix)
        {
            for(int i = 0; i < matrix.Length; i++)
            {
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write("{0}, ", matrix[i][j]);
                }
                Console.Write("\n");
            }
        }
        public void ex8()
        {
            int[][] matrix1 = new int[][]
            {
                new int[] {1, 2, 3},
                new int[] {4, 5, 6, 7, 8, 9},
                new int[] {10, 11, 12, 13},
                new int[] {14, 15, 16, 17, 18},
                new int[] {19, 20, 21}
            };
            int[][] matrix2 = new int[5][];
            matrix2[0] = new int[] { 1, 2, 3 };
            matrix2[1] = new int[] { 4, 5, 6, 7, 8, 9 };
            matrix2[2] = new int[] { 10, 11, 12, 13 };
            matrix2[3] = new int[] { 14, 15, 16, 17, 18 };
            matrix2[4] = new int[] { 19, 20, 21 };
            Console.WriteLine("\n\n\nExercise 8\nFirst way:");
            displayMatrix(matrix1);
            Console.WriteLine("Second way:");
            displayMatrix(matrix2);
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
        }
    }
}
