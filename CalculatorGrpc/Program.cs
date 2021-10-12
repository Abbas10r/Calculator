using System;
using System.Threading.Tasks;
using CalculatorGrpc.Calculator;
using CalculatorGrpc.Calculator.Contracts;

namespace CalculatorGrpc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите выражение: ");
            string input = Console.ReadLine();
            IElement calculator = new Calculator.Calculator(input);
            calculator.Accept(new EvaluateVisitor());
            Console.ReadKey();
        }
    }
}