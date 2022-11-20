
namespace SPP_laba_2.Generators
{
    internal class DoubleGenerator : IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            return random.NextDouble() * random.Next();
        }
    }
}
