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

                var testtask1 = SlowRepo();
                var testtask2 = SlowRepo();
                
                //Do something else parallel

                await Task.WhenAll(testtask1, testtask2);
                return testtask1.Result || testtask2.Result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e.GetBaseException();
            }
            
        }

        public static async Task<bool> SlowRepo()
        {
            await Task.Delay(10000);
            return true;
        }
    }
}