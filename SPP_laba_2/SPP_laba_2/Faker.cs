using System.Reflection;

namespace SPP_laba_2
{
    public class Faker
    {
        public T Create<T>()
        {
            T resultT = default(T);
            Type type = typeof(T);
            var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            var constructor = constructors.First();
            resultT = (T?)constructor.Invoke(parameters: null);
            var publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (var field in publicFields)
            {
                var value = field.GetValue(resultT);
                Console.WriteLine($"{field.Name}   {value}");
                var fieldType = field.GetType();
            }
            return resultT;
        }
    }
}
