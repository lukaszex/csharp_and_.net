using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {
        public enum Color { red, blue, green };
        public enum TypeOfBauble { sphere, star, angel };
        public class Tree
        {
            public string name { get; set; }
            public int age { get; set; }
            public Tree(string _name, int _age)
            {
                name = _name;
                age = _age;
            }
            public Tree() { }
        }     
        public class Fir : Tree
        {
            protected List<Bauble> baubles;
            public Fir()
            {
                baubles = new List<Bauble>();
            }
            public class Bauble
            {
                public Color color;
                public TypeOfBauble typeOfBauble;
                public Bauble(Color _color, TypeOfBauble _typeOfBauble)
                {
                    color = _color;
                    typeOfBauble = _typeOfBauble;
                }

            }
            public void add(string _color, string _typeOfBauble)
            {
                Color color;
                TypeOfBauble typeOfBauble;
                switch (_color)
                {
                    case "red":
                        color = Color.red;
                        break;
                    case "green":
                        color = Color.green;
                        break;
                    case "blue":
                        color = Color.blue;
                        break;
                    default:
                        color = Color.blue;
                        break;
                }
                switch (_typeOfBauble)
                {
                    case "sphere":
                        typeOfBauble = TypeOfBauble.sphere;
                        break;
                    case "star":
                        typeOfBauble = TypeOfBauble.star;
                        break;
                    case "angel":
                        typeOfBauble = TypeOfBauble.angel;
                        break;
                    default:
                        typeOfBauble = TypeOfBauble.sphere;
                        break;
                }
                Bauble bauble = new Bauble(color, typeOfBauble);
                baubles.Add(bauble);
            }
            public void remove(int index)
            {
                baubles.RemoveAt(index);
            }
        }
        public class ChristmasTree : Fir
        {
            public virtual string this[int i] => baubles[i].color.ToString();
            public int this[Color _color] => baubles.Count(c => c.color == _color);
            public Color this[int i, Color _color] { set => baubles[i].color = _color; }
        }
        public class ChristmasTreeA : ChristmasTree
        {
            public override string this[int i] => baubles[i].typeOfBauble.ToString();
            public string BaubleColor (int idx)
            {
                return base[idx];
            }
        }
        public class ChristmasTreeB : ChristmasTreeA
        {
            public new string this[int i] => baubles[i].color.ToString() + "_" + baubles[i].typeOfBauble.ToString();

        }
        public sealed class ChristmasTreeC : ChristmasTreeB { }
        public abstract class Home
        {
            public abstract int Price();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Let us create christmas tree with 1 blue sphere, 1 green star and 1 red angel");
            ChristmasTree tree = new ChristmasTree();
            tree.add("blue", "sphere");
            tree.add("green", "star");
            tree.add("red", "angel");
            Color color =  Color.red;
            Console.WriteLine("Color of the 2nd bouble: {0}", tree[1].ToString());
            Console.WriteLine("Number of red boubles: {0}", tree[color]);
            ChristmasTreeA treeA = new ChristmasTreeA();
            treeA.add("red", "star");
            Console.WriteLine("\n\nFor ChristmasTreeA we have added a red star. Now we will check if the indexer works fine:");
            Console.WriteLine("Type of bauble: {0}, color of bouble: {1}", treeA[0], treeA.BaubleColor(0));
            ChristmasTreeB treeB = new ChristmasTreeB();
            treeB.add("red", "star");
            Console.WriteLine("\n\nFor ChristmasTreeB we have done the same. We will check its color and type: {0}", treeB[0]);
        }
    }
}
