using CalculatorGrpc.Calculator.Contracts;

namespace CalculatorGrpc.Calculator
{
    /// <summary>
    /// Оператор
    /// </summary>
    public class OperatorElement : IElement
    {
        public string Operator { get; set; }
        
        public OperatorElement(string operatorParam)
        {
            this.Operator = operatorParam;
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