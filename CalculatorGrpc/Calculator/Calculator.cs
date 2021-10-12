using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CalculatorGrpc.Calculator.Contracts;

namespace CalculatorGrpc.Calculator
{
    /// <summary>
    /// Класс парсер
    /// </summary>
    public class Calculator : IElement
    {
        private List<IElement> elements = new List<IElement>();

        public Calculator(string s)
        {
            ParseInput(s);
        }

        /// <summary>
        /// Посещение
        /// </summary>
        /// <param name="visitor"></param>
        public void Accept(IVisitor visitor)
        {
            foreach(var item in elements) {
                item.Accept(visitor);
            }
            visitor.Visit(this);
        }

        /// <summary>
        /// Парсинг выражения
        /// </summary>
        /// <param name="input"></param>
        private void ParseInput(string input)
        {
            string pattern = "[0-9]?(\\.)?(\\s+)?";
            string pattern2 = "(\\s+)+";
            Regex rgx = new Regex(pattern);
            Regex rgx2 = new Regex(pattern2);
            string previousToken = "";
            int i = 0;
            int numParenthesis = 0;

            if (input.Length == 0)
            {
                throw new Exception("Пустая строка.");
            }
            else if (rgx2.IsMatch(input))
            {
                throw new Exception("Строка состоит из пробелов.");
            }

            while (i < input.Length)
            {
                string stringValue = string.Empty;
                string c = input[i..(i+1)];
                if (!IsOperator(c) && !IsParenthesis(c) && !rgx.IsMatch(pattern))
                {
                    throw new Exception("Использован неверный символ.");
                }

                if (IsOperator(c))
                {
                    if (previousToken == "operator")
                    {
                        throw new Exception("Использование операторов один за другим.");
                    }

                    elements.Add(new OperatorElement(c));
                    i++;
                    previousToken = "operator";
                }
                else if (c.Equals("("))
                {
                    elements.Add(new OperatorElement(c));
                    i++;
                    numParenthesis++;
                    previousToken = "parenthesis";
                }
                else if (c.Equals(")"))
                {
                    elements.Add(new OperatorElement(c));
                    i++;
                    numParenthesis--;
                    previousToken = "parenthesis";
                }
                else if (c.Equals(" "))
                {
                    i++;
                    continue;
                }
                else
                {
                    if (previousToken == "number")
                    {
                        throw new Exception("Использование чисел одно за другим без оператора.");
                    }

                    int start = i;
                    int end = i + 1;
                    if (end == input.Length)
                    {
                        stringValue = input[start..end];
                        elements.Add(new NumberElement(stringValue));
                        i = end;
                        continue;
                    }

                    string newToken = input[(i+1)..(i+2)];
                    while (!IsOperator(newToken) && !IsParenthesis(newToken) && !newToken.Equals(" ") &&
                           i + 2 <= input.Length)
                    {
                        i++;
                        if (i + 2 <= input.Length)
                        {
                            newToken = input[(i+1)..(i+2)]; 
                        }

                        end = i + 1;
                    }

                    stringValue = input[start..end];
                    elements.Add(new NumberElement(stringValue));
                    i = end;
                    previousToken = "number";
                }
            }

            if (numParenthesis != 0)
            {
                throw new Exception("Неверно расставлены скобки.");
            }
        }

        /// <summary>
        /// Проверка оператора
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool IsOperator(string s)
        {
            if (s.Equals("+") || s.Equals("-") || s.Equals("*") || s.Equals("/"))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Проверка скобок
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private bool IsParenthesis(string s)
        {
            if (s.Equals("(") || s.Equals(")"))
            {
                return true;
            }
            return false;
        }
    }
}