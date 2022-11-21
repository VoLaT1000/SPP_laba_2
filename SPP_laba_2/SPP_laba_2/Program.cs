namespace SPP_laba_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var faker = new Faker();
            var result = faker.Create<Class1>();
            Console.WriteLine(result._bool);
            Console.WriteLine(result._date);
            Console.WriteLine(result._double);
            Console.WriteLine(result._int);
            Console.WriteLine(result._long);
            Console.WriteLine(result._string);
        }
    }
}