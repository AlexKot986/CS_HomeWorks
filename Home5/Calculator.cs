
namespace Home5
{
    internal class Calculator : ICalc
    {
        public event EventHandler<EventArgs> GotResult;
        public int Result = 0;
        private Stack<int> stack = new Stack<int>();
        public void Add(int i)
        {
            int current = Result;
            stack.Push(Result);
            Result += i;
            RaisEvent($"{current} + {i} ");
        }

        public void CancelLast()
        {
            if (stack.Count > 0)
            {
                int current = Result;
                Result = stack.Pop();
                RaisEvent($"CancelLast LastResult = {current}");
            }
            else Console.WriteLine("Нет значений!");
        }

        public void Div(int i)
        {
            int current = Result;
            stack.Push(Result);
            Result /= i;
            RaisEvent($"{current} / {i} ");
        }

        public void Mul(int i)
        {
            int current = Result;
            stack.Push(Result);
            Result *= i;
            RaisEvent($"{current} * {i} ");
        }

        public void Sub(int i)
        {
            int current = Result;
            stack.Push(Result);
            Result -= i;
            RaisEvent($"{current} - {i} ");
        }

        private void RaisEvent(string message)
        {
            Console.WriteLine(message);
            GotResult?.Invoke(this, EventArgs.Empty);
        }
    }
}
