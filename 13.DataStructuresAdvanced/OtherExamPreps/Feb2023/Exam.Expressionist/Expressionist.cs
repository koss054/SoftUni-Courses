using System;
using System.Collections.Generic;
using System.Text;

namespace Exam.Expressionist
{
    public class Expressionist : IExpressionist
    {
        private Dictionary<string, Expression> _expressions = new Dictionary<string, Expression>();

        public void AddExpression(Expression expression)
        {
            if (_expressions.Count > 0)
            {
                throw new ArgumentException();
            }

            _expressions.Add(expression.Id, expression);
        }

        public void AddExpression(Expression expression, string parentId)
        {
            if (!_expressions.ContainsKey(parentId))
            {
                throw new ArgumentException();
            }

            var parentExpression = _expressions[parentId];

            if (parentExpression.LeftChild is null)
            {
                parentExpression.LeftChild = expression;
            }
            else if (parentExpression.RightChild is null)
            {
                parentExpression.RightChild = expression;
            }
            else
            {
                throw new ArgumentException();
            }

            expression.Parent = parentExpression;
            _expressions.Add(expression.Id, expression);
        }

        public bool Contains(Expression expression)
        {
            return _expressions.ContainsKey(expression.Id);
        }

        public int Count()
        {
            return _expressions.Count;
        }

        public string Evaluate()
        {
            throw new NotImplementedException();
        }

        public Expression GetExpression(string expressionId)
        {
            if (!_expressions.ContainsKey(expressionId))
            {
                throw new ArgumentException();
            }

            return _expressions[expressionId];
        }

        public void RemoveExpression(string expressionId)
        {
            if (!_expressions.ContainsKey(expressionId))
            {
                throw new ArgumentException();
            }
            
            var expression = _expressions[expressionId];
            var parentExpression = expression.Parent;

            if (parentExpression.LeftChild.Equals(expression))
            {
                parentExpression.LeftChild = parentExpression.RightChild;
                parentExpression.RightChild = null;
            }
            else if (parentExpression.RightChild.Equals(expression))
            {
                parentExpression.RightChild = null;
            }

            RemoveChildExpressions(expression);
            _expressions.Remove(expressionId);
        }

        private void RemoveChildExpressions(Expression expression)
        {
            if (expression is null)
            {
                return;
            }

            RemoveChildExpressions(expression.LeftChild);
            _expressions.Remove(expression.Id);
            RemoveChildExpressions(expression.RightChild);
        }
    }
}
