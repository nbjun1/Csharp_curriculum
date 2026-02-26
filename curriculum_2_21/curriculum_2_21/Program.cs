using System;
using System.Collections.Generic;

namespace curriculum_2_21
{
    // ① インターフェイス IBillable
    // 「日給計算ができる」という能力を定義する
    interface IBillable
    {
        int CostForDay(int hoursWorked);
    }

    // ② 抽象クラス Employee
    // IBillableを実装し、社員の共通データ（Id, Name）を管理する
    abstract class Employee : IBillable
    {
        public string Id { get; }
        public string Name { get; }

        public Employee(string id, string name)
        {
            Id = id;
            Name = name;
        }

        // 抽象メソッドとして定義（中身はサブクラスに任せる）
        public abstract int CostForDay(int hoursWorked);
    }

    // ③ サブクラス：正社員
    class FullTimeEmployee : Employee
    {
        public FullTimeEmployee(string id, string name) : base(id, name) { }

        public override int CostForDay(int hoursWorked)
        {
            int baseRate = 1250;
            if (hoursWorked <= 8)
            {
                return hoursWorked * baseRate;
            }
            else
            {
                int overtime = hoursWorked - 8;
                // 1.25倍の計算（doubleで計算してからintにキャストして端数を切る）
                double pay = (8 * baseRate) + (overtime * baseRate * 1.25);
                return (int)pay;
            }
        }
    }

    // ③ サブクラス：契約社員
    class ContractEmployee : Employee
    {
        public ContractEmployee(string id, string name) : base(id, name) { }

        public override int CostForDay(int hoursWorked)
        {
            return hoursWorked * 1000;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // ④ List<IBillable> に追加
            // 社員という枠組みを超えて「請求可能なもの（IBillable）」として扱う
            List<IBillable> billables = new List<IBillable>
            {
                new FullTimeEmployee("F001", "山田"),
                new ContractEmployee("C001", "佐藤")
            };

            // 全員 9 時間勤務として出力
            foreach (IBillable item in billables)
            {
                Console.WriteLine($"日給: {item.CostForDay(9)}円");
            }
        }
    }
}