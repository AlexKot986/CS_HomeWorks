
namespace H7_Reflection
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class MyCustomNameAttribute : Attribute
    {
        public string Name { get; set; }
        public MyCustomNameAttribute(string name)
        {
            Name = name;
        }
    }
}
