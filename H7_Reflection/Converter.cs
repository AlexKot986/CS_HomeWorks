
using System.Reflection;
using System.Text;

namespace H7_Reflection
{
    internal static class Converter
    {
        public static string ObjectToString(object o)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(o.GetType().AssemblyQualifiedName + " | ");
            stringBuilder.Append(o.GetType());

            PropertyInfo[] properties = o.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes(false);
                foreach (var attribute in attributes)
                {
                    if (attribute is MyCustomNameAttribute myAttribute)
                        stringBuilder.Append(" | " + myAttribute.Name + ":");
                }
                if (property.PropertyType == typeof(char[]))
                {
                    stringBuilder.Append(new string(property.GetValue(o) as char[]));
                }
                else
                {
                    stringBuilder.Append(property.GetValue(o));
                }
            }
            return stringBuilder.ToString();
        }

        public static object StringToObject(string s)
        {
            string[] someStringArray = s.Split("|");
            var o = Activator.CreateInstance(someStringArray[0].Split(".")[0], someStringArray[1].Trim())?.Unwrap() as TestClass ?? throw new Exception("Не удалось создать объект!");

            var properties = o.GetType().GetProperties();
            foreach (var property in properties)
            {
                MyCustomNameAttribute? myAttribute = Attribute.GetCustomAttribute(property, typeof(MyCustomNameAttribute)) as MyCustomNameAttribute;
                for (int i = 2; i < someStringArray.Length; i++)
                {
                    if (myAttribute?.Name == someStringArray[i].Split(":")[0].Trim())
                    {
                        switch (property.PropertyType.Name)
                        {
                            case "Int32": property.SetValue(o, int.Parse(someStringArray[i].Split(":")[1])); break;
                            case "String": property.SetValue(o, someStringArray[i].Split(":")[1].Trim()); break;
                            case "Decimal": property.SetValue(o, decimal.Parse(someStringArray[i].Split(":")[1])); break;
                            case "Char[]": property.SetValue(o, someStringArray[i].Split(":")[1].Trim().ToCharArray()); break;
                        }
                    }
                }
            }        
            return o;
        }
    }
}
