
using Home5;
using System.Text.RegularExpressions;

void Calculator_GotResult(object sender, EventArgs e)
{
    Console.WriteLine($"Result = {((Calculator)sender).Result} ");
}

ICalc calc = new Calculator();
calc.GotResult += Calculator_GotResult;

Console.WriteLine("Введите выражение (типа ('+2', '/ 4') или 'canc' для сброса последнего значения");
while (true)
{
    string input = Console.ReadLine().Replace(" ", "");
    if (input is "canc")
    {
        calc.CancelLast();
        continue;
    }

    Regex regex = new(@"[*/+-]{1}\d");

    int digit;
    
    if (regex.IsMatch(input))
    {
        digit = int.Parse(input.Substring(1, input.Length - 1));
        switch (input.Substring(0, 1))
        {
            case "+": calc.Add(digit); break;
            case "-": calc.Sub(digit); break;
            case "*": calc.Mul(digit); break;
            case "/": calc.Div(digit); break;
        }
    }
    else
    {
        Console.WriteLine("Работа завершена!");
        break;
    }
}

calc.GotResult -= Calculator_GotResult;