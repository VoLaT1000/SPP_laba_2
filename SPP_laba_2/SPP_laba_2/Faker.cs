using System.Collections;
using System.Reflection;

namespace SPP_laba_2
{
    public class Faker
    {
        readonly DictionaryOfGenerators dictionaryOfGenerators;
        private List<Type> innerTypes = new List<Type>();
        public Faker()
        {
            dictionaryOfGenerators = new DictionaryOfGenerators();
        }
        public T Create<T>()
        {
            return (T)CreateDTO(typeof(T));
        }
        private object CreateDTO(Type type)
        {
            object resultT;
            if (dictionaryOfGenerators.GeneratorExists(type))
            {
                resultT = dictionaryOfGenerators.Generate(type);
            }
            else
            {
                if (type.IsGenericType)
                {
                    var genericType = type.GetGenericArguments()[0];
                    var listType = typeof(List<>).MakeGenericType(genericType);
                    var list = (IList)Activator.CreateInstance(listType);
                    for (int i = 0; i < 10; i++)
                    {
                        list.Add(CreateDTO(genericType));
                    }
                    resultT = Convert.ChangeType(list, listType);
                }
                else
                {
                    if (innerTypes.Contains(type))
                    {
                        return null;
                    }
                    else
                    {
                        innerTypes.Add(type);
                        resultT = CreateObject(type);
                        FillFieldsAndProperties(resultT);
                        innerTypes.Remove(type);
                    }
                }
            }
            return resultT;
        }
        private object CreateObject(Type type)
        {
            try
            {
                var constructor = Constructor(type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance));
                var constructorParameters = constructor.GetParameters();
                List<object> parameters = new List<object>();

                if (constructorParameters.Any())
                {
                    foreach (var parameter in constructorParameters)
                    {
                        parameters.Add(CreateDTO(parameter.ParameterType));
                    }
                }
                return constructor.Invoke(parameters.ToArray());
            }
            catch
            {
                return Activator.CreateInstance(type);
            }
        }

        private ConstructorInfo? Constructor(ConstructorInfo[] constructors)
        {
            if (constructors.Length > 1)
            {
                var AllConstructors =
                constructors.OrderByDescending(ob => ob.GetParameters().Count()).ToList();
                return AllConstructors[0];
            }
            else return constructors.First();
        }
        private void FillFieldsAndProperties(object resultT)
        {
            var type = resultT.GetType();
            var publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Static |
               BindingFlags.Instance);

            foreach (var field in publicFields)
            {
                try
                {
                    field.SetValue(resultT, CreateDTO(field.FieldType));
                }
                catch
                {
                    field.SetValue(resultT, null);
                }
            }

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                if (property.SetMethod != null)
                {
                    try
                    {
                        property.SetValue(resultT, CreateDTO(property.PropertyType));
                    }
                    catch
                    {
                        property.SetValue(resultT, null);
                    }
                }
            }
        }
    }
}
