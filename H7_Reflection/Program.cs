
using H7_Reflection;
using static H7_Reflection.Converter;

TestClass test = new TestClass(1, "STR", 2.0m, new char[] { '5', '0', '5', ' ', '=', ' ', 'S', 'O', 'S' });
string s = ObjectToString(test);
Console.WriteLine(s + "\n");


var testClass = StringToObject(s) as TestClass;
Console.WriteLine($"{testClass?.GetType()} | I:{testClass?.I} | S:{testClass?.S} | D:{testClass?.D} | C:{new string(testClass?.C)}");
