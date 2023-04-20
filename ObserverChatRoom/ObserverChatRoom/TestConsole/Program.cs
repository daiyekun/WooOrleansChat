using System.Dynamic;
using System.Reflection;

namespace TestConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            dynamic s = new RequestMetadata();
            s.Type = "1";
            s.Name = "111";
            s.DefaultValue = "str";


            Console.WriteLine($"{s.Type}");
        }
    }

   

 }