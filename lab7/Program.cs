using System;

namespace lab7
{
    public static class Program
    {
        static void Main(string[] args)
        {
            MixedNumber m1 = new MixedNumber(2, 3);
            MixedNumber m2 = new MixedNumber(-1, 3);
            Console.WriteLine($"{m1} + ({m2}) = ({m1 + m2})");

            object[] objects = new object[] {
                new Line(),
                new Ring(),
                new Square("red"),
                new Circle("blue")
            };

            WriteObjects(objects);

            Console.WriteLine("abcdef123".ChangeLetters());
        }

        public static void WriteObjects(object[] objects)
        {
            foreach (var item in objects)
            {
                if (item is IFigure figure)
                {
                    if (figure is IHasInterior figureWithInterior)
                        Console.WriteLine(figureWithInterior.Color);
                    else
                        Console.WriteLine("no color");
                }
            }
        }

        public static string ChangeLetters(this string str)
        {
            char[] changed = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                if (Char.IsLetter(str[i]))
                {
                    if (i % 2 == 0)
                        changed[i] = Char.ToLower(str[i]);
                    else
                        changed[i] = Char.ToUpper(str[i]);
                }
                else
                    changed[i] = '.';
            }
            return String.Join("", changed);
        }
    }
}
