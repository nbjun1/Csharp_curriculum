using System;

namespace curriculum_2_14
{
    class Program
    {
        static void Main(string[] args)
        {
            // ①配列の宣言
            var myArray = new[] { "aaa", "bbb", "ccc", "ddd", "abc" };

            Console.WriteLine(myArray.Contains("aaa")
                ? "含んでいます"
                : "含んでいません"
                );

            // ②listの宣言
            var bird = new List<string>();
            bird.Add("crow");
            bird.Add("sparrow");
            bird.Add("swallow");
            bird.Add("pigeon");
            bird.Remove("sparrow");
            bird.RemoveAt(1);
            foreach (var b in bird)
            {
                Console.WriteLine(b);

            }
        }
    }
}