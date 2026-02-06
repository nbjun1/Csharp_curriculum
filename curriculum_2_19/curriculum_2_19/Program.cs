using System;

namespace curriculum_2_19
{
    // 基底クラス
    class TestPerson
    {
        // 変数の宣言
        public string name;
        public int age;

        // コンストラクタ：引数は名前、年齢
        public TestPerson(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        // 出力処理1と2
        public void ShowBaseInfo()
        {
            Console.WriteLine("基底クラス");
            Console.WriteLine($"名前： {name}, 年齢： {age}");
        }
    }

    // 派生クラス TestPersonを継承    
    class TestInfo : TestPerson
    {
        public int height;
        public int weight;

        // コンストラクタ：名前、年齢、身長、体重を受け取る
        // 「: base(name, age)」で親クラスのコンストラクタに名前と年齢を渡す
        public TestInfo(string name, int age, int height, int weight) : base(name, age)
        {
            this.height = height;
            this.weight = weight;
        }

        // 出力処理3と4
        public void ShowDerivationInfo()
        {
            Console.WriteLine("派生クラス");
            Console.WriteLine($"身長：{height}, 体重： {weight}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // 派生クラスのインスタンスを生成（引数でデータを渡す）
            TestInfo info = new TestInfo("山田", 20, 170, 60);

            // メソッドを呼び出して出力
            info.ShowBaseInfo();
            info.ShowDerivationInfo();
        }
    }
}