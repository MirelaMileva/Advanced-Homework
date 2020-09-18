using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            bool isBalanced = false;

            for (int i = 0; i < input.Length; i++)
            {
                var symbol = input[i];

                if (symbol == '(')
                {
                    stack.Push(symbol);
                }
                else if (symbol == ')')
                {
                    if (!stack.Any())
                    {
                        isBalanced = false;
                        break;
                    }
                    else
                    {
                        if (stack.Peek() == '(')
                        {
                            isBalanced = true;
                            stack.Pop();

                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    
                }
                else if (symbol == '{')
                {
                    stack.Push(symbol);
                }
                else if (symbol == '}')
                {
                    if (!stack.Any())
                    {
                        isBalanced = false;
                        break;
                    }
                    else
                    {
                        if (stack.Peek() == '{')
                        {
                            isBalanced = true;

                            stack.Pop();
                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    
                }
                else if (symbol == '[')
                {
                    stack.Push(symbol);
                }
                else if (symbol == ']')
                {
                    if (!stack.Any())
                    {
                        isBalanced = false;
                        break;
                    }
                    else
                    {
                        if (stack.Peek() == '[')
                        {
                            isBalanced = true;
                            stack.Pop();

                        }
                        else
                        {
                            isBalanced = false;
                            break;
                        }
                    }
                    
                }
            }

            if (stack.Count == 0 && isBalanced)
            {

                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
