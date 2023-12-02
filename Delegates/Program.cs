using System;

namespace Delegates
{
    public delegate int MainDelegate(int firstNumber, int secondNumber);
    public class Program
    {
        static void Main(string[] args)
        {
            MainDelegate mainDelegate = new MainDelegate(Addition);
            mainDelegate += Subtract;
            while (true)
            {

                Delegate[] methods = mainDelegate.GetInvocationList();

                MainDelegate addition = (MainDelegate)methods[0];
                MainDelegate subtraction = (MainDelegate)methods[1];

                Console.Write("Enter first number: ");
                int firstNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter second number: ");
                int secondNumber = int.Parse(Console.ReadLine());

                Console.Write("Enter index\n" + "Addition - 0, Subtraction - 1:");

                string choosenAsString = (Console.ReadLine() ?? "0");

                if(choosenAsString == "break")
                {
                    break;
                }

                int value = int.Parse(choosenAsString);


                if(value >= 0 && value < methods.Length)
                {
                    MainDelegate chosenFunction = (MainDelegate)methods[value];
                    Console.WriteLine(chosenFunction(firstNumber, secondNumber));
                }
                else
                {
                    Console.WriteLine("Incorrect");
                }
            }

        }

        static int Addition(int firstNumber, int secondNumber) => firstNumber + secondNumber;
        static int Subtract(int firstNumber, int secondNumber) => firstNumber - secondNumber;
    }
}