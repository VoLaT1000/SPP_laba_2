
namespace SPP_laba_2.Generators
{
    internal class DateGenerator : IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            DateTime start = new DateTime(2003, 02, 18);
            return start.AddDays(random.Next((DateTime.Today - start).Days));
        }
    }
}
