using curriculum_2_22.Solid.Srp;
using curriculum_2_22.Solid.Dip;
using curriculum_2_22.Solid.Isp;
using curriculum_2_22.Solid.Lsp;
using curriculum_2_22.Solid.Ocp;
using System;
using System.Collections.Generic;

namespace curriculum_2_22
{
    namespace Solid.Srp
    {
        public class Report
        {
            public string EmployeeName { get; set; }
            public int HoursWorked { get; set; }
        }

        public class ReportCalculator
        {
            public int CalculateWage(Report r) => r.HoursWorked * 1200;
        }

        public class ReportSaver
        {
            public void Save(Report r) => Console.WriteLine($"【SRP】{r.EmployeeName}のレポートを保存しました。");
        }
    }


    // ② 開放閉鎖の原則 (OCP)

    namespace Solid.Ocp
    {
        public interface IBillable
        {
            int CostForDay(int hours);
        }

        public class FullTimeEmployee : IBillable
        {
            public int CostForDay(int hours) => hours * 1250;
        }

        public class ContractEmployee : IBillable
        {
            public int CostForDay(int hours) => hours * 1000;
        }
    }
    // ③ リスコフの置換原則 (LSP)

    namespace Solid.Lsp
    {
        public abstract class Employee
        {
            public abstract void Work(int hours);
        }

        public class FullTimeEmployee : Employee
        {
            public override void Work(int hours) => Console.WriteLine($"正社員が{hours}時間働きます。");
        }

        public class InternEmployee : Employee
        {
            public override void Work(int hours)
            {
                // 親クラスの「働く」という仕様を守りつつ、内部で制約を適用
                int actual = Math.Min(hours, 4);
                Console.WriteLine($"インターンが{actual}時間働きます。（制限により最大4時間）");
            }
        }
    }


    // ④ インターフェイス分離の原則 (ISP)

    namespace Solid.Isp
    {
        public interface IWorkable { void Work(); }
        public interface IEatable { void Eat(); }

        public class Robot : IWorkable
        {
            public void Work() => Console.WriteLine("ロボットが稼働します。");

        }

        public class Human : IWorkable, IEatable
        {
            public void Work() => Console.WriteLine("人間が働きます。");
            public void Eat() => Console.WriteLine("人間が食事をします。");
        }
    }


    // ⑤ 依存関係逆転の原則 (DIP)

    namespace Solid.Dip
    {
        public interface IOutput
        {
            void Write(string text);
        }

        public class ConsoleOutput : IOutput
        {
            public void Write(string text) => Console.WriteLine($"[Console]: {text}");
        }

        public class FileOutput : IOutput
        {
            public void Write(string text) => Console.WriteLine($"[File]: {text}");
        }

        public class ReportPrinter
        {
            private readonly IOutput _output;
            public ReportPrinter(IOutput output) => _output = output;

            public void Print(string text) => _output.Write(text);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SOLID原則：動作確認デモ ===\n");

            // 1. 【SRP】単一責任の原則（ここは重複がないのでそのままでOK）
            var report = new Solid.Srp.Report { EmployeeName = "山田", HoursWorked = 160 };
            var calc = new Solid.Srp.ReportCalculator();
            var saver = new Solid.Srp.ReportSaver();
            saver.Save(report);

            Console.WriteLine("\n------------------------------\n");

            // 2. 【OCP】開放閉鎖の原則
            // ★ここを「Solid.Ocp.FullTimeEmployee」のように指定します
            var staffList = new List<Solid.Ocp.IBillable>
    {
        new Solid.Ocp.FullTimeEmployee(),
        new Solid.Ocp.ContractEmployee()
    };
            foreach (var s in staffList)
            {
                Console.WriteLine($"[OCP] 日給計算: {s.CostForDay(8)}円");
            }

            Console.WriteLine("\n------------------------------\n");

            // 3. 【LSP】リスコフの置換原則
            // ★ここも「Solid.Lsp.Employee」や「Solid.Lsp.InternEmployee」のように指定
            Solid.Lsp.Employee employee = new Solid.Lsp.InternEmployee();
            employee.Work(8);

            Console.WriteLine("\n------------------------------\n");

            // 4. 【ISP】インターフェイス分離の原則
            Solid.Isp.IWorkable worker = new Solid.Isp.Robot();
            worker.Work();

            Console.WriteLine("\n------------------------------\n");

            // 5. 【DIP】依存関係逆転の原則
            var printer = new Solid.Dip.ReportPrinter(new Solid.Dip.ConsoleOutput());
            printer.Print("全レポートの出力が完了しました。");

            Console.WriteLine("\nプログラムを終了するには何かキーを押してください...");
            Console.ReadKey();
        }
    }
}
