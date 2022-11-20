
using SPP_laba_2.Generators;

namespace SPP_laba_2
{
    public class DictionaryOfGenerators
    {
        private Dictionary<Type, IGenerator> dictionary = new Dictionary<Type, IGenerator>();
        public DictionaryOfGenerators()
        {
            dictionary.Add(typeof(bool), new BoolGenerator());
            dictionary.Add(typeof(int), new IntGenerator());
            dictionary.Add(typeof(long), new LongGenerator());
            dictionary.Add(typeof(double), new DoubleGenerator());
            dictionary.Add(typeof(string), new StringGenerator());
            dictionary.Add(typeof(DateTime), new DateGenerator());
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
