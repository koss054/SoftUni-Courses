using Exam.Expressionist;

var expressionist = new Expressionist();
var A = new Expression("A", "+", ExpressionType.Operator, null, null);
var B = new Expression("B", "5", ExpressionType.Value, null, null);
var C = new Expression("C", "10", ExpressionType.Value, null, null);

expressionist.AddExpression(A);
expressionist.AddExpression(B, "A");
expressionist.AddExpression(C, "A");

