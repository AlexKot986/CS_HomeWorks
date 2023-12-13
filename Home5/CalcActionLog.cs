
namespace Home5
{
    internal class CalcActionLog
    {
        public CalcAction CalcAction { get; private set; }
        public double CalcArgument { get; private set; }
        public CalcActionLog(CalcAction calcAction, double calcArgument) 
        {
            CalcAction = calcAction;
            CalcArgument = calcArgument;
        }
    }
}
