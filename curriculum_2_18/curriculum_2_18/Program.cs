using System;

namespace curriculum_2_18
{
    // Employeeクラスの定義
    class Employee
    {
        // 自動プロパティの宣言
        public string EmployeeId { get; set; }
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Employeeクラスのインスタンスを作成し、プロパティに値を設定
            Employee emp = new Employee
            {
                EmployeeId = "E002",
                Name = "田中花子"
            };
            // プロパティの値を表示
            Console.WriteLine($"社員ID: {emp.EmployeeId}, 名前: {emp.Name}");
        }
    }
}