
namespace Home5
{
    internal class CalculatorException : Exception
    {
        public CalculatorException(string message, Stack<CalcActionLog> actionLogs) : base(message)
        {
            ActionLogs = actionLogs;
        }
        public CalculatorException(string message, Exception exception) : base(message, exception){ }
        public Stack<CalcActionLog> ActionLogs { get; set; }

        public override string ToString() 
        { 
            return Message + ": " + string.Join("\n", ActionLogs.Select(x => $"{x.CalcAction} {x.CalcArgument}"));
        }
    }

    internal class CalculatorDivideByZeroException : CalculatorException
    { 
        public CalculatorDivideByZeroException(string message, Stack<CalcActionLog> actionLogs) : base(message, actionLogs){ }
        public CalculatorDivideByZeroException(string message, Exception exception) : base(message, exception){ }
    }

    internal class CalculatorOperationCauseOverflowException : CalculatorException
    {
        public CalculatorOperationCauseOverflowException(string message, Stack<CalcActionLog> actionLogs) : base(message, actionLogs) { }
        public CalculatorOperationCauseOverflowException(string message,  Exception exception) : base(message, exception) { }
    }
}
