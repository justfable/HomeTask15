using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace HomeTask15
{
    public class Program
    {
        static void Main(string[] args)
        {
            // 1. Получение и вывод списка методов класса Console
            Type consoleType = typeof(Console);
            MethodInfo[] consoleMethods = consoleType.GetMethods();
            foreach (var method in consoleMethods)
            {
                Console.WriteLine(method.Name);
            }

            // 2. Описание класса с несколькими свойствами

            // 3. Использование рефлексии для работы со свойствами экземпляра MyCustomClass
            var myObject = new MyCustomClass(10, "Hello", true);
            Type myObjectType = myObject.GetType();
            PropertyInfo[] properties = myObjectType.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name} = {property.GetValue(myObject)}");
            }

            // 4. Вызов метода Substring класса String с помощью рефлексии
            string testString = "Hello World";
            MethodInfo substringMethod = typeof(string).GetMethod("Substring", new[] { typeof(int), typeof(int) });
            string substringResult = (string)substringMethod.Invoke(testString, new object[] { 0, 5 });
            Console.WriteLine(substringResult);

            // 5. Получение списка конструкторов класса List<T>
            Type listType = typeof(List<>);
            ConstructorInfo[] listConstructors = listType.GetConstructors();
            foreach (var constructor in listConstructors)
            {
                Console.WriteLine(constructor);
            }
        }
    }

    // 2.
    public class MyCustomClass
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }
        public bool Property3 { get; set; }

        public MyCustomClass(int property1, string property2, bool property3)
        {
            Property1 = property1;
            Property2 = property2;
            Property3 = property3;
        }
    }
}
