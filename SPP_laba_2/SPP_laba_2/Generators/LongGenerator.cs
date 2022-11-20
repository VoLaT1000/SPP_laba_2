
namespace SPP_laba_2.Generators
{
    internal class LongGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextInt64();
        }
    }
}
