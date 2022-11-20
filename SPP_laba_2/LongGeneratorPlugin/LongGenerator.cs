using SPP_laba_2.Generators;

namespace LongGeneratorPlugin
{
    public class LongGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextInt64();
        }
        public Type GetGeneratorType()
        {
            return typeof(long);
        }
    }
}