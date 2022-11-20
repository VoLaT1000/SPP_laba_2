
namespace SPP_laba_2.Generators
{
    internal class StringGenerator : IGenerator
    {
        public object Generate()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var _string = new char[10];
            var random = new Random();
            for (int i = 0; i < _string.Length; i++)
            {
                _string[i] = chars[random.Next(chars.Length)];
            }
            return new string(_string);
        }
    }
}
