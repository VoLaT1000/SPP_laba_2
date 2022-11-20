namespace SPP_laba_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker();
            var result = faker.Create<Class1>();
            Console.WriteLine(result.random);
        }
    }
}