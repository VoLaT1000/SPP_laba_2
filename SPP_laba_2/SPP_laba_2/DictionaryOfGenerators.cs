
using SPP_laba_2.Generators;
using System.Reflection;

namespace SPP_laba_2
{
    public class DictionaryOfGenerators
    {
        private Dictionary<Type, IGenerator> dictionary = new Dictionary<Type, IGenerator>();
        public DictionaryOfGenerators()
        {
            dictionary.Add(typeof(bool), new BoolGenerator());
            dictionary.Add(typeof(double), new DoubleGenerator());
            dictionary.Add(typeof(string), new StringGenerator());
            dictionary.Add(typeof(DateTime), new DateGenerator());
            ConnectDll();
        }
        private void ConnectDll()
        {
            string pathToDll = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Plugins\\");
            string[] allDll = Directory.GetFiles(pathToDll, "*.dll");
            foreach (string dllPath in allDll)
            {
                Assembly asm = Assembly.LoadFrom(dllPath);
                foreach (Type type in asm.GetExportedTypes())
                {
                    if (type.IsClass && typeof(IGenerator).IsAssignableFrom(type))
                    {
                        IGenerator g = (IGenerator)Activator.CreateInstance(type);
                        dictionary.Add(g.GetGeneratorType(), g);
                    }
                }
            }
        }
        public object Generate(Type type)
        {
            return dictionary[type].Generate();
        }
        public bool GeneratorExists(Type type)
        {
            return dictionary.ContainsKey(type);
        }
    }
}
