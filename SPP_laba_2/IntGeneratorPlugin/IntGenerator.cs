using SPP_laba_2.Generators;

namespace IntGeneratorPlugin
{
    public class IntGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().Next();
        }
        public Type GetGeneratorType()
        {
            return typeof(int);
        }
    }
}