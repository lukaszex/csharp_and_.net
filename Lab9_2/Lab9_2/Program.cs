using System;
using System.Runtime.InteropServices;

namespace Lab9_2
{
    class Program
    {
        public class Publisher
        {
            public event EventHandler isDigit;
            public event EventHandler isCharacter;
            public virtual void onDigitOrCharacter(bool clicked, EventArgs e)
            {
                if(clicked)
                {
                    isDigit?.Invoke(this, e);
                }
                else
                {
                    isCharacter?.Invoke(this, e);
                }
            }
        }
        public static void digitHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Naciśnięto cyfrę");
        }
        public static void characterHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Naciśnięto literę");
        }
        public class DisposeObject: IDisposable
        {
            protected bool disposed = false;
            public IntPtr handle;
            //private Component components;
            public DisposeObject(IntPtr _handle)
            {
                handle = _handle;
            }
            ~DisposeObject()
            {
                Dispose(false);
            }
            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            protected virtual void Dispose(bool disposing)
            {
                if(!disposed)
                {
                    if(disposing)
                    {
                        //components.Dispose();
                    }
                    CloseHandle(handle);
                }
                disposed = true;
            }
            [System.Runtime.InteropServices.DllImport("Kernel32")]
            private extern static Boolean CloseHandle(IntPtr handle);
        }
        public void ex1()
        {
            string[] slowa = new string[]
            {
                "Już północ", "cień", "ponury", "pół", "świata",
                "okrywa", "A jeszcze", "serce", "zmysłom",
                "spoczynku nie daje"
            };
            Console.WriteLine("Exercise 1");
            Console.WriteLine($"{slowa[^1]}");
            string[] sonet1 = slowa[2..6];
            foreach(string slowo in sonet1)
            {
                Console.Write($"< {slowo}");
            }
            Console.WriteLine();
            string[] sonet2 = slowa[^3..^0];
            foreach (string slowo in sonet2)
            {
                Console.Write($"< {slowo}");
            }
            Console.WriteLine();
            string[] sonet3 = slowa[..];
            foreach (string slowo in sonet3)
            {
                Console.Write($"< {slowo}");
            }
            Console.WriteLine();
            string[] sonet4 = slowa[..5];
            foreach (string slowo in sonet4)
            {
                Console.Write($"< {slowo}");
            }
            Console.WriteLine();
            string[] sonet5 = slowa[7..];
            foreach (string slowo in sonet5)
            {
                Console.Write($"< {slowo}");
            }
            Console.WriteLine();
            Index stri = ^5;
            Console.WriteLine(slowa[stri]);
            Range fraza = 2..7;
            string[] tekst = slowa[fraza];
            foreach(string slowo in tekst)
            {
                Console.Write($"{slowo}");
            }
            Console.WriteLine();
        }
        public void ex2()
        {
            Console.WriteLine("\n\n\nExercise 2");
            Publisher p = new Publisher();
            p.isDigit += digitHandler;
            p.isCharacter += characterHandler;
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter a number or a character");
                char clicked = Console.ReadKey().KeyChar;
                if(Char.IsDigit(clicked))
                {
                    p.onDigitOrCharacter(true, EventArgs.Empty);
                }
                else if(Char.IsLetter(clicked))
                {
                    p.onDigitOrCharacter(false, EventArgs.Empty);
                }
                else
                {
                    Console.WriteLine("Neither a number, nor a character was entered");
                    break;
                }
            }
        }
        public void ex3()
        {
            Console.WriteLine("\n\n\nExercise 3");
            IntPtr ptr = Marshal.AllocHGlobal(10);
            DisposeObject d = new DisposeObject(ptr);
            Marshal.FreeHGlobal(ptr);
            d.Dispose();
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
