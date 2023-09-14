namespace Problem04.BalancedParentheses
{
    using System;
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
            => Solve(parentheses);

        bool Solve(string parentheses)
        {
            if (parentheses.Length % 2 != 0 || parentheses.Length == 0)
                return false;


            var stack = new Stack<char>(parentheses.Length / 2);

            foreach (char c in parentheses)
            {
                char expectedChar = default;

                switch(c)
                {
                    case ')':
                        expectedChar = '(';
                        break;
                    case ']':
                        expectedChar = '[';
                        break;
                    case '}':
                        expectedChar = '{';
                        break;
                    default:
                        stack.Push(c);
                        break;
                }

                if (expectedChar == default)
                    continue;

                if (stack.Pop() != expectedChar)
                    return false;
            }

            return stack.Count == 0;
        }
    }
}
