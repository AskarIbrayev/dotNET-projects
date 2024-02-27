using System;
using System.Collections;

namespace Fraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new Fraction(1, 3);
            var b = new Fraction(2, 3);
            var c = new Fraction(4, 7);
            
            var dictionary = new Dictionary<int, Fraction>()
            {
                { a.GetHashCode(), a },
                { b.GetHashCode(), b },
                { c.GetHashCode(), c },
            };
            
            var hashTable = new Hashtable()
            {
                { a.GetHashCode(), a },
                { b.GetHashCode(), b },
                { c.GetHashCode(), c },
            };

            var hashSet = new HashSet<int>()
            {
                { a.GetHashCode() },
                { b.GetHashCode() },
                { c.GetHashCode() }
            };
            
            Console.WriteLine($"Addition of {a} and {b}: {a.Plus(b)}");
            Console.WriteLine($"Subtraction of {a} and {b}: {a.Minus(b)}");
            Console.WriteLine($"Multiplication of {a} and {b}: {a.Times(b)}");
            Console.WriteLine($"Division of {a} by {b}: {a.DivideBy(b)}");
            Console.WriteLine($"Conversion of fraction {a} to double: {a.ToDouble()}");

            Console.WriteLine($"{a} is Equal to {b}: {a.Equals(b)}");
            Console.WriteLine($"{a} is Greater than {b}: {a.GreaterThan(b)}");
            Console.WriteLine($"{a} is Less than {b}: {a.LessThan(b)}");
            Console.WriteLine($"{a} is Greater or Equal to {b}: {a.GreaterOrEqual(b)}");
            Console.WriteLine($"{a} is Less or Equal to {b}: {a.LessOrEqual(b)}");
            
            Console.WriteLine($"find {a} in dictionary by its hash code: {dictionary[a.GetHashCode()]}");
            Console.WriteLine($"find {b} in hashTable by its hash code: {hashTable[b.GetHashCode()]}");

            Console.WriteLine($"Hash codes of {a}, {b}, {c} stored in hashSet:");
            foreach (var hashSetItem in hashSet)
            {
                Console.WriteLine(hashSetItem);
            }
        }
    }
}

