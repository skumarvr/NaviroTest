using System;
using System.Linq;
using System.Threading.Tasks;

namespace NaviroTest
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            do
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("1. Question 1");
                Console.WriteLine("2. Question 1");
                Console.WriteLine("3. Question 3");
                Console.WriteLine("4. Question 4");
                Console.WriteLine("8. Question 8");
                Console.WriteLine("0. Exit");
                Console.Write("\n Enter the choice");
                var ch = Convert.ToInt32(Console.ReadLine());

                switch(ch)
                {
                    case 1:
                        InvokeQuestion1();
                        break;
                    case 2:
                        InvokeQuestion2();
                        break;
                    case 3:
                        InvokeQuestion3();
                        break;
                    case 4:
                        InvokeQuestion4();
                        break;
                    case 8:
                        await InvokeQuestion8();
                        break;
                    case 0:
                        return 1;
                }
            } while (true);            
        }

        static void InvokeQuestion1()
        {
            Console.WriteLine("Program to check if a string is null or empty...");
            Console.Write("\nEnter a string : ");
            var input = Console.ReadLine();
            Console.WriteLine("IsNullOrEmpty : " + Question1.IsNullOrEmpty(input).ToString());
        }

        static void InvokeQuestion2()
        {
            Console.WriteLine("Program to positive divisors of the input integer....");
            Console.Write("Enter a positive number : ");
            var ch = Convert.ToUInt32(Console.ReadLine());
            Question2 q2 = new Question2();
            var result = q2.GetPostiveDivisors(ch);
            Console.WriteLine("Positive divisors : " + String.Join(',', result));
        }

        private static void InvokeQuestion3()
        {
            Console.WriteLine("Program to output the area of the triangle....");
            Console.WriteLine("\nSample input (three sides of the triangle) : 1,2,3");
            Console.Write("\nInput : ");
            var numStr = Console.ReadLine();
            Question3 q3 = new Question3();
            int[] sides = numStr.Split(',').Select(Int32.Parse).ToArray();
            var result = q3.CalculateArea(sides[0], sides[1], sides[2]);
            Console.WriteLine("\n Area : " + result.ToString());
        }

        private static void InvokeQuestion4()
        {
            Console.WriteLine("Program to return the most common integer in the input...");
            Console.WriteLine("\nSample input : 1,2,3,4,5,1,6,7");
            Console.Write("\nInput : ");
            var numStr = Console.ReadLine();
            Question4 q4 = new Question4();
            var result = q4.GetMostCommon(numStr.Split(',').Select(Int32.Parse).ToArray());
            Console.WriteLine("\n Most common integer : " + String.Join(',', result));
        }

        static async Task InvokeQuestion8()
        {
            Console.WriteLine("Link checker...");
            Console.Write("\nEnter the file name (with ful path) : ");
            var fileName = Console.ReadLine();
            Question8 q8 = new Question8();
            // q8.ExtractAllAHrefTags(@"C:\Workspace\dotNet\NaviroTest\NaviroTest\test.html");
            q8.ExtractAllAHrefTags(fileName);
            await q8.CheckLinks();
            System.IO.File.WriteAllLines("ValidUrls.txt", q8.ValidUrls);
            System.IO.File.WriteAllLines("InValidUrls.txt", q8.InvalidUrls);
            Console.Write("\nOutput files : ValidUrls.txt and InValidUrls.txt ");
        }
    }
}
