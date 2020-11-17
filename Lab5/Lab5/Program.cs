using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;



namespace Lab5
{
    public class Program
    {
        [DllImport("msvcrt.dll")]
        private static extern void puts(string text);
        [DllImport("msvcrt.dll")]
        private static extern int _flushall();
        class Stack
        {
            List<int> values = new List<int>();

            public void addItem(int a)
            {
                values.Add(a);
            }
            public int deleteItem()
            {
                int elem = values[0];
                values.RemoveAt(0);
                return elem;
            }
            public void showTheNumberOfItems()
            {
                Console.WriteLine("Number of elements: {0}", values.Count);
            }
            public void showMinItem()
            {
                Console.WriteLine("Min value: {0}", values.Min());
            }
            public void showMaxItem()
            {
                Console.WriteLine("Max value: {0}", values.Max());
            }
            public int findAnItem(int a)
            {
                return values.FindIndex(x => x.Equals(a));
            }
            public void printAllItems()
            {
                foreach (int x in values)
                {
                    Console.Write("{0}, ", x);
                }
                Console.Write("\n");
            }
            public void clearAll()
            {
                values.Clear();
            }
        }
        class Matrix
        {
            int[] matrix;
            int c;
            int l;

            public Matrix(int _c, int _l, int[] values)
            {
                c = _c;
                l = _l;
                int size = c * l;
                int[] newValues = new int[size];
                if (values.Length < size)
                {
                    Array.Copy(values, newValues, values.Length);
                }
                else
                {
                    Array.Copy(values, newValues, size);
                }
                matrix = newValues;
            }
            public void addElem(int _c, int _l, int value)
            {
                if(_c <= c && _l <= l)
                {
                    matrix[(_c - 1) * l + _l - 1] += value;
                }
            }
            public int[] getSize()
            {
                return new int[2] { c, l };
            }
            public int[] getValues()
            {
                int[] copied = new int[l * c];
                Array.Copy(matrix, copied, l * c);
                return copied;
            }
            public int getValue(int _c, int _l)
            {
                if (_c <= c && _l <= l)
                {
                    return matrix[(_c - 1) * l + _l - 1];
                }
                else
                {
                    return 0;
                }
            }
            public Matrix addMatrix(Matrix anotherMatrix)
            {
                int newC;
                int newL;
                int[] anotherSize = anotherMatrix.getSize();
                if(anotherSize[0] > c)
                {
                    newC = anotherSize[0];
                }
                else
                {
                    newC = c;
                }
                if(anotherSize[1] > l)
                {
                    newL = anotherSize[1];
                }
                else
                {
                    newL = l;
                }
                int[] resValues = new int[newC * newL];
                Matrix result = new Matrix(newC, newL, resValues);
                for(int i = 1; i <= newC; i++)
                {
                    for(int j = 1; j <= newL; j++)
                    {
                        result.addElem(i, j, this.getValue(i, j) + anotherMatrix.getValue(i, j));
                    }
                }
                return result;
            }
            public override string ToString()
            {
                string result = "";
                for(int i = 1; i <= c; i++)
                {
                    for(int j = 1; j <= l; j++)
                    {
                        result += this.getValue(i, j) + " ";
                    }
                    result += "\n";
                }
                return result;
            }
        }
        class Matrix2
        {
            protected int[,] matrix;
            int c;
            int l;
            public Matrix2(int _c, int _l, int[] values)
            {
                c = _c;
                l = _l;
                int[,] newValues = new int[c, l];
                for(int i = 0; i < c; i++)
                {
                    for(int j = 0; j < l; j++)
                    {
                        newValues[i, j] = values[i * l + j];
                    }
                }
                matrix = newValues;
            }
            public void addElem(int _c, int _l, int value)
            {
                if (_c <= c && _l <= l)
                {
                    matrix[_c - 1, _l - 1] += value;
                }
            }
            public int[] getSize()
            {
                return new int[2] { c, l };
            }
            public int[,] getValues()
            {
                int[,] copied = new int[l, c];
                Array.Copy(matrix, copied, l * c);
                return copied;
            }
            public int getValue(int _c, int _l)
            {
                if (_c <= c && _l <= l)
                {
                    return matrix[_c - 1, _l - 1];
                }
                else
                {
                    return 0;
                }
            }
            public Matrix2 addMatrix(Matrix2 anotherMatrix)
            {
                int newC;
                int newL;
                int[] anotherSize = anotherMatrix.getSize();
                if (anotherSize[0] > c)
                {
                    newC = anotherSize[0];
                }
                else
                {
                    newC = c;
                }
                if (anotherSize[1] > l)
                {
                    newL = anotherSize[1];
                }
                else
                {
                    newL = l;
                }
                int[] resValues = new int[newC * newL];
                Matrix2 result = new Matrix2(newC, newL, resValues);
                for (int i = 1; i <= newC; i++)
                {
                    for (int j = 1; j <= newL; j++)
                    {
                        result.addElem(i, j, this.getValue(i, j) + anotherMatrix.getValue(i, j));
                    }
                }
                return result;
            }
            public Matrix2 substractMatrix(Matrix2 anotherMatrix)
            {
                int newC;
                int newL;
                int[] anotherSize = anotherMatrix.getSize();
                if (anotherSize[0] > c)
                {
                    newC = anotherSize[0];
                }
                else
                {
                    newC = c;
                }
                if (anotherSize[1] > l)
                {
                    newL = anotherSize[1];
                }
                else
                {
                    newL = l;
                }
                int[] resValues = new int[newC * newL];
                Matrix2 result = new Matrix2(newC, newL, resValues);
                for (int i = 1; i <= newC; i++)
                {
                    for (int j = 1; j <= newL; j++)
                    {
                        result.addElem(i, j, this.getValue(i, j) - anotherMatrix.getValue(i, j));
                    }
                }
                return result;
            }
            public override string ToString()
            {
                string result = "";
                for (int i = 1; i <= c; i++)
                {
                    for (int j = 1; j <= l; j++)
                    {
                        result += this.getValue(i, j) + " ";
                    }
                    result += "\n";
                }
                return result;
            }
        }
        class Book
        {
            string _title;
            string _author;
            double _price;
            readonly string _isbn;
            DateTime _date;
            public Book(string title, string author, double price, string isbn, DateTime date)
            {
                _title = title;
                _author = author;
                _price = price;
                _isbn = isbn;
                _date = date;
            }
            public string Title
            {
                get { return _title; }
            }
            public string Author
            {
                get { return _author; }
            }
            public double Price
            {
                get { return _price; }
            }
            public string Isbn
            {
                get { return _isbn; }
            }
            public DateTime Date
            {
                get { return _date; }
            }
            public override string ToString()
            {
                string result = String.Format("Title: {0}\nAuthor: {1}\nPrice: {2}\nISBN: {3}\nDate: {4}",
                    _title, _author, _price, _isbn, _date);
                return result;
            }
        }
        sealed class BookLibrary
        {
            private static BookLibrary _instance;
            List<Book> books;
            private BookLibrary()
            {
                books = new List<Book>();
            }
            public static BookLibrary getInstance()
            {
                if(_instance == null)
                {
                    _instance = new BookLibrary();
                }
                return _instance;
            }
            public void add(Book book)
            {
                if(searchByIsbn(book.Isbn) == null)
                {
                    books.Add(book);
                }
                else
                {
                    Console.WriteLine("Book with that ISBN is already in the library");
                }
            }
            public void remove(Book book)
            {
                books.Remove(book);
            }
            public Book searchByIsbn(string isbn)
            {
                return books.Find(book => book.Isbn == isbn);
            }
            public List<Book> searchByTitle(string title)
            {
                return books.FindAll(book => book.Title == title);
            }
            public List<Book> searchByAuthor(string author)
            {
                return books.FindAll(book => book.Author == author);
            }
            public List<Book> searchByPrice(double price)
            {
                return books.FindAll(book => book.Price == price);
            }
            public bool doesExist(Book book)
            {
                if (books.FindIndex(bookx => bookx == book) != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override string ToString()
            {
                string result = "";
                foreach (Book book in books)
                {
                    result += book.ToString() + "\n\n";
                }
                return result;
            }
        }
        public void ex1()
        {
            Console.WriteLine("Exercise 1\nEnter a number:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("For loop:");
            for(int i = 0; i < number; i++)
            {
                for(int j = 0; j < i + 1; j++)
                {
                    Console.Write("{0} ", j + 1);
                }
                Console.Write("\n");
            }
            Console.WriteLine("While loop:");
            int k = 0;
            int m = 0;
            while(k < number)
            {
                m = 0;
                while(m < k + 1)
                {
                    Console.Write("{0} ", m + 1);
                    m++;
                }
                Console.Write("\n");
                k++;
            }
            Console.WriteLine("Do while loop:");
            k = 0;
            m = 0;
            do
            {
                m = 0;
                do
                {
                    Console.Write("{0} ", m + 1);
                    m++;
                }
                while (m < k + 1);
                Console.Write("\n");
                k++;
            }
            while (k < number);
            Console.WriteLine("\nPart 2");
            Console.WriteLine("For loop:");
            for (int i = 0; i < number; i++)
            {
                for (int j = 0; j < i + 1; j++)
                {
                    Console.Write("{0} ", i + 1);
                }
                Console.Write("\n");
            }
            Console.WriteLine("While loop:");
            k = 0;
            m = 0;
            while (k < number)
            {
                m = 0;
                while (m < k + 1)
                {
                    Console.Write("{0} ", k + 1);
                    m++;
                }
                Console.Write("\n");
                k++;
            }
            Console.WriteLine("Do while loop:");
            k = 0;
            m = 0;
            do
            {
                m = 0;
                do
                {
                    Console.Write("{0} ", k + 1);
                    m++;
                }
                while (m < k + 1);
                Console.Write("\n");
                k++;
            }
            while (k < number);
        }
        public void ex2()
        {
            Console.WriteLine("\n\n\nExercise 2");
            Int32 i = 23;
            object o = i;
            i = 123;
            Console.WriteLine(i + ", " + (Int32)o);//o jest opakowane i istnieje na stercie jako osobna zmienna
            //long j = (long)o; - rzuca wyjątek, rzutowanie jest niedozwolone
        }
        public void ex3()
        {
            int? i;
            Console.WriteLine("\n\n\nExercise 3");
            //Console.WriteLine(i); - niedozwolone
            i = null;
            Console.WriteLine("GetValueOrDefault(0): {0}", i.GetValueOrDefault(0));
            Console.WriteLine("Has value? {0}", i.HasValue);
            i = 5;
            Console.WriteLine("After setting to 5: {0}", i);
        }
        public void ex4()
        {
            int? i = null;
            int j = 10;
            Console.WriteLine("\n\n\nExercise 4");
            Console.WriteLine("i < j: {0}", i < j);
            Console.WriteLine("i > j: {0}", i > j);
            Console.WriteLine("i == j: {0}", i == j);
        }
        public void ex5()
        {
            Console.WriteLine("\n\n\nExercise 5");
            puts("Test string");
            Console.WriteLine("_flushall(): {0}", _flushall());
        }
        public void ex6()
        {
            Console.WriteLine("\n\n\nExercise 6");
            Stack stack1 = new Stack();
            Stack stack2 = new Stack();
            Stack stack3 = new Stack();
            Random r = new Random();
            for(int i = 0; i < 100; i++)
            {
                int number1 = r.Next(0, 100);
                int number2 = r.Next(0, 100);
                stack1.addItem(number1);
                stack2.addItem(number2);
            }
            for(int i = 0; i < 100; i++)
            {
                int number1 = stack1.deleteItem();
                int number2 = stack2.deleteItem();
                if(number1%2 == 0 & stack3.findAnItem(number1) == -1)
                {
                    stack3.addItem(number1);
                }
                if (number2%2 == 0 & stack3.findAnItem(number2) == -1)
                {
                    stack3.addItem(number2);
                }
            }
            Console.WriteLine("Numbers in the third stack:");
            stack3.printAllItems();
            stack3.showTheNumberOfItems();
        }
        public void ex7()
        {
            Console.WriteLine("\n\n\nExercise 7");
            int[] values1 = new int[] { 1, 1, 1, 1 };
            int[] values2 = new int[] { 2, 2, 2, 2, 2, 2 };
            Matrix matrix1 = new Matrix(2, 2, values1);
            Matrix matrix2 = new Matrix(3, 2, values2);
            Matrix result = matrix1.addMatrix(matrix2);
            Console.WriteLine("Matrix 1:\n{0}", matrix1.ToString());
            Console.WriteLine("Matrix 2:\n{0}", matrix2.ToString());
            Console.WriteLine("Matrix 1 + Matrix 2:\n{0}", result.ToString());
        }
        public void ex8()
        {
            Console.WriteLine("\n\n\nExercise 8");
            int[] values1 = new int[] { 1, 1, 1, 1 };
            int[] values2 = new int[] { 2, 2, 2, 2, 2, 2 };
            Matrix2 matrix1 = new Matrix2(2, 2, values1);
            Matrix2 matrix2 = new Matrix2(3, 2, values2);
            Matrix2 result = matrix1.addMatrix(matrix2);
            Matrix2 result2 = matrix1.substractMatrix(matrix2);
            Console.WriteLine("Matrix 1:\n{0}", matrix1.ToString());
            Console.WriteLine("Matrix 2:\n{0}", matrix2.ToString());
            Console.WriteLine("Matrix 1 + Matrix 2:\n{0}", result.ToString());
            Console.WriteLine("Matrix 1 - Matrix 2:\n{0}", result2.ToString());

        }
        public void ex9()
        {
            Console.WriteLine("\n\n\nExercise 9");
            BookLibrary bookLibrary = BookLibrary.getInstance();
            Book book1 = new Book("Idiot", "Fyodor Dostoyevsky", 40, "2748", DateTime.Now);
            Book book2 = new Book("Hero of our times", "Mikhail Lermontov", 30, "1111", DateTime.Now);
            Book book3 = new Book("Oblomov", "Ivan Goncharov", 40, "2345", DateTime.Now);
            bookLibrary.add(book1);
            bookLibrary.add(book2);
            Console.WriteLine("Now there are these books available: \n{0}", bookLibrary.ToString());
            Console.WriteLine("We will now remove \"Hero of our times\"");
            bookLibrary.remove(book2);
            Console.WriteLine("Now there are these books available: \n{0}", bookLibrary.ToString());
            bookLibrary.add(book3);
            Console.WriteLine("Now we will add \"Oblomov\" and check if it is properly added: {0}", bookLibrary.doesExist(book3));
            Console.WriteLine("We print all books which cost 40:");
            List<Book> books40 = bookLibrary.searchByPrice(40);
            foreach(Book book in books40)
            {
                Console.WriteLine(book.ToString() + "\n");
            }
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
        }
    }
}
