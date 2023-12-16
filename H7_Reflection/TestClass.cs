
namespace H7_Reflection
{
    internal class TestClass
    {
        [MyCustomName("CustomName_1")]
        public int I { get; set; }
        [MyCustomName("CustomName_2")]
        public string? S { get; set; }
        [MyCustomName("CustomName_3")]
        public decimal D { get; set; }
        [MyCustomName("CustomName_4")]
        public char[]? C { get; set; }

        public TestClass()
        { }
        private TestClass(int i)
        {
            this.I = i;
        }
        public TestClass(int i, string s, decimal d, char[] c) : this(i)
        {
            this.S = s;
            this.D = d;
            this.C = c;
        }
    }
}
