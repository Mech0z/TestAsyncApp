using System;
using System.Threading.Tasks;

namespace TestAsyncApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var result = FirstBlock().Result;
        }

        public static async Task<bool> FirstBlock()
        {
            try
            {
                bool result = false;
                var result1 = SecondBlock();
                var result2 = SecondBlock();

                await Task.WhenAll(result1, result2);
                return result1.Result || result2.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e.GetBaseException();
            }
            
        }

        public static async Task<bool> SecondBlock()
        {
            return await ThirdBlock();
        }

        public static async Task<bool> ThirdBlock()
        {
            await Task.Delay(1000);
            throw new Exception("some exception");
        }
    }
}