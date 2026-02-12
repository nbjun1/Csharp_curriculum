using System;

namespace curriculum_2_20
{
    // ① 抽象クラス Employee
    abstract class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }

        // コンストラクタで初期化
        public Employee(string id, string name)
        {
            Id = id;
            Name = name;
        }

        // 抽象メソッド：給料計算（中身は書かずに定義だけ）
        public abstract double CalculateDailyWage(double hoursWorked);
    }

    // ② 正社員クラス
    class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string id, string name) : base(id, name) { }

        // ③ 正社員の計算ロジック：時給1250円、8時間超は1.25倍
        public override double CalculateDailyWage(double hoursWorked)
        {
            double baseRate = 1250;
            if (hoursWorked <= 8)
            {
                return hoursWorked * baseRate;
            }
            else
            {
                double overtime = hoursWorked - 8;
                return (8 * baseRate) + (overtime * baseRate * 1.25);
            }
        }
    }

    // ② 契約社員クラス
    class ContractEmployee : Employee
    {
        public ContractEmployee(string id, string name) : base(id, name) { }

        // ③ 契約社員の計算ロジック：時給1000円（固定）
        public override double CalculateDailyWage(double hoursWorked)
        {
            return hoursWorked * 1000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ④ List<Employee> に複数の社員を追加
            List<Employee> employees = new List<Employee>
            {
                new FullTimeEmployee("E001", "山田太郎"),
                new ContractEmployee("C001", "佐藤花子"),
                new FullTimeEmployee("E002", "鈴木一郎")
            };

            // ⑤ foreach ループで一気に処理
            foreach (var emp in employees)
            {
                // ⑦ 勤務時間の振り分け（出力例に合わせる）
                double hours = (emp.Id == "E001") ? 8.5 : 8.0;

                // ⑥ サブクラスを意識せず CalculateDailyWage を呼び出す
                double wage = emp.CalculateDailyWage(hours);

                // 出力（給料は整数で表示するために (int) でキャスト）
                Console.WriteLine($"社員ID: {emp.Id}, 名前: {emp.Name}, 給料: {(int)wage}");
            }
        }
    }
}