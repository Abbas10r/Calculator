namespace CalculatorGrpc.Calculator.Contracts
{
    /// <summary>
    /// Интерфейс посетителя
    /// </summary>
    public interface IVisitor
    {
        void Visit(NumberElement number);
        void Visit(OperatorElement operatorr);
        void Visit(Calculator calculator);
    }
}