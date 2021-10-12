using System;
using CalculatorGrpc.Calculator.Contracts;

namespace CalculatorGrpc.Calculator
{
    /// <summary>
    /// Число
    /// </summary>
    public class NumberElement : IElement
    {
        public double Number { get; set; }
        
        public NumberElement(string number) {
            Number = Convert.ToDouble(number);
        }

        /// <summary>
        /// Посещение
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(IVisitor visitor) {
            visitor.Visit(this);
        }
    }
}