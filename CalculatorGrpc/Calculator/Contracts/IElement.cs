namespace CalculatorGrpc.Calculator.Contracts
{
    /// <summary>
    /// Интерфейс элемента
    /// </summary>
    public interface IElement
    {
        void Accept(IVisitor visitor);
    }
}