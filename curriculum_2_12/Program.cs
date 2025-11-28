using System;
namespace curriculum_2_12
{
    class Program
    {
        static void Main(string[] args)
        {
            // 課題①1から10までの整数を順番に表示するプログラムを for文 を使って作成してください。
            // 10になるまで1ずつ加算される、初期値は1
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
            }

            // ②配列 { "りんご", "みかん", "ぶどう" } を用意し、foreach文 を使って1つずつ表示するプログラムを作成してください。
            string[] fruits = { "りんご", "みかん", "ぶどう" };
            // 配列fruitsの要素を1つずつ取り出して, 変数fruitに代入し, 繰り返し処理を実行
            foreach (string fruit in fruits)
            {
                Console.WriteLine(fruit);
            }

            // ③ユーザーに数値を入力させ、合計が100を超えるまで繰り返し入力を受け付けるプログラムを作成してください。

            // int型変数名sumの初期値を0に設定
            int sum = 0;
            // sumが100未満の間、繰り返し処理を実行
            while (sum <= 100)
            {
                Console.Write("数字を入力してください: ");
                string input = Console.ReadLine();
                // 入力された値をint型に変換し、numberに代入
                if (int.TryParse(input, out int number))
                {
                    // 入力された数値(代入)numberをsumに加算
                    sum += number;
                }
                else
                {
                    Console.WriteLine("有効な数値を入力してください。");
                }
            }
            // 合計が100を超えた場合、合計値を表示
            Console.WriteLine("合計は" + sum + "です");
        }
    }
}