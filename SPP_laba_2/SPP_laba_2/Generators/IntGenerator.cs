
namespace SPP_laba_2.Generators
{
    internal class IntGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().Next();
        }
    }
}
