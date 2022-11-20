
namespace SPP_laba_2.Generators
{
    public class BoolGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().NextDouble() >= 0.5;
        }
    }
}
