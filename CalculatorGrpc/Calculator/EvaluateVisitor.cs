using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculatorGrpc.Calculator.Contracts;

namespace CalculatorGrpc.Calculator
{
    /// <summary>
    /// Класс вычислений
    /// </summary>
    public class EvaluateVisitor : IVisitor
    {
        private Stack<string> operatorElementStack = new Stack<string>();
        private Stack<double> valueStack = new Stack<double>();

        /// <summary>
        /// Посещение оператора
        /// </summary>
        /// <param name="operatorElement"></param>
        public void Visit(OperatorElement operatorElement)
        {
            string operatorElem = operatorElement.Operator;

            if (operatorElem.Equals("("))
            {
                operatorElementStack.Push(operatorElem);
            }
            else if (operatorElem.Equals(")"))
            {
                while (!operatorElementStack.Peek().Equals("("))
                {
                    double secondNum = valueStack.Pop();
                    double firstNum = valueStack.Pop();
                    string operatorChar = operatorElementStack.Pop();
                    if (operatorChar.Equals("+"))
                    {
                        valueStack.Push(firstNum + secondNum);
                    }
                    else if (operatorChar.Equals("-"))
                    {
                        valueStack.Push(firstNum - secondNum);
                    }
                    else if (operatorChar.Equals("*"))
                    {
                        valueStack.Push(firstNum * secondNum);
                    }
                    else if (operatorChar.Equals("/"))
                    {
                        valueStack.Push(firstNum / secondNum);
                    }
                }

                operatorElementStack.Pop();
            }
            else if (operatorElem.Equals("*") || operatorElem.Equals("/"))
            {
                while (operatorElementStack.Count != 0  && (GetPriority(operatorElementStack.Peek()) >= GetPriority(operatorElem)))
                {
                    double secondNum = valueStack.Pop();
                    double firstNum = valueStack.Pop();
                    string operatorChar = operatorElementStack.Pop();
                    if (operatorChar.Equals("*"))
                    {
                        valueStack.Push(firstNum * secondNum);
                    }
                    else if (operatorChar.Equals("/"))
                    {
                        valueStack.Push(firstNum / secondNum);
                    }
                }

                operatorElementStack.Push(operatorElem);
            }
            else if (operatorElem.Equals("+") || operatorElem.Equals("-"))
            {
                while (operatorElementStack.Count != 0 && !operatorElementStack.Peek().Equals("("))
                {
                    double secondNum = valueStack.Pop();
                    double firstNum = valueStack.Pop();
                    string operatorChar = operatorElementStack.Pop();
                    if (operatorChar.Equals("+"))
                    {
                        valueStack.Push(firstNum + secondNum);
                    }
                    else if (operatorChar.Equals("-"))
                    {
                        valueStack.Push(firstNum - secondNum);
                    }
                    else if (operatorChar.Equals("*"))
                    {
                        valueStack.Push(firstNum * secondNum);
                    }
                    else if (operatorChar.Equals("/"))
                    {
                        valueStack.Push(firstNum / secondNum);
                    }
                }

                operatorElementStack.Push(operatorElem);
            }
        }

        /// <summary>
        /// Посещение числа
        /// </summary>
        /// <param name="number"></param>
        public void Visit(NumberElement number)
        {
            valueStack.Push(number.Number);
        }

        /// <summary>
        /// Посещение калькулятора
        /// </summary>
        /// <param name="calculator"></param>
        public void Visit(Calculator calculator)
        {
            while (operatorElementStack.Count != 0)
            {
                double secondNum = valueStack.Pop();
                double firstNum = valueStack.Pop();
                string operatorChar = operatorElementStack.Pop();
                if (operatorChar.Equals("+"))
                {
                    valueStack.Push(firstNum + secondNum);
                }
                else if (operatorChar.Equals("-"))
                {
                    valueStack.Push(firstNum - secondNum);
                }
                else if (operatorChar.Equals("*"))
                {
                    valueStack.Push(firstNum * secondNum);
                }
                else if (operatorChar.Equals("/"))
                {
                    valueStack.Push(firstNum / secondNum);
                }
            }

            PrintResult();
        }

        /// <summary>
        /// Получение приоритета операции
        /// </summary>
        /// <param name="operatorElem"></param>
        /// <returns></returns>
        private int GetPriority(string operatorElem)
        {
            if (operatorElem.Equals("*") || operatorElem.Equals("/"))
            {
                return 2;
            }
            else if (operatorElem.Equals("+") || operatorElem.Equals("-"))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Вывести ответ
        /// </summary>
        private void PrintResult()
        {
            Console.WriteLine(valueStack.First());
        }
    }
}