using System;
using System.Threading.Tasks;

namespace NaviroTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //InvokeQuestion1();
            //InvokeQuestion2();
            await InvokeQuestion8();
        }

        static void InvokeQuestion1()
        {
            Console.WriteLine("Program to check if a string is null or empty...");
            Console.Write("Enter a string : ");
            var input = Console.ReadLine();
            Console.WriteLine("IsNullOrEmpty : " + Question1.IsNullOrEmpty(input).ToString());
        }

        static void InvokeQuestion2()
        {
            Console.WriteLine("Program to check if a string is null or empty...");
            Console.Write("Enter a string : ");
            var input = Console.ReadLine();
            Console.WriteLine("IsNullOrEmpty : " + Question1.IsNullOrEmpty(input).ToString());
        }

        static async Task InvokeQuestion8()
        {
            Question8 q8 = new Question8();
            q8.ExtractAllAHrefTags(@"C:\Workspace\dotNet\NaviroTest\NaviroTest\test.html");
            await q8.CheckLinks();
            System.IO.File.WriteAllLines("ValidUrls.txt", q8.ValidUrls);
            System.IO.File.WriteAllLines("InValidUrls.txt", q8.InvalidUrls);
        }
    }
}
