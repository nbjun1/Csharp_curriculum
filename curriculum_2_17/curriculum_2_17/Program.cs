using System;

namespace curriculum_2_17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("HelloWorld");

            // ②コンソールで2つの文字列を入力し、その文字列を結合した文字列を出力するプログラム
            Console.Write("コンソールに文字列１を入力：");
            string str1 = Console.ReadLine();
            Console.Write("コンソールに文字列２を入力：");
            string str2 = Console.ReadLine();
            // 文字列を結合する
            string result = string.Concat(str1, str2);
            Console.WriteLine("出力：" + result);
        }
    }
}