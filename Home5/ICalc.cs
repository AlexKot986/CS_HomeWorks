
namespace Home5
{
    internal interface ICalc
    {
        event EventHandler<EventArgs> GotResult;
        void Add(int i);
        void Sub(int i);
        void Mul(int i);
        void Div(int i);
        void Add(double i);
        void Sub(double i);
        void Mul(double i);
        void Div(double i);
        void CancelLast();
    }
}
