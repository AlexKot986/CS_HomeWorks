
namespace Home5
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs> GotResult;
        public double Result = 0;
        private Stack<double> stack = new Stack<double>();
        private Stack<CalcActionLog> stackActionLogs = new Stack<CalcActionLog>();
        public void Add(int i)
        {
            if ((long) Result + i < int.MinValue || (long) Result + i > int.MaxValue)
            {
                stackActionLogs.Push(new CalcActionLog(CalcAction.Add, i));
                throw new CalculatorOperationCauseOverflowException("Переполнение", stackActionLogs);
            }
            double current = Result;
            stack.Push(Result);
            Result += i;
            RaisEvent($"{current} + {i} ");
        }

        public void CancelLast()
        {
            if (stack.Count > 0)
            {
                double current = Result;
                Result = stack.Pop();
                RaisEvent($"CancelLast LastResult = {current}");
            }
            else Console.WriteLine("Нет значений!");
        }

        public void Div(int i)
        {
            if (i == 0)
            {
                stackActionLogs.Push(new CalcActionLog(CalcAction.Div, i));
                throw new CalculatorDivideByZeroException("Деление на ноль!", stackActionLogs);
            }               
            double current = Result;
            stack.Push(Result);
            Result /= i;
            RaisEvent($"{current} / {i} ");          
        }

        public void Mul(int i)
        {
            checked
            {              
                if ((long) Result * i < int.MinValue || (long) Result * i > int.MaxValue)
                {
                    stackActionLogs.Push(new CalcActionLog(CalcAction.Mul, i));
                    throw new CalculatorOperationCauseOverflowException("Переполнение", stackActionLogs);
                }
                double current = Result;
                stack.Push(Result);
                Result *= i;
                RaisEvent($"{current} * {i} ");
            }
        }

        public void Sub(int i)
        {
            checked
            {
                if ((long) Result - i < int.MinValue || (long) Result - i > int.MaxValue)
                {
                    stackActionLogs.Push(new CalcActionLog(CalcAction.Sub, i));
                    throw new CalculatorOperationCauseOverflowException("Переполнение", stackActionLogs);
                }
                double current = Result;
                stack.Push(Result);
                Result -= i;
                RaisEvent($"{current} - {i} ");
            }
        }

        public void Add(double i)
        {
            if ((long)Result + i < int.MinValue || (long)Result + i > int.MaxValue)
            {
                stackActionLogs.Push(new CalcActionLog(CalcAction.Add, i));
                throw new CalculatorOperationCauseOverflowException("Переполнение", stackActionLogs);
            }
            double current = Result;
            stack.Push(Result);
            Result += i;
            RaisEvent($"{current} + {i} ");
        }

        public void Sub(double i)
        {
            checked
            {
                if ((long)Result - i < int.MinValue || (long)Result - i > int.MaxValue)
                {
                    stackActionLogs.Push(new CalcActionLog(CalcAction.Sub, i));
                    throw new CalculatorOperationCauseOverflowException("Переполнение", stackActionLogs);
                }
                double current = Result;
                stack.Push(Result);
                Result -= i;
                RaisEvent($"{current} - {i} ");
            }
        }

        public void Mul(double i)
        {
            checked
            {
                if ((long)Result * i < int.MinValue || (long)Result * i > int.MaxValue)
                {
                    stackActionLogs.Push(new CalcActionLog(CalcAction.Mul, i));
                    throw new CalculatorOperationCauseOverflowException("Переполнение", stackActionLogs);
                }
                double current = Result;
                stack.Push(Result);
                Result *= i;
                RaisEvent($"{current} * {i} ");
            }
        }

        public void Div(double i)
        {
            if (i == 0)
            {
                stackActionLogs.Push(new CalcActionLog(CalcAction.Div, i));
                throw new CalculatorDivideByZeroException("Деление на ноль!", stackActionLogs);
            }
            double current = Result;
            stack.Push(Result);
            Result /= i;
            RaisEvent($"{current} / {i} ");
        }


        private void RaisEvent(string message)
        {
            Console.WriteLine(message);
            GotResult?.Invoke(this, EventArgs.Empty);
        }
    }
}
