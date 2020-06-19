using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    abstract class Steel
    {
        public int density { get; set; }
        public int thickness { get; set; }
        public string type { get; set; }

        public virtual double square
        {
            get
            {
                return 0;
            }
        }
        
        public virtual double weight
        {
            get
            {
                return square * thickness * density / 1000000000;
            }
        }

        public virtual string perimetr
        {
            get
            {
                return " ";
            }
        }

        public override string ToString()
        {
            return type + "\t" + "Sides:" + perimetr + "\t" + "Square:" + square + "mm3\t" + "Weight:" + weight + "kg";
        }
    }

    class Square : Steel
    {
        public Square(int height_, int thickness_, int density_)
        {
            height = height_;
            thickness = thickness_;
            density = density_;
            type = "square";
        }

        public int height { get; set; }

        public override double square
        {
            get
            {
                return height * height;
            }
        }

        public override string perimetr
        {
            get
            {
                return Convert.ToString(height) + "x" + Convert.ToString(height);
            }
        }
    }

    class Rectangle : Steel
    {
        public Rectangle(int height_, int width_, int thickness_, int density_)
        {
            width = width_;
            height = height_;
            thickness = thickness_;
            density = density_;
            type = "rectangle";
        }

        public int height { get; set; }
        public int width { get; set; }

        public override double square
        {
            get
            {
                return height * width;
            }
        }

        public override string perimetr
        {
            get
            {
                return Convert.ToString(height) + "x" + Convert.ToString(width);
            }
        }
    }

    class Triangle : Steel
    {
        public Triangle(int height_, int width_, int thickness_, int density_)
        {
            width = width_;
            height = height_;
            thickness = thickness_;
            density = density_;
            type = "triangle";
        }

        public int height { get; set; }
        public int width { get; set; }

        public override double square
        {
            get
            {
                return height * width / 2;
            }
        }

        public override string perimetr
        {
            get
            {
                return Convert.ToString(height) + "x" + Convert.ToString(width);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Steel> steel = new List<Steel>();

            steel.Add(new Square(100, 5, 7900));
            steel.Add(new Square(120, 7, 7800));
            steel.Add(new Square(90, 10, 7900));
            steel.Add(new Square(10, 1, 8000));
            steel.Add(new Square(75, 228, 7900));

            steel.Add(new Rectangle(90, 110, 5, 7900));
            steel.Add(new Rectangle(80, 100, 4, 7800));
            steel.Add(new Rectangle(100, 110, 3, 7950));
            steel.Add(new Rectangle(100, 100, 2, 7900));
            steel.Add(new Rectangle(60, 120, 1, 7900));
            steel.Add(new Rectangle(100, 100, 2, 7900));
            steel.Add(new Rectangle(20, 140, 5, 7911));

            steel.Add(new Triangle(100, 100, 5, 7900));
            steel.Add(new Triangle(100, 150, 1, 7900));
            steel.Add(new Triangle(110, 100, 50, 7800));

            while(true)
            {
                Console.Clear();
                Console.WriteLine("Your steel:");
                Console.WriteLine("");
                for (int i = 0; i < steel.Count; i++)
                    Console.WriteLine(Convert.ToString(i + 1) + " " + steel[i]);
                Console.WriteLine("");
                Console.WriteLine("Add steel: Add [type] [sizes] [thickness] [density]");
                Console.WriteLine("Remove steel: Remove [number]");
                Console.WriteLine("");
                string[] input = Console.ReadLine().Split(' ');
                try
                {
                    if (input[0] == "Add")
                    {
                        if (input[1] == "Square")
                            steel.Add(new Square(Convert.ToInt32(input[2]), Convert.ToInt32(input[3]), Convert.ToInt32(input[4])));

                        else if (input[1] == "Rectangle")
                            steel.Add(new Rectangle(Convert.ToInt32(input[2]), Convert.ToInt32(input[3]), Convert.ToInt32(input[4]), Convert.ToInt32(input[5])));

                        else if (input[1] == "Triangle")
                            steel.Add(new Rectangle(Convert.ToInt32(input[2]), Convert.ToInt32(input[3]), Convert.ToInt32(input[4]), Convert.ToInt32(input[5])));
                    }
                    else if (input[0] == "Remove")
                        steel.RemoveAt(Convert.ToInt32(input[1]));
                }
                catch
                {
                    Console.WriteLine("error...");
                    Console.ReadKey();
                }
            }
        }
    }
}
