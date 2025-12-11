using System;

namespace curriculum_2_14
{
    class Program
    {
        static void Main(string[] args)
        {
            // ①配列の宣言
            var myArray = new[] {"aaa", "bbb", "ccc", "ddd", "abc"};
            
            Console.WriteLine(myArray.Contains("aaa")
                ? "含んでいます"
                : "含んでいません"
                );
        }
    }
}