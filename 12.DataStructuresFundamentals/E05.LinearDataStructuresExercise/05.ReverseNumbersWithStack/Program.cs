#nullable disable

string input = Console.ReadLine();

if (input.Length == 0)
{
    Console.WriteLine("(empty)");
    return;
}

string[] stringNumbers = input.Split(" ");
Stack<int> numbers = new Stack<int>();

foreach (string stringNumber in stringNumbers)
    numbers.Push(int.Parse(stringNumber));

while (numbers.Count > 0)
    Console.Write($"{numbers.Pop()} ");

Console.WriteLine();